using FlexBazaar.DtoLayer.IdentityDtos.LoginDtos;
using FlexBazaar.WebUI.Services.Interfaces;
using FlexBazaar.WebUI.Settings;
using IdentityModel.Client;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Protocols.OpenIdConnect;
using System.Security.Claims;

namespace FlexBazaar.WebUI.Services.Concrete
{
    public class IdentityService : IIdentityService
    {
        private readonly HttpClient _httpClient;
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly ClientSettings _clientSettings;
        private readonly ServiceApiSettings _serviceApiSettings;

        public IdentityService(HttpClient httpClient, IHttpContextAccessor httpContextAccessor, IOptions<ClientSettings> clientSettings, IOptions<ServiceApiSettings> serviceApiSettings)
        {
            _httpClient = httpClient;
            _httpContextAccessor = httpContextAccessor;
            _clientSettings = clientSettings.Value;
            _serviceApiSettings = serviceApiSettings.Value;
        }

        public async Task<bool> SignIn(SignInDto signInDto)
        {
            /*
             new DiscoveryDocumentRequest
            {
                Address = "http://localhost:5001",
                Policy = new DiscoveryPolicy
                {
                    RequireHttps = false,
                }
            }
            bu kod sadece https'i geçersiz kılmak için kullanıldı. Proje canlıya alınacağı zaman düzeltilmesi gerekiyor.
             */
            var discoveryEndpoint = await _httpClient.GetDiscoveryDocumentAsync(new DiscoveryDocumentRequest
            {
                Address = _serviceApiSettings.IdentityServerUrl,
                Policy = new DiscoveryPolicy
                {
                    RequireHttps = false,
                }
            });

            var passwordTokenRequest = new PasswordTokenRequest
            {
                ClientId = _clientSettings.FlexBazaarManagerClient.ClientId,
                ClientSecret = _clientSettings.FlexBazaarManagerClient.ClientSecret,
                UserName = signInDto.Username,
                Password = signInDto.Password,
                Address = discoveryEndpoint.TokenEndpoint
            };

            var token = await _httpClient.RequestPasswordTokenAsync(passwordTokenRequest);

            var userInfoRequest = new UserInfoRequest
            {
                Token = token.AccessToken,
                Address = discoveryEndpoint.UserInfoEndpoint
            };

            // kullanıcı bilgilerine erişim
            var userValues = await _httpClient.GetUserInfoAsync(userInfoRequest);

            // kullanıcı adı ve rolünü getirecek
            ClaimsIdentity claimsIdentity = new ClaimsIdentity(userValues.Claims, CookieAuthenticationDefaults.AuthenticationScheme, "name", "role");

            ClaimsPrincipal claimsPrincipal = new ClaimsPrincipal(claimsIdentity);

            var authenticationProperties = new AuthenticationProperties();

            authenticationProperties.StoreTokens(new List<AuthenticationToken>()
            {
                new AuthenticationToken
                {
                    // AccessToken kısa süreli(1 saat gibi) işlemler için
                    Name = OpenIdConnectParameterNames.AccessToken,
                    Value = token.AccessToken
                },
                new AuthenticationToken
                {
                    // RefreshToken uzun süreli(30 gün gibi) işlemler için
                    Name = OpenIdConnectParameterNames.RefreshToken,
                    Value = token.RefreshToken
                },
                new AuthenticationToken
                {
                    // Token'ın son kullanma tarihi
                    Name = OpenIdConnectParameterNames.ExpiresIn,
                    Value = DateTime.Now.AddSeconds(token.ExpiresIn).ToString()
                }
            });

            // oluşturulan cookie'nin tarayıcı oturumu sona erdiğinde silinip silinmeyeceğini kontrol eder.
            // burada false olarak ayarlandığı için oturum sona erdiğinde cookie silinecektir.
            authenticationProperties.IsPersistent = false;

            // kullanıcıyı oturum açmış olarak işaretler
            await _httpContextAccessor.HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, claimsPrincipal, authenticationProperties);

            // kullanıcı oturum açma işlemi başarılı ise true döner
            return true;
        }
    }
}
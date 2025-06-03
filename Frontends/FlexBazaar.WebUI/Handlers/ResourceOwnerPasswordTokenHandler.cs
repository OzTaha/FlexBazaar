
using FlexBazaar.WebUI.Services.Interfaces;
using Microsoft.AspNetCore.Authentication;
using Microsoft.IdentityModel.Protocols.OpenIdConnect;
using System.Net;
using System.Net.Http.Headers;

namespace FlexBazaar.WebUI.Handlers
{
    public class ResourceOwnerPasswordTokenHandler:DelegatingHandler
    {
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly IIdentityService _identityService;

        public ResourceOwnerPasswordTokenHandler(IHttpContextAccessor httpContextAccessor, IIdentityService identityService)
        {
            _httpContextAccessor = httpContextAccessor;
            _identityService = identityService;
        }

        protected override async Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
        {
            // giriş yapan kullanıcının tokeni alınacak
            var accessToken = await _httpContextAccessor.HttpContext.GetTokenAsync(OpenIdConnectParameterNames.AccessToken);
            request.Headers.Authorization = new AuthenticationHeaderValue("Bearer", accessToken);
            var response = await base.SendAsync(request, cancellationToken);

            // eğer token geçersiz ise, yeni token alınacak
            if (response.StatusCode == HttpStatusCode.Unauthorized)
            {
                // yeni token almak için identity service çağrılacak
                var tokenResponse = await _identityService.GetRefreshToken();
                
                if (tokenResponse != null)
                {
                    request.Headers.Authorization = new AuthenticationHeaderValue("Bearer", accessToken);
                    response = await base.SendAsync(request, cancellationToken);
                }
            }
            // eğer hala unauthorized ise, hata mesajı dönecek
            if (response.StatusCode == HttpStatusCode.Unauthorized)
            {
                // hata mesajı
            }
            return response;
        }
    }
}


using FlexBazaar.WebUI.Services.Interfaces;
using System.Net;
using System.Net.Http.Headers;

namespace FlexBazaar.WebUI.Handlers
{
    public class ClientCredentialTokenHandler: DelegatingHandler
    {
        private readonly IClientCredentialTokenService _clientCredentialTokenService;

        public ClientCredentialTokenHandler(IClientCredentialTokenService clientCredentialTokenService)
        {
            _clientCredentialTokenService = clientCredentialTokenService;
        }

        // gönderilen her isteğe client credential token eklenecek
        protected override async Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
        {

            request.Headers.Authorization = new AuthenticationHeaderValue("Bearer", await _clientCredentialTokenService.GetToken());
            var response = await base.SendAsync(request, cancellationToken);
            // 401 Unauthorized dönerse hata mesajı gösterilecek.
            if (response.StatusCode == HttpStatusCode.Unauthorized)
            {
                // hata mesajı
            }

            return response;
        }
    }
}

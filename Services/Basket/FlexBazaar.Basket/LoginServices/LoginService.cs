using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;

namespace FlexBazaar.Basket.LoginServices
{
    public class LoginService : ILoginService
    {
        private readonly IHttpContextAccessor _httpContextAccessor;
        // JwtRegisteredClaimNames kullanılarak JWT içindeki claim isimleri tanımlanır
        private const string SubClaim = JwtRegisteredClaimNames.Sub;

        public LoginService(IHttpContextAccessor contextAccessor)
        {
            _httpContextAccessor = contextAccessor;
        }

        public string GetUserId
        {
            // eski kod
            /*_httpContextAccessor.HttpContext.User.FindFirst("sub").Value;*/       
            // yeni kod
           get
            {
                // 1. HttpContext alınır
                var httpContext = _httpContextAccessor.HttpContext
                                  ?? throw new InvalidOperationException("HttpContext mevcut değil.");

                // 2. Kullanıcının id'si doğrulanmış mı kontrol edilir
                if (httpContext.User.Identity?.IsAuthenticated != true)
                    throw new InvalidOperationException("Kullanıcı doğrulanmamış.");

                // 3. Kullanıcı objesi alınır
                var user = httpContext.User;
                // 4. JWT içindeki "sub" claim'inden kullanıcı id'si alınmaya çalışılır
                //    Eğer "sub" yoksa, ClaimTypes.NameIdentifier (ör: Microsoft’un varsayılanı) kontrol edilir
                var rawId = user.FindFirstValue(SubClaim)
                            ?? user.FindFirstValue(ClaimTypes.NameIdentifier)
                            ?? throw new InvalidOperationException("Kullanıcı ID’si bulunamadı.");

                // 5. Alınan değer bir GUID mi kontrol edilir
                if (!Guid.TryParse(rawId, out var parsed))
                    throw new FormatException("Kullanıcı ID’si geçerli değil.");
                // 6. GUID string olarak döndürülür
                return parsed.ToString();
            }
        }
    }
}

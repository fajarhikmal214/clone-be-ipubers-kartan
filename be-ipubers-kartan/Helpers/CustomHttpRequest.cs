using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;

namespace be_ipubers_kartan.Helpers
{
    public static class CustomHttpRequest
    {
        public static string? GetHeaderValueByKey(this HttpRequest request, string key)
        {
            try
            {
                var result = request.Headers.FirstOrDefault(q => q.Key == key).Value.FirstOrDefault();
                return result;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public static string? GetValueFromJWT(string type, string token)
        {
            try
            {
                var stream = token.Replace("Bearer ", "").Replace("bearer", "");
                var handler = new JwtSecurityTokenHandler();
                var jsonToken = handler.ReadToken(stream);
                var tokenS = jsonToken as JwtSecurityToken;
                if (tokenS == null) return null;

                string? result = null;
                switch (type)
                {
                    case ClaimTypes.Name:
                        result = tokenS.Claims.FirstOrDefault(q => q.Type == type || q.Type == "unique_name")?.Value;
                        break;
                    case ClaimTypes.GivenName:
                        result = tokenS.Claims.FirstOrDefault(q => q.Type == type || q.Type == "given_name")?.Value;
                        break;
                    default:
                        result = tokenS.Claims.FirstOrDefault(q => q.Type == type)?.Value;
                        break;
                }

                return result;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}

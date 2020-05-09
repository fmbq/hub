using Microsoft.AspNetCore.Mvc;

namespace FMBQ.Hub.Auth
{
    public class AuthRequiredAttribute : TypeFilterAttribute
    {
        public AuthRequiredAttribute() : base(typeof(AuthFilter))
        {
        }
    }
}

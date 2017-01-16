namespace Discountify.Composition
{
    using Microsoft.AspNetCore.Http;
    using System.Security.Claims;

    public class ClaimsPrincipleProvider : IClaimsPrincipleProvider
    {
        private readonly IHttpContextAccessor httpContextAccessor;

        public ClaimsPrincipleProvider(IHttpContextAccessor httpContextAccessor)
        {
            this.httpContextAccessor = httpContextAccessor;
        }

        public ClaimsPrincipal CurrentPrinciple
        {
            get
            {
                if (this.httpContextAccessor.HttpContext.Equals(null))
                {
                    return null;
                }

                if (this.httpContextAccessor.HttpContext.User.Equals(null))
                {
                    return null;
                }

                return this.httpContextAccessor.HttpContext.User;
            }
        }
    }
}

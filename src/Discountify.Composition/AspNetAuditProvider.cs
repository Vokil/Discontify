namespace Discountify.Composition
{
    using Core.Audit;
    using Microsoft.AspNetCore.Identity;
    using Models;

    public class AspNetAuditProvider : IAuditProvider
    {
        private readonly IClaimsPrincipleProvider claimsPrincipleProvider;

        private readonly UserManager<User> userManager;

        public AspNetAuditProvider(IClaimsPrincipleProvider claimsPrincipleProvider, UserManager<User> userManager)
        {
            this.claimsPrincipleProvider = claimsPrincipleProvider;
            this.userManager = userManager;
        }

        public string UserId
        {
            get
            {
                if (this.claimsPrincipleProvider.CurrentPrinciple.Equals(null))
                {
                    return null;
                }

                return this.userManager.GetUserId(this.claimsPrincipleProvider.CurrentPrinciple);
            }
        }
    }
}
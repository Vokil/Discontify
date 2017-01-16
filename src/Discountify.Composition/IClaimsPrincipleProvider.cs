namespace Discountify.Composition
{
    using System.Security.Claims;

    public interface IClaimsPrincipleProvider
    {
        ClaimsPrincipal CurrentPrinciple { get; }
    }
}

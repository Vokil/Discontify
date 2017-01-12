namespace Discountify.Services.Contracts
{
    using Models;
    using System.Collections.Generic;

    public interface ICardService
    {
        ICollection<Card> List();
    }
}

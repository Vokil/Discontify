namespace Discountify.Data.Repositories.Contracts
{
    using Discountify.Models;
    using System.Collections.Generic;

    public interface ICardRepository
    {
        ICollection<Card> List();
    }
}

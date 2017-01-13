namespace Discountify.Data.Repositories
{
    using Discountify.Data.Repositories.Contracts;
    using Discountify.Models;
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class CardRepository : BaseRepository<Card>, ICardRepository
    {
        public CardRepository(IDiscountifyContext discountifyContext)
            : base(discountifyContext) { }

        public ICollection<Card> List()
        {
            var cardsCollection = this
                .Collection
                .ToArray();

            return cardsCollection;
        }

        public ICollection<Card> List(Guid userId)
        {
            var cardsCollection = this
                .Collection
                .Where(cards => cards.User.Id.Equals(userId))
                .ToArray();

            return cardsCollection;
        }
    }
}

using Discountify.Data.Repositories.Contracts;
using Discountify.Models;
using Discountify.Services.Contracts;
using System;
using System.Collections.Generic;

namespace Discountify.Services
{
    public class CardService : ICardService
    {
        private readonly ICardRepository cardRepository;

        public CardService(ICardRepository cardRepository)
        {
            this.cardRepository = cardRepository;
        }

        public ICollection<Card> List()
        {
            var cards = this.cardRepository.List();

            return cards;
        }
    }
}

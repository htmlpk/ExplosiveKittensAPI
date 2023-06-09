﻿using Redis.OM.Searching;
using Redis.OM;
using ExplosiveKittens.Data.Entities;
using System;
using System.Threading.Tasks;
using System.Collections.Generic;
using ExplosiveKittens.Business.Interfaces;
using System.Linq;

namespace ExplosiveKittens.Business.Services
{
    public class KittensGameService:IKittensGameService
    {
        private readonly RedisCollection<Deck> _deck;
        private readonly RedisConnectionProvider _provider;
        public KittensGameService(RedisConnectionProvider provider)
        {
            _provider = provider;
            _deck = (RedisCollection<Deck>)provider.RedisCollection<Deck>();
        }

        public async Task CreateDeckInCacheAsync()
        {
            try
            {
                var deck = new Deck();
                deck.GameId = Guid.NewGuid();
                deck.Cards = DeckUtil.GenerateStartDeck(2);
                await _deck.InsertAsync(deck);
            }
            catch (Exception e)
            {
                var a = e;
                throw;
            }

        }

        public async Task<IList<Deck>> GetDeckAsync(Guid gameId)
        {
            try
            {
                var deck = await _deck.ToListAsync();
                var cards = deck.Where(x=>x.GameId.Equals(gameId)).FirstOrDefault();
                return deck;
            }
            catch (Exception e)
            {
                var a = e;
                throw;
            }
            
        }
    }
}


using ExplosiveKittens.Data.Entities;
using Microsoft.Analytics.Interfaces;
using Microsoft.Analytics.Interfaces.Streaming;
using Microsoft.Analytics.Types.Sql;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace ExplosiveKittens.Business
{
    public class DeckUtil
    {
        static int ExplosiveCount = 4;
        static int DefusalCount = 6;
        static int FutureCount = 5;
        static int NoCount = 5;
        static int GoAwayCount = 4;
        static int AskCount = 4;
        static int AttackCount = 4;
        static int ShuffleCount = 4;
        static int SikotCount = 4;
        static int MotherCount = 4;
        static int ZombieCount = 4;
        static int BikiniCount = 4;
        static int ShredingerCount = 4;


        public DeckUtil()
        {

        }

        public static List<Card> GenerateFullDeck()
        {
            var deck = new List<Card>();
            for (int i = 0; i < ExplosiveCount - 1; i++)
            {
                deck.Add(new Card { Id = Guid.NewGuid(), Type = Data.Enums.KittenType.Explosive });
            }
            for (int i = 0; i < DefusalCount - 1; i++)
            {
                deck.Add(new Card { Id = Guid.NewGuid(), Type = Data.Enums.KittenType.Defuse });
            }
            for (int i = 0; i < FutureCount - 1; i++)
            {
                deck.Add(new Card { Id = Guid.NewGuid(), Type = Data.Enums.KittenType.Future });
            }
            for (int i = 0; i < NoCount - 1; i++)
            {
                deck.Add(new Card { Id = Guid.NewGuid(), Type = Data.Enums.KittenType.Defuse });
            }
            for (int i = 0; i < Deck.GoAwayCount - 1; i++)
            {
                deck.Add(new Card { Id = Guid.NewGuid(), Type = Data.Enums.KittenType.GoAvay });
            }
            for (int i = 0; i < Deck.AskCount - 1; i++)
            {
                deck.Add(new Card { Id = Guid.NewGuid(), Type = Data.Enums.KittenType.Ask });
            }
            for (int i = 0; i < Deck.AttackCount - 1; i++)
            {
                deck.Add(new Card { Id = Guid.NewGuid(), Type = Data.Enums.KittenType.Attack });
            }
            for (int i = 0; i < Deck.ShuffleCount - 1; i++)
            {
                deck.Add(new Card { Id = Guid.NewGuid(), Type = Data.Enums.KittenType.Shuffle });
            }
            for (int i = 0; i < Deck.SikotCount - 1; i++)
            {
                deck.Add(new Card { Id = Guid.NewGuid(), Type = Data.Enums.KittenType.Sikot });
            }
            for (int i = 0; i < Deck.MotherCount - 1; i++)
            {
                deck.Add(new Card { Id = Guid.NewGuid(), Type = Data.Enums.KittenType.Mother });
            }
            for (int i = 0; i < Deck.ZombieCount - 1; i++)
            {
                deck.Add(new Card { Id = Guid.NewGuid(), Type = Data.Enums.KittenType.Zombie });
            }
            for (int i = 0; i < Deck.BikiniCount - 1; i++)
            {
                deck.Add(new Card { Id = Guid.NewGuid(), Type = Data.Enums.KittenType.Bikini });
            }
            for (int i = 0; i < Deck.ShredingerCount - 1; i++)
            {
                deck.Add(new Card { Id = Guid.NewGuid(), Type = Data.Enums.KittenType.Shredinger });
            }
            return deck;

        }

        public static List<Card> GenerateStartDeck(int playerCount)
        {
            var deck = new List<Card>();

            for (int i = 0; i < DefusalCount - 1 - playerCount; i++)
            {
                deck.Add(new Card { Id = Guid.NewGuid(), Type = Data.Enums.KittenType.Defuse });
            }
            for (int i = 0; i < FutureCount - 1; i++)
            {
                deck.Add(new Card { Id = Guid.NewGuid(), Type = Data.Enums.KittenType.Future });
            }
            for (int i = 0; i < NoCount - 1; i++)
            {
                deck.Add(new Card { Id = Guid.NewGuid(), Type = Data.Enums.KittenType.Defuse });
            }
            for (int i = 0; i < Deck.GoAwayCount - 1; i++)
            {
                deck.Add(new Card { Id = Guid.NewGuid(), Type = Data.Enums.KittenType.GoAvay });
            }
            for (int i = 0; i < Deck.AskCount - 1; i++)
            {
                deck.Add(new Card { Id = Guid.NewGuid(), Type = Data.Enums.KittenType.Ask });
            }
            for (int i = 0; i < Deck.AttackCount - 1; i++)
            {
                deck.Add(new Card { Id = Guid.NewGuid(), Type = Data.Enums.KittenType.Attack });
            }
            for (int i = 0; i < Deck.ShuffleCount - 1; i++)
            {
                deck.Add(new Card { Id = Guid.NewGuid(), Type = Data.Enums.KittenType.Shuffle });
            }
            for (int i = 0; i < Deck.SikotCount - 1; i++)
            {
                deck.Add(new Card { Id = Guid.NewGuid(), Type = Data.Enums.KittenType.Sikot });
            }
            for (int i = 0; i < Deck.MotherCount - 1; i++)
            {
                deck.Add(new Card { Id = Guid.NewGuid(), Type = Data.Enums.KittenType.Mother });
            }
            for (int i = 0; i < Deck.ZombieCount - 1; i++)
            {
                deck.Add(new Card { Id = Guid.NewGuid(), Type = Data.Enums.KittenType.Zombie });
            }
            for (int i = 0; i < Deck.BikiniCount - 1; i++)
            {
                deck.Add(new Card { Id = Guid.NewGuid(), Type = Data.Enums.KittenType.Bikini });
            }
            for (int i = 0; i < Deck.ShredingerCount - 1; i++)
            {
                deck.Add(new Card { Id = Guid.NewGuid(), Type = Data.Enums.KittenType.Shredinger });
            }
            return deck;
        }

        public static List<Card> AddCardsToDeck(List<Card> cards, List<Card> deck)
        {
            deck.AddRange(cards);
            return deck;
        }

        public static void RemoveCardsFromDeck(List<Card> cards, List<Card> deck)
        {
            foreach (var item in cards)
            {
                deck.Remove(item);
            }

        }

        public static List<Card> ShuffleTheDeck(List<Card> deck)
        {
            return deck.OrderBy(a => Guid.NewGuid()).ToList();
        }


    }
}
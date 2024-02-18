using Dapper;
using MagicTheGathering.API.Models;
using System.Data.SqlClient;

namespace MagicTheGathering.API.Repositories
{
    public class CardRepository : ICardRepository
    {
        string connectionString = "Data Source=DESKTOP-AK2QQS6\\LOCALHOST; Initial Catalog=Magic; Integrated Security=true"; //database connection, catalog is the database you are looking at, integrated security means the local host windows copy doesn't need password

        public Task<Card> AddCard(Card card)
        {
            throw new NotImplementedException();
        }

        public Task<ICollection<Card>> GetAllCards()
        {
            throw new NotImplementedException();
        }

        public async Task<Card> GetCardById(int id)
        {
            try
            {
                IEnumerable<Card> cardResult = null;

                Card card = null;

                //using will be deleted by IDisposable after it finishes
                using (var connection = new SqlConnection(connectionString)) //establishes connection to sql server
                {
                    string sqlGetCard = @"SELECT Card.CardId, Name, ImageURI, ConvertedManaCost, Colorless, White, Blue, Black, Red, Green 
                                        FROM Card
                                        WHERE Card.CardId = @SelectedId";

                    cardResult = await connection.QueryAsync<Card, ManaCost, Card>(sqlGetCard, (card, manacost) =>
                    {
                        card.ManaCost = manacost;
                        return card;
                    }, splitOn: "Colorless", param: new { SelectedId = id });

                    if (cardResult == null) 
                    {
                        return null; 
                    }

                    string sqlGetCardTypes = @"SELECT CardType.TypeName, Card_CardType.IsSubType
                                             FROM Card 
                                             INNER JOIN Card_CardType ON Card.CardId = Card_CardType.CardId
                                             INNER JOIN Cardtype on Card_CardType.CardTypeId = CardType.CardTypeId
                                             WHERE Card.CardId = @SelectedId";

                    var cardCardTypes = await connection.QueryAsync<CardCardType>(sqlGetCardTypes, param: new { SelectedId = id });

                    card = cardResult.First();

                    if (cardCardTypes != null)
                    {
                        card.CardType = new List<string>();
                        card.CardSubType = new List<string>();

                        foreach (var cardType in cardCardTypes)
                        {
                            if (cardType.IsSubType == 1)
                            {
                                card.CardSubType.Add(cardType.TypeName);
                            }
                            else
                            {
                                card.CardType.Add(cardType.TypeName);
                            }
                        }
                    }
                }
                return card;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public Task<bool> RemoveCard(int id)
        {
            throw new NotImplementedException();
        }

        public Task<bool> UpdateCard(Card card)
        {
            throw new NotImplementedException();
        }
    }
}

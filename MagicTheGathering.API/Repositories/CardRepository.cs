using Dapper;
using MagicTheGathering.API.Models;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.VisualBasic;
using System.ComponentModel;
using System.Data.SqlClient;

namespace MagicTheGathering.API.Repositories
{
    public class CardRepository : ICardRepository
    {
        string connectionString = "Data Source=DESKTOP-AK2QQS6\\LOCALHOST; Initial Catalog=Magic; Integrated Security=true"; //database connection, catalog is the database you are looking at, integrated security means the local host windows copy doesn't need password

        public async Task<Card> AddCard(Card card)
        {
            try
            {
                using (var connection = new SqlConnection(connectionString))
                {
                    string sqlAddCard = @"INSERT INTO Card (Name, ImageURI, ConvertedManaCost, Colorless, White, Blue, Black, Red, Green)
                                       OUTPUT INSERTED.CardId
                                       VALUES (@Name, @ImageURI, @ConvertedManaCost, @Colorless, @White, @Blue, @Black, @Red, @Green)";

                    var curCardId = await connection.QuerySingleAsync<int>(sqlAddCard, new { Name = card.Name, ImageURI = card.ImageUri, ConvertedManaCost = card.ConvertedManaCost, Colorless = card.ManaCost.Colorless, White = card.ManaCost.White,
                        Blue = card.ManaCost.Blue, Black = card.ManaCost.Black, Red = card.ManaCost.Red, Green = card.ManaCost.Green });

                    foreach (var cardtype in card.CardType)
                    {
                        string sqlAddCardT = @"INSERT INTO CardType (TypeName)
                                           VALUES (@TypeName)";

                        var addedCardType = await connection.ExecuteAsync(sqlAddCardT, new { TypeName = cardtype });

                        string sqlGetCTId = @"SELECT TOP 1 CardTypeId, TypeName FROM CardType
                                           WHERE TypeName = @TypeName";

                        CardTypes curCT = await connection.QuerySingleAsync<CardTypes>(sqlGetCTId, new { TypeName = cardtype });

                        string sqlAddCCT = @"INSERT INTO Card_CardType (CardId, CardTypeId, IsSubType)
                                          VALUES (@CardId, @CardTypeId, @IsSubType)";

                        var addedCCT = await connection.ExecuteAsync(sqlAddCCT, new { CardId = curCardId, CardTypeId = curCT.CardTypeId, IsSubType = 0});
                    }

                    foreach (var cardtype in card.CardSubType)
                    {
                        string sqlAddCardT = @"INSERT INTO CardType (TypeName)
                                           VALUES (@TypeName)";

                        var addedCardType = await connection.ExecuteAsync(sqlAddCardT, new { TypeName = cardtype });

                        string sqlGetCTId = @"SELECT TOP 1 CardTypeId, TypeName FROM CardType
                                           WHERE TypeName = @TypeName";

                        CardTypes curCT = await connection.QuerySingleAsync<CardTypes>(sqlGetCTId, new { TypeName = cardtype });

                        string sqlAddCCT = @"INSERT INTO Card_CardType (CardId, CardTypeId, IsSubType)
                                          VALUES (@CardId, @CardTypeId, @IsSubType)";

                        var addedCCT = await connection.ExecuteAsync(sqlAddCCT, new { CardId = curCardId, CardTypeId = curCT.CardTypeId, IsSubType = 1 });
                    }

                    return card;
                }
            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task<ICollection<Card>> GetAllCards()
        {
            try
            {
                ICollection<Card> cardList = null;
                IEnumerable<Card> cardResult = null;
                Card card = null;

                using (var connection = new SqlConnection(connectionString))
                {
                    string sqlGetAllCards = @"SELECT Card.CardId, Name, ImageURI, ConvertedManaCost, Colorless, White, Blue, Black, Red, Green 
                                        FROM Card";

                    cardResult = await connection.QueryAsync<Card, ManaCost, Card>(sqlGetAllCards, (card, manacost) =>
                    {
                        card.ManaCost = manacost;
                        return card;
                    }, splitOn: "Colorless");

                    if (cardResult == null)
                    {
                        return null;
                    }

                    string sqlGetCardTypes = @"SELECT CardType.TypeName, Card_CardType.IsSubType, Card_CardType.CardId
                                             FROM Card 
                                             INNER JOIN Card_CardType ON Card.CardId = Card_CardType.CardId
                                             INNER JOIN Cardtype on Card_CardType.CardTypeId = CardType.CardTypeId";

                    var cardCardTypes = await connection.QueryAsync<CardCardType>(sqlGetCardTypes);

                    if (cardCardTypes != null)
                    {

                        foreach (var curCard in cardResult)
                        {
                            var curId = curCard.CardId;
                            var curCardTypes = cardCardTypes.Where(C => C.CardId == curId);
                            card = curCard;
                            card.CardType = new List<string>();
                            card.CardSubType = new List<string>();

                            foreach (var curCardType in curCardTypes)
                            {
                                if (curCardType.CardId == curId && curCardType.IsSubType == 1)
                                {
                                    card.CardSubType.Add(curCardType.TypeName);
                                }
                                else if (curCardType.CardId == curId)
                                {
                                    card.CardType.Add(curCardType.TypeName);
                                }
                            }
                        }
                    }

                    cardList = cardResult.ToList();
                }
                return cardList;
            }
            catch (Exception)
            {
                throw;
            }
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

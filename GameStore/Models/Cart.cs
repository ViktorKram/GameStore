using System.Collections.Generic;
using System.Linq;


namespace GameStore.Models
{
    public class Cart
    {
        private List<CartLine> lineCollection = new List<CartLine>();

        public IEnumerable<CartLine> Lines
        {
            get { return lineCollection; }
        }

        public void AddItem(Game game, int quantity)
        {
            CartLine line = lineCollection
                .Where(p => p.Game.GameId == game.GameId)
                .FirstOrDefault();

            if (line == null)
            {
                lineCollection.Add(new CartLine
                {
                    Game = game,
                    Quantity = quantity
                });
            }
            else
            {
                line.Quantity += quantity;
            }
        }

        public void RemoveLine(Game game)
        {
            var gameToRemove = lineCollection.Where(g => g.Game.GameId == game.GameId).FirstOrDefault();

            gameToRemove.Quantity -= 1;

            if (gameToRemove.Quantity == 0)
            {
                lineCollection.Remove(gameToRemove);
            }
            //lineCollection.RemoveAll(l => l.Game.GameId == game.GameId);
        }

        public decimal ComputeTotalValue()
        {
            return lineCollection.Sum(e => e.Game.Price * e.Quantity);
        }

        public void Clear()
        {
            lineCollection.Clear();
        }
    }


}
using KoiKingdom_BusinessObject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KoiKingdom_Repository
{
    public interface ICartItemRepo
    {
        public void AddCartItem(Tour tour, int quantity);
        public List<CartItem> GetCartItems();
        public void RemoveCartItem(Tour tour, int quantity);
        List<(Tour tour, int quantity)> GetList();
    }
}

using KoiKingdom_BusinessObject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KoiKingdom_Service
{
    public interface ICartItemServices
    {
        public void AddTourToCart(Tour tour, int quantity);
        public List<CartItem> GetCartItems();
        public void RemoveTourFromCart(int tourId);
    }
}

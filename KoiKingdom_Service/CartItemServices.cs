using KoiKingdom_BusinessObject;
using KoiKingdom_Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KoiKingdom_Service
{
    public class CartItemServices : ICartItemServices
    {
        private ICartItemRepo iCartRepo;

        public CartItemServices()
        {
            iCartRepo = new CartItemRepository();
        }

        // Thêm một tour vào giỏ hàng với logic kiểm tra số lượng
         public void AddTourToCart(Tour tour, int quantity)
        {
            if (quantity > 0)
            {
                iCartRepo.AddCartItem(tour, quantity);
            }
            else
            {
                throw new ArgumentException("Số lượng phải lớn hơn 0");
            }
        }
        // Lấy các mục trong giỏ hàng
        public List<CartItem> GetCartItems()
        {
            return iCartRepo.GetCartItems();
        }

        public List<(Tour tour, int quantity)> GetList()
        {
            return iCartRepo.GetList();
        }

        // Xóa tour khỏi giỏ hàng
        public void RemoveTourFromCart(Tour tour, int quantity)
        {
            iCartRepo.RemoveCartItem(tour, quantity);
        }
    }
}

using KoiKingdom_BusinessObject;
using KoiKingdom_Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KoiKingdom_Service
{
    public class CartService
    {
        private CartItemRepository cartItemRepository;

        public CartService()
        {
            cartItemRepository = new CartItemRepository();
        }

        // Thêm một tour vào giỏ hàng với logic kiểm tra số lượng
         public void AddTourToCart(Tour tour, int quantity)
        {
            if (quantity > 0)
            {
                cartItemRepository.AddCartItem(tour, quantity);
            }
            else
            {
                throw new ArgumentException("Số lượng phải lớn hơn 0");
            }
        }
        // Lấy các mục trong giỏ hàng
        public List<CartItem> GetCartItems()
        {
            return cartItemRepository.GetCartItems();
        }

        // Xóa tour khỏi giỏ hàng
        public void RemoveTourFromCart(int tourId)
        {
            cartItemRepository.RemoveCartItem(tourId);
        }
    }
}

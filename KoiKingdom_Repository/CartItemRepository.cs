using KoiKingdom_BusinessObject;
using KoiKingdom_DAOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KoiKingdom_Repository
{
    public class CartItemRepository : ICartItemRepo
    {

        // Thêm một mục vào giỏ hàng
        public void AddCartItem(Tour tour, int quantity)=> CartItemDAO.Instance.AddCartItem(tour, quantity);


        // Lấy tất cả các mục trong giỏ hàng
        public List<CartItem> GetCartItems() => CartItemDAO.Instance.GetCartItems();



        // Xóa một mục khỏi giỏ hàng
        public void RemoveCartItem(int tourId) => CartItemDAO.Instance.RemoveCartItem(tourId);



    }
}

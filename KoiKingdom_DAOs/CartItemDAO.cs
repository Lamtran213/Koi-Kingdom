using KoiKingdom_BusinessObject;
using System;
using System.Collections.Generic;
using System.Linq;

namespace KoiKingdom_DAOs
{
    public class CartItemDAO
    {

        private KOI_PRNContext dbContext;
        private static CartItemDAO instance;

        public CartItemDAO()
        {
            dbContext = new KOI_PRNContext();
        }

        public static CartItemDAO Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new CartItemDAO();
                }
                return instance;
            }
        }

        // Giả sử bạn sử dụng một danh sách tạm thời để lưu giỏ hàng
        private static List<CartItem> cartItems = new List<CartItem>();

        // Thêm một mục vào giỏ hàng
        public void AddCartItem(Tour tour, int quantity)
        {
            // Tìm kiếm mục đã tồn tại trong giỏ hàng theo TourId
            var existingItem = cartItems.FirstOrDefault(item => item.tour.TourId == tour.TourId);
            if (existingItem != null)
            {
                // Nếu đã tồn tại, tăng số lượng người
                existingItem.numberOfPeople += quantity;
            }
            else
            {
                // Nếu chưa tồn tại, thêm mới
                cartItems.Add(new CartItem { tour = tour, numberOfPeople = quantity });
            }
        }

        // Lấy tất cả các mục trong giỏ hàng
        public List<CartItem> GetCartItems()
        {
            return cartItems;
        }

        // Xóa một mục khỏi giỏ hàng
        public void RemoveCartItem(int tourId)
        {
            // Tìm kiếm mục để xóa theo TourId
            var itemToRemove = cartItems.FirstOrDefault(item => item.tour.TourId == tourId);
            if (itemToRemove != null)
            {
                // Nếu tìm thấy, xóa mục đó
                cartItems.Remove(itemToRemove);
            }
        }

        // Lấy danh sách tour và số lượng
        public List<(Tour tour, int quantity)> GetList()
        {
            return cartItems.Select(item => (item.tour, item.numberOfPeople)).ToList();
        }
    }
}

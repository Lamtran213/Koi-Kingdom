﻿using KoiKingdom_BusinessObject;
using KoiKingdom_Service;
using System.IO;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media.Imaging;

namespace KoiKingdomPRN_WPF
{
    public partial class MyCartWindow : Window
    {
        private readonly ICartItemServices cartItemServices;
        private readonly Tour currentTour; // Store the current tour
        private readonly int quantity; // Store the quantity
        private CartItemServices cartService;


        public MyCartWindow(ICartItemServices cartItemServices, CartItemServices cartService, Tour currentTour, int quantity)
        {
            InitializeComponent();
            this.cartItemServices = cartItemServices ?? throw new ArgumentNullException(nameof(cartItemServices), "CartItemServices cannot be null.");
            this.currentTour = currentTour;
            this.quantity = quantity;
            LoadCartItems();
            UpdateCartWithSelectedTour(); // Update cart with selected tour
        }


        private void UpdateCartWithSelectedTour()
        {
            if (currentTour != null && quantity > 0)
            {
                cartItemServices.AddTourToCart(currentTour, quantity);
            }
        }

        // Method to load cart items into the ListView
        private void LoadCartItems()
        {
            if (cartItemServices == null)
            {
                MessageBox.Show("CartItemServices is not initialized.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            // Load cart items and display them
            var cartItems = cartItemServices.GetList();

            string currentDirectory = AppDomain.CurrentDomain.BaseDirectory;

            CartItemsListView.ItemsSource = cartItems.Select(item => new
            {
                TourImage = new BitmapImage(new Uri(Path.Combine(currentDirectory, item.tour.Image), UriKind.Absolute)), // Corrected here
                TourName = item.tour.TourName, // Assuming the Tour object has a TourName property
                Quantity = item.quantity,
                TourPrice = string.Format("{0:C}", item.tour.TourPrice), // Format price as currency
                TotalPrice = string.Format("{0:C}", item.tour.TourPrice * item.quantity), // Calculate total price
                Item = item // Keep a reference to the item for removal
            }).ToList();
        }

    }
}

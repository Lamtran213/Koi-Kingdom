using KoiKingdom_BusinessObject;
using KoiKingdom_Service;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Windows;
using System.Windows.Media.Imaging;

namespace KoiKingdomPRN_WPF
{
    public partial class KoiTypeListWindow : Window
    {
        private readonly IKoitypeService iKoiTypeService;

        public KoiTypeListWindow(IKoitypeService iKoiTypeService)
        {
            InitializeComponent();
            this.iKoiTypeService = iKoiTypeService;
            LoadKoiTypeListInformation();
        }

        private void LoadKoiTypeListInformation()
        {
            try
            {
                var koiTypeList = iKoiTypeService.GetKoitypes().ToList();
                if (koiTypeList.Any())
                {
                    string currentDirectory = AppDomain.CurrentDomain.BaseDirectory;
                    var koiTypeItems = koiTypeList.Select(list => new
                    {
                        KoiTypeID = list.KoiTypeId,
                        TypeName = list.TypeName,
                        Description = list.Description,
                        Image = new BitmapImage(new Uri(Path.Combine(currentDirectory, list.Image), UriKind.Absolute)),
                    }).ToList();

                    // Assuming koiTypeListBox is a ListBox in your XAML for displaying koi types
                    koiTypeListBox.ItemsSource = koiTypeItems;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading koi type information: " + ex.Message, "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        // Parameterless constructor removed if it’s unnecessary
    }
}

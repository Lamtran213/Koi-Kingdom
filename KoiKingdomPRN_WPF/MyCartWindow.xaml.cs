using KoiKingdom_Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace KoiKingdomPRN_WPF
{
    /// <summary>
    /// Interaction logic for MyCartWindow.xaml
    /// </summary>
    public partial class MyCartWindow : Window
    {
        private readonly ICartItemServices cartItemServices;
        public MyCartWindow(ICartItemServices cartItemServices)
        {
            InitializeComponent();
            this.cartItemServices = cartItemServices;
        }
        public MyCartWindow() { }



    }
}

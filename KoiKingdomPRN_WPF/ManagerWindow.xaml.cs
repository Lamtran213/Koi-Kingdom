using KoiKingdom_BusinessObject;
using KoiKingdom_DAOs;
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
    /// Interaction logic for ManagerWindow.xaml
    /// </summary>
    public partial class ManagerWindow : Window
    {
        
        private Employee employee;

        public ManagerWindow()
        {
        }

        public ManagerWindow(KoiKingdom_BusinessObject.Employee employee)
        {
            InitializeComponent();
            EmployeeDAO.Instance.CurrentEmployee = employee;
            HeaderManagerWindow headerManagerWindow = (HeaderManagerWindow)this.FindName("headerManagerWindowControl");
            this.employee = employee;
            if (headerManagerWindow != null)
            {
                headerManagerWindow.SetEmployee(employee);
            }
        }
    }
}

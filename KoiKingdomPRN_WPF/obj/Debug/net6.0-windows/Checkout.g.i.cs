﻿#pragma checksum "..\..\..\Checkout.xaml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "6A49CAD6E60069080DAEB6BA516B17E7FC3C469C"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using KoiKingdomPRN_WPF;
using System;
using System.Diagnostics;
using System.Windows;
using System.Windows.Automation;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Controls.Ribbon;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Forms.Integration;
using System.Windows.Ink;
using System.Windows.Input;
using System.Windows.Markup;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Media.Effects;
using System.Windows.Media.Imaging;
using System.Windows.Media.Media3D;
using System.Windows.Media.TextFormatting;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Shell;


namespace KoiKingdomPRN_WPF {
    
    
    /// <summary>
    /// Checkout
    /// </summary>
    public partial class Checkout : System.Windows.Window, System.Windows.Markup.IComponentConnector {
        
        
        #line 57 "..\..\..\Checkout.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox txtFullName;
        
        #line default
        #line hidden
        
        
        #line 58 "..\..\..\Checkout.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox txtEmail;
        
        #line default
        #line hidden
        
        
        #line 62 "..\..\..\Checkout.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox txtAddress;
        
        #line default
        #line hidden
        
        
        #line 63 "..\..\..\Checkout.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ComboBox ProvinceComboBox;
        
        #line default
        #line hidden
        
        
        #line 66 "..\..\..\Checkout.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ComboBox DistrictComboBox;
        
        #line default
        #line hidden
        
        
        #line 69 "..\..\..\Checkout.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ComboBox WardComboBox;
        
        #line default
        #line hidden
        
        private bool _contentLoaded;
        
        /// <summary>
        /// InitializeComponent
        /// </summary>
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "8.0.8.0")]
        public void InitializeComponent() {
            if (_contentLoaded) {
                return;
            }
            _contentLoaded = true;
            System.Uri resourceLocater = new System.Uri("/KoiKingdomPRN_WPF;component/checkout.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\Checkout.xaml"
            System.Windows.Application.LoadComponent(this, resourceLocater);
            
            #line default
            #line hidden
        }
        
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "8.0.8.0")]
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Design", "CA1033:InterfaceMethodsShouldBeCallableByChildTypes")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Maintainability", "CA1502:AvoidExcessiveComplexity")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1800:DoNotCastUnnecessarily")]
        void System.Windows.Markup.IComponentConnector.Connect(int connectionId, object target) {
            switch (connectionId)
            {
            case 1:
            
            #line 26 "..\..\..\Checkout.xaml"
            ((System.Windows.Controls.MenuItem)(target)).Click += new System.Windows.RoutedEventHandler(this.Home_Click);
            
            #line default
            #line hidden
            return;
            case 2:
            
            #line 28 "..\..\..\Checkout.xaml"
            ((System.Windows.Controls.MenuItem)(target)).Click += new System.Windows.RoutedEventHandler(this.TourBooking_Click);
            
            #line default
            #line hidden
            return;
            case 3:
            
            #line 29 "..\..\..\Checkout.xaml"
            ((System.Windows.Controls.MenuItem)(target)).Click += new System.Windows.RoutedEventHandler(this.CustomTour_Click);
            
            #line default
            #line hidden
            return;
            case 4:
            
            #line 31 "..\..\..\Checkout.xaml"
            ((System.Windows.Controls.MenuItem)(target)).Click += new System.Windows.RoutedEventHandler(this.Services_Click);
            
            #line default
            #line hidden
            return;
            case 5:
            
            #line 33 "..\..\..\Checkout.xaml"
            ((System.Windows.Controls.MenuItem)(target)).Click += new System.Windows.RoutedEventHandler(this.Farm_Click);
            
            #line default
            #line hidden
            return;
            case 6:
            
            #line 34 "..\..\..\Checkout.xaml"
            ((System.Windows.Controls.MenuItem)(target)).Click += new System.Windows.RoutedEventHandler(this.KoiType_Click);
            
            #line default
            #line hidden
            return;
            case 7:
            
            #line 36 "..\..\..\Checkout.xaml"
            ((System.Windows.Controls.MenuItem)(target)).Click += new System.Windows.RoutedEventHandler(this.Contact_Click);
            
            #line default
            #line hidden
            return;
            case 8:
            
            #line 42 "..\..\..\Checkout.xaml"
            ((System.Windows.Controls.MenuItem)(target)).Click += new System.Windows.RoutedEventHandler(this.AddToCart_Click);
            
            #line default
            #line hidden
            return;
            case 9:
            
            #line 43 "..\..\..\Checkout.xaml"
            ((System.Windows.Controls.MenuItem)(target)).Click += new System.Windows.RoutedEventHandler(this.Button2_Click);
            
            #line default
            #line hidden
            return;
            case 10:
            
            #line 45 "..\..\..\Checkout.xaml"
            ((System.Windows.Controls.MenuItem)(target)).Click += new System.Windows.RoutedEventHandler(this.MyBookingTour_Click);
            
            #line default
            #line hidden
            return;
            case 11:
            
            #line 46 "..\..\..\Checkout.xaml"
            ((System.Windows.Controls.MenuItem)(target)).Click += new System.Windows.RoutedEventHandler(this.MyProfile_Click);
            
            #line default
            #line hidden
            return;
            case 12:
            this.txtFullName = ((System.Windows.Controls.TextBox)(target));
            return;
            case 13:
            this.txtEmail = ((System.Windows.Controls.TextBox)(target));
            return;
            case 14:
            this.txtAddress = ((System.Windows.Controls.TextBox)(target));
            return;
            case 15:
            this.ProvinceComboBox = ((System.Windows.Controls.ComboBox)(target));
            
            #line 63 "..\..\..\Checkout.xaml"
            this.ProvinceComboBox.SelectionChanged += new System.Windows.Controls.SelectionChangedEventHandler(this.ProvinceComboBox_SelectionChanged);
            
            #line default
            #line hidden
            return;
            case 16:
            this.DistrictComboBox = ((System.Windows.Controls.ComboBox)(target));
            
            #line 66 "..\..\..\Checkout.xaml"
            this.DistrictComboBox.SelectionChanged += new System.Windows.Controls.SelectionChangedEventHandler(this.DistrictComboBox_SelectionChanged);
            
            #line default
            #line hidden
            return;
            case 17:
            this.WardComboBox = ((System.Windows.Controls.ComboBox)(target));
            return;
            }
            this._contentLoaded = true;
        }
    }
}

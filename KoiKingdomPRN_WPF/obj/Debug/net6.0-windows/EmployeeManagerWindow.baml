   M S B A M L   `   `   `  ����L  HKoiKingdomPRN_WPF, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null5clr-namespace:KoiKingdomPRN_WPFKoiKingdomPRN_WPF  5   	   -    'KoiKingdomPRN_WPF.EmployeeManagerWindow   5   	   W SPresentationCore, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35^ ZWindowsFormsIntegration, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35H 9http://schemas.microsoft.com/winfx/2006/xaml/presentation      5   	   R NSystem.Xaml, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   1localclr-namespace:KoiKingdomPRN_WPF     5   	   -   5          � Title$  EmployeeManagerWindow��5   	   $	��450��6'   $
��1200��64    � WindowStartupLocation$ CenterScreen=�5	   	    � AllowsTransparency$
 True��5
   	    � WindowStyle$
 None=�5   	   
������ .��5      �� -   5         �� CornerRadius$ 30��5      ��5   
   �� 5       �� 
StartPoint$	 0,1&�6"    �� EndPoint$	 1,0&�63   .��5      �  � Color$ OldLace��6    � Offset$ 0Q�6/   � 5      $ 
BlueViolet��6   $
 0.75Q�62   5      ._�5   
   �� $ 20��6   $��5q�6#   	 J� Opacity$		 0.9Q�67   ��5      �� 5      $	 0,0&�6&   $	 1,1&�67   .��5      � $ #006600��6#   $ 0Q�63   � 5      $ #007700��6#   $ 0Q�63   � 5      $ #FF66CC��6#   $ 0Q�63   5      ._�5      � 
 � ColumnDefinitions
 5      �� 5      $	��200 �6'   �� 5!      $��* �6'   .+�5&      +   %KoiKingdomPRN_WPF.HeaderManagerWindow  $��0��6,   � 5)      $��1��6   $��10,81,10,10q�6'    � RowDefinitions 5*      �� 5+      $
��Auto �6(   �� 5-      $
��Auto �6(   �� 5/      $
��Auto �6(   �� 51      $��* �6(   
 56      �� 57      $	��150 �6+   �� 59      $��* �6+   �� 5;      $	��150 �6+   �� 5=      $��* �6+   .+�5A      �� $��
EmployeeID��6   $��0��61   $��0��6>   $��Right=�6N   $��	10,10,0,0q�6j   �� 5B      -   5         ��Name$ txtEmployeeID��5B      $��0��65   $��1��6B   $��10,5,0,5q�6R   �� 5D      $��Status��6   $��0��6-   $��2��6:   $��Right=�6J   $��	10,10,0,0q�6f   �� 5E      -   5         ��Name$ 	cmbStatus��5E      $��3��62   $��5,0,5,0q�6B   .@�5F      �� $��Active��6'   
 � Tag$
 True��68   �� 5G      $��Blocked��6'   $ False��69   5H      �� 5K      $��	Full Name��6   $��1��60   $��0��6=   $��Right=�6M   $��	0,10,10,0q�6i   �� 5L      -   5        $ txtFullName��5L      $��1��63   $��1��6@   $��10,5,0,5q�6P   �� 5N      $��Email��6   $��1��6,   $��2��69   $��Right=�6I   $��	10,10,0,0q�6e   �� 5O      -   5        $ txtEmail��5O      $��1��60   $��3��6=   $��5,5,5,5q�6M   �� 5R      $��Address��6   $��2��6.   $��0��6;   $��Right=�6K   $��	0,10,21,0q�6g   �� 5S      -   5        $ 
txtAddress��5S      $��2��62   $��1��6?   $��10,5,0,5q�6O   &   System.Windows.Controls.DataGrid  5V      -   5          Name$ dtgEmployee��5V      $��3��64   $��4��6A   $��Center=�6U   $	��Top=�6r   $��0,34,0,0q�5W      $	��206��6)   $	��200��66   $	��922��6F   5X   B   5Y      5Z      5[      5\      5]      
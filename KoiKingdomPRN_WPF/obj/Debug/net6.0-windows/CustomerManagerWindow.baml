   M S B A M L   `   `   `  ����L  HKoiKingdomPRN_WPF, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null5clr-namespace:KoiKingdomPRN_WPFKoiKingdomPRN_WPF  5   	   -    'KoiKingdomPRN_WPF.CustomerManagerWindow   5   	   W SPresentationCore, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35^ ZWindowsFormsIntegration, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35H 9http://schemas.microsoft.com/winfx/2006/xaml/presentation      5   	   R NSystem.Xaml, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   1localclr-namespace:KoiKingdomPRN_WPF     5   	   -   5          � Title$  CustomerManagerWindow��5   	   $	��450��6'   $
��1200��64    � WindowStartupLocation$ CenterScreen=�5	   	    � AllowsTransparency$
 True��5
   	    � WindowStyle$
 None=�5   	   
������ .��5      �� -   5         �� CornerRadius$ 30��5      ��5   
   �� 5       �� 
StartPoint$	 0,1&�6"    �� EndPoint$	 1,0&�63   .��5      �  � Color$
 Lime��6    � Offset$ 0Q�6,   � 5      $ 	Chocolate��6   $
 0.75Q�61   5      ._�5   
   �� $ 20��6   $��5q�6#   	 J� Opacity$		 0.9Q�67   ��5      �� 5      $	 0,0&�6&   $	 1,1&�67   .��5      � $ #006600��6#   $ 0Q�63   � 5      $ #007700��6#   $ 0Q�63   � 5      $ #FF66CC��6#   $ 0Q�63   5      ._�5      � 
 � ColumnDefinitions
 5      �� 5      $	��200 �6'   �� 5!      $��* �6'   .+�5&      +   %KoiKingdomPRN_WPF.HeaderManagerWindow  $��0��6,   � 5)      $��1��6   $��10q�6'    � RowDefinitions 5*      �� 5+      $
��Auto �6(   �� 5,      $
��Auto �6(   �� 5-      $
��Auto �6(   �� 5.      $
��Auto �6(   �� 5/      $
��Auto �6(   �� 50      $
��Auto �6(   �� 51      $��* �6(   
 56      �� 57      $	��150 �6+   �� 58      $��* �6+   �� 59      $	��150 �6+   �� 5:      $��* �6+   .+�5>      �� $��Customer ID��6   $��1��62   $��0��6?   $��Right=�6O   $��
0,29,41,15q�6k   $��2��6   �� 5?      -   5         ��Name$ txtCustomerID��5?      $��1��65   $��135,17,25,27q�6B   $��2��6X   $��2��6l   �� 5B      $��	Full Name��6   $��2��60   $��2��6=   $��Right=�6M   $��
0,2,65,343q�6i   $��5��6}   �� 5C      -   5        $ txtFullName��5C      $��1��63   $��2��6@   $��110,29,50,15q�6P   $��2��6f   $��2��6z   �� 5F      $��Email��6   $��6��6,   $��0��69   $��Right=�6I   $��
0,0,79,291q�6e   �� 5G      -   5        $ txtEmail��5G      $��1��60   $��135,34,25,324q�6=   $��6��6T   $��2��6e   �� 5J      $��Address��6   $��6��6.   $��2��6;   $
��Left=�6K   $��24,10,0,266q�6f   �� 5K      -   5        $ 
txtAddress��5K      $��1��62   $��2��6?   $��110,23,50,321q�6O   $��2��6f   $��6��6z   �� 5N      $��Account Type��6   $��6��63   $��Center=�6@   $��
0,49,0,240q�6]   �� 5O      -   5        $ txtAccountType��5O      $��6��66   $��135,10,25,280q�6C   $��2��6Z   �� 5R      $��Status��6   $��6��6-   $��2��6:   $��Right=�6J   $��0,51,86,239q�6f   �� 5S      -   5         ��Name$ 	cmbStatus��5S      $��6��62   $��2��6?   $��110,49,50,0q�6O   $��2��6�   $	��Top=�6�   .@�5T      �� $��Active��6'   
 � Tag$
 True��68   �� 5U      $��Blocked��6'   $ False��69   5V      &   System.Windows.Controls.DataGrid  5Y      -	   5          Name$ dtgCustomer��5Y      $��6��64   $��4��6A   $
��Left=�6U   $	��Top=�6p   $��	0,105,0,0q�5Z      $	��226��6*   $	��200��67   $	��942��6G   5[   B   5\      5]      5^      5_      5`      
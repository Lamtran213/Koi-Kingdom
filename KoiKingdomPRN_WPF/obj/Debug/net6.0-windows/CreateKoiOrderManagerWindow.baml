   M S B A M L   `   `   `  ����L  HKoiKingdomPRN_WPF, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null5clr-namespace:KoiKingdomPRN_WPFKoiKingdomPRN_WPF  5   	   3    -KoiKingdomPRN_WPF.CreateKoiOrderManagerWindow   5   	   W SPresentationCore, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35^ ZWindowsFormsIntegration, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35H 9http://schemas.microsoft.com/winfx/2006/xaml/presentation      5   	   R NSystem.Xaml, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   1localclr-namespace:KoiKingdomPRN_WPF     5   	     � Title$!  CreateKoiOrderManagerWindow��5   	   $	��800��6-   $
��1200��6:    � WindowStartupLocation$ CenterScreen=�5	   	    � AllowsTransparency$
 True��5
   	    � WindowStyle$
 None=�5   	   
������ .��5      �� -   5         �� CornerRadius$ 30��5      ��5   
   �� 5       �� 
StartPoint$	 0,1&�6"    �� EndPoint$	 1,0&�63   .��5      �  � Color$ AntiqueWhite��6    � Offset$ 0Q�64   � 5      $ 	Chocolate��6   $
 0.75Q�61   5      ._�5   
   �� $ 20��6   $��5q�6#   	 J� Opacity$		 0.9Q�67   ��5      �� 5      $	 0,0&�6&   $	 1,1&�67   .��5      � $ #006600��6#   $ 0Q�63   � 5      $ #007700��6#   $ 0Q�63   � 5      $ #FF66CC��6#   $ 0Q�63   5      ._�5      �� $
��Auto=�6   .��5       � .+�5"      .   (KoiKingdomPRN_WPF.HeaderConsultingWindow  $��0��63   $��0,0,0,-7q�6C   � 5$      $��212,20,0,20q�6   $
��Left=�60   $	��900��6K   .+�5&      �� $��Create Koi Order��6$   $��24(�6<   $
��Bold"�6J   
��� � �$
��Left=�5'      $	��Top=�6/   $��
370,10,0,0q�6G   �� 5*      $��Customer ID��6$   $��102,79,726,0q�67   $	��Top=�6M   $��30��6e   �� 5+      -   5        
 ��Name$
 txtCustomerID��5+   "   $��30��69   $��180,64,450,0q�6E   $	��Top=�6[   �� 5.      $��
Order Date��6$   $��102,123,732,0q�66   $	��Top=�6M   (  "System.Windows.Controls.DatePicker  5/      -   5          Name$ 	orderDate��5/   %   $
��Left=�68   $��28��6S   $��180,109,0,0q�6_   $	��Top=�6t   $	��270��6�   �� 52      $��Koi Order Details��6$   $��20(�6=   $
��Bold"�6K   
��� � �$
��Left=�53      $	��Top=�6/   $��384,181,0,0q�6G   �� 56      $��Select Farm��6$   $��102,240,732,0q�67   $	��Top=�6N   �� 57      -   5         ��Name$ cmbFarm��57   $   $	��140��66   $��30��6B   $��180,225,580,0q�6N   $	��Top=�6e   �� 5:      $��Select Koi Type��6$   $��403,240,413,0q�6;   $	��Top=�6R   �� 5;      -   5        $ 
cmbKoiType��5;   #   $	��140��68   $��30��6D   $��524,225,236,0q�6P   $	��Top=�6g   �� 5>      $��
Select Koi��6$   $��102,307,741,0q�66   $	��Top=�6M   $��25��6e   �� 5?      -   5        $ cmbKoi��5?   #   $	��140��63   $��30��6?   $��180,293,580,0q�6K   $	��Top=�6b   �� 5B      $��Quantity��6$   $��403,307,444,0q�64   $	��Top=�6K   �� 5C      -   5        $
 txtQuantity��5C   "   $	��140��67   $��30��6C   $��524,293,236,0q�6O   $	��Top=�6f   �� 5F      -   5        $��Return��5F   !   $��32��62   $��349,390,322,0q�6>   $	��Top=�6U   ���#6C757D
������� J� RenderTransformOrigin$ -0.675,0.686&�5G   9   6^   �� 5H      -	   5        $��Submit Order��5H   !   $��349,482,322,236q�68   ���#28A745
�������5I   9   5K      5L      5M      5N      5O      5P      
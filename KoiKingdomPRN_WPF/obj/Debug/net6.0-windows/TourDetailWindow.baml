   M S B A M L   `   `   `  ����L  HKoiKingdomPRN_WPF, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null5clr-namespace:KoiKingdomPRN_WPFKoiKingdomPRN_WPF  5   	   (    "KoiKingdomPRN_WPF.TourDetailWindow   5   	   W SPresentationCore, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35^ ZWindowsFormsIntegration, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35H 9http://schemas.microsoft.com/winfx/2006/xaml/presentation      5   	   R NSystem.Xaml, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   1localclr-namespace:KoiKingdomPRN_WPF     5   	     � Title$  Tour Detail Page��5   	   $	��800��6"   $
��1200��6/    � 
ResizeMode$ NoResize=�6<   
������  � AllowsTransparency$
 True��5       � WindowStyle$
 None=�5       � WindowStartupLocation$ CenterOwner=�5	      .��5
   
   �� -   5         �� CornerRadius$ 30��5
      ��5      �� 5       �� 
StartPoint$	 0,1&�6&    �� EndPoint$	 1,0&�67   .��5      �  � Color$ #FFCCCC��6#   	 � Offset$		 0.0Q�63   � 5      $ White��6#   $		 1.0Q�61   5      ._�5      �� $ 20��6   $��5q�6'   
 J� Opacity$	
 0.9Q�6;   ��5      �� 5      $	 0,0&�6*   $	 1,1&�6;   .��5      � $ #006600��6'   $	 0Q�67   � 5      $ #007700��6'   $		 0.5Q�67   � 5      $ #FF66CC��6'   $	 1Q�67   5      ._�5      � $
��1140��6   $��Center=�6$   .+�5      �� .��5      �� $��-21,0,-34,0q�6!   .+�5      ��  �� Orientation$ 
Horizontal=�6%   $��Right=�6>   $��10q�6Z   .+�5      �� -   5        $��Back to Tour List��5   %   $��5q�6^   5       $   KoiKingdomPRN_WPF.HeaderWindow  5"      $��Stretch=�6-   $��10q�6K   � 5%      $��10q�6   $	��Top=�6+    � RowDefinitions 5&      �� 5'   "   $
��Auto �60   �� 5(   "   $
��Auto �60    � ColumnDefinitions 5+      �� 5,   "   $
��1.5* �63   �� 5-   "   $��2* �63   .+�51      �� -   5         ��Name$ 	TourImage��51   $   $��UniformToFill=�67   $��10q�6O   $	��300��6[   $��0��6h   $��0��6u   �� 54      $��10q�6)   $��0��65   $��1��6B   $	��Top=�6R   .+�55   "   �� -   5         ��Name$ TourName��55   ,   $��24(�6>   $
��Bold"�6L   $��0,0,0,10q�6^   �� 56   "   -   5        $ Rating��56   ,   $��16(�6<   
��� ���$��0,0,0,10q�6\   �� 57   "   -   5        $ Duration��57   ,   $��14(�6>   $��0,0,0,5q�6L   �� 58   "   -   5        $ 	StartDate��58   ,   $��14(�6?   $��0,0,0,5q�6M   �� 59   "   -   5        $ EndDate��59   ,   $��14(�6=   $��0,0,0,5q�6K   �� 5:   "   -	   5        $ 	FarmNames��5:   ,   $��14(�6?   $��0,0,0,5q�6M   �� 5;   "   -
   5        $ KoiTypes��5;   ,   $��14(�6>   $��0,0,0,5q�6L   �� 5<   "   -   5        $ DepartureLocation��5<   ,   $��14(�6G   $��0,0,0,5q�6U   �� 5=   "   -   5        $ 	TourPrice��5=   ,   $��16(�6?   $
��Bold"�6M   $��0,10,0,0q�6_   �� 5@   "   $ 
Horizontal=�6-   $��Center=�6F   $��0,10,0,0q�6a   .+�5A   &   �� $��Number of people:��60   $��0,0,10,0q�6I   �� 5B   &   -   5        $��-��5B   -   $��30��6X   $��Center=�6c   �� 5C   &   -   5        $ QuantityDisplay��5C   0   $��0��6I   $��30��6R   $��Center=�6]    �� TextAlignment$ Center=�6z   $��Center=�6�   �� 5D   &   -   5        $��+��5D   -   $��30��6X   $��Center=�6c   5E   #   �� 5H   "   $ 
Horizontal=�6-   $��Center=�6F   $
��0,10q�6c   .+�5I   &   �� -   5        $��Add to Cart��5I   -   $	��100��6[   $��5q�6g   �� 5J   &   -   5        $��Book Now��5J   -   $	��100��6V   $��5q�6b   5K   #   5L      5M         KoiKingdomPRN_WPF.Footer  5P      $
��1202��6'   $	��189��64   $��Center=�6A   $��
10,20,10,0q�6^   5Q      5R      5S      5T      5U      5V      
   M S B A M L   `   `   `  ����L  HKoiKingdomPRN_WPF, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null5clr-namespace:KoiKingdomPRN_WPFKoiKingdomPRN_WPF  5      +    %KoiKingdomPRN_WPF.MyBookingTourWindow   5   	   W SPresentationCore, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35^ ZWindowsFormsIntegration, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35H 9http://schemas.microsoft.com/winfx/2006/xaml/presentation      5      R NSystem.Xaml, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      1localclr-namespace:KoiKingdomPRN_WPF     5        � Title$  MyBookingTourWindow��5   	   $	��800��6%   $
��1200��62   
������  � AllowsTransparency$
 True��5
   	    � WindowStyle$
 None=�5   	    � 
ResizeMode$ NoResize=�5   	   .��5      �� -   5         �� CornerRadius$ 30��5      ��5   
   �� 5       �� 
StartPoint$	 0,1&�6"    �� EndPoint$	 1,0&�63   .��5      �  � Color$
 pink��6    � Offset$	 0.0Q�6,   � 5      $ PaleGoldenrod��6   $	 1.0Q�65   5      ._�5   
   �� $ 20��6   $��5q�6#   	 J� Opacity$		 0.9Q�67   ��5      �� 5      $	 0,0&�6&   $	 1,1&�67   .��5      � $ #006600��6#   $ 0Q�63   � 5      $ #007700��6#   $	 0.5Q�63   � 5      $ #FF66CC��6#   $ 1Q�63   5      ._�5      � 
������$��20q�6'   .+�5       $   KoiKingdomPRN_WPF.HeaderWindow  $	��Top=�6%   $��89��6=   $
��1200��6I   $��-20,0,-20,0q�6V   z�5!      V� 5"      .~�5#      �� �� 5$      �� 5%      T� 5&      5'      5)      �� 5,      $
��Auto=�6   $��-10,121,10,-61q�6B   .��5-      �� 
 �� Orientation$
 Vertical=�6!   .+�5/      �� -   5         ��Name$ BookingItemsListView��5/   '   $��Stretch=�6E   $��Stretch=�6a   ��50      �� 51   "   .R�52   &   �� $ 8��6-   ���#E0E0E0$��1q�6T   $��5q�6h    �� Padding$ 5q�6s   ._�53   *   �  � ColumnDefinitions 54   .   �� 56   2   $	��120 �6C   �� 58   2   $��4* �6C   �� 5:   2   $��2* �6C   .+�5>   .   �� $	��100��6Q   $	��100��6]   $��0��6j   $
��Left=�6z   $��Center=�6�   $��10q�6�   ��64   �� *	TourImage+6�   �� 5A   .   $��1��69   $��Center=�6I   $
��10,0q�6d   .+�5B   2   �� $��18(�6V   $
��Bold"�6d   ��6<   �� *
TourName+6d   �� 5C   2   
�������$��14(�6�   ��6<   �� *
Quantity+ �� StringFormat$ Quantity: {0}��6�   �� 5D   2   
��� E��$��16(�6n   ��6<   �� *	TourPrice+6n   5E   /   �� 5H   .   $��2��69   $��Right=�6I   $��Center=�6e   .+�5I   2   �� $��16(�6X   $
��Bold"�6f   $��Right=�6x   ��6<   �� *
TotalPrice+6x   �� 5J   2   $��Status: Completed��6<   $��14(�6U   
��� � �$��Right=�6v   �� 5K   2   $��Thank you for booking!��6<   $��12(�6Z   
�������$��Right=�6z   �� 5L   2   $ ��Please review our service.��6<   $��12(�6^   
�������$��Right=�6~   �� 5M   2   $��Edit Review��6<   
��� � �$��12(�6b   $��	Underline{�6p    � Cursor$
 Hand��6�   $��Right=�6�   $��0,10,0,0q�6�   5N   /   5O   +   5P   '   5Q   #   5S      5W      5X      5Y      5Z      5[      5\      
   M S B A M L   `   `   `  ����L  HKoiKingdomPRN_WPF, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null5clr-namespace:KoiKingdomPRN_WPFKoiKingdomPRN_WPF  5   	   "    KoiKingdomPRN_WPF.HomeWindow   5   	   W SPresentationCore, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35^ ZWindowsFormsIntegration, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35H 9http://schemas.microsoft.com/winfx/2006/xaml/presentation      5   	   R NSystem.Xaml, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   _ [MaterialDesignThemes.Wpf, Version=5.1.0.0, Culture=neutral, PublicKeyToken=df2a72020bd7962aFmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes  5   	   +localclr-namespace:KoiKingdomPRN_WPF  5   	     � Title$  
HomeWindow��5	   	   $
��2300��6   $
��1200��6*   
������  � AllowsTransparency$
 True��5   	    � WindowStyle$
 None=�5   	    � WindowStartupLocation$ CenterOwner=�5   	    � 
ResizeMode$ NoResize=�5   	   .��5      �� -   5         �� CornerRadius$ 30��5      ��5   
   �� 5       �� 
StartPoint$	 0,1&�6"    �� EndPoint$	 1,0&�63   .��5      �  � Color$ #FFCCCC��6   	 � Offset$		 0.0Q�6/   � 5      $ White��6   $		 1.0Q�6-   5      ._�5   
   �� $ 20��6   $��5q�6#   
 J� Opacity$	
 0.9Q�67   ��5      �� 5      $	 0,0&�6&   $	 1,1&�67   .��5      � $ #006600��6#   $	 0Q�63   � 5      $ #007700��6#   $		 0.5Q�63   � 5      $ #FF66CC��6#   $	 1Q�63   5      ._�5!      � .+�5%      �� $
��Auto=�6   $��Disabled=�6B   $��0,50,0,0q�6k   .��5&      �� $��Center=�6!   .+�5)      $   KoiKingdomPRN_WPF.HeaderWindow  -   5          Name$ headerWindowControl��5)   -   $	��102��6J   $��0,0,0,20q�6W   $
��1192��6i   �� 5*      $��/koibanner.gif��6    $
��1190��68   $	��406��6E   $��UniformToFill=�6R   �� 5-      $��Welcome to Koi Kingdom��6$   $��25(�6B   $
��Bold"�6P   $��Meiryo)�6b   
���   �$��Center=�6�   $��	0,20,0,20q�6�   �� 5.      $?��9- Explore the world of Koi with our exclusive farm tours.��6$   $��15(�6e   $��Meiryo)�6s   $
��Wrap=�6�   $��0,0,0,10q�6�   �� 5/      $]��W- Experience Japan's top Koi farms, learn from experts, and see stunning fish up close.��6$   $��15(�6�   $��Meiryo)�6�   $
��Wrap=�6�   $��0,0,0,10q�6�   �� 50      $w��q- Whether you're a Koi enthusiast or new to the hobby, our tours offer an unforgettable glimpse into Koi culture.��6$   $��15(�6�   $��Meiryo)�6�   $
��Wrap=�6�   $��0,0,0,20q�6�   �� 53      $��Where do you want to go?��6$   $��25(�6D   $
��Bold"�6R   $��Meiryo)�6d   
���   �$��Center=�6�   $��	0,20,0,20q�6�   �� 54       �� Orientation$ 
Horizontal=�6%   $��Center=�6>   .+�55      �� $��/koi-farm.jpg��6$   $	��341��6;   $	��228��6G   $��0,0,10,0q�6T   �� 56      $��
/kyoto.jpg��6$   $	��200��68   $	��211��6D   $��	10,0,10,0q�6Q   �� 57      $��/nagoya.jpg��6$   $	��191��69   $	��212��6E   $��	10,0,10,0q�6R   �� 58      $��
/osaka.jpg��6$   $	��213��68   $	��213��6D   $��10,0,0,0q�6Q   59      �� 5<      $��Popular Tour��6$   $��25(�68   $
��Bold"�6F   $��Meiryo)�6X   
���   �$��Center=�6   $��	0,40,0,20q�6�   �� 5=      $ 
Horizontal=�6%   $��Center=�6>   $��0,0,0,20q�6[   .+�5>      �� $��
/kyoto.jpg��6$   $	��200��68   $	��211��6D   $��	10,0,10,0q�6Q   �� 5?      $��/nagoya.jpg��6$   $	��191��69   $	��212��6E   $��	10,0,10,0q�6R   �� 5@      $��
/osaka.jpg��6$   $	��213��68   $	��213��6D   $��10,0,0,0q�6Q   5A      �� 5D      $��Popular Koi Fish Breeds��6$   $��25(�6C   $
��Bold"�6Q   $��Meiryo)�6c   
���   �$��Center=�6�   $��	0,40,0,20q�6�   �� 5E      $ 
Horizontal=�6%   $��Center=�6>   $��0,0,0,20q�6[   .+�5F      �� $��/Kohaku.jpg��6$   $	��220��69   $	��220��6E   $��	10,0,10,0q�6R   �� 5G      $��/Kohaku.jpg��6$   $	��220��69   $	��220��6E   $��	10,0,10,0q�6R   �� 5H      $��/Kohaku.jpg��6$   $	��220��69   $	��220��6E   $��10,0,0,0q�6R   5I      �� 5L      $(��"Why should you choose Koi Kingdom?��6$   $��25(�6N   $
��Bold"�6\   $��Meiryo)�6n   
���   �$��Center=�6�   $��	0,40,0,20q�6�   �� 5M      $ 
Horizontal=�6%   $��Center=�6>   $��0,0,0,20q�6[   .+�5O      �� $ Vertical=�6)   $��Center=�6@   $��10q�6]   .+�5P   "   �� $��/doctor-appointment.png��6(   $	��126��6I   $	��112��6U   $��0,0,0,10q�6b   �� 5Q   "   $q��kExpert Care: Our team has extensive experience in Koi care, ensuring the health and vitality of every fish.��6,   $��15(�5R      $
��Wrap=�6"   $	��200��66    �� TextAlignment$ Center=�6B   5S      �� 5V      $ Vertical=�6)   $��Center=�6@   $��10q�6]   .+�5W   "   �� $��/quality.png��6(   $	��125��6>   $	��115��6J   $��0,0,0,10q�6W   �� 5X   "   $k��eQuality Koi Selection: We offer carefully selected, high-quality Koi fish from top breeders in Japan.��6,   $��15(�5Y      $
��Wrap=�6"   $	��200��66   $ Center=�6B   5Z      �� 5]      $ Vertical=�6)   $��Center=�6@   $��10q�6]   .+�5^   "   �� $��/comprehension.png��6(   $	��121��6D   $	��109��6P   $��0,0,0,10q�6]   �� 5_   "   $x��rComprehensive Services: From purchasing to shipping, we provide full support for a seamless Koi buying experience.��6,   $��15(�5`      $
��Wrap=�6"   $	��200��66   $ Center=�6B   5a      5b         KoiKingdomPRN_WPF.Footer  5c      $	��203��6'   5f      5g      5h      5i      5j      5k      
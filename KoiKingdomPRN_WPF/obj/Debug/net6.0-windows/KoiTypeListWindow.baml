   M S B A M L   `   `   `  ����L  HKoiKingdomPRN_WPF, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null5clr-namespace:KoiKingdomPRN_WPFKoiKingdomPRN_WPF  5   	   )    #KoiKingdomPRN_WPF.KoiTypeListWindow   5   	   W SPresentationCore, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35^ ZWindowsFormsIntegration, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35H 9http://schemas.microsoft.com/winfx/2006/xaml/presentation      5   	   R NSystem.Xaml, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   1localclr-namespace:KoiKingdomPRN_WPF     5   	     � Title$  Koi Type List��5   	   $	��800��6   $
��1200��6,   
������  � WindowStyle$
 None=�5
   	    � 
ResizeMode$ NoResize=�6   .��5      �� -   5         �� CornerRadius$ 30��5      ��5   
   �� 5       �� 
StartPoint$	 0,1&�6"    �� EndPoint$	 1,0&�63   .��5      �  � Color$ 	#FF71EFED��6    � Offset$ 0Q�61   � 5      $ 	#FF2B48BD��6   $
 0.75Q�61   5      ._�5   
   �� $ 20��6   $��5q�6#    J� Opacity$	 0.9Q�67   ��5      �� 5      $	 0,0&�6&   $	 1,1&�67   .��5      � $ 	#FF2496D2��6#   $ 0Q�65   � 5      $ 	#FF2496D2��6#   $ 0Q�65   � 5      $ 	#FFC50E48��6#   $ 0Q�65   5      ._�5      � 	 � ColumnDefinitions	 5      �� 5      $
��189* �6'   �� 5      $
��601* �6'   .+�5"      �� $��Koi Type List��6   $
��Left=�60   $	��Top=�6L   $��30(�5#      $
��Bold"�6&   $��Meiryo)�68   $��1��6L   $��187,115,0,0q�6\   
 J� Effect
 5$      3  -System.Windows.Media.Effects.DropShadowEffect  5%         Color$ Black��6+      
BlurRadius$ 4Q�69      ShadowDepth$ 2Q�6H   5'      �� 5*      -   5         ��Name$ koiTypeListBox��5*      $��10,169,10,10q�62   $��2��6H   ��5+      �� 5,      .R�5-      �� ���#E0E0E0$��1q�6;    �� Padding$ 10q�6O   $��5q�6\   $ 10��6g   
�������
 5.   "     5/   &   $
 Gray��67   $ 8Q�6D   $ 4Q�6S   ��51   "   �� 52   &    �� 
TargetType" ��6,    �� Triggers 53   *   P� 54   .    P� Property �@J�IsMouseOver P� Value$
 True��6M   . �55   2   ��  �� Property � �� �� Value �#F0F8FF6O   �� 56   2    � �� �#87CEFA6P   57   /   59   '   ._�5;   "   ��  �� Orientation$ 
Horizontal=�6-   .+�5=   &   �� $��80��6E   $��80��6P   $��UniformToFill=�6\   $��5q�6t   ��6,   �� *Image+6t   �� 5?   &   $��Center=�61   .+�5@   *   �� $
��Bold"�6N   $��16(�6`   ���#333��64   �� *
TypeName+6n   �� 5A   *   $
��Wrap=�6Q   $	��400��6e   ���#555��64   �� *Description+6q   5B   '   5C   #   5D      5E      5G      $   KoiKingdomPRN_WPF.HeaderWindow  5H      $��2��6%   $��
0,10,0,680q�69      KoiKingdomPRN_WPF.Footer  5I      $��2��6   $��
0,573,0,26q�63   5L      5M      5N      5O      
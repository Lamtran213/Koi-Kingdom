   M S B A M L   `   `   `  ����L  HKoiKingdomPRN_WPF, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null5clr-namespace:KoiKingdomPRN_WPFKoiKingdomPRN_WPF  5   	   &     KoiKingdomPRN_WPF.FarmListWindow   5   	   W SPresentationCore, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35^ ZWindowsFormsIntegration, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35H 9http://schemas.microsoft.com/winfx/2006/xaml/presentation      R NSystem.Xaml, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   1localclr-namespace:KoiKingdomPRN_WPF     5   	     � Title$  	Farm List��5   	   $	��800��6   $
��1200��6(   
������  � WindowStyle$
 None=�5
   	    � 
ResizeMode$ NoResize=�6   .��5      �� -   5         �� CornerRadius$ 30��5      ��5   
   �� 5       �� 
StartPoint$	 0,1&�6"    �� EndPoint$	 1,0&�63   .��5      �  � Color$ 
LightGreen��6    � Offset$ 0Q�62   � 5      $ MediumSeaGreen��6   $
 0.75Q�66   5      ._�5   
   �� $ 20��6   $��5q�6#    J� Opacity$	 0.9Q�67   ��5      �� 5      $	 0,0&�6&   $	 1,1&�67   .��5      � $ #006600��6#   $ 0Q�63   � 5      $ #007700��6#   $ 0Q�63   � 5      $ #FF66CC��6#   $ 0Q�63   5      ._�5      � 	 � RowDefinitions	 5      �� 5      $	��61* �6$   �� 5      $
��729* �6$   .+�5!      �� $��	Farm List��6   $
��Left=�6,   $��
493,55,0,0q�6G   $	��Top=�6[   $��30(�5"      $
��Bold"�6&   $��Meiryo)�5#      $��1��6,   
 J� Effect
 5$      3  -System.Windows.Media.Effects.DropShadowEffect  5%         Color$ Black��6+      
BlurRadius$ 4Q�69      ShadowDepth$ 2Q�6H   5'      �� 5*      -   5         ��Name$ FarmListBox��5*      $��10,108,10,10q�6/   $��1��6E   ��5+      �� 5,      .R�5-      �� ���#E0E0E0$��1q�6;    �� Padding$ 10q�6O   $��5q�6\   $ 10��6g   
�������
 5.   "     5/   &   $
 Gray��67   $ 8Q�6D   $ 4Q�6S   ��51   "   �� 52   &    �� 
TargetType" ��6,    �� Triggers 53   *   P� 54   .    P� Property �@J�IsMouseOver P� Value$
 True��6M   . �55   2   ��  �� Property � �� �� Value �#F0F8FF6O   �� 56   2    � �� �#87CEFA6P   57   /   59   '   ._�5;   "   ��  �� Orientation$ 
Horizontal=�6-   .+�5=   &   �� $��80��6E   $��80��6P   $��UniformToFill=�6\   $��5q�6t   ��6,   �� *Image+6t   �� 5?   &   $��Center=�61   .+�5@   *   �� $
��Bold"�6N   $��16(�6`   ���#333��64   �� *
FarmName+6n   �� 5A   *   $��Italic$�6N   ���#777��64   �� *
Location+6a   �� 5B   *   $
��Wrap=�6Q   $	��400��6e   ���#555��64   �� *Description+6q   5C   '   5D   #   5E      5F      5H      $   KoiKingdomPRN_WPF.HeaderWindow  5I      -   5          Name$ headerWindowControl��5I   F    J� RenderTransformOrigin$ 0.5,0.5&�6%   $��2,15,24,675q�6c   $��2��6x   z�5J      V� 5K      .~�5L      �� �� 5M       �� AngleY$ -0.114Q�6,   �� 5N      T� 5O       T� Y$ -0.798Q�61   5P      5R         KoiKingdomPRN_WPF.Footer  5S      $��
0,524,0,10q�6   $��1��63   5T      5U      5V      5W      
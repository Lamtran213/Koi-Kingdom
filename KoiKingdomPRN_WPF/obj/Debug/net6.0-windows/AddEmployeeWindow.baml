   M S B A M L   `   `   `  ����L  HKoiKingdomPRN_WPF, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null5clr-namespace:KoiKingdomPRN_WPFKoiKingdomPRN_WPF  5   	   )    #KoiKingdomPRN_WPF.AddEmployeeWindow   5   	   W SPresentationCore, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35^ ZWindowsFormsIntegration, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35H 9http://schemas.microsoft.com/winfx/2006/xaml/presentation      5   	   R NSystem.Xaml, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   1localclr-namespace:KoiKingdomPRN_WPF     5   	     � Title$  AddEmployeeWindow��5   	   $	��450��6#   $
��1200��60    � WindowStartupLocation$ CenterScreen=�5	   	    � AllowsTransparency$
 True��5
   	    � WindowStyle$
 None=�5   	   
������ .��5      �� -   5         �� CornerRadius$ 30��5      ��5   
   �� 5       �� 
StartPoint$	 0,1&�6"    �� EndPoint$	 1,0&�63   .��5      �  � Color$ #FFCCFF��6    � Offset$ 0Q�6/   � 5      $ 
Aquamarine��6   $
 0.75Q�62   5      ._�5   
   �� $ 20��6   $��5q�6#   	 J� Opacity$		 0.9Q�67   ��5      �� 5      $	 0,0&�6&   $	 1,1&�67   .��5      � $ #006600��6#   $ 0Q�63   � 5      $ #007700��6#   $ 0Q�63   � 5      $ #FF66CC��6#   $ 0Q�63   5      ._�5      � $��	186,0,0,0q�6   .+�5      �� $��Add Employee
��6   $
��Left=�69   $��
380,49,0,0q�6T   $	��Top=�6h   $	��164��6�   $��20(�6�   $
��Bold"�6�   �� 5      -   5        $��Add employee
��5      $
��Left=�6:   $��337,328,0,0q�6U   $	��Top=�6j   $	��262��6�   $��30��6�   6�   �� 5       -   5        
 ��Name$
 txtEmailEmployee��5       $
��Left=�64   $��209,144,0,0q�6O    �� TextWrapping$
 Wrap=�6d   $	��Top=�6x   $	��174��6�   �� 5!      $
��Left=�6   $��
88,153,0,0q�67   $
��Wrap=�6K   $��Employee's email��6_   $	��Top=�6w   $	��101��6�   G� 5"      -   5         G�Name$ pswEmployee��5"      $
��Left=�63   $��209,196,0,0q�6N   $	��Top=�6c   $	��174��6{   �� 5#      $
��Left=�6   $��88,0,0,0q�67   $
��Wrap=�6I   $��Center=�6]   $��96��6x   �� 6�   $�Password��6�   �� 6�   �� 6�   6�   �� 5$      $
��Left=�6   $��
88,255,0,0q�67   $
��Wrap=�6K   $	��Top=�6_   �� 6x   $
�Role��6|   �� 6�   �� 6�   6�   �� 5%      -   5         ��Name$ cbxRole��5%      $
��Left=�6,   $��209,246,0,0q�6G   $	��Top=�6\   $	��174��6t   .@�5&      �� $��Sales��6#   �� 5'      $��Manager��6#   �� 5(      $��Delivery��6#   �� 5)      $��
Consulting��6#   5*      �� 5+      $
��Left=�6   $��489,153,0,0q�67   $
��Wrap=�6L   $	��Top=�6`   $��65��6x   $��18��6�   �� 6�   $�	Last name��6�   �� 6�   �� 6�   6�   �� 5,      -   5        $
 txtFirstNameEmployee��5,      $
��Left=�68   $��579,144,0,0q�6S   $
 Wrap=�6h   $	��Top=�6|   $	��178��6�   �� 5-      $
��Left=�6   $��	489,0,0,0q�67   $
��Wrap=�6J   $��Center=�6^   �� 6z   $�
First name��6~   �� 6�   �� 6�   6�   �� 5.      -   5        $
 txtLastNameEmployee��5.      $
��Left=�67   $��579,196,0,0q�6R   $
 Wrap=�6g   $	��Top=�6{   $	��178��6�   �� 5/      $
��Left=�6   $��489,258,0,0q�67   $
��Wrap=�6L   $��Address��6`   $	��Top=�6o   �� 50      -   5        $
 txtAddressEmployee��50      $
��Left=�66   $��579,246,0,0q�6Q   $
 Wrap=�6f   $	��Top=�6z   $	��178��6�   +   %KoiKingdomPRN_WPF.HeaderManagerWindow  51      $��0��6,   $��-180,0,978,0q�6<   53      54      55      56      
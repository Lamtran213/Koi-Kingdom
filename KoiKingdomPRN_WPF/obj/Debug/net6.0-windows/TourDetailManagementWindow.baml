   M S B A M L   `   `   `  ����L  HKoiKingdomPRN_WPF, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null5clr-namespace:KoiKingdomPRN_WPFKoiKingdomPRN_WPF  5      2    ,KoiKingdomPRN_WPF.TourDetailManagementWindow   5      W SPresentationCore, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35^ ZWindowsFormsIntegration, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35H 9http://schemas.microsoft.com/winfx/2006/xaml/presentation      R NSystem.Xaml, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      1localclr-namespace:KoiKingdomPRN_WPF     5        � Title$  Tour Detail Management��5      $	��450��5      $	��800��5      .��5	      � .+�5   
   � $��10q�6   .+�5      �� $��Tour Detail Management��6   $��24(�5      $
��Bold"�5      $��Center=�5      $	��Top=�5      $��0,0,0,20q�5      &   System.Windows.Controls.DataGrid  5      -   5          Name$ TourDetailDataGrid��5         AutoGenerateColumns$ False��5         CanUserAddRows$ False��5         
IsReadOnly$
 True��5      $��
163,60,0,0q�5         AlternatingRowBackground
 �����   ColumnHeaderStyle 5      �� 5       �� 
TargetType=  7System.Windows.Controls.Primitives.DataGridColumnHeader"  6   .�5       ��  �� Property � ��	 �� Value
	 � � �67   �� 5!       � ��
	 �����67   �� 5"       � ��$
	 Bold"�67   �� 5#       � ��$	 Center=�6G   5$      
   Columns
 5(      0  *System.Windows.Controls.DataGridTextColumn  5)      ,  &System.Windows.Controls.DataGridColumn   Header$ Tour Booking ID��6)      Width5  /System.Windows.Controls.DataGridLengthConverter$ * 6i   1  +System.Windows.Controls.DataGridBoundColumn   Binding 6B   �� *TourBookingDetail1+6i     5*      $ Customer ID��6)   $ * 6]    6>   �� *
CustomerId+6]     5+      $ Customer Name��6)   $ * 6a    6@   �� *CustomerName+6a     5,      $ Tour ID��6)   $ * 6U    6:   �� *TourId+6U     5-      $ Quantity��6)   $ * 6X    6;   �� *
Quantity+6X     5.      $ 
Unit Price��6)   $ * 6[    6=   �� *	UnitPrice+6[     5/      $ Total Price��6)   $ * 6]    6>   �� *
TotalPrice+6]     50      $ Status��6)   $ * 6T      
Foreground
 � � � 69   �� *Status+6^     51      $ 	Tour Type��6)   $ * 6Y    6<   �� *
TourType+6Y   4  .System.Windows.Controls.DataGridTemplateColumn  54      $ Actions��6-   $
 Auto 6>      CellTemplate 55      �� 56      .R�57   "   �� $��Update��6)   ���#4CAF50
�������$��60��5:   )   $��5q�5;   )   ��5<   )   �� *UpdateCommand+5=      5?      5A      5B      .   (KoiKingdomPRN_WPF.HeaderConsultingWindow  5E   
   $
��Left=�6'   $	��Top=�6B   $��
-15,13,0,0q�6Z   $	��424��6n   5F      5G      
   M S B A M L   `   `   `  ����K  GPILLARSALT KIOSK, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null3clr-namespace:PILLARSALT_KIOSKPILLARSALT_KIOSK  5   	   !    PILLARSALT_KIOSK.Screen0023   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   0localclr-namespace:PILLARSALT_KIOSK     5   	     � Title$%  Enter Recipient Account Details��5      $	��600��60   $
��1024��6=   $��33.333(�6J   $
��Bold"�6\    � 
ResizeMode$ NoResize=�6n    � ShowInTaskbar .   � Topmost .  � WindowStartupLocation$ CenterScreen=�6�    � WindowState$ 	Maximized=�6�    � Cursor$ Arrow��6�    � WindowStyle$
 None=�6�   .��5
      � $��
0,-10,0,10q�6    � ColumnDefinitions 5   
   �� 5      �� 5      	 � RowDefinitions	 5   
   �� 5      $	��68* �6   �� 5      $	��55* �6   �� 5      $
��394* �6   �� 5      $	��83* �6   .+�5   
   �� -   5        
 ��Name$
 label��5      $%��ENTER RECIPIENT ACCOUNT DETAILS��6   ���	#FFECF1E3$��33.333(�6`   $��Center=�6r   $��0,0,0,8q�6�   $��2��6�    J� Effect 5      3  -System.Windows.Media.Effects.DropShadowEffect  5      5      �� 5   
   -   5         ��Name$ btnBack��5      $��27,0,0,8q�6"   $
��BACK��65   
���   �$��Center=�6W   $��Right=�6y   $��3��6�   $��0��5      $	��217��6   $
��Left=�6)   $��0q�6D    J� RenderTransformOrigin$ 0.5,0.5&�6X   $��40(�6x   $��64��6�   $��Bottom=�6�    5        5      ��5      �� 5        �� ImageSource$ AppImages/Back2.png��6    j� Stretch$ Uniform=�6?    j� 
AlignmentX$
 Left=�6Q   5#      �� 5$   
   -   5        $ btnContinue��5$      {�.  $��	0,0,29,10q�68   $��Center=�6L   $
��left=�6n   $��3��6�   $��Right=�6�   $	��287��6�   $ 0.5,0.5&�6�   $��60��6�   $��Bottom=�6�   $��0q�6  $��CONTINUE��6   $��40(�63  $��1��6R   5%        5&      ��5(      �� 5)      $ AppImages/Back.png��6   $ Uniform=�6>   $ Right=�6P   5,      �� 5-   
   -   5        $
 bankLbl_Copy��5-      $��1��6&   $��LISTED BANKS��63   $��2��6J   ���	#FF05B60D���	#FFFBFBFB$
��10,0q�6�   �� 5/   
   -   5        $��listbox��5/      $��10,1.674,10,6q�6#   $��2��6<   $��0��6I   .@�50      �� $��SKY BANK��6   �� 51      $��DIAMOND BANK��6   �� 52      $��ECOBANK��6   �� 53      $��GTBANK��6   �� 54      $��
UNION BANK��6   �� 55      $��INTERCONTINENTAL BANK��6   �� 56      $��STANBIC CHARTERED BANK��6   �� 57      $	��UBA��6   �� 58      $��ZENITH BANK��6   59      �� 5;   
   -   5        $��listbox1��5;      $��10,1.674,10,6q�6$   $��2��6=   $��1��6J   .@�5<      �� $��SKY BANK��6   �� 5=      $��DIAMOND BANK��6   �� 5>      $��ECOBANK��6   �� 5?      $��GTBANK��6   �� 5@      $��
UNION BANK��6   �� 5A      $��INTERCONTINENTAL BANK��6   �� 5B      $��STANBIC CHARTERED BANK��6   �� 5C      $	��UBA��6   �� 5D      $��ZENITH BANK��6   5E      5F      5G      
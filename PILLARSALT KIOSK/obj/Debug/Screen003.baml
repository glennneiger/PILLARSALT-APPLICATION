   M S B A M L   `   `   `  ����K  GPILLARSALT KIOSK, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null3clr-namespace:PILLARSALT_KIOSKPILLARSALT_KIOSK  5   	        PILLARSALT_KIOSK.Screen003   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   0localclr-namespace:PILLARSALT_KIOSK     5   	     � Title$  hupperScreen��5   	   $	��600��6   $
��1024��6+    � WindowStyle$
 None=�68    � 
ResizeMode$ NoResize=�6K    � Topmost .  � WindowStartupLocation$ CenterScreen=�6p    � WindowState$ 	Maximized=�6�   $��40(�6�   $
��Bold"�6�   .��5	      � -   5         �Name$ DepositCount��5	       � RowDefinitions 5
   
   �� 5      $	��20* �6   �� 5      $
��153* �6   �� 5      $	��27* �6    � ColumnDefinitions 5   
   �� 5      $	��15* �6   �� 5      $	��34* �6   �� 5      $	��15* �6   .+�5   
   �� -   5        	 ��Name$	 label��5      $/��)PLACE MONEY IN THE HOPPER, PRESS CONTINUE��6   $��0,0,0,0q�6S   ���	#FFECF1E3$��33.333(�6{   $��Center=�6�   $��3��6�   
 J� Effect
 5      3  -System.Windows.Media.Effects.DropShadowEffect  5      5      �� 5   
   -   5         ��Name$ btnBack��5      $��27,0,0,8q�6"   $
��BACK��65   
���   �$��Center=�6W   $��Right=�6y   $��2��6�   $��0��5   
   $	��188��6   $
��Left=�6&   $��0q�6A    J� RenderTransformOrigin$ 0.5,0.5&�6U   $��40(�6u   $��64��6�   $��Bottom=�6�   
 5        5      ��5      �� 5        �� ImageSource$ AppImages/Back2.png��6    j� Stretch$ Uniform=�6?    j� 
AlignmentX$
 Left=�6Q   5#      �� 5$   
   -   5        $ btnContinue��5$      $��	0,0,29,10q�6&   $��Center=�6:   $
��left=�6\   $��2��6~   $��Right=�6�   $	��287��6�   $ 0.5,0.5&�6�   $��60��6�   $��Bottom=�6�   $��0q�6�   $��CONTINUE��6  $��40(�6!  $��1��6@  $��2��6P  
 5%        5&      ��5(      �� 5)      $ AppImages/Back.png��6   $ Uniform=�6>   $ Right=�6P   5,      �� 5-   
   -   5         ��Name$ image��5-      $��1��6   $��10q�6/   $��1��6;   $��AppImages/hupper.png��6H   $
��Fill=�6f   5.      5/      
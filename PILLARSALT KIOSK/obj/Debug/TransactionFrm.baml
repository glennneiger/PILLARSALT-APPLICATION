   M S B A M L   `   `   `  ����K  GPILLARSALT KIOSK, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null3clr-namespace:PILLARSALT_KIOSKPILLARSALT_KIOSK  5   	   %    PILLARSALT_KIOSK.TransactionFrm   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   0localclr-namespace:PILLARSALT_KIOSK     5   	   -   5          � Title$  TransactionFrm��5      $	��600��6   $
��1024��6,    � WindowState$ 	Maximized=�69    � WindowStyle$
 None=�6Q   .��5
      �  � ColumnDefinitions 5   
   �� 5      $
��505* �6   �� 5      $
��511* �6    � RowDefinitions 5   
   �� 5      $	��85* �6   �� 5      $	��95* �6   �� 5      $
��305* �6   �� 5      $
��107* �6   ��5   
   �� 5       �� ImageSource$ AppImages/pro.jpg��6    j� Stretch$ UniformToFill=�69   .+�5   
   �� -   5         ��Name$ TxtScreenTitle��5      $(��"THANK YOU!!!, TRANSACTION COMPLETE��6(   $��15,10,22,6.117q�6U   ���	#FFECF1E3$��40(�6�   $��Center=�6�   $
��Bold"�6�   $��2��6�    J� Effect 5      3  -System.Windows.Media.Effects.DropShadowEffect  5      5      �� 5   
   ���	#FFF4F4F5$��
15,8,22,10q�6%   $��1��69   
���   �$��2��6U   $��2��6f   $��0��5      �� 5    
   -   5        	 ��Name$	 
BtnEnglish��5       $��PRINT RECEIPT��6%   $��15,10,10,20q�6=   $��3��6R   $��0��6_   $��33.333(�5!   &   $
��Bold"�68   ��5"      �� 5#      
 �� EndPoint$
 0.5,1&�6&    �� 
StartPoint$ 0.5,0&�67   .��5$      �  � Color$ 	#FFD5F0C6��6#    � Offset$ 0.277Q�65   � 5%      $ 	#FFA2D386��6#   $ 0.474Q�65   5&      5(      �� 5)   
   -   5         ��Name$ TxtDenomData��5)      $��15,25,10,25q�6*   $��1��6?   $��2��6L   $��0��6]   $
��Wrap=�6m   $��33.333(�6�   $
��Bold"�6�   �� 5*   
   -   5        $ TxtSumTotal��5*      $��1��6)   $��10,100,22,25q�69   $��2��6O   $
��Wrap=�6\   $��40(�6p   $
��Bold"�6~   ���	#FFCD0808�� 6�   $�TOTAL AMOUNT��6�    �� TextDecorations$ 	Underline{�6�   �� 6�   �� 6�   $
�NGN ��6�   6�   �� 5+   
   -   5        $	 BtnGotoMenu��5+      $��START NEW TRANSACTION��6&   $��10,10,22,20q�6F   $��3��6[   $��33.333(�6}   $
��Bold"�6�   $��1��6�   ��5,      �� 5-      $
 0.5,1&�6&   $ 0.5,0&�67   .��5.      � $ 	#FFD5F0C6��6#   $ 0.277Q�65   � 5/      $ 	#FFA2D386��6#   $ 0.474Q�65   50      52      �� 53   
   -   5        $ TxtReceiver��53      $��1��6)   $	��155��69   $��
10,25,22,0q�6F   $��1��6Z   $
��Wrap=�6g   $	��Top=�6{   $��33.333(�6�   $
��Bold"�6�   $��Receiver��6�   $��	Underline{�6�   $��2��6�   55      56      
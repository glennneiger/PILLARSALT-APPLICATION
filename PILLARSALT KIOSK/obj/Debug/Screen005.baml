   M S B A M L   `   `   `  ����  PILLARSALT KIOSK     PILLARSALT_KIOSK.Screen005   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   
   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   -   5          � Title$  Counted Notes Summary��5      $	��600��6%   $
��1024��62    � WindowStyle$
 None=�6?    � 
ResizeMode$ NoResize=�6R    � Topmost .  � WindowStartupLocation$ CenterScreen=�6w    � WindowState$ 	Maximized=�6�   $��40(�6�   $
��Bold"�6�   .��5      � -   5         �Name$ CountSummary��5       � ColumnDefinitions 5	   
   �� 5
      $
��398* �6   �� 5      $
��176* �6   �� 5      $
��199* �6   �� 5      $
��251* �6    � RowDefinitions 5   
   �� 5      $	��71* �6   �� 5      $
��441* �6   �� 5      $	��88* �6   .+�5   
   �� -   5        	 ��Name$	 label��5      $��COUNTED NOTE(S) SUMMARY��6   $��0,3,0,11q�6A   ���	#FFECF1E3$��33.333(�6j   $��Center=�6|   $��4��6�   
 J� Effect
 5      3  -System.Windows.Media.Effects.DropShadowEffect  5      5      &   System.Windows.Controls.DataGrid  5   
   -   5          Name$ grdCount��5      $��1��6>   $��0��6K   $��
10,14,10,6q�6[      AutoGenerateColumns .    
IsReadOnly .    CanUserAddRows .     MinRowHeight$ 26Q�6�   ���	#FF080808$��2��6�   ��6%   �� 6�   �� 5   
   $��2��6   ���	#FFAA2203$��	13,5,10,6q�65   $��1��6H   
���   �$��2��6d   �� 5   
   -   5         ��Name$ 	textBlock��5      $��2��6'   $��28,18,145,0q�67   $��1��6L   $
��Wrap=�6Y   $��TOTAL��6m   ���	#FFF5ECEC$��	Underline{�6�   $��60��6�   $	��Top=�6�   $��2��6�   �� 5   
   -   5        $ txtTotalCounted��5      $��2��6-   $��28,73,27,23q�6=   $��1��6R   $
��Wrap=�6_   ���	#FFF5ECEC$��2��6�   ��6�   Z� 6�   �� 5   
   -   5         ��Name$ btnBack��5      $��	14,0,0,13q�6"   $��BACK/REJECT��66   
���   �$��Center=�6_   $��Right=�6�   $��2��6�   $��0��5   
   $	��343��6   $
��Left=�6&   $��0q�6A    J� RenderTransformOrigin$ 0.5,0.5&�6U   $��40(�6u   $��64��6�   $��Bottom=�6�   
 5        5       ��5"      �� 5#       �� ImageSource$ AppImages/Back2.png��6    j� Stretch$ Uniform=�6?    j� 
AlignmentX$
 Left=�6Q   5&      �� 5'   
   -   5        $ 	btnAccept��5'      $��ACCEPT��6$   $��
14,0,10,13q�65   $��3��6I   $��2��6Y   $��40(�6f   $
��Bold"�6t   {�. $��66��6�   $��Bottom=�6�   ��5(      �� 5)       �� EndPoint$ 0.5,1&�6&    �� 
StartPoint$ 0.5,0&�67   .��5*      �  � Color$ 	#FFD5F0C6��6#    � Offset$ 0.277Q�65   � 5+      $ 	#FFA2D386��6#   $ 0.474Q�65   5,      5.      �� 5/   
   -	   5        $ btnRetry��5/      $��
RECOUNT(3)��6#   $y�Visible=�68   $��	0,0,13,13q�6M   $��2��6`   $��40(�6m   $
��Bold"�6{   $��65��6�   $��Bottom=�6�   $��2��6�   $��1��6�   $��Right=�6�   $	��267��6	  ��50      �� 51      $ 0.5,1&�6&   $ 0.5,0&�67   .��52      � $ 	#FFD5F0C6��6#   $ 0.277Q�65   � 53      $ 	#FFA2D386��6#   $ 0.474Q�65   54      56      58      59      
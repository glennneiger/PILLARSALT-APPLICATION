   M S B A M L   `   `   `  ����K  GPILLARSALT KIOSK, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null3clr-namespace:PILLARSALT_KIOSKPILLARSALT_KIOSK  5   	   !    PILLARSALT_KIOSK.BusyScreen   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   0localclr-namespace:PILLARSALT_KIOSK     5   	   J FWpfAnimatedGif, Version=1.4.14.0, Culture=neutral, PublicKeyToken=null,gif"http://wpfanimatedgif.codeplex.com  5   	     � Title$
  Busy��5	   	   $	��600��6   $
��1024��6#    � Topmost .  � WindowStartupLocation$ CenterScreen=�6?    � WindowState$ 	Maximized=�6d   $��53.333(�6|    � 
ResizeMode$ NoResize=�6�    � WindowStyle$
 None=�6�   .��5      �  � RowDefinitions 5   
   �� 5      $	��20* �6   �� 5      $	��53* �6   �� 5      $	��47* �6    � ColumnDefinitions 5   
   �� 5      .+�5   
   �� "  WpfAnimatedGif.ImageBehavior   AnimatedSource$ AppImages/index.gif��6   $��387,17,369,10q�6G   	 J� RenderTransformOrigin$	 0.5,0.5&�6^   $��1��6~   �� 5   
   -   5        
 ��Name$
 txtProcessing��5      $��Center=�6+   $��Center=�6H   $��
10,9,10,32q�6c   $
��Wrap=�6w   $
��Bold"�6�   ���	#FF465F32&   System.Windows.Media.TextOptions   TextHintingMode$ Animated=�6�   $��2��6�   $	��194��6�   $
��1004��6�   $��Italic$�6   J� Effect 5      3  -System.Windows.Media.Effects.DropShadowEffect  5         Color$
 Gray��6#      ShadowDepth$ 6Q�60      	Direction$	 300Q�6@      
BlurRadius$ 10Q�6P   �� 5   !   $�Transaction��6%   �� 6:   $� is p��6>   �� 6M   $�rocessing...��6Q   5      �� 5   
   -   5         ��Name$ btnOk��5      $��2��6   $��40(�6-   $
��Bold"�6;   $��Ok��6M   $��
0,124,48,0q�6Z   $y�Hidden=�6o   $��79��6�   $	��Top=�6�   $��Right=�6�   $	��112��6�   ��5      �� 5       �� EndPoint$ 0.5,1&�6&    �� 
StartPoint$ 0.5,0&�67   .��5       �  � Color$ 	#FFD5F0C6��6#    � Offset$ 0.277Q�65   � 5!      $ 	#FFA2D386��6#   $ 0.474Q�65   5"      5$      �� 5&   
   -   5        $ 	btnCancel��5&   .   $��0��6   $��2��6!   $��40(�6A   $
��Bold"�6O   $��Cancel��6a   $��
10,124,0,0q�6r   $y�Hidden=�6�   $��79��6�   $	��Top=�6�   $
��Left=�6�   $	��216��6�   ��5'      �� 5(      $ 0.5,1&�6&   $ 0.5,0&�67   .��5)      � $ 	#FFD5F0C6��6#   $ 0.277Q�65   � 5*      $ 	#FFA2D386��6#   $ 0.474Q�65   5+      5-      50      51      
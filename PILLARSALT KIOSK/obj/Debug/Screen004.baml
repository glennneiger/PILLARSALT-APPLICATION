   M S B A M L   `   `   `  ����  PILLARSALT KIOSK     PILLARSALT_KIOSK.Screen004   5   
   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   J FWpfAnimatedGif, Version=1.4.14.0, Culture=neutral, PublicKeyToken=null,gif"http://wpfanimatedgif.codeplex.com  5   	     � Title$  Start-Count��5	      $	��600��6   $
��1024��6(    � WindowStyle$
 None=�65    � 
ResizeMode$ NoResize=�6H    � Topmost .  � WindowStartupLocation$ CenterScreen=�6m    � WindowState$ 	Maximized=�6�   $��40(�6�   $
��Bold"�6�   .��5
      � -   5         �Name$ DepositCount��5
       � ColumnDefinitions 5   
   �� 5      $
��113* �6   �� 5      $
��799* �6   �� 5      $
��112* �6    � RowDefinitions 5   
   �� 5      $	��73* �6   �� 5      $
��138* �6   �� 5      $
��189* �6   �� 5      $
��116* �6   �� 5      $	��84* �6   .+�5   
   �� -   5        	 ��Name$	 btnStartCount��5      $��40(�6(   $��START-COUNT��66   $��170,75,173,0q�6L   $��1��6b   $��63��6�   $	��Top=�6�   $��1��6�   ��5      �� 5      
 �� EndPoint$
 0.5,1&�6&    �� 
StartPoint$ 0.5,0&�67   .��5      �  � Color$ 	#FFD5F0C6��6#    � Offset$ 0.277Q�65   � 5      $ 	#FFA2D386��6#   $ 0.474Q�65   5      5      �� 5   
   -   5         ��Name$ label��5      $ ��PRESS START-COUNT TO COUNT��6   $��0,3,0,13q�6D   ���	#FFECF1E3$��33.333(�6m   $��Center=�6   $��3��6�    J� Effect 5       3  -System.Windows.Media.Effects.DropShadowEffect  5!      5#      �� 5$   
   -   5         ��Name$ txtProcessing��5$      $��61��6)   $��
10,38,10,0q�65   $��2��6I    �� TextWrapping$
 Wrap=�6V   $��Wait, processing count...��6j   $	��Top=�6�   ���	#FFF50707$��1��6�   
�������$y�Hidden=�6�   �� 5%   
   -   5        $	 btnBack��5%      $��	27,7,0,13q�6"   $
��BACK��66   
���   �$��Center=�6X   $��Right=�6z   $��4��6�   $��0��5&   
   $	��212��6   $
��Left=�6&   $��0q�6A    J� RenderTransformOrigin$ 0.5,0.5&�6U   $��40(�6u   $��2��6�    5'        5(      ��5*      �� 5+       �� ImageSource$ AppImages/Back2.png��6    j� Stretch$ Uniform=�6?    j� 
AlignmentX$
 Left=�6Q   5.      �� 50   
   -   5        $��gifImg��50      "  WpfAnimatedGif.ImageBehavior   AnimatedSource$ AppImages/index.gif��6   $��282,5,282,8q�6U   $ 0.5,0.5&�6j   $��2��6�   $��1��6�   �� 51   
   -   5         ��Name$ txtProcessingAnim��51      $��	0,15,0,27q�6/   $
��Wrap=�6B   $
��Bold"�6W   ���	#FF465F32&   System.Windows.Media.TextOptions   TextHintingMode$ Animated=�6�   $��3��6�   $��Italic$�6�   $��1��52       53        54         Color$
 Gray��6#      ShadowDepth$ 6Q�60      	Direction$	 300Q�6@      
BlurRadius$ 10Q�6P   �� 55   !   $�Transaction��6%   �� 6:   $� is p��6>   �� 6M   $�rocessing...��6Q   6h   �� 56   
   -   5        $ 	txtResult��56      $��1��6%   $��56��65   $��	0,15,20,0q�6A   $��4��6T   $
 Wrap=�6a   $	��Top=�6u   $��Right=�6�   $	��551��6�   $y�Hidden=�6�   58      59      
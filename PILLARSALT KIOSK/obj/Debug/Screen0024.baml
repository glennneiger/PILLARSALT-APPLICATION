   M S B A M L   `   `   `  ����K  GPILLARSALT KIOSK, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null3clr-namespace:PILLARSALT_KIOSKPILLARSALT_KIOSK  5   	   !    PILLARSALT_KIOSK.Screen0024   5      \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   0localclr-namespace:PILLARSALT_KIOSK     5   	   J FWpfAnimatedGif, Version=1.4.14.0, Culture=neutral, PublicKeyToken=null,gif"http://wpfanimatedgif.codeplex.com  5   	   -   5          � Title$  Account Holder Details��5	      $	��600��6'   $
��1024��64   $��33.333(�6A   $
��Bold"�6S    � 
ResizeMode$ NoResize=�6e    � ShowInTaskbar .   � Topmost .  � WindowStartupLocation$ CenterScreen=�6�    � WindowState$ 	Maximized=�6�    � Cursor$ Arrow��6�    � WindowStyle$
 None=�6�   .��5
      �  � ColumnDefinitions 5   
   �� 5      $
��244* �6   �� 5      $
��537* �6   �� 5      $
��243* �6   	 � RowDefinitions	 5   
   �� 5      $	��60* �6   �� 5      $	��54* �6   �� 5      $
��184* �6   �� 5      $
��209* �6   �� 5      $	��93* �6   .+�5   
   �� -   5        
 ��Name$
 txtScreenTitle��5      $��ACCOUNT HOLDER DETAILS��6(   ���	#FFECF1E3$��40(�6`   $��Center=�6n   $��3��6�    J� Effect 5      3  -System.Windows.Media.Effects.DropShadowEffect  5      5      �� 5   
   -   5         ��Name$ gifImg��5      "  WpfAnimatedGif.ImageBehavior   AnimatedSource$ AppImages/index.gif��6    $��148,40,150,10q�6W    J� RenderTransformOrigin$ 0.5,0.5&�6n   $��1��6�   $��1��6�   $��2��6�   �� 5   
   -   5         ��Name$ txtProcessingAnim��5      $
��Wrap=�6/   $
��Bold"�6D   ���	#FF465F32&   System.Windows.Media.TextOptions   TextHintingMode$ Animated=�6m   $��3��6�   $��Italic$�6�   $��1��6�   $��	94,0,95,0q�6�    5         5!         Color$
 Gray��6#      ShadowDepth$ 6Q�60      	Direction$	 300Q�6@      
BlurRadius$ 10Q�6P   �� 5"   !   $�Wait, ...getting details��6%   6H   �� 5#   
   -   5         ��Name$ btnContinue��5#      {�.  $��	0,0,29,10q�68   $��Center=�6L   $
��left=�6n   $��4��6�   $��Right=�6�   $	��287��6�   $ 0.5,0.5&�6�   $��60��6�   $��Bottom=�6�   $��0q�6  $��CONTINUE��6   $��40(�63  $��1��6R  $��2��6b  $y�Hidden=�6v   5$        5%      ��5'      �� 5(       �� ImageSource$ AppImages/Back.png��6    j� Stretch$ Uniform=�6>    j� 
AlignmentX$ Right=�6P   5+      �� 5,   
   -   5        $ btnBack��5,      $��27,0,0,8q�6"   $
��BACK��65   
���   �$��Center=�6W   $��Right=�6y   $��4��6�   $��0��5-      $	��188��6   $
��Left=�6)   $��0q�6D   $ 0.5,0.5&�6X   $��40(�6x   $��64��6�   $��Bottom=�6�   $y�Hidden=�6�    5.        5/      ��51      �� 52      $ AppImages/Back2.png��6   $ Uniform=�6?   $
 Left=�6Q   55      57      58      
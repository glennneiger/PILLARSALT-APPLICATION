   M S B A M L   `   `   `  ����K  GPILLARSALT KIOSK, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null3clr-namespace:PILLARSALT_KIOSKPILLARSALT_KIOSK  5   	   !    PILLARSALT_KIOSK.Screen0051   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   0localclr-namespace:PILLARSALT_KIOSK     5   	   e aTelerik.Windows.Controls, Version=2016.1.112.45, Culture=neutral, PublicKeyToken=5803cfa389c90ce7?telerik1http://schemas.telerik.com/2008/xaml/presentation  5   	     � Title$  Start-Count��5	   	   $	��600��6   $
��1024��6*    � WindowStyle$
 None=�67    � 
ResizeMode$ NoResize=�6J    � Topmost .  � WindowStartupLocation$ CenterScreen=�6o    � WindowState$ 	Maximized=�6�   $��40(�6�   $
��Bold"�6�   .��5
      � -   5         �Name$ DepositorScreen��5
       � ColumnDefinitions 5   
   �� 5      $
��438* �6   �� 5      $
��101* �6   �� 5      $
��177* �6   �� 5      $
��308* �6    � RowDefinitions 5   
   �� 5      $	��72* �6   �� 5      $
��212* �6   �� 5      $
��231* �6   �� 5      $	��85* �6   .+�5   
   �� -   5        	 ��Name$	 btnBack��5      $��	10,0,0,15q�6"   $��BACK/CANCEL��65   $��Center=�6L   $��Center=�6n   $��3��6�   $��0��5      $��60��6   $��Bottom=�6    $��40(�6;   $
��Bold"�6I   $��0q�6[   $
��Left=�6�   $	��418��6�   
 J� Effect
 5      3  -System.Windows.Media.Effects.DropShadowEffect  5      ��5      �� 5       �� ImageSource$ AppImages/Back2.png��6    j� Stretch$ Uniform=�6?    j� 
AlignmentX$
 Left=�6Q   5      �� 5    
   -   5        $	 btnContinue��5       $��	0,0,10,15q�6&   $��Center=�6:   $
��left=�6\   $��3��6~   $��Right=�6�   $	��287��6�    J� RenderTransformOrigin$ 0.5,0.5&�6�   $��60��6�   $��Bottom=�6�   $��0q�6�   $��CONTINUE��6  $��40(�6!  $��3��6@  
 5!        5"      ��5$      �� 5%      $ AppImages/Back.png��6   $ Uniform=�6>   $ Right=�6P   5(      �� 5)   
   -   5         ��Name$ label��5)      $��0��6   $��
WARNING!!!��6,   $��0,1,0,6q�6A   
���  ��
�������$��40(�6v   $��Center=�6�   $��4��6�   
 5*        5+      5-      �� 5.   
   -   5         ��Name$ txtReceiver��5.      $��	10,69,6,0q�6)   $��2��6<   $
��Wrap=�6I   $	��Top=�6]   $	��152��6u   $��2��6�   �� 5/   
   -   5        $ label2��5/      $��Receiver��6    $
��Left=�63   $��	10,10,0,0q�6N   $��2��6a   $	��Top=�6n   $	��418��6�   $��54��6�   �� 50   
   -   5        $ txtTotalAmount��50      $��	0,69,10,0q�6,   $��2��6?   $
��Wrap=�6L   $	��Top=�6`   $	��152��6x   $��2��6�   $��2��6�   �� 51   
   -   5        $ label2_Copy��51      $��Amount��6%   $
��Left=�66   $��0,10,0,0q�6Q   $��2��6c   $	��Top=�6p   $	��418��6�   $��2��6�   $��2��6�   $��63��6�   �� 52   
   -	   5        $ 	textBlock��52      $M��GThe counted note(s) will be deposited into the provide account details:��6'   $��50(�6v   
���  ��$��Center=�6�   $��	10,10,0,0q�6�   $��1��6�   $
��Wrap=�6�   $	��Top=�6�   $��4��6�   $	��192��6  $
��1004��6   54      55      
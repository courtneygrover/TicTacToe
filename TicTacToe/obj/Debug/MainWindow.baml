   M S B A M L   `   `   `  ����D  @TicTacToe, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null%clr-namespace:TicTacToe	TicTacToe  5   	       TicTacToe.MainWindow   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   )localclr-namespace:TicTacToe     5   	     � Title$  
MainWindow��5   	   $	��400��6   $	��600��6)   .��5	      ]� .+�5
   
   o� -   5         o�Name$
 menu��5
      $	��Top=�6   .@�5      m� $
��Game��6   .@�5      m� -   5        $��Start��5      6*   m� 5      -   5        $��Reset��5      6*   �� 5      m� 5      -   5        $
��Exit��5      6)   5      m� 5      $��Settings��6   .@�5      m� -   5        $��	menu2Play��5      $��2 Player Mode��6,   6C   m� 5      -   5        $��menuCompPlay��5      $��Computer Mode��6/   6F   5      m� 5      $
��Help��6   .@�5      m� -   5        $��About��5      6*   m� 5      -   5        $��Rules��5      6*   5      5      � 5   
   .+�5      �� $
��Left=�6   $	��Top=�64   $��15q�6L   .+�5      �� -	   5         ��Name$ 
mainCanvas��5      $	��Top=�6-   $	��300��6E   $	��300��6Q   $
��Left=�6^   
�������6�   5      �� 5        �� Orientation$ 
Horizontal=�6   $��Right=�62   $��Center=�6N   $��20q�6i   .+�5!      	� -
   5         	�Name$ 
radio2Play��5!       	� 	GroupName$
 Mode��62   $��2 Player Mode��6C   $��	10,0,10,0q�6[   6n   	� 5"      -   5        $ radioCompPlay��5"      $
 Mode��65   $��Computer Mode��6F   $��	10,0,10,0q�6^    d� 	IsChecked$
 TrueY�6q   6�   5#      �� 5%      $ Vertical=�6   $��334,68,0,189.5q�60   .+�5&      �� $��TIC TAC TOE��6   $��20(�6.   $
��Bold"�6<   $��	50,0,49,0q�6N   �� 5'      -   5         ��Name$ winLoseLabel��5'      $��23(�6.   $
��Bold"�6<   
���  ��$��10,0,8,0q�6_   5(      �� 5*      $��Center=�6   $��Bottom=�66   $��10q�6Q   .+�5+      �� -   5         ��Name$ startBtn��5+      $��START��6+   $��	10,1,10,1q�6;   6O   5,      �� 5-      -   5        $ player1��5-      $��
Player 1 =��6%   $
��Left=�6:   $��351,243,0,0q�6U   $	��Top=�6j   �� 5.      -   5        $ player2��5.      $��
Player 2 =��6%   $
��Left=�6:   $��470,243,0,0q�6U   $	��Top=�6j   5/      50      51      
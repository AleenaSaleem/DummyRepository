   M S B A M L   `   `   `  ����C  ?Frontend, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null#clr-namespace:FrontendFrontend  5          Frontend.MainPage   5      \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      (localclr-namespace:Frontend     5      .��5
      ]� $
��True��6   .+�5   
   �� -   5          ��Name$  
leftBorder��5      
�������$��2q�69   $
��Left=�6M   
�������._�5      �� .+�5      �� -   5        $
��Menu��5      $��2q�6%   $
��Menu��61   $��20q�6@   $	��Top=�6L   $��20(�6d   6�      Frontend.MenuControl  5      -   5          Name$ MenuOptions��5   ;   $y�	Collapsed=�6$   $��10q�6P   6^   5      5      �� 5   
   -   5        $  bottomBorder��5      
�������$��2q�6;   $��Bottom=�6O   
�������._�5      �� $��Right=�6   $��Bottom=�65   $��20q�6P   .+�5      �� $��
Change ICU��6   $��18(�6.   
���   �6Q   �� 5      -   5         ��Name$ icuComboBox��5      
���   �$��30��6�   $	��100��6�   $��Center=�6�   $��Center=�6�   ��60   ��  �� Path$ 	IcuIdList�6�   5      5      �� 5   
   -   5        $  rightBorder��5      
�������$��2q�6:   $��Right=�6N   
�������._�5      �� $��Right=�6   .+�5      �� -   5         ��Name$ ViewAll��5      $��View All��6+   $��20q�6>   $	��Top=�6J   $��20(�6b   6�      Frontend.ViewAllControl  5      -   5          Name$ ViewAllOptions��5   >   $y�	Collapsed=�6'   $��10q�6V   6d   5      5      �� 5   
   -	   5        $  	topBorder��5      
�������$��2q�68   $	��Top=�6L   
�������._�5      �� $	��Top=�6   $	��100��6.    �� Orientation$ Vertical=�6<   $��Center=�6S   $��Center=�6p   .+�5      �� $ Vertical=�6   $��80 10 10 10q�64   .+�5       �� $ 
Horizontal=�6!   .+�5!      �� $��IcuId : ��6$   $��10 10 60 10q�64   $��18(�6I   
���   �$
}�True��6j   6�   �� 5"      -
   5         ��Name$ icuId��5"   "    �� 
IsReadOnly$
 True��61   $��10 10 40 10q�6�   $��16(�6�   $��70��6�   $��30��6�   ��6C   �� $ IcuId�	 �� Mode$	 OneWay=�
 �� UpdateSourceTrigger$
 PropertyChanged=�6�   �� 5#      $��	MaxBeds :��6$   $��
10 10 25 5q�65   $��18(�6I   
���   �6l   �� 5$      -   5        $ maxBeds��5$   "   $
 True��63   $��15 10 20 10q�6�   $��16(�6�   $��70��6�   $��30��6�   ��6E   �� $ MaxBeds�$	 OneWay=�$
 PropertyChanged=�6�   5%      �� 5&      $ 
Horizontal=�6!   .+�5'      �� $��PresentBeds:��6$   $��	5 10 5 5 q�68   $��18(�6K   
���   �6n   �� 5(      -   5        $ noOfBeds��5(   "   $
 True��64   $��25 10 30 10q�6�   $��16(�6�   $��70��6�   $��30��6�   ��6F   �� $ NoOfBeds�$	 OneWay=�$
 PropertyChanged=�6�   �� 5)      $��	Freebeds:��6$   $��	20 10 5 5q�65   $��18(�6H   
���   �6k   �� 5*      -   5        $ freeBeds��5*   "   $
 True��64   $��35 10 20 10q�6�   $��16(�6�   $��70��6�   $��30��6�   ��6F   �� $ FreeBeds�$	 OneWay=�$
 PropertyChanged=�6�   5+      5,      5.      5/      ]� 51   
   -   5         ]�Name$ BedDock��51      $��Center=�6%   $��Center=�6@   $��False��6]   .+�52      �� -   5         ��Name$ V1StackPanel��52      $ Vertical=�6/   $��5 0 0 0q�6F   6Y   �� 53      -   5        $ HStackPanel��53   Q   $��Bottom=�6   $��Center=�64   $ 
Horizontal=�6f   $��0q�6   6�   �� 54      -   5        $ V2StackPanel��54      $ Vertical=�60   $��0q�6G   6T   55      58      59      
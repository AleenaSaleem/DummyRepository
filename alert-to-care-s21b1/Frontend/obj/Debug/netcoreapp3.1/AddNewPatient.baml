   M S B A M L   `   `   `  ����C  ?Frontend, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null#clr-namespace:FrontendFrontend  5      ;"clr-namespace:Frontend.ValidationsFrontend.Validations  5          Frontend.AddNewPatient   5      \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      (localclr-namespace:Frontend     5      >validationrules"clr-namespace:Frontend.Validations     5      .��5
      ]� .+�5   
   �� -   5          ��Name$  
backButton��5      $
��Back��6%   $	��Top=�64   $��20q�6I   $
��Left=�6U   $��70��6�   $��20(�6�   6�   �� 5   
   $	��Top=�6   $��10q�6)   $��Center=�65   $��Add Patient��6R   $��40(�6e   $��Black"�6s   6�   �� 5   
   -   5        $  
addPatient��5      $��Bottom=�6%   $	��Top=�6=   $	��Add��6U   $��10 10 10 60q�6d   $��90��6�   $��40��6�   $��20(�6�   ��5      �� 5       �� 
TargetType" ��6   .�5      ��  �� Property � {� �� Value$ False��62    �� Triggers 5      ^� 5       ^� 
Conditions 5      �� 5   "    �� Binding 6,   ��  �� Path$ (Validation.HasError)� �� ElementName$
 name��	 �� Value		 False6m   �� 5   "    6,   �� $ (Validation.HasError)�$	 age��		 False6l   �� 5   "    6,   �� $ (Validation.HasError)�$ address��		 False6p   �� 5   "    6,   �� $ (Validation.HasError)�$ 	bedIdList��		 False6r   �� 5   "    6,   �� $ (Validation.HasError)�$ 
genderList��		 False6s   �� 5   "    6,   �� $ (Validation.HasError)�$ contact��		 False6p   .0�5      ��  � {�$
 True��6:   5      5      5       � 5"   
   $��Center=�6   $��Center=�6,   
 � RowDefinitions
 5#      �� 5$      $��60 �6    6.   �� 5%      $��60 �6    6.   �� 5&      $��60 �6    6.   �� 5'      $��60 �6    6.   �� 5(      $��60 �6    6.   �� 5)      $��60 �6    6.   �� 5*      $��60 �6    6.    � ColumnDefinitions 5,      �� 5-      $	��250 �6#   61   �� 5.      $	��300 �6#   61   +�50      �� 52      $��IcuId : ��6   $��15q�6,   $��0��68   $��0��6E   $��20(�6U   $��Center=�6c   $��Center=�6�   6�   �� 53      $��BedId : ��6   $��15q�6,   $��1��68   $��0��6E   $��20(�6U   $��Center=�6c   $��Center=�6�   6�   �� 54      $��Name : ��6   $��15q�6+   $��2��67   $��0��6D   $��20(�6T   $��Center=�6b   $��Center=�6   6�   �� 55      $��Age : ��6   $��15q�6*   $��3��66   $��0��6C   $��20(�6S   $��Center=�6a   $��Center=�6~   6�   �� 56      $��
Address : ��6   $��15q�6.   $��4��6:   $��0��6G   $��20(�6W   $��Center=�6e   $��Center=�6�   6�   �� 57      $��	Gender : ��6   $��15q�6-   $��5��69   $��0��6F   $��20(�6V   $��Center=�6d   $��Center=�6�   6�   �� 58      $��
Contact : ��6   $��15q�6.   $��6��6:   $��0��6G   $��20(�6W   $��Center=�6e   $��Center=�6�   6�   �� 59      -   5         ��Name$ 	icuIdList��59      $��5q�6.   $��0��6�   $��1��6�   $��20(�6�   $��Center=�6�   $��Center=�6  ��69   �� $ 	IcuIdList� �� Mode$ TwoWay=� �� UpdateSourceTrigger$ PropertyChanged=� �� Text 5:      �� 5;      $ IcuId�6"   $ PropertyChanged=�6/    �� ValidatesOnExceptions$
 True��6U    �� NotifyOnValidationError$
 True��6r    �� ValidationRules 5<      1   +Frontend.Validations.AddIcuFieldValidations  5=   "   ,  &System.Windows.Controls.ValidationRule   ValidatesOnTargetUpdated$
 True��6I   6k   5?      5A      �� 5B      -   5        $ 	bedIdList��5B      $��1��6.   $��1��6;   $��5q�6K   $��Center=�6}   $��Center=�6�   $��20(�6�      errorFeedbackStyle#��[  6�   ��6V   �� $ 	BedIdList� 5C      �� 5D      $ BedId�6"   $ PropertyChanged=�6/   $
 True��6U   $
 True��6r    5E        5F   "   $
 True��6I   6k   5H      5J      �� 5K      -   5         ��Name$
 name��5K      $��2��6(   $��1��65   $��5q�6E   $��Center=�6P   $��Center=�6t   $��20(�6�   #��[  6�   .��6�   ��5L      �� 5M      $
 Name�6"   $ TwoWay=�6.   $
 True��6<   $
 True��6Z   $ PropertyChanged=�6z    5N        5O   "   $
 True��6I   6k   5Q      .��5R   $   5S      �� 5T      -   5        $	 age��5T      $��3��6'   $��1��64   $��5q�6D   $��Center=�6O   $��Center=�6s   $��20(�6�   #��[  6�   .��6�   ��5U      �� 5V      $	 Age�6"   $ TwoWay=�6-   $
 True��6;   $
 True��6X   $ PropertyChanged=�6w    5W      (   "Frontend.Validations.AgeValidation  5X   "   $
 True��6@   6b   5Z      .��5[   $   5\      �� 5]      -   5        $ address��5]      $��4��6+   $��1��68   $��5q�6H   $��Center=�6S   $��Center=�6w   $��20(�6�   #��[  6�   .��6�   ��5^      �� 5_      $ Address�6"   $ TwoWay=�61   $
 True��6?   $
 True��6\   $ PropertyChanged=�6{    5`        5a   "   $
 True��6I   6k   5c      .��5d   $   5e      �� 5f      -   5        $ 
genderList��5f      $��5q�6/   $��5��6:   $��1��6G   $��20(�6W   $��Center=�6e   $��Center=�6�   .@�5g      �� .��6#   Male6)   �� 5h      .��6#   Female6+   �� 5i      .��6#   Other6*    5j      �� 5k      $ Gender�6"   $ PropertyChanged=�60   $
 True��6V   $
 True��6s    5l        5m   "   $
 True��6I   6k   5o      5q      �� 5r      -	   5        $ contact��5r      $��6��6+   $��1��68   $��5q�6H   $��Center=�6S   $��Center=�6w   $��20(�6�   #��[  6�   .��6�   ��5s      �� 5t      $ Contact�6"   $ TwoWay=�61   $
 True��6?   $
 True��6\   $ PropertyChanged=�6{    5u        5v   "   $
 True��6I   6k   5x      .��5y   $   5z      5}      5      5�      
   M S B A M L   `   `   `  ����C  ?Frontend, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null#clr-namespace:FrontendFrontend  5      ;"clr-namespace:Frontend.ValidationsFrontend.Validations  5          Frontend.AddBed   5      \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      (localclr-namespace:Frontend     5      >validationrules"clr-namespace:Frontend.Validations     5      .��5
      ]� .+�5   
   �� -   5        $	��Top=�5      $
��Back��6&   $��20(�65   $
��Left=�6C   $��10q�6^   6�   �� 5   
   $��Add Bed��6   
��� � �$��Center=�66   $	��Top=�6S   $��40(�6h   $
��Bold"�6v   $��80 100 100 150q�6�   6�   �� 5   
   $	��Top=�6   $��Center=�6*   .+�5      �� $��
Select Icu��6   $��20q�6*   $��25(�66   6F   �� 5      -   5          ��Name$  icuList��5      $	��250��6(   $��40��64   $��20(�6@      errorFeedbackStyle#��[  6s   $��Center=�6�   $��Center=�6�   ��6N   ��  �� Path$ IcuList� �� Text 5      �� 5      $ IcuId�6    �� UpdateSourceTrigger$ PropertyChanged=�6+    �� ValidatesOnExceptions$
 True��6Q    �� NotifyOnValidationError$
 True��6n    �� ValidationRules 5      1   +Frontend.Validations.AddIcuFieldValidations  5      ,  &System.Windows.Controls.ValidationRule   ValidatesOnTargetUpdated$
 True��6E   6g   5      5      �� 5      -   5        $��addBed��5      $	��Add��6#   $��20q�61   $��25(�6=   $	��100��6K   ��5      �� 5       �� 
TargetType" ��6   .�5      �� 	 �� Property	 � {�
 �� Value$
 False��66    �� Triggers 5      ^� 5       ^� 
Conditions 5   "   �� 5   &    �� Binding 60   �� $ (Validation.HasError)� �� ElementName$ icuList�� �� Value	 False6t   .0�5!   "   �� 	 � {�$

 True��6>   5"      5$      5&      5'      5(      5)      
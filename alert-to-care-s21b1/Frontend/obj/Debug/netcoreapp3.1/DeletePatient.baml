   M S B A M L   `   `   `  ����C  ?Frontend, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null#clr-namespace:FrontendFrontend  5      ;"clr-namespace:Frontend.ValidationsFrontend.Validations  5          Frontend.DeletePatient   5      \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      (localclr-namespace:Frontend     5      >validationrules"clr-namespace:Frontend.Validations     5      .��5
      ]� .+�5   
   �� -   5          ��Name$  
backButton��5      $
��Back��6%   $	��Top=�64   $
��Left=�6I   $��70��6d   $��30��6o   $��20(�6{   $��10q�6�   6�   �� 5   
   $	��Top=�6   $��Center=�6)   $��40(�6F   $��Discharge Patient��6T   $
��Bold"�6m   $��30q�6   6�   �� 5   
   $��Center=�6   $��100 150 100 100q�62   .+�5      �� $��Select PatientId: ��6   $��20(�62   $��20q�6@   6N   �� 5      -   5         ��Name$ patientIdList��5      $��20(�6Y   $��Center=�5      $��Center=�64   $��30��6O   $	��250��6[   $��Center=�6g   $��Center=�6�      errorFeedbackStyle#��[  6�   ��5   .   ��  �� Path$ PatientIdList� �� Text 5      �� 5      $ 	PatientId�6    �� UpdateSourceTrigger$ PropertyChanged=�6/    �� ValidatesOnExceptions$
 True��6U    �� NotifyOnValidationError$
 True��6r    �� ValidationRules 5      1   +Frontend.Validations.AddIcuFieldValidations  5      ,  &System.Windows.Controls.ValidationRule   ValidatesOnTargetUpdated$
 True��6E   6g   5      5      �� 5      -   5        $  deleteButton��5      $��	Discharge��6+   $��40q�6Z   $	��120��6f   $��30��6r   $��20(�6~   ��5      �� 5      	 �� 
TargetType"	 ��6   .�5      �� 
 �� Property
 � {� �� Value$ False��66    �� Triggers 5      ^� 5       ^� 
Conditions 5   "   �� 5    &    �� Binding 60   �� $ (Validation.HasError)� �� ElementName$ patientIdList�� �� Value	 False6z   .0�5#   "   �� 
 � {�$
 True��6>   5$      5&      5(      5)      5,      5-      
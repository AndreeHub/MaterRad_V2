   M S B A M L   `   `   `  ����E  AAproxiCalc, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null5clr-namespace:AproxiCalc.ModelsAproxiCalc.Models  5      =#clr-namespace:AproxiCalc.ViewModelsAproxiCalc.ViewModels  5      7 clr-namespace:AproxiCalc.HelpersAproxiCalc.Helpers  5      "    AproxiCalc.Views.ColumnsView   5      W SPresentationCore, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5      R NSystem.Xaml, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      2modelsclr-namespace:AproxiCalc.Models     5      :
viewModels#clr-namespace:AproxiCalc.ViewModels     5      _ [MaterialDesignThemes.Wpf, Version=5.1.0.0, Culture=neutral, PublicKeyToken=df2a72020bd7962aFmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes  5      .helpers clr-namespace:AproxiCalc.Helpers  5        � 	Resources  5      1   +AproxiCalc.Helpers.EnumDisplayNameConverter   EnumDisplayNameConverter��%   &	          5   
   6+   5      .��5      � $��10q�6    � RowDefinitions 5   
   �� 5      $
��Auto �6   �� 5      $��* �6   �� 5      $
��Auto �6   .+�5   
   ��  �� Orientation$ Vertical=�6   $��0��5      .+�5      � $��0,0,0,10q�6    � ColumnDefinitions 5      �� 5      $
��Auto �6'   �� 5       $��* �6'   �� 5!      $
��Auto �6'   �� 5"      $��* �6'   .+�5&      �� $��Name:��6   $��Center=�5'      $��5q�5(      �� 5)      $��1��5*      $��5q�5+      ��5)      �� *NewColumnName+ �� UpdateSourceTrigger$ PropertyChanged=�5+      �� 5.      $��Type:��6   $��Center=�5/      $��2��50      $��5q�51      �� 52      $��3��54      $��5q�55      ��52      �� *ColumnTypes+ �� SelectedItem 53      �� *NewColumnType+��56      �� 57      .R�58      �� ��6(   ��  �� 	Converter# [  59      5;      5<      � 5?       5@      �� 5A      $
��Auto �6'   �� 5C      $��* �6'   �� 5E      $
��Auto �6'   �� 5G      $
��Auto �6'   �� 5I      $��* �6'   �� 5K      $
��Auto �6'   .+�5P      �� $��
Modulus E:��6   $��Center=�5Q      $��5q�5R      $��0��5S      �� 5T      $��1��5U      $��5q�5V      ��5T      �� *NewColumnModulusE+$ PropertyChanged=�5V      �� 5W      $	��GPa��6   $��Center=�5X      $��5q�5Y      $��2��5Z      �� 5]      $��Moment of Inertia I:��6   $��Center=�5^      $��3��5_      $��5q�5`      �� 5a      $��4��5b      $��5q�5c      ��5a      �� *NewColumnMomentOfInertia+$ PropertyChanged=�5c      �� 5d      $
��m⁴��6   $��Center=�5e      $��5q�5f      $��5��5g      5h      �� 5k      $	��Add��6     MaterialDesignRaisedButton#��[ 5m      $��Right=�5n      $��5q�5o      ��5l      �� *AddColumnCommand+5o      5p      &   System.Windows.Controls.DataGrid  5s   
      AutoGenerateColumns$ False��5t         CanUserAddRows$ False��5u      $��1��5w      ��5s      �� *	Columns+ 5v      �� *SelectedColumn+	   Columns	 5x      0  *System.Windows.Controls.DataGridTextColumn  5y      ,  &System.Windows.Controls.DataGridColumn
   Header$

 Name��6%      Width5  /System.Windows.Controls.DataGridLengthConverter$ * 5{   %   1  +System.Windows.Controls.DataGridBoundColumn   Binding 5z   %   �� *Name+5{   %     5|      $

 Type��6%   $ * 5~   %    5}   %   �� *Type+5~   %     5      $
 Modulus E (GPa)��6%   $ * 5�   %    5�   %   �� *
ModulusE+5�   %     5�      $ 
 Moment of Inertia I (m⁴)��6%   $ * 5�   %    5�   %   �� *MomentOfInertia+5�   %   5�      �� 5�   
   $ 
Horizontal=�6   $��Right=�5�      $��2��5�      $��5q�5�      .+�5�      �� $��Delete��6   #��[ 5�      $��5q�5�      ��5�      �� *DeleteColumnCommand+5�      5�      5�      5�      
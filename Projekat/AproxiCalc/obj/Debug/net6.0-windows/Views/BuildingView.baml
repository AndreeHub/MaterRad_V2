   M S B A M L   `   `   `  ����E  AAproxiCalc, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null=#clr-namespace:AproxiCalc.ViewModelsAproxiCalc.ViewModels  5      #    AproxiCalc.Views.BuildingView   5      W SPresentationCore, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5      R NSystem.Xaml, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      _ [MaterialDesignThemes.Wpf, Version=5.1.0.0, Culture=neutral, PublicKeyToken=df2a72020bd7962aFmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes  5      4
viewModels#clr-namespace:AproxiCalc.ViewModels  5      .��5	      � $��10q�6     � RowDefinitions  5
   
   �� 5      $
��Auto �6   �� 5      $��* �6   �� 5      $
��Auto �6   .+�5   
   ��  �� Orientation$ Vertical=�6   $��0��5      .+�5      � $��0,0,0,10q�6    � ColumnDefinitions 5      �� 5      $
��Auto �6'   �� 5      $��* �6'   �� 5      $
��Auto �6'   �� 5      $��* �6'   .+�5      �� $��Floor Name:��6   $��Center=�5       $��5q�5!      �� 5"      $��1��5#      $��5q�5$       %  !MaterialDesignFloatingHintTextBox#��[  5%      )  #MaterialDesignThemes.Wpf.HintAssist   Hint$ 
Floor Name��5&      ��5"      �� *NewFloorName+ �� UpdateSourceTrigger$ PropertyChanged=� �� ValidatesOnDataErrors$
 True�� �� NotifyOnValidationError$
 True��5&      �� 5)      $��Floor Height:��6   $��Center=�5*      $��2��5+      $��5q�5,      �� 5-      $��3��5.      $��5q�5/      #��[  50      $ Floor Height (m)��51      ��5-      �� *NewFloorHeight+$ PropertyChanged=�$
 True��$
 True�� �� StringFormat$ F2�� �� ConverterCulture$ en-US��51      52      �� 55      $	��Add��6     MaterialDesignRaisedButton#��[ 57      $��Right=�58      $��5q�59      ��56      �� *AddFloorCommand+59      5:      &   System.Windows.Controls.DataGrid  5=   
   	   AutoGenerateColumns$	 False��5>      
   CanUserAddRows$
 False��5?      $��1��5A      ��5=      �� *Floors+ �� SelectedItem 5@      �� *SelectedFloor+   Columns 5B      0  *System.Windows.Controls.DataGridTextColumn  5C      ,  &System.Windows.Controls.DataGridColumn   Header$ 
Floor Name��6%      Width5  /System.Windows.Controls.DataGridLengthConverter$ * 5E   %   1  +System.Windows.Controls.DataGridBoundColumn   Binding 5D   %   �� *Name+5E   %     5F      $ Floor Height (m)��6%   $ * 5H   %    5G   %   �� *Height+5H   %   5J      �� 5M   
   $ 
Horizontal=�6   $��Right=�5N      $��2��5O      $��5q�5P      .+�5Q      �� $��Delete��6   #��[ 5S      $��5q�5T      ��5R      �� *DeleteFloorCommand+5T      5U      5V      5W      
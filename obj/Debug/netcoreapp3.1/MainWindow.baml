   M S B A M L   `   `   `  ����M  IGematriaCalculator, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null7 clr-namespace:GematriaCalculatorGematriaCalculator  5   	   #    GematriaCalculator.MainWindow   5   	   W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   2local clr-namespace:GematriaCalculator     5   	   -   5          �Name$  
mainWindow��5   	    � Title$ Gematria Calculator��5   	   $	��600��6%   $	��900��62    � WindowStartupLocation$ CenterScreen=�6Y    � Icon$ /gematria.ico��6~   .��5	      ]� .+�5
   
   ]� $	��Top=�6   $��25��6)   .+�5      �� $
��Left=�6    �� Orientation$ 
Horizontal=�6/   .+�5      �� .��6   	Language:6#   �� 5      -   5         ��Name$ cmbLanguage��5      $��0��60   $��0��6=   $	��150��6M   $��0q�6Y   6�   d� 5      -   5         d�Name$ 
btnReverse��5      $��0q�63    d� 	IsChecked$ FalseY�6G   $��	10,0,10,0q�6Y   .��6�   	Reverse6�   �� 5      .��6   Human Name:6%   5      �� 5      -   5         ��Name$ textName��5      $
��Auto��6(   $��Stretch=�65   	 �� CharacterCasing$	 Upper=�6}   6�   5      � 5   
   
 � ColumnDefinitions
 5      �� 5      $	��450 �6#   61   �� 5      $	��450 �6#   61   .+�5      ]� $��0��6   .+�5      �� $	��Top=�6   $ Vertical=�62   .+�5      �� $��25��6   $��Center=�6(   .��6L   Gematria Result6]   &   System.Windows.Controls.DataGrid  5      -   5          Name$ 
gridResult��5      "   VerticalScrollBarVisibility$ Hidden=�6b   $��0q�6�      HorizontalGridLinesBrush
 �����   VerticalGridLinesBrush
 �����6�   5      5      ]� 5      $��1��6   .+�5      �� $	��Top=�6   $ Vertical=�62   .+�5       �� $��25��6   $��Center=�6(   .��6L   Gematria System6]   � 5!      
 5"      �� 5#      $	��150 �6/   6=   �� 5$      $	��150 �6/   6=   �� 5%      $	��150 �6/   6=   .+�5'        -   5        $ gridSystem1��5'   #   $��0��68   $	��275��6H   $ Hidden=�6U   $��0q�6z   
 �����
 �����6�     5(      -   5        $ gridSystem2��5(   #   $��1��68   $	��275��6H   $ Hidden=�6U   $��0q�6z   
 �����
 �����6�     5)      -   5        $ gridSystem3��5)   #   $��2��68   $	��275��6H   $ Hidden=�6U   $��0q�6z   
 �����
 �����6�   5*      �� 5+      $��25��6   $��Center=�6(   .��6L   Gematria Method6]     5,      -	   5        $ 
gridMethod��5,      $��3��63   $��3��6@   $	��275��6T   $ Hidden=�6a   $��0q�6�   
 �����
 �����6�   5-      5.      5/      50      51      
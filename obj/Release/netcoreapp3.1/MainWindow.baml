   M S B A M L   `   `   `  ���� M  IGematriaCalculator, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null7 clr-namespace:GematriaCalculatorGematriaCalculator  #    GematriaCalculator.MainWindow   W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     @d2http://schemas.microsoft.com/expression/blend/2008     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     2local clr-namespace:GematriaCalculator     -     �Name$  
mainWindow�� � Title$ Gematria Calculator��$	��600��$	��900�� � WindowStartupLocation$ CenterScreen=� � Icon$ /gematria.ico��.��]� .+�]� $	��Top=�$��25��.+��� $
��Left=� �� Orientation$ 
Horizontal=�.+��� .��	Language:�� -    ��Name$ cmbLanguage��$��0��$��0��$	��150��$��0q�d� -    d�Name$ 
btnReverse��$��0q� d� 	IsChecked$ FalseY�$��	10,0,10,0q�.��	Reverse�� .��Human Name:�� -    ��Name$ textName��$
��Auto��$��Stretch=�	 �� CharacterCasing$	 Upper=�� 
 � ColumnDefinitions
 �� $	��450 ��� $	��450 �.+�]� $��0��.+��� $	��Top=�$ Vertical=�.+��� -    ��Name$ 	txtResult��$��25��$��Center=�$
��Bold"�.��Gematria Result&   System.Windows.Controls.DataGrid  -     Name$ 
gridResult��   
IsReadOnly$
 True��"   VerticalScrollBarVisibility$ Hidden=�$��0q�   HorizontalGridLinesBrush
 �����   VerticalGridLinesBrush
 �����]� $��1��.+��� $	��Top=�$ Vertical=�.+��� -   $ 	txtSystem��$��25��$��Center=�$
��Bold"�.��Gematria System� 
 �� $	��150 ��� $	��150 ��� $	��150 �.+�  -   $ gridSystem1��$��0��$	��275��$
 True��$ Hidden=�$��0q�
 �����
 �����  -	   $ gridSystem2��$��1��$	��275��$
 True��$ Hidden=�$��0q�
 �����
 �����  -
   $ gridSystem3��$��2��$	��275��$
 True��$ Hidden=�$��0q�
 �����
 ������� -   $ 	txtMethod��$��25��$��Center=�$
��Bold"�.��Gematria Method  -   $ 
gridMethod��$��3��$��3��$
 True��$	��275��$ Hidden=�$��0q�
 �����
 �����
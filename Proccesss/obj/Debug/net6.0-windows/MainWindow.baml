   M S B A M L   `   `   `  ����D  @Proccesss, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null%clr-namespace:Proccesss	Proccesss  5   	       Proccesss.MainWindow   5   	   W SPresentationCore, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   )localclr-namespace:Proccesss     5   	     � Title$  
MainWindow��5   	   $	��600��6   $
��1000��6)   .��5	      � $��0,0,0,0q�6    � ColumnDefinitions 5
   
   �� 5      �� 5      .+�5   
   &   System.Windows.Controls.DataGrid  $	��300��5      $	��Top=�5      $��5q�5         AutoGenerateColumns$ False��5         CanUserDeleteRows$ False��5       �� SelectedItem 5      �� *SelectedItem+��5      �� *Proc+   Columns 5      0  *System.Windows.Controls.DataGridTextColumn  5      ,  &System.Windows.Controls.DataGridColumn   Header$
 Name��6%   1  +System.Windows.Controls.DataGridBoundColumn   Binding 63   �� *ProcessName+  5      $ Id��6%    61   �� *Id+  5      $ Machine Name��6%    6;   �� *MachineName+5       �� 5!   
   -   5        $��Create��5!      $��Create��6   $��40��60   $��0,357,131,87q�6=   $	��100��6S   $��Right=�6_   6{   �� 5"   
   -   5        $	��End��5"      $	��End��6   $��40��6*   $	��100��67   $��0,357,10,87q�6D   $��Right=�6Z   6v   �� 5$   
   -   5        $��Textbox��5$      $��40��6"   $	��200��6.   $
��Left=�6:   $��40,357,0,87q�6U   �� 5'   
   -   5        $��blckTextbox��5'   .   $��Bottom=�6   $��1��6A   $��40��6Q   $	��200��6]   $
��Left=�6i   $��
29,0,0,137q�6�   �� 5(   
   -   5        $	��Add��5(      $	��Add��6   $��1��6,   $��40��6=   $	��100��6J   $��250,407,0,0q�6W   $	��Top=�6l   $
��Left=�6�   6�   �� 5)   
   -   5        $��Delete��5)      $��Delete��6!   $��1��62   $��40��6C   $	��100��6P   $��
0,0,35,137q�6]   $��Bottom=�6q   $��Right=�6�   6�     5-   
   $	��300��5.      $	��Top=�5/      $��1��50      $��5q�51      $ False��52      $ False��55       53      �� *SelectedItemblck+��54      �� *	BlackList+ 56        57      $
 Name��6%    64   �� 5:      5>      5?      
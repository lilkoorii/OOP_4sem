   M S B A M L   `   `   `  ����@  <Laba9, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullclr-namespace:Laba9Laba9  5   	       Laba9.ChannelWindow   5   	   W SPresentationCore, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   %localclr-namespace:Laba9     5   	     � Title$  ChannelWindow��5   	   $	��300��6   $	��600��6,   .��5	      � 
����d�.+�5
   
   &   System.Windows.Controls.DataGrid  -   5          Name$ 	DataGrid1��5
         AutoGenerateColumns$ False��6&   $
��Left=�6B   $	��175��6]   $��	41,11,0,0q�6j   $	��Top=�6}   $	��476��6�      Columns 5      0  *System.Windows.Controls.DataGridTextColumn  5      ,  &System.Windows.Controls.DataGridColumn   Header$ ID��6<      Width5  /System.Windows.Controls.DataGridLengthConverter$ 30 6H   1  +System.Windows.Controls.DataGridBoundColumn   Binding 6%   �� *Id+6H     5      $# Название канала��6?   $	 110 6X    6%   �� *Title+6X     5      $ Описание��6E   $ 70 6W    6%   �� *Description+6W     5      $ Ссылка��6>   $ 70 6N    6%   �� *Link+6N     5      $ Копирайт��6C   $ 70 6U    6%   �� *	Copyright+6U   5      �� 5   
   -   5        $	��Add��5      $
��Left=�6   $��
41,208,0,0q�6:   $	��Top=�6N   $��75��6f   6q   �� 5   
   -   5        $��Change��5      $
��Left=�6"   $��
89,241,0,0q�6=   $	��Top=�6Q   $��75��6i   6t   �� 5   
   -   5        $��Delete��5      $
��Left=�6"   $��137,208,0,0q�6=   $	��Top=�6R   $��75��6j   6u   �� 5   
   -   5        $y�	Collapsed=�5      $��Items��6(   $
��Left=�68   $��299,226,0,0q�6S   $	��Top=�6h   $��75��6�   6�   �� 5   
   -   5        $��Label1��5      $�� ��6   $
��Left=�6)   $��410,220,0,0q�6D   $	��Top=�6Y   5      5      
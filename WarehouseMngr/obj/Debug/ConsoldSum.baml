   M S B A M L   `   `   `  ����H  DWarehouseMngr, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null-clr-namespace:WarehouseMngrWarehouseMngr  5          WarehouseMngr.ConsoldSum   5      W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      -localclr-namespace:WarehouseMngr     5      $	��450��5      $	��800��6%     N� Title$  
ConsoldSum��5      .��5
      � .+�5   
   &   System.Windows.Controls.DataGrid  -   5        $��DGView��5      $��Center=�6!      AutoGenerateColumns .  $	��Top=�6Z   $	��329��6r   $	��800��6   $��0,70,0,0q�6�      Columns 5      0  *System.Windows.Controls.DataGridTextColumn  5      ,  &System.Windows.Controls.DataGridColumn   Header$ Id��6%      Width5  /System.Windows.Controls.DataGridLengthConverter$ * 63   1  +System.Windows.Controls.DataGridBoundColumn   Binding 6=   �� *ProdID+  5      $
 Name��6%   $ * 65    6?   �� *
ProdName+  5      $ Location��6%   $ * 69    6C   �� *	ProdLoc+  5      $ Price��6%   $ * 66    6@   �� *	ProdPrice+  5      $ Count��6%   $ * 66    6@   �� *	ProdCount+5      �� 5   
   -   5        $��datelbl��5      $�� ��6   $
��Left=�6*   $��	10,29,0,0q�6E   $	��Top=�6X   $	��120��6p   �� 5   
   -   5        $��namelbl��5      $A��;ООО Балашихский кирпичный склад��6   $
��Left=�6J   $��10,9,0,0q�6e   $	��Top=�6w   $	��219��6�   �� 5   
   -   5        $��sumLbl��5      $�� ��6   $
��Left=�6)   $��600,414,0,0q�6D   $	��Top=�6Y   �� 5   
   -   5        $��printclk��5   "   $��Печать��6   $
��Left=�6F   $��747,420,0,0q�6a   $	��Top=�6v   5      5      
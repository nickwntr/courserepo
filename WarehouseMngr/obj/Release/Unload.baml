   M S B A M L   `   `   `  ���� H  DWarehouseMngr, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null-clr-namespace:WarehouseMngrWarehouseMngr      WarehouseMngr.UnloadPage   W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     @d2http://schemas.microsoft.com/expression/blend/2008     -localclr-namespace:WarehouseMngr     $	��450��$	��800��  N� Title$  
UnloadPage��.��� .+�&   System.Windows.Controls.DataGrid  -   $��DGView��$��Center=�   AutoGenerateColumns .  $	��Top=�$	��261��$	��800��$��0,70,0,0q�   Columns 0  *System.Windows.Controls.DataGridTextColumn  ,  &System.Windows.Controls.DataGridColumn   Header$ Id��   Width5  /System.Windows.Controls.DataGridLengthConverter$ * 1  +System.Windows.Controls.DataGridBoundColumn   Binding �� *LoadID+  $
 Name��$ *  �� *
LoadName+  $ Count��$ *  �� *	LoadCount+  $ Price��$ *  �� *	LoadPrice+�� $��Клиент��$
��Left=�$��	10,37,0,0q�$	��Top=��� -   $��CltsCB��$
��Left=�$��	63,41,0,0q�$	��Top=�$	��120��(  "System.Windows.Controls.DatePicker  -   $��DateFrom��$
��Left=�$��
264,40,0,0q�$	��Top=��� $��С��$
��Left=�$��
242,38,0,0q�$	��Top=��� $
��По��$
��Left=�$��
369,39,0,0q�$	��Top=�  -   $��DateTo��$
��Left=�$��
400,41,0,0q�$	��Top=��� -   $��sumLbl��$�� ��$
��Left=�$��673,346,0,0q�$	��Top=�$��96���� -   $��printclk��$��Печать��$
��Left=�$��700,391,0,0q�$	��Top=��� -   $��AddGrid��$��0,336,168,0q�._�� .+��� $��Артикул��$
��Left=�$	��Top=�$��4,0,0,0q��� $��Имя��$
��Left=�$	��Top=�$��	10,32,0,0q��� $��Дата��$
��Left=�$��	10,63,0,0q�$	��Top=��� $��Клиент��$
��Left=�$��	224,0,0,0q�$	��Top=��� $��Цена��$
��Left=�$��
229,26,0,0q�$	��Top=��� $��Кол-во��$
��Left=�$��
224,58,0,0q�$	��Top=��� $��Тип��$
��Left=�$��	424,8,0,0q�$	��Top=��� -   $��UnlArt��$
��Left=�$��77,4,0,0q� �� TextWrapping$
 Wrap=�$�� ��$	��Top=�$	��120���� -	   $��UnlName��$
��Left=�$��	77,34,0,0q�$
 Wrap=�$�� ��$	��Top=�$	��120��  -
   $��UnlDate��$
��Left=�$��	77,65,0,0q�   Text$  ��$	��Top=�$	��120���� -   $��AddClnt��$
��Left=�$��	282,4,0,0q� �� Text$  ��$	��Top=�$	��120���� -   $��UnlPrice��$
��Left=�$��
282,31,0,0q�$
 Wrap=�$�� ��$	��Top=�$	��120���� -   $��UnlCount��$
��Left=�$��
282,65,0,0q�$
 Wrap=�$�� ��$	��Top=�$	��120���� -   $��AddType��$
��Left=�$��
470,10,0,0q�$  ��$	��Top=�$	��120���� -   $��UnlClk��$��Добавить��$
��Left=�$��	470,0,0,0q�$��Center=�$	��120���� $A��;ООО Балашихский кирпичный склад��$
��Left=�$��15,6,0,0q�$	��Top=�
   M S B A M L   `   `   `  ����G  CGroupProject, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null+clr-namespace:GroupProjectGroupProject  5   	       GroupProject.MainWindow   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   ,localclr-namespace:GroupProject     5   	     � Title$  
MainWindow��5   	   $	��450��6   $	��800��6)   .��5	      ]� .+�5
   
   o� -   5         o�Name$ MenuBar��5
      $	��Top=�6    .@�5      m� $��_File��6   .@�5      m� -   5        $��_Exit��5      6*   5      m� 5      $��_Tools��6   .@�5      m� -   5        $��_Search Invoices...��5      68   m� 5      -   5        $��_Browse Item List...��5      69   5      5      � 5   
   $��Bottom=�6   .+�5      �� -   5         ��Name$ InvoiceGroupBox��5      $��Invoice��60   $
��Left=�6A   $	��336��6\   $��
435,14,0,0q�6i   $	��Top=�6}   $	��347��6�   �� 5      $��Items��6   $
��Left=�6&   $	��336��6A   $��	25,14,0,0q�6N   $	��Top=�6a   $	��405��6y   .��5      �� -   5         ��Name$ 
SaveButton��5      $
��Save��6-   $
��Left=�6<   $��
10,291,0,0q�6W   $	��Top=�6k   $	��371��6�   {�.  6�   5      �� 5      -   5        $ CreateInvoiceButton��5      $��Create��62   $
��Left=�6C   $��454,261,0,0q�6^   $	��Top=�6s   $	��288��6�   6�   �� 5      -   5        $ DeleteInvoiceButton��5      $��Delete��62   $
��Left=�6C   $��630,209,0,0q�6^   $	��Top=�6s   $	��112��6�   6�   �� 5      -	   5        $ EditInvoiceButton��5      $
��Edit��60   $
��Left=�6?   $��454,209,0,0q�6Z   $	��Top=�6o   $	��112��6�   6�   �� 5      -
   5         ��Name$ InvoiceCostTextBox��5      $
��Left=�62   $��22��6M   $��622,167,0,0q�6Y    �� TextWrapping$
 Wrap=�6n   $	��Top=�6�   $	��120��6�    �� 
IsReadOnly . 6�   �� 5      -   5        $ InvoiceNumberTextBox��5      $
��Left=�64   $��22��6O   $��
622,98,0,0q�6[   $
 Wrap=�6o   $	��Top=�6�   $	��120��6�   6�   �� 5       -   5         ��Name$ InvoiceNumLabel��5       $��Invoice Number:��6-   $
��Left=�6G   $��
492,94,0,0q�6b   $	��Top=�6v   �� 5!      -   5        $ InvoiceDateLabel��5!      $��Invoice Date:��6.   $
��Left=�6F   $��492,126,0,0q�6a   $	��Top=�6v   �� 5"      -   5        $ InvoiceCostLabel��5"      $��Total Cost:��6.   $
��Left=�6D   $��492,163,0,0q�6_   $	��Top=�6t   (  "System.Windows.Controls.DatePicker  5#      -   5          Name$ InvoiceDatePicker��5#      $
��Left=�64   $��622,126,0,0q�6O   $	��Top=�6d   $	��120��6|   {�.  6�   &   System.Windows.Controls.DataGrid  5$      -   5        	  Name$	 InvoiceItemsDataGrid��5$      $
��Left=�65   $	��268��6P   $��
211,41,0,0q�6]   $	��Top=�6q   $	��205��6�   
   CanUserAddRows
 .  {�.  6�   �� 5%      -   5         ��Name$ ItemsListComboBox��5%      $
��Left=�62   $��	87,87,0,0q�6M   $	��Top=�6`   $	��113��6x   6�   �� 5&      $��Items:��6   $
��Left=�6%   $��	38,87,0,0q�6@   $	��Top=�6S   $��22��6k   $��10(�6w   �� 5'      -   5        $ ItemCostTextBox��5'      $
��Left=�6/   $��20��6J   $��
87,126,0,0q�6V   $
 Wrap=�6j   $	��Top=�6~   $	��113��6�    . 6�   �� 5(      -   5        $ ItemCostLabel��5(      $��
Item Cost:��6+   $
��Left=�6@   $��
38,126,0,0q�6[   $	��Top=�6o   $��20��6�   $��9(�6�   �� 5)      -   5        $ 	AddButton��5)      $	��Add��6(   $
��Left=�66   $��
38,163,0,0q�6Q   $	��Top=�6e   $��75��6}   {�.  6�   �� 5*      -   5        $ RemoveButton��5*      $��Remove��6+   $
��Left=�6<   $��124,163,0,0q�6W   $	��Top=�6l   $��76��6�   {�.  6�   �� 5+      -   5         ��Name$ lbItemQueue��5+      $
��Left=�6+   $	��100��6F   $��
54,209,0,0q�6S   $	��Top=�6g   $	��100��6   5-      5.      5/      
   M S B A M L   `   `   `  ����J  FEscritorioFerme, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null1clr-namespace:EscritorioFermeEscritorioFerme  5   	   )    #EscritorioFerme.AgregarProductosWpf   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   /localclr-namespace:EscritorioFerme     5   	   U QMaterialDesignThemes.Wpf, Version=3.0.1.920, Culture=neutral, PublicKeyToken=nullFmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes  5   	   $��504.927��5      $��681.249��6+     � WindowStartupLocation$  CenterScreen=�6;    � 
ResizeMode$ NoResize=�6`   
���   �
������� J� OpacityMask
 �   � � ShowInTaskbar .   � WindowStyle$
 None=�6�    J� SnapsToDevicePixels . $��3q�6�   .��5	      � -   5        
�������$��0,0,0,0q�5	   9   $
��Left=�6J   $	��675��6e   .+�5
   
   �� $	��Top=�6   .+�5      � 
���<��$��40��6(   .+�5      ��  �� Orientation$ 
Horizontal=�6   $��Right=�66   $
��10 0q�6R   .+�5      �� $��Usuario��6    $��0 10 0 0q�6/   $��15(�6A   
�������6d   �� 5      $��30��6   $��30��6(   $��0q�6a   
���������64   Z� ��6J   Z� .��5      '  !MaterialDesignThemes.Wpf.PackIcon     Kind$ Account=�62   5      5      5      5      � 5   
   $
��Left=�6   $	��369��6*   $��	10,59,0,0q�67   $	��Top=�6J   $	��627��6b   .+�5      �� -   5         ��Name$ textBox_Copy1��5      $
��Left=�6-   $��23��6H   $��
252,62,0,0q�6T   	 �� TextWrapping$
	 Wrap=�6h   $��Ingrese Nombre��6|   $	��Top=�6�   $	��135��6�   �� 5      -   5        $ textBox_Copy4��5      $
��Left=�6-   $��23��6H   $��252,286,0,0q�6T   $
	 Wrap=�6i   $��Ingrese Precio��6}   $	��Top=�6�   $	��135��6�   �� 5      -   5        
 ��Name$
 label��5      $��	Proveedor��6#   $
��Left=�67   $��	15,23,0,0q�6R   $	��Top=�6e   $	��108��6}   �� 5      -   5        $
 
label_Copy��5      $��Tipo de producto��6(   $
��Left=�6C   $��236,149,0,0q�6^   $	��Top=�6s   $	��108��6�   �� 5      -   5        $
 label_Copy1��5      $��Precio��6)   $
��Left=�6:   $��236,253,0,0q�6U   $	��Top=�6j   $	��108��6�   �� 5      -   5        $
 label_Copy2��5      $��Descripción��6)   $
��Left=�6?   $��
15,253,0,0q�6Z   $	��Top=�6n   $	��108��6�   �� 5      -   5        $
 label_Copy3��5      $��Fecha Vencimiento��6)   $��15,149,338,0q�6E   $	��Top=�6[   �� 5      -	   5        $
 label_Copy4��5      $��Nombre Producto��6)   $��236,23,227,0q�6C   $	��Top=�6Y   �� 5      -
   5         ��Name$ comboBox��5      $
��Left=�6)   $��252,173,0,0q�6D   $	��Top=�6Y   $	��135��6q   �� 5      -   5        $ textBox_Copy��5      $
��Left=�6,   $��23��6G   $��
458,62,0,0q�6S   $
	 Wrap=�6g   $��Ingrese Nombre��6{   $	��Top=�6�   $	��135��6�   �� 5      -   5        $ textBox_Copy2��5      $
��Left=�6-   $��23��6H   $��458,178,0,0q�6T   $
	 Wrap=�6i   $��Ingrese Nombre��6}   $	��Top=�6�   $	��135��6�   �� 5       -   5        $
 label_Copy5��5       $��Stock Critico��6)   $��429,149,34,0q�6A   $	��Top=�6W   �� 5!      -   5        $
 label_Copy6��5!      $��Stock��6)   $��429,23,34,0q�69   $	��Top=�6N   (  "System.Windows.Controls.DatePicker  5"      $
��Left=�6   $��
29,178,0,0q�64   $	��Top=�6H   $	��135��6`   �� 5#      -   5         ��Name$ 	textBlock��5#      $
��Left=�6+   $��
29,286,0,0q�6F   $
��Wrap=�6Z   $��Descripción del producto��6n   $	��Top=�6�   $��56��6�   $	��120��6�   �� 5$      -   5        $ comboBox_Copy��5$      $
��Left=�6.   $��	29,57,0,0q�6I   $	��Top=�6\   $	��135��6t   5%      �� 5&   
   -   5         ��Name$ button��5&      $��Agregar��6!   $
��Left=�63   $��525,433,0,0q�6N   $	��Top=�6c   $��90��6{   ���	#FF0055AA��6�   Z� 6�   �� 5'   
   -   5        $ button_Copy��5'      $��Cancelar��6&   $
��Left=�69   $��
29,433,0,0q�6T   $	��Top=�6h   $��93��6�   ���	#FFB61C1C��6�   Z� 6�   �� 5(   
   -   5        $ button_Copy1��5(      $��	Modificar��6'   $
��Left=�6;   $��380,433,0,0q�6V   $	��Top=�6k   $	��120��6�   ���	#FF4B4BFF��6�   Z� 6�   5)      5*      
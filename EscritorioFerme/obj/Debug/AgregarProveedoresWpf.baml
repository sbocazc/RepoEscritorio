   M S B A M L   `   `   `  ����J  FEscritorioFerme, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null1clr-namespace:EscritorioFermeEscritorioFerme  5   	   +    %EscritorioFerme.AgregarProveedoresWpf   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   /localclr-namespace:EscritorioFerme     5   	   U QMaterialDesignThemes.Wpf, Version=3.0.1.920, Culture=neutral, PublicKeyToken=nullFmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes  5   	   $��395.547��5      $	��600��6+     � WindowStartupLocation$  CenterScreen=�67    � 
ResizeMode$ NoResize=�6\   
���   �
������� J� OpacityMask
 �   � � ShowInTaskbar .   � WindowStyle$
 None=�6�    J� SnapsToDevicePixels . $��3q�6�   .��5	      � -   5        
�������$��0,0,0,4q�5	   9   .+�5
   
   �� $	��Top=�6   .+�5      � 
���<��$��40��6(   .+�5      ��  �� Orientation$ 
Horizontal=�6   $��Right=�66   $
��10 0q�6R   .+�5      �� $��Usuario��6    $��0 10 0 0q�6/   $��15(�6A   
�������6d   �� 5      $��30��6   $��30��6(   $��0q�6a   
���������64   Z� ��6J   Z� .��5      '  !MaterialDesignThemes.Wpf.PackIcon     Kind$ Account=�62   5      5      5      5      � 5   
   $
��Left=�6   $	��229��6*   $��	82,59,0,0q�67   $	��Top=�6J   $	��438��6b   .+�5      �� -   5         ��Name$ textBox��5      $
��Left=�6'   $��23��6B   $��	29,62,0,0q�6N   	 �� TextWrapping$
	 Wrap=�6a   $��Ingrese Rut��6u   $	��Top=�6�   $	��120��6�   �� 5      -   5        $ textBox_Copy1��5      $
��Left=�6-   $��23��6H   $��
265,62,0,0q�6T   $
	 Wrap=�6h   $��Ingrese Fono��6|   $	��Top=�6�   $	��135��6�   �� 5      -   5        $ textBox_Copy3��5      $
��Left=�6-   $��23��6H   $��
29,178,0,0q�6T   $
	 Wrap=�6h   $��Ingrese Rubro��6|   $	��Top=�6�   $	��120��6�   �� 5      -   5        
 ��Name$
 label��5      $��Rut Proveedor��6#   $
��Left=�6;   $��	15,23,0,0q�6V   $	��Top=�6i   $	��108��6�   �� 5      -   5        $
 label_Copy3��5      $��Rubro��6)   $��15,149,338,0q�69   $	��Top=�6O   �� 5      -   5        $
 label_Copy4��5      $
��Fono��6)   $��252,23,51,0q�68   $	��Top=�6M   5      �� 5   
   -   5         ��Name$ button��5      $��Agregar��6!   $
��Left=�63   $��430,316,0,0q�6N   $	��Top=�6c   $��90��6{   ���	#FF0055AA��6�   Z� 6�   �� 5   
   -	   5        $ button_Copy��5      $��Cancelar��6&   $
��Left=�69   $��
82,316,0,0q�6T   $	��Top=�6h   $��93��6�   ���	#FFB61C1C��6�   Z� 6�   �� 5   
   -
   5        $ button_Copy1��5      $��	Modificar��6'   $
��Left=�6;   $��309,316,0,0q�6V   $	��Top=�6k   $	��101��6�   ���	#FF4B4BFF��6�   Z� 6�   5      5       
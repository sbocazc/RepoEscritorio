   M S B A M L   `   `   `  ����J  FEscritorioFerme, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null1clr-namespace:EscritorioFermeEscritorioFerme  5   	   $    EscritorioFerme.OrdenCompraWpf   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   /localclr-namespace:EscritorioFerme     5   	   U QMaterialDesignThemes.Wpf, Version=3.0.1.920, Culture=neutral, PublicKeyToken=nullFmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes  5   	   $��424.453��5      $��590.147��6+     � WindowStartupLocation$  CenterScreen=�6;    � 
ResizeMode$ NoResize=�6`   
���   �
������� J� OpacityMask
 �   � � ShowInTaskbar .   � WindowStyle$
 None=�6�    J� SnapsToDevicePixels . $��3q�6�   .��5	      � -   5        
�������$��2,0,0,1q�5	   9    J� RenderTransformOrigin$ 0.5,0.5&�6J   z�5
   
   V� 5      .~�5      �� �� 5      �� 5       �� Angle$ 0.027Q�6"   T� 5      5      .+�5   
   �� $	��Top=�6   .+�5      � 
���<��$��40��6(   .+�5      ��  �� Orientation$ 
Horizontal=�6   $��Right=�66   $
��10 0q�6R   .+�5      �� $��Usuario��6    $��0 10 0 0q�6/   $��15(�6A   
�������6d   �� 5      $��30��6   $��30��6(   $��0q�6a   
���������64   Z� ��6J   Z� .��5      '  !MaterialDesignThemes.Wpf.PackIcon  	   Kind$	 Account=�62   5      5      5      5      � 5   
   $
��Left=�6   $	��270��6*   $��	66,59,0,0q�67   $	��Top=�6J   $	��451��6b   .+�5      �� -   5        
 ��Name$
 textBox_Copy��5      $
��Left=�6,   $��23��6G   $��
29,205,0,0q�6S    �� TextWrapping$
 Wrap=�6g   $!��Ingrese nombre del producto��6{   $	��Top=�6�   $	��161��6�   �� 5      -   5        $
 textBox_Copy4��5      $
��Left=�6-   $��23��6H   $��265,205,0,0q�6T   $
 Wrap=�6i   $��Cantidad��6}   $	��Top=�6�   $	��135��6�   �� 5      -   5         ��Name$ label��5      $��	Proveedor��6#   $
��Left=�67   $��	15,23,0,0q�6R   $	��Top=�6e   $	��108��6}   �� 5       -   5        $ label_Copy1��5       $��Cantidad del producto��6)   $
��Left=�6I   $��252,156,0,0q�6d   $	��Top=�6y   $	��133��6�   �� 5!      -   5        $ label_Copy2��5!      $��Nombre Producto��6)   $
��Left=�6C   $��
15,156,0,0q�6^   $	��Top=�6r   $	��108��6�   �� 5"      -   5        $ label_Copy4��5"      $��Empleado Solicitante��6)   $��252,23,51,0q�6H   $	��Top=�6]   �� 5#      -   5         ��Name$ comboBox_Copy��5#      $
��Left=�6.   $��
265,52,0,0q�6I   $	��Top=�6]   $	��135��6u   �� 5$      -	   5        $ comboBox_Copy1��5$      $
��Left=�6/   $��	29,52,0,0q�6J   $	��Top=�6]   $	��135��6u   5%      �� 5&   
   -
   5         ��Name$ button��5&      $��Enviar��6!   $
��Left=�62   $��427,334,0,0q�6M   $	��Top=�6b   $��90��6z   ���	#FF0055AA��6�   Z� 6�   �� 5'   
   -   5        $ button_Copy��5'      $��Cancelar��6&   $
��Left=�69   $��
66,334,0,0q�6T   $	��Top=�6h   $��93��6�   ���	#FFB61C1C��6�   Z� 6�   5(      5)      
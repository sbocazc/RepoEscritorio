   M S B A M L   `   `   `  ����J  FEscritorioFerme, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null1clr-namespace:EscritorioFermeEscritorioFerme  5   	        EscritorioFerme.MainWindow   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   /localclr-namespace:EscritorioFerme     5   	   U QMaterialDesignThemes.Wpf, Version=3.0.1.920, Culture=neutral, PublicKeyToken=nullFmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes  5   	   $	��700��5      $
��1240��6'     � WindowStartupLocation$  CenterScreen=�64    � 
ResizeMode$ NoResize=�6Y    � ShowInTaskbar .   � WindowStyle$
 None=�6�   .��5	      � -   5        
�������.+�5
   
   �� $	��Top=�6   ���	#FF191919.+�5      � 
���<��$��10��6(   5      � 5      $��5q�6   .+�5      ��  �� Orientation$ 
Horizontal=�6   $��Right=�66   $
��10 0q�6R   .+�5      �� $��Usuario��6   $��0 5 0 0q�6+   $��15(�6<   
�������6c   �� 5      $��30��6   $��30��6$   $��0q�6]   
���������60   Z� ��6F   Z� .��5      '  !MaterialDesignThemes.Wpf.PackIcon     Kind$ Account=�6.   5      �� 5      -   5         ��Name$ btnShut��5      $��30��6*   $��30��65   $��0q�6n   
�������$	��Top=�6�   ��6A   Z� ��6W   Z� .��5        $ Power=�6.   5      5      5      5      � 5   
   $��
250 55 0 0q�6   .+�5      � -   5         �Name$ GridPrincipal��5      $��Center=�6*   $��Center=�6G   5      5      � 5   
   $	��250��6   $
��Left=�6   
���<��.+�5       ?  9MaterialDesignThemes.Wpf.Transitions.TransitioningContent  -   5          Name$ TransitionSlide��5    2   C  =MaterialDesignThemes.Wpf.Transitions.TransitioningContentBase	   OpeningEffect	 6K   D  >MaterialDesignThemes.Wpf.Transitions.TransitionEffectExtension  *SlideInFromLeft+
   Duration$
 0:0:0.2X�.��5!      � -   5        $ 
GridCursor��5!      $��	0 150 0 0q�6'   $��10��6:   $
��Left=�6E   $��60��6`   ���	#FF8D001C$	��Top=�6�   6�   5"      �� 5#      -   5         ��Name$ ListViewMenu��5#      $��0 150q�6-   
�������$��Champagne & Limousines)�6P   .@�5$      �� $��60��6   .��5%      �� $ 
Horizontal=�6!   .+�5&        $
 Home=�62   $��30��6>   $��30��6I   $��Center=�6U   $��5q�6p   6}   �� 5'      $��Inicio��6$   $��18(�62   $��Center=�6@   $
��20 0q�6[   6k   5(      5)      �� 5*      $��60��6   .��5+      �� $ 
Horizontal=�6!   .+�5,        $ UserAdd=�62   $��30��6A   $��30��6L   $��Center=�6X   $��5q�6s   6�   �� 5-      $��Colaboradores��6$   $��18(�69   $��Center=�6G   $
��20 0q�6b   6r   5.      5/      �� 50      $��60��6   .��51      �� $ 
Horizontal=�6!   .+�52        $ Truck=�62   $��30��6?   $��30��6J   $��Center=�6V   $��5q�6q   6~   �� 53      $��Proovedores��6$   $��18(�67   $��Center=�6E   $
��20 0q�6`   6p   54      55      �� 56      $��60��6   .��57      �� $ 
Horizontal=�6!   .+�58        $ Person=�62   $��30��6@   $��30��6K   $��Center=�6W   $��5q�6r   6   �� 59      $��Clientes��6$   $��18(�64   $��Center=�6B   $
��20 0q�6]   6m   5:      5;      �� 5<      $��60��6   .��5=      �� $ 
Horizontal=�6!   .+�5>        $ Email=�62   $��30��6?   $��30��6J   $��Center=�6V   $��5q�6q   6~   �� 5?      $��Orden de Compra��6$   $��18(�6;   $��Center=�6I   $
��20 0q�6d   6t   5@      5A      �� 5B      $��60��6   .��5C      �� $ 
Horizontal=�6!   .+�5D        $ Toolbox=�62   $��30��6A   $��30��6L   $��Center=�6X   $��5q�6s   6�   �� 5E      $��	Productos��6$   $��18(�65   $��Center=�6C   $
��20 0q�6^   6n   5F      5G      5H      5I      5J      5K      
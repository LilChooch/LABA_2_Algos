   M S B A M L   `   `   `  ����B  >WpfApp5, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null!clr-namespace:WpfApp5WpfApp5  5          WpfApp5.Page2   5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      'localclr-namespace:WpfApp5     5      b ^MaterialDesignThemes.Wpf, Version=3.2.0.1979, Culture=neutral, PublicKeyToken=df2a72020bd7962aFmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes  5        N� Title$  Page3��5
      .��5      �  � RowDefinitions 5   
   �� 5      $
��Auto �6   �� 5      $��* �6   .+�5   
   � $��2��6   $��2��6   $��6��63   ���#FFD4736D   � 5   
   $��2��6   $��0��6#   $��6��63   ���#FFD4736E   �� 5   
   -   5        ���#FFD473$��3��5   ;   $	��Top=�6K   $��Right=�6d   $��
10 5 22 10q�6�   $��80��6�   $��70��6�   $��45��6�   .��5      '  !MaterialDesignThemes.Wpf.PackIcon     Kind$
 Home=�6&   
�������$��25��6D   $��42��6P   $��Center=�6[   $��Center=�6x   6�   5      �� 5   
   $��0��6    �� Orientation$ Vertical=�6"   $��10q�69   .+�5      �� $ 
Horizontal=�6   $	��0,5q�62   .+�5      �� $��Размер сетки:��6   $	��100��60   $��Center=�6<   �� 5      -   5         ��Name$ 
SizeSlider��5       � Minimum$	 100Q�6-    � Maximum$
 1000Q�6;    � Value$	 400Q�6J   $	��200��6V   $��Center=�6b    �� IsSnapToTickEnabled . 	 �� TickFrequency$	 1Q�6�   �� 5      -   5        
 ��Name$
 SizeTextBox��5      $
��Auto��6/   $��10 -80 100 -60q�6<   $��Center=�6T   ��6p   ��  �� ElementName$ 
SizeSlider�� �� Path$ Value� �� UpdateSourceTrigger$ PropertyChanged=� �� StringFormat$ F0��5      �� 5      $ 
Horizontal=�6   $	��0,5q�62   .+�5      �� $2��,Масштабный коэффициент:��6   $
��Auto��6:   $��Center=�6G   �� 5       -   5        $ ScaleFactorSlider��5       $��10 0 0 0q�64   $ 1Q�6F   $ 10Q�6R   $ 2Q�6_   $	��200��6i   $��Center=�6u    . $	 1Q�6�   �� 5!      -   5        $
 ScaleFactorTextBox��5!      $
��Auto��66   $��10 -80 100 -60q�6C   $��Center=�6[   ��6v   �� $ ScaleFactorSlider��$ Value�$ PropertyChanged=�$ F0��5"      �� 5#      $ 
Horizontal=�6   $	��0,5q�62   .+�5$      �� $&�� Количество песка:��6   $
��Auto��64   $��Center=�6A   �� 5%      -   5        $ SandAmountSlider��5%      $��10 0 0 0q�63   $	 100Q�6E   $
 5000Q�6S   $
 1000Q�6b   $	��200��6o   $��Center=�6{    . $	 1Q�6�   �� 5&      -   5        $
 SandAmountTextBox��5&      $
��Auto��65   $��10 -80 100 -60q�6B   $��Center=�6Z   ��6u   �� $ SandAmountSlider��$ Value�$ PropertyChanged=�$ F0��5'      �� 5(      $ 
Horizontal=�6   $
��0,10q�62   .+�5)      �� -   5         ��Name$ StartButton��5)      $��
Старт��6.   $	��100��6>   6J   �� 5*      -	   5        $ 
StopButton��5*      $��Стоп��6-   $	��100��6<   6H   �� 5+      -
   5        $ ContinueButton��5+      $��Продолжить��61   $
��Auto��6F   6S   5,      �� 5-      -   5         ��Name$ TimerTextBlock��5-      $
��0,10q�60   $'��!Время работы: 00:00:00��6>   5.      �� 51   
   -   5         ��Name$ SandpileImage��51      $��1��6'   $��Uniform=�64    � 52   
   -   5          �Name$ MyFRame2��52      $��5��6"   $��5��66   53      59      
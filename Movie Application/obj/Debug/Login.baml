   M S B A M L   `   `   `  ����L  HMovie Application, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null5clr-namespace:Movie_ApplicationMovie_Application  5   	       Movie_Application.Login   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   b ^MaterialDesignThemes.Wpf, Version=4.1.0.2556, Culture=neutral, PublicKeyToken=df2a72020bd7962aFmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes  5   	   :d2http://schemas.microsoft.com/expression/blend/2008  5   	   Dmc;http://schemas.openxmlformats.org/markup-compatibility/2006  5   	   +localclr-namespace:Movie_Application  5   	     � Title$  Login��5	   	   $	��400��6   $	��350��6$    � WindowStartupLocation$ CenterScreen=�60    � 
ResizeMode$ NoResize=�6U   ���	#FF051525$��14(�6�    � WindowStyle$
 None=�6�   
�������$��2q�5
   !   .��5      � .+�5   
   �� -   5        $��0 3 3 0q�5      $��18��6"   $��18��6.   $	��Top=�69   $��Right=�6Q   $��0q�6�   ���	#FF151515$��0q�6�   .��5      �� $��0q�6   $
��Fill=�6    $��/AppImages/exit2.png��6/   5      �� 5   
   -   5        $��0 3 25 0q�5      $��18��6#   $��18��6/   $	��Top=�6:   $��Right=�6R   $��0q�6�   ���	#FF151515$��0q�6�   .��5      �� $��/AppImages/minimize.png��6   $��0q�65   $
��Fill=�6@   5      �� 5   
   ���	#FF151515 �� CornerRadius$ 30��6(   $��20q�6:   $��2q�6F   
�������._�5      �� $��20q�6   .+�5      �� $��Login��6   $��Center=�6(   $��29(�6E   
�������6S   �� 5      
�������6   �� 5      $��	Username:��6   
�������$��0 4 4 4q�6C   �� 5      -   5        $��
tbUsername��5      $��25��6,   ���	#FF051525$��2q�6O   
�������
�������6{   �� 5      $��	Password:��6   
�������$��0 4 4 4q�6C   G� 5      -   5        $��
pbPassword��5      $��25��60   ���	#FF051525$��2q�6S   
�������
�������6   �� 5      -   5        $��btnLogin��5      $��30��6C   $��
60 20 60 0q�6O   ���	#FF003A03$��2q�6z   
�������
�������.��5      ��  �� Orientation$ 
Horizontal=�6!   .+�5      '  !MaterialDesignThemes.Wpf.PackIcon     Kind$ login=�62   $��25��6?   $��25��6J   $��0 0 5 0q�6V   �� 5      $��Login��6$   
�������$��Center=�6H   5      5      �� 5       $��OR��6   $��15(�6%   
�������$��Center=�6J   �� 5!      -   5        $��btnRegister��5!      $��30��6C   $
��60 0q�6O   ���	#FF510000$��2q�6t   
�������
�������.��5"      �� $ 
Horizontal=�6!   .+�5#        $ Register=�62   $��25��6B   $��25��6M   $��0 0 5 0q�6Y   �� 5$      $��Register��6$   
�������$��Center=�6K   5%      5&      5'      5(      5)      5*      
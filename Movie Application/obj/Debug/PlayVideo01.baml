   M S B A M L   `   `   `  ����p  lSystem.Windows.Controls.Input.Toolkit, Version=3.5.40128.1, Culture=neutral, PublicKeyToken=31bf3856ad364e35pTclr-namespace:System.Windows.Controls;assembly=System.Windows.Controls.Input.ToolkitSystem.Windows.Controls  5   	   L HMovie Application, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null5clr-namespace:Movie_ApplicationMovie_Application 5   	   #   Movie_Application.PlayVideo01   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   xSystem_Windows_ControlsTclr-namespace:System.Windows.Controls;assembly=System.Windows.Controls.Input.Toolkit     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   1localclr-namespace:Movie_Application     5   	   b ^MaterialDesignThemes.Wpf, Version=4.1.0.2556, Culture=neutral, PublicKeyToken=df2a72020bd7962aFmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes  5   	     � Title$  	PlayVideo��5
      $
��50 0q�6    � WindowStyle$
 None=�6)   ���	#FF151515 � WindowStartupLocation$ CenterScreen=�6S    � 
ResizeMode$ NoResize=�6x   .��5      � .+�5   
   �� -   5        $��0 0 3 0q�5      $��25��6"   $��25��6.   $	��Top=�69   $��Right=�6Q   $��0q�6�   ���	#FF151515$��0q�6�   .��5      �� $��0q�6   $
��Fill=�6    $��/AppImages/exit2.png��6/   5      �� 5   
   -   5        $��0 0 30 0q�5      $��25��6#   $��25��6/   $	��Top=�6:   $��Right=�6R   $��0q�6�   ���	#FF151515$��0q�6�   .��5      �� $��/AppImages/minimize.png��6   $��0q�65   $
��Fill=�6@   5      �� 5   
   -   5         ��Name$ brMovie��5      $��20 28 20 100q�6"   $��3q�68   
�������._�5      � -   5         �Name$ gridPlayVideo��5      $��0q�6*   .+�5      r� -   5         r�Name$ VideoControl��5       r� Volume$	 100Q�65    r� Source$^ XC:\Users\DELL\source\repos\Movie Application\Movie Application\AppVideos/High Strung.wmv?�6C   	 r� UnloadedBehavior$	 Manual=�6�   
 r� LoadedBehavior$
 Manual=�6�    r� Stretch$
 Fill=�6�   �� 5      -   5         ��Name$ btnPlay��5      $��25��6*   $��25��66   $
��Left=�6A   $��Bottom=�6\   
�������.��5      �� $��/AppImages/VideoPlay.png��6   5      �� 5      -   5        $ btnPause��5      $��25��6+   $��25��67   $
��Left=�6B   $��Bottom=�6]   
�������{�.  $��30 0 0 0q�6�   .��5      �� $��/AppImages/VideoPause.png��6   5      �� 5      -   5        $ btnStop��5      $��25��6*   $��25��66   $
��Left=�6A   $��Bottom=�6\   
�������{�.  $��60 0 0 0q�6�   .��5      �� $��/AppImages/VideoStop.png��6   5      5      5      � 5    
   $��Bottom=�6   $��	20 0 20 7q�6*   $��85��6=    � ColumnDefinitions 5!      �� 5"      $��2* �6#   �� 5#      $��* �6#   .+�5%      �� $��0��6   .+�5&      ��  �� Orientation$ 
Horizontal=�6   $��Center=�66   .+�5'      �� $��Movie Name:��6    
�������$��30(�6J   $��Center=�6X   �� 5(      -	   5        $��tbMovieName��5(       $�� ��63   
�������$��30(�6R   $��Center=�6`   5)      �� 5*      $	��Top=�6   � 5+      $��Bottom=�6   $��	10 10 0 0q�62    5,      �� 5-      $��* �6+   �� 5.      $��* �6+   �� 5/      $��* �6+   �� 50      $��* �6+   .+�52      �� $��0��6!   $ 
Horizontal=�61   .+�53      �� $��Data Relased:��6$   
�������$��15(�6P   �� 54      -
   5        $��tbDataRelased��54   $   $�� ��69   
�������$��15(�6X   $��7 0 0 0q�6f   55      �� 56      $��1��6!   $ 
Horizontal=�61   .+�57      �� $��Genre:��6$   
�������$��15(�6I   �� 58      -   5        $��tbGenre��58   $   $�� ��63   
�������$��15(�6R   $��7 0 0 0q�6`   59      �� 5:      $��2��6!   $ 
Horizontal=�61   .+�5;      �� $��Actor:��6$   
�������$��15(�6I   �� 5<      -   5        $��tbActor��5<   $   $�� ��63   
�������$��15(�6R   $��7 0 0 0q�6`   5=      �� 5>      $��3��6!   $ 
Horizontal=�61   .+�5?      �� $��	Director:��6$   
�������$��15(�6L   �� 5@      -   5        $��
tbDirector��5@   $   $�� ��66   
�������$��15(�6U   $��7 0 0 0q�6c   5A      5B      5C      �� 5D      $��1��6   $ 
Horizontal=�6)   $��Center=�6B   $	��Top=�6_   .+�5E      �� $��Movie Rating:��6   
�������$��30(�6H   $��Center=�6V   �� 5F      -   5        $��tbMovieRating��5F      $	��-.-��61   
��� ���$��30(�6Q   $��Center=�6_   $��30 0 0 0q�6|   $��Segoe UI Black)�6�   5G      �� 5H      $��1��6   $ 
Horizontal=�6)   $��Center=�6B   $��Bottom=�6_   $��0 0 0 5q�6z   .+�5I      �� -   5        $��tbRatedMovie��5I      $��Rate the movie��60   
�������$��20(�6]   $��Center=�6k   �� 5J      -   5        $��cbRatedMovie��5J      $��5 0 0 0q�6/   $��66��6@   $��20��6K   .@�5K      �� .��6#   106'   �� 5L      .��6#   96&   �� 5M      .��6#   86&   �� 5N      .��6#   76&   �� 5O      .��6#   66&   �� 5P      .��6#   56&   �� 5Q      .��6#   46&   �� 5R      .��6#   36&   �� 5S      .��6#   26&   �� 5T      .��6#   16&   �� 5U       �� 
IsSelected . {�.  .��6G   	1 to 106P   5V      �� 5W      -   5        $��confirmRate��5W      $��OK��6,   
���   �$��3 1 3 1q�6f   $��Center=�6x   $��5 0 0 0q�6�   $y�	Collapsed=�6�   5X      5Y      �� 5Z   
   -   5        $��
tbUsername��5Z       �� Padding$	 5 0q�6&   
�������$
��Left=�6K   $��20,9,0,0q�6f   $
��Wrap=�6x   $	��Top=�6�   5[      5\      
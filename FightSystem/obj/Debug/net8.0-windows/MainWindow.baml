   M S B A M L   `   `   `  ����  FightSystem    FightSystem.MainWindow   5   	   W SPresentationCore, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	     � Title$  RPG Harc - Harcrendszer��5   	   $	��600��6)   $	��800��66   .��5      � 
���OO/� � RowDefinitions 5   
   �� 5      $
��Auto �6   �� 5      $��* �6   �� 5	      $
��Auto �6   .+�5   
   ��  �� Orientation$ 
Horizontal=�6   $��Center=�6.   $��10q�6K   .+�5      �� $��20q�6   .+�5      �� $��	Játékos��6   $��24(�6+   
������� �� TextAlignment$ Center=�6L   �� 5      -   5         ��Name$ PlayerNameText��5      $��18(�64   
�������$��Név: ��6U   �� 5      -   5        $ PlayerHealthText��5      $��18(�66   
�������$��Életerő: ��6W   �� 5      -   5        $ PlayerStatsText��5      $��14(�65   
�������$��Statisztikák: ��6V   5      �� 5      $��20q�6   .+�5      �� $��	Ellenfél��6   $��24(�6,   
�������$ Center=�6M   �� 5      -   5        $ EnemyNameText��5      $��18(�63   
�������$��Név: ��6T   �� 5      -   5        $ EnemyHealthText��5      $��18(�65   
�������$��Életerő: ��6V   �� 5      -   5        $ EnemyStatsText��5      $��14(�64   
�������$��Statisztikák: ��6U   5      5      �� 5   
   -   5         ��Name$ CombatLogTextBox��5      $��1��6,   $��10q�69   
���   �
��� � �$��Consolas)�5      $��14(�6(    �� 
IsReadOnly$
 True��66   " �� VerticalScrollBarVisibility$
 Auto=�6H    �� TextWrapping$
 Wrap=�6k   �� 5    
   -   5        	 ��Name$	 NextRoundButton��5       $��2��6*   $��Következő Kör��67   $��20(�6O   $��10q�5!      $��10q�6   6*   5"      5#      
   M S B A M L   `   `   `  ����   FightSystem    FightSystem.MainWindow   W SPresentationCore, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     R NSystem.Xaml, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml       � Title$  RPG Harc��$	��600��$	��800��.��� 
���OO/� � RowDefinitions �� $
��Auto ��� $��* ��� $
��Auto �.+���  �� Orientation$ 
Horizontal=�$��Center=�$��10q�.+��� $��20q�.+��� $��	Játékos��$��24(�
������� �� TextAlignment$ Center=��� -    ��Name$ PlayerNameText��$��18(�
�������$��Név: ���� -   $ PlayerHealthText��$��18(�
�������$��Életerő: ���� -   $ PlayerStatsText��$��14(�
�������$��Statisztikák: ���� $��20q�.+��� $��	Ellenfél��$��24(�
�������$ Center=��� -   $ EnemyNameText��$��18(�
�������$��Név: ���� -   $ EnemyHealthText��$��18(�
�������$��Életerő: ���� -   $ EnemyStatsText��$��14(�
�������$��Statisztikák: ���� -    ��Name$ CombatLogTextBox��$��1��$��10q�
���   �
��� � �$��Consolas)�$��14(� �� 
IsReadOnly$
 True��" �� VerticalScrollBarVisibility$
 Auto=� �� TextWrapping$
 Wrap=��� -   	 ��Name$	 NextRoundButton��$��2��$��Következő Kör��$��20(�$��10q�$��10q�
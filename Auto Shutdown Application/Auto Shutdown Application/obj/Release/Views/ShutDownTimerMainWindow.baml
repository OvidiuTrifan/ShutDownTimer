   M S B A M L   `   `   `  ���� T  PAuto Shutdown Application, Version=1.0.0.1, Culture=neutral, PublicKeyToken=nullW0clr-namespace:AutoShutdownApplication.Properties"AutoShutdownApplication.Properties  c6clr-namespace:AutoShutdownApplication.Views.Converters(AutoShutdownApplication.Views.Converters  ;    5AutoShutdownApplication.Views.ShutDownTimerMainWindow   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     Aresx0clr-namespace:AutoShutdownApplication.Properties     Fcnv6clr-namespace:AutoShutdownApplication.Views.Converters     -     �Name$  MainWindowPanel��4   .AutoShutdownApplication.Properties.UIResources   ID_TITLE � Title# Z  � Icon$&  ../Resources/Images/shutdown.png��$��90��$	��363�� � 
ResizeMode$ NoResize=�
�����_� � 	Resources    ReadOnlyTextBoxStyle �� 
TargetType �� Property �� Value	   ID_TIME_SEPARATOR
 �� Triggers �� Binding �� ElementName �� Path �� Value  TextBoxStyle  ButtonStyle   ID_START   ID_STOPC  =AutoShutdownApplication.Views.Converters.InvertValueConverter  InvertValueConverter��%  &	        &	 �    &	 j    &	 �    �� " ��.���  � ��$ 15(���  � ��$
 Bold"���  � ��
 ���� ��  � ��$ 0q���  � ��$ 10����  � ��$ 20����  �@��
IsReadOnly . ��  � ��$ Center=���  � ��# Z	 
 ��  �� $ MainWindowPanel��$ IsActive� True.a���  � ��
 �  ����  �� $ MainWindowPanel��$ IsActive�	 False.a���  � ��
 � � ��� " ��.���  � ��$ 15(���  � ��$
 Bold"���  � ��$ Center=���  � ��$ Center=���  � ��$ Center=���  �@��	MaxLength$ 2����  � ��$ 25����  � ��$ 20��
 ��  �� $ MainWindowPanel��$ IsActive� True.a���  � ��
 �  ����  �@��
IsReadOnly . ��  � ��
 ���� ��  � ��
 ���� ��  �� $ MainWindowPanel��$ IsActive�	 False.a���  � ��
 � � ��� " ��.���  � ��$ 10(���  � ��$
 Bold"���  � ��$	 100����  � ��$ 20����  � ��$ Center=���  � ��# Z 
 ��  �� $ MainWindowPanel��$ IsActive� True.a���  � ��
 �  ����  � ��# Z ��  �� $ MainWindowPanel��$ IsActive�	 False.a���  � ��
 � � ���  � ��# Z   .���  � RowDefinitions �� $��5 ��� $
��Auto ��� $��5 ��� $
��Auto � � ColumnDefinitions �� $
��Auto ��� $��* �.+�� $��1��$��0��$��2�� �� $
��Auto � �� $��5 ��� $
��Auto ��� $��10 ��� $
��Auto ��� $
��Auto ��� $
��Auto ��� $
��Auto ��� $
��Auto ��� $��10 ��� $
��Auto �.+��� -   $��0��$��1��$��20��$	��120��$��Bottom=�$��Center=�$��Center=�$��10(�$
��Bold"� �� SelectedValue �� *Action+ �� Mode$ TwoWay=�{��� $ MainWindowPanel��$ IsActive� �� 	Converter# [ �� $��0��$��3��#��[ ���� *Hours+$ TwoWay=��� $��0��$��4��#��[  �� $��0��$��5��#��[ ���� *	Minutes+$ TwoWay=��� $��0��$��6��#��[  �� $��0��$��7��#��[ ���� *	Seconds+$ TwoWay=��� -   $��1��$��9��$��2��#��[ �� $��0��$��2��$��4��
�������   ID_INFO � ToolTip# Z $��0,0,0,-1q�.+��� $��0��$��0,0,23,0q�$��Center=�$��Center=�$
��Bold"�$��10(�   ID_COMERCIAL_USE# Z    ID_COPYRIGHT#��Z 
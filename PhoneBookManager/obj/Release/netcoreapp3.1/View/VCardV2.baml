   M S B A M L   `   `   `  ���� K  GPhoneBookManager, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null=#clr-namespace:PhoneBookManager.ViewPhoneBookManager.View  3clr-namespace:PhoneBookManagerPhoneBookManager  I)clr-namespace:PhoneBookManager.ConvertersPhoneBookManager.Converters  I)clr-namespace:PhoneBookManager.ExtensionsPhoneBookManager.Extensions  S OREMixERP.Net.vCards.Core, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullcGclr-namespace:MixERP.Net.VCards.Types;assembly=REMixERP.Net.vCards.CoreMixERP.Net.VCards.Types Q-clr-namespace:PhoneBookManager.View.BehaviorsPhoneBookManager.View.Behaviors  #    PhoneBookManager.View.VCardV2   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     @d2http://schemas.microsoft.com/expression/blend/2008     5local#clr-namespace:PhoneBookManager.View     0mainwclr-namespace:PhoneBookManager     @
converters)clr-namespace:PhoneBookManager.Converters     @
extensions)clr-namespace:PhoneBookManager.Extensions     V RMaterialDesignThemes.Wpf, Version=3.1.1.1361, Culture=neutral, PublicKeyToken=nullFmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes  #domain1MaterialDesign.Domain  QerpGclr-namespace:MixERP.Net.VCards.Types;assembly=REMixERP.Net.vCards.Core  =	behaviors-clr-namespace:PhoneBookManager.View.Behaviors  _ [Microsoft.Xaml.Behaviors, Version=1.1.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a3b+http://schemas.microsoft.com/xaml/behaviors     MaterialDesignBody#���   $��Regular"�$��13(�&   System.Windows.Media.TextOptions    TextFormattingMode$  Ideal=�   TextRenderingMode$
 Auto=�  MaterialDesignPaper#���    MaterialDesignFont#���   � 	Resources >  8PhoneBookManager.Converters.ArrayStringToStringConverter  ArrStrConverter/  )PhoneBookManager.Converters.DateConverter  DateConverter6  0PhoneBookManager.Converters.Base64ImageConverter  	Base64Img6  0PhoneBookManager.Converters.PhoneNumberConverter  PhoneConverter  BorderGradient �� Property �� Value �� EndPoint �� 
StartPoint �� RelativeTransform �� CenterY	 �� CenterX
 �� CenterY �� CenterX �� Angle �� CenterY �� CenterX  
Primary600 � Color � Offset 	 HeadersText 
 FieldMargin$   PhoneBookManager.View.MiniCard  Minicard��%�  &	       &	      &	 
     &	      &	      &		     &	
 "    &	 G            �� .���  � �� �� $ 0.5,1&�$ 0.5,0&� V� .~��� $	 0.5Q�$		 0.5Q��� $	
 0.5Q�$	 0.5Q��� $ 45Q�$	 0.5Q�$	 0.5Q�T� .��� # �  $ 1Q�� $ White��$ 0.613Q���  � ��$ 0.5,0,0,0.5q��� .���  � ��$
 Bold"��� .���  � ��$ 	10,0,10,0q�  .���  � RowDefinitions �� $	��150 ��� .+��  � ColumnDefinitions �� $
��Auto ���  �� $��1* ��� .+��� -    ��Name$ 	AvatarImg��$��0��$��0��$��2��$	��150������ *Photo+ �� 	Converter# [  �� Mode$ OneWay=��� $��1��$��0��$��Bottom=�$��5,0,0,10q�$��32(����� *FormattedName+ �� UpdateSourceTrigger$ PropertyChanged=�$ OneWay=��� $��1��$��1��$��5,0,0,10q�$��24(����� *DisplayNumber+$ PropertyChanged=�$ OneWay=�# [ �� $��1��$
��Auto=�.��� $��1�� �� $
��15px ��� �� $
��15px � �� $
��Auto ��� $
��Auto ��� $
��Auto ��� $
��Auto ��� $
��Auto ��� $
��Auto �.+�9� $��1��$��Основные�� 9� 
IsExpanded$
 True��.���  �� �� ��  �� �� .+��� $��0��$��0��.+��� $��Center=�$��Фамилия:��$��	10,0,10,0q�#��[	 �� -    ��Name$ NameTextBox��$	��150��$��	10,0,10,0q�)  #MaterialDesignThemes.Wpf.HintAssist   Hint$# Введите фамилию��$��Center=�.������  �� Path$ LastName�$ PropertyChanged=�$ TwoWay=�.���� $��1��$��0��$	��150��.+��� $��Center=�$��Имя:��$��	10,0,10,0q�#��[	 �� $ Введите имя��$��	10,0,10,0q����� *	FirstName+$ PropertyChanged=�$ TwoWay=��� $��2��$��0��$	��150��.+��� $��Center=�$��Отчество:��$��	10,0,10,0q�#��[	 �� $% Введите отчество��$��	10,0,10,0q����� *
MiddleName+$ PropertyChanged=�$ TwoWay=��� $��1��$��1��$	��150��$��	0,10,0,10q�$y�	Collapsed=�.+��� $��Center=�$��Никнейм��$��	10,0,10,0q�#��[	 �� $* $Nick, кличка, позывной��$��	10,0,10,0q����� *
NickName+$ PropertyChanged=�$ TwoWay=��� $	��150��$��2��$��1��$��	0,10,0,10q�$y�	Collapsed=�.+��� $��Center=�$��Пол��$��	10,0,10,0q�#��[	 ��  �� DisplayMemberPath$ Description�� �� SelectedValuePath$ Value��$��	10,0,10,0q�����  �� Source 6   0PhoneBookManager.Extensions.EnumerationExtension  *M� *
erp:Gender++ �� SelectedValue �� $ Gender�$ PropertyChanged=�$ TwoWay=��� $	��150��$��0��$��1��$��	0,10,0,10q�.+��� $��Center=�$��	10,0,10,0q�$��День рожденья��#��[	 (	  "System.Windows.Controls.DatePicker	  -   $��LocaleDatePicker��$
��Auto��$��	10,0,10,0q� 	  SelectedDate �� *
BirthDay+$ PropertyChanged=�# [ 9� $��1��$��1��$��Контакты��$
 True��.���  �� $
��Auto ��� �� $
��15px � �� $
��Auto ��� $
��Auto ��� $
��Auto ��� $
��Auto ��� $
��Auto ��� $
��Auto ��� $
��Auto ��� $
��Auto �.+��� $��1��$��0��$��Телефоны��#��[	 �� $��0��$��1��*
  $Microsoft.Xaml.Behaviors.Interaction  
  	Behaviors  >   8PhoneBookManager.View.Behaviors.IgnoreMouseWheelBehavior  .+��� $��5,5,5,5q�! � Cursor$
! Hand������ *AddPhoneNumber+.��'  !MaterialDesignThemes.Wpf.PackIcon  "   Kind$
" Plus=��� -   # ��Name$# 	PhonesBar��$ �� SelectionMode$$ Single=�$��1��$��Disabled=�$��1������ *
Telephones+$ PropertyChanged=�$ TwoWay=�% �� SelectedItem% �� *SelectedPhone+    ���� .R�� $��Disabled=����� .R��� #��[ ._��  �� $
��Auto ��� �� $
��Auto ���  �� $��4* ��� $��4* �.+�  $" 	Cellphone=�$��0��$��Center=��� $��1��$��0��$��5,5,5,5q�$ Description��$ Value������    *M� *erp:TelephoneType++ �� *Type+$ PropertyChanged=�$ TwoWay=��� $��1��$��2��$��1��$��5,5,5,5q����� *Number+# [ .���� $��2��$��0��$��Right=�$��0q�$��25��$��25����Z� ��Z� ���� *DataContext.DelPhoneNumber+& �� RelativeSource& �� ' �� AncestorType"' ������ & �� "' ��.��  $" Close=��� $��1��$��2��$��
Почта��#��[	 �� $��0��$��3��    .+��� $��5,5,5,5q����� *
AddEmail+.��  $
" Plus=��� -   $# EmailBar��$$ Single=�$��1��$��3��$��Disabled=����� *Emails+% �� *SelectedEmail+    ���� .R�� $��Disabled=����� .R��� #��[ ._��  �� $
��Auto ��� ��  �� $��4* ��� $��4* �.+�  $" At=�$��0��$��Center=��� $��1��$��0��$��5,5,5,5q�$ Description��$ Value������    *M� *erp:EmailType++ �� $
 Type�$ PropertyChanged=�$ TwoWay=��� $��1��$��2��$��1��$��5,5,5,5q�.������ $ EmailAddress�$ PropertyChanged=�( �� ValidationRules( 5  /System.Windows.Controls.DataErrorValidationRule  .���� $��2��$��0��$��Right=�$��0q�$��25��$��25����Z� ��Z� ���� *DataContext.DelEmail+& �� "' ������ & �� "' ��.��  $" Close=��� $��1��$��4��$��
Адрес��#��[	 �� $��0��$��5��    .+��� $��5,5,5,5q�$
! Hand������ *
AddAddress+.��  $
" Plus=��� -   $# 
AddressBar��$$ Extended=�$��1��$��5��$��Disabled=����� *	Addresses+% �� *SelectedAddress+    ���� .R�� $��Disabled=����� .R��� #��[ ._��  �� $
��Auto ��� ��  �� $��4* ��� $��4* �.+�  $" 	MapMarker=�$��0��$��Center=��� $��1��$��0��$��5,5,5,5q�$ Description��$ Value������    *M� *erp:AddressType++ �� $
 Type�$ PropertyChanged=�$ TwoWay=��� $��1��$��2��$��1��$��5,5,5,5q����� *Street+.���� $��2��$��0��$��Right=�$��0q�$��25��$��25����Z� ��Z� ���� *DataContext.DelAddress+& �� "' ������ & �� "' ��.��  $" Close=��� $��6��$��Сайт��#��[	 �� $��0��$��7��$��3������ *
Card.Url+9� $��1��$��2��$��Работа��$ False��.���  �� $	��120��$
��Auto ��� $��1* ��� $
��Auto � �� $
��Auto ��� $
��Auto ��� $
��Auto ��� $
��Auto ��� $
��Auto �.+��� $��2��$��5������ *Logo+�� $��0��$��Организация��#��[	 �� $��1��$��0������ *Organization+�� $��1��$��Должность��#��[	 �� $��1��$��1������ *Role+�� $��2��$%��Род деятельности��#��[	 �� $��1��$��2������ *Title+9� $��1��$��3��$��Прочее��.���  �� $	��120��$
��Auto ��� $��1* ��� $
��Auto � �� $
��Auto �.+��� $��0��$��Примечание��#��[	 �� $��1��$��0��$��1q�
����+��._��� ) �� TextWrapping$
) Wrap=�* �� AcceptsReturn$
* True��"+ �� VerticalScrollBarVisibility$+ Visible=�, �� MinLines$, 5������ *Note+9� -   - 9�Name$- CustomExtensions��$��4��$��1��$/��)Пользовательские поля��.��� -   . �Name$. CustomExtensionsGrid��.+�&   System.Windows.Controls.DataGrid  /   AutoGenerateColumns$/ False������ *CustomExtensions+$ PropertyChanged=�$ TwoWay=�    0   Columns0 0  *System.Windows.Controls.DataGridTextColumn  ,  &System.Windows.Controls.DataGridColumn1   Header$1 Заголовок��2   
FontWeight$
2 Bold"�3   
IsReadOnly$
3 True��1  +System.Windows.Controls.DataGridBoundColumn4   Binding4 �� *Key+  $1 Содержимое��$
2 Bold"�4 �� *Values+# [ 9� $��5��$��1��$/��)Объединенные контакты��y��� *ConcatInnerVcard.Count+   NotZeroToVisibilityConverter# [ .���� $��Disabled=����� *ConcatInnerVcard+    ���� .R�� $��Disabled=����� 5 �� DataType"5  .R�  
   M S B A M L   `   `   `  ���� O  KWSChina2020AppComp03, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null_4clr-namespace:WSChina2020AppComp03.Pages.Coordinator&WSChina2020AppComp03.Pages.Coordinator  @    :WSChina2020AppComp03.Pages.Coordinator.SponsorshipViewPage   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35^ ZWindowsFormsIntegration, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     @d2http://schemas.microsoft.com/expression/blend/2008     Flocal4clr-namespace:WSChina2020AppComp03.Pages.Coordinator       N� Title$  SponsorshipViewPage��.���  � RowDefinitions �� $
��auto ��� $��* �.+��� $��Center=�$��Center=�.+��� $��Center=�   StyleTblTitle#��[  $��15q�Sponsorship View��  �� Orientation$ 
Horizontal=�.+��� .+��� $��Right=�$ 
Horizontal=�.+��� $��Center=�  StyleTbBody#��[ Event:�� -   $��CbEvent�� �� DisplayMemberPath$
 Name��$	��300���� $��Right=�$ 
Horizontal=�.+��� $��Center=�#��[ 
Sponsor:�� -    ��Name$ 	TbSponsor��$	��300���� $��10 0 0 0q�.+��� $��Right=�$ 
Horizontal=�.+��� $��Center=�#��[ Competition:�� -   $��CbCompetition��$
 Name��$	��150���� $��0 15 0 0q�$��Right=�$ 
Horizontal=�.+��� -    ��Name$ 	BtnSearch��$��30��$	��100��$��5q�.��Search�� -   $ 	BtnExport��$��30��$	��100��$��5q�.��Export�� #��[ $
��Bold"�$��Center=�$��5 5 5 0q�&   System.Windows.Controls.DataGrid  -     Name$ DgSponsorship��$��5 5 5 30q�   AutoGenerateColumns .     CanUserAddRows .  $��1��	   Columns	 0  *System.Windows.Controls.DataGridTextColumn  ,  &System.Windows.Controls.DataGridColumn
   Header$
 Event��   Width5  /System.Windows.Controls.DataGridLengthConverter$ * 1  +System.Windows.Controls.DataGridBoundColumn   Binding �� *" EventCompetition.YearCountryTown+   ElementStyle ��  �� 
TargetType" ��.���  �� Property � �� �� Value$
 Wrap=�  $
 
Competiton��$ *  �� *Competition.FullCompetition+ �� " ��.���  � ��$
 Wrap=�  $
 Sponsor��$ *  �� *Sponsor.Name+ �� " ��.���  � ��$
 Wrap=�  $

 Item��$ *  �� *CategoryOfSponsorship.Name+ �� " ��.���  � ��$
 Wrap=�  $
 
Amount(¥)��$ *  �� *FullPriceOneCategory+ �� " ��.���  � ��$
 Wrap=�
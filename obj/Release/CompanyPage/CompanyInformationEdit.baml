   M S B A M L   `   `   `  ???? R  NMobileAppUsageDashboard, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullA%clr-namespace:MobileAppUsageDashboardMobileAppUsageDashboard  @    :MobileAppUsageDashboard.CompanyPage.CompanyInformationEdit   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     @d2http://schemas.microsoft.com/expression/blend/2008     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     7local%clr-namespace:MobileAppUsageDashboard     U QMaterialDesignThemes.Wpf, Version=2.6.0.325, Culture=neutral, PublicKeyToken=nullFmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes  -      MaterialDesignBody#???   $??Regular"?$??13(?&   System.Windows.Media.TextOptions    TextFormattingMode$  Ideal=?   TextRenderingMode$
 Auto=????#DDC6B6 ? Title$ CompanyInformationEdit??$	??500??$	??400?? ? 
ResizeMode$ NoResize=?$??Roboto)?$??14(? ? WindowStartupLocation$ CenterScreen=?.???  ? RowDefinitions ?? $	??100 ??? $??* ?.+?(  "MaterialDesignThemes.Wpf.ColorZone     Mode$ 
PrimaryMid=?$??0??$??Stretch=????#262223.???? $??업체 정보 수정??$??Center=?$??20q?$??30(??? $??10 30q?$??1??.+?? .+?'  !MaterialDesignThemes.Wpf.PackIcon  ?  ?ControlzEx.PackIconBase`1[[MaterialDesignThemes.Wpf.PackIconKind, MaterialDesignThemes.Wpf, Version=2.6.0.325, Culture=neutral, PublicKeyToken=null]]   Kind$
 Shop=?$??Bottom=?$
??2 12q????? *BorderBrush+ ?? ElementName$ EditShop???? -   	 ??Name$	 EditShop??$??5q?)  #MaterialDesignThemes.Wpf.HintAssist
   Hint$
 업체 이름??$??8 0 0 0q? % !MaterialDesignFloatingHintTextBox#??[  ?? 
CaretBrush ?#262223? .+?  $
 Face=?$??Bottom=?$
??2 12q????? *BorderBrush+$ 
EditNumber???? -   $	 
EditNumber??$??5q?$
 전화번호??$??8 0 0 0q?#??[  ?#262223?  ? ColumnDefinitions ?? $
??265* ??? $
??109* ?.+?  $ At=?$??Bottom=?$??2,0,0,12q????? *BorderBrush+$ EditAddress???? -   $	 EditAddress??$??5q?$
 주소??$??8 0 0 0q?#??[  ?#262223$??2???  ?? $
??265* ??? $
??109* ?.+?  $ At=?$??Bottom=?$??2,0,0,12q????? *BorderBrush+$ 	EditIntro???? -   $	 	EditIntro??$??5q?$
 	소개글??$??8 0 0 0q?#??[  ?#262223$??2???? -    ??Name$ companyNumEdit??$
??Wrap=??? -   $??2??$??50 72q?$??Right=?$	??Top=? , (MaterialDesignFloatingActionAccentButton#??[ ???	#FFD4844C???	#FFD4844C.??  $ ContentSave=?
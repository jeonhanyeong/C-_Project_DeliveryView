   M S B A M L   `   `   `  ???? U  QLiveCharts.Wpf, Version=0.9.7.0, Culture=neutral, PublicKeyToken=0bc1f845d1ebb8dfG4clr-namespace:LiveCharts.Wpf;assembly=LiveCharts.WpfLiveCharts.Wpf  R NMobileAppUsageDashboard, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullA%clr-namespace:MobileAppUsageDashboardMobileAppUsageDashboard "   MobileAppUsageDashboard.Main   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    Blvc4clr-namespace:LiveCharts.Wpf;assembly=LiveCharts.Wpf    R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     @d2http://schemas.microsoft.com/expression/blend/2008     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     7local%clr-namespace:MobileAppUsageDashboard     U QMaterialDesignThemes.Wpf, Version=2.6.0.325, Culture=neutral, PublicKeyToken=nullFmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes  -      MaterialDesignBody#???   $??Regular"?$??13(?&   System.Windows.Media.TextOptions    TextFormattingMode$  Ideal=?   TextRenderingMode$
 Auto=?  MaterialDesignPaper#???    MaterialDesignFont#???   ? Title$" Application Usage Statistics??$	??900??$
??1600?? ? WindowStartupLocation$ CenterScreen=? ? AllowsTransparency .  ? WindowStyle$
 None=?.??)  #MaterialDesignThemes.Wpf.DrawerHost  -     Name$ 
mainDrawer??   LeftDrawerContent ??  ?? Orientation$ Vertical=?$	??240??.+??? $??10q?$	??Top=?$ 
Horizontal=?.+??? $??Center=?$??0,0,10,0q?목록??   MaterialDesignFlatButton#??[ $??135,0q?	   CloseDrawerCommand#??Z	 .??'  !MaterialDesignThemes.Wpf.PackIcon  ?  ?ControlzEx.PackIconBase`1[[MaterialDesignThemes.Wpf.PackIconKind, MaterialDesignThemes.Wpf, Version=2.6.0.325, Culture=neutral, PublicKeyToken=null]]
   Kind$
 HamburgerMenuBack=??? $ Vertical=?.+??? -   #??[ .??가게 관리?? -   #??[ .??대행업체 리스트?? -   #??[ .??주문 정보?? -   #??[ .??리뷰 관리.??#  MaterialDesignThemes.Wpf.Card  $??Stretch=?$??Stretch=?????  ?? EndPoint$ 0.5,1&? ?? 
StartPoint$ 0.5,0&?.???  ? Color$ Black?? ? Offset$ 1Q?? $ 	#FF474747??.???  ? ColumnDefinitions ?? ?? $??0* ??? $??0* ?.+??? $??0??$ Vertical=?$??10q?.+??? $ 
Horizontal=?$??62??.+??? #??[    OpenDrawerCommand#??Z $	??Top=?$??Right=?$??61??$??83??.??  $
 HamburgerMenu=?$??39??$??50??
????????? $??DeliveryView_Shop??$??25(?$??0,16,0,0q?$??40??$	??Top=??  ?? $
??303* ??? $	??92* ? ? 	Resources  ?? 
TargetType ?? Property ?? Value??%C   '        ?? "  .???  ? ??$ 30????  ? ??$ 30??.+?? $??0??.+??? $??10q?.+?  $??30 20q?   UniformCornerRadius$ 20Q?$	??457??.???? .+?? .+??? $??20q?$
??Left=?$??SemiBold"?$??매출??$??18(??? $ 
Horizontal=?$??Right=?.+??? $??	ExtraBold"?$??14(?$	????$??	wingdings)?$??Center=????#42A5F4?? $??월간??$??Right=?$??Center=?$??SemiBold"?$??14(?$??5 0 10 0q??? $??	ExtraBold"?$??14(?$	????$??	wingdings)?$??Center=????#F55F54?? $??주간??$??Right=?$??Center=?$??SemiBold"?$??14(?$??5 0 20 0q?#   LiveCharts.Wpf.CartesianChart  
???   ?$
??10 0q?$	??202??&    LiveCharts.Wpf.Charts.Base.Chart   Series ?? *SeriesCollection+   AxisX    LiveCharts.Wpf.Axis   	   LiveCharts.Wpf.DefaultAxes 	  CleanSeparator   	Separator# Z    Labels ?? *Labels+  
???   ?$
??10 0q?$	??182?? ?? *SeriesCollection1+   # Z  ?? *	Labels1+? $??Center=?$
??30,0q?$
??1132??.+?  $??10q?$ 20Q?$??10q?$
??1104??????  ?? Color$ 	#FF424242?? ?? Opacity$	 0.5Q?.???? .+??? $??일간??$??10 20q?$??SemiBold"?$??46??$??35(?? $	??150?? ?? $
??161* ??? $
??923* ? ? RowDefinitions ?? ?? ?? .+??? $??매출??$??0??$??0??$??Center=?$??Center=?$??13(?$??SemiBold"?$??30??$??10q?$	??141?? J? RenderTransformOrigin$ 1.059,2.062&? ?? TextAlignment$ Center=??? $??주문건수??$??0??$??1??$??Center=?$??Center=?$??13(?$??SemiBold"?$??30??$??10q?$	??141??$ Center=??? $??별점??$??0??$??2??$??Center=?$??Center=?$??13(?$??SemiBold"?$??30??$??10q?$	??141??$ Center=??? $??1??$??0??$ 
Horizontal=?$??10,10,10,10q?.+?? $	??903??$??0q?.+?? -   $??매출??$??0,0,0,0q?  ? Minimum$  0Q?! ? Maximum$	! 100Q?" ? Value$" 77Q?$
??Auto??$	??903?????	#FF94EC14
???   ???Z? ?? $??Center=?$??Center=????? # ?? ElementName$# 매출??$ ?? Path$$ Value?% ?? StringFormat$% {0:0}%???? $??1??$??1??$ 
Horizontal=?$??10,10,10,10q?.+?? $	??903??$??0q?.+?? -   $??주문건수??$??0,0,0,0q?$  0Q?$	! 100Q?$" 77Q?$
??Auto??$	??903?????	#FFE22F2F
???   ???Z? ?? $??Center=?$??Center=????? $# 주문건수??$$ Value?$% {0:0}%???? $??1??$??2??$ 
Horizontal=?$??10,10,10,10q?.+?? $	??903??$??0q?.+?? -	   $??별점??$??0,0,0,0q?$  0Q?$! 5Q?$	" 4.3Q?$
??Auto??$	??903????Z? ??Z? ??Z? ?? $??Center=?$??Center=????? $# 별점??$$ Value?$% {0:0}점???? $??1??.+??? $??40 10q?& ?? CornerRadius$& 20??._??? -
   ' ??Name$' 
ImgCartoon??$??Resources/logo.png??$??Uniform=?$	??150??&
   System.Windows.Controls.Calendar
  -   ( 
 Name$( Calendar_Box??$??45 10q?? $??38??.+??? -   ) ??Name$) 	clear_btn??$??매출확인??$
??Auto??$??215,0,50,10q????	#FF864879? $	??244??$??	40,0,45,0q?.+??? $??	0,0,0,122q????	#FF1F1D36* ?? RadiusY$* 10??+ ?? RadiusX$+ 10??? $??
0,0,10,122q?.+?? $??35??$??50??$
??Left=?$	??Top=?$
??20 0q?.+?  $
 CartAdd=?$??Center=?$??Bottom=?$??	0,0,15,20q?
???????$??20??$??20???? -   , ??Name$, 	Date1_Box??$??0 ??$??
60,4,83,93q????	#DDFFFFFF$??20(??? $??주문건수??$??Right=?$??Champagne & Limousines)?$??5q?$	??Top=?
????????? $ 
Horizontal=?$??Right=?$	??Top=?$??10 30q?.+??? -   $, rjstn??$	??건??$??Champagne & Limousines)?$??Center=?
???????$??25(??? $??	0,129,0,0q????	#FF3F3351$* 10??$+ 10??? $??
0,129,10,0q?.+?? $??35??$??50??$
??Left=?$	??Top=?$
??20 0q?.+?  $
 Wallet=?$??Center=?$??Bottom=?$??	5,0,10,20q?
???????$??20??$??20???? -   $, 	Date2_Box??$??0 ??$??
60,4,83,85q????	#DDFFFFFF$??20(??? $??매출??$??Right=?$??Champagne & Limousines)?$??5q?$	??Top=?
????????? $ 
Horizontal=?$??Right=?$	??Top=?$??10 30q?.+??? -   $, aocnf??$??0??$??Champagne & Limousines)?$??Center=?
???????$??25(??  9MaterialDesignThemes.Wpf.Transitions.TransitioningContent  $??1??$??Stretch=?$??Stretch=?$??2??C  =MaterialDesignThemes.Wpf.Transitions.TransitioningContentBase-   OpeningEffect- D  >MaterialDesignThemes.Wpf.Transitions.TransitionEffectExtension  .   Kind$. SlideInFromTop=??? -   #??[ #??Z $??Right=?$??	0,10,60,0q?$??32??$	??Top=?.??  $
 LogoutVariant=?
????????? -   #??[ #??Z $	??Top=?$??Right=?$??	0,10,10,0q?.??  $
 power=?
????????? -   #??[ #??Z $??Right=?$??
0,10,110,0q?$??32??$	??Top=?.??  $

 Home=?
???????
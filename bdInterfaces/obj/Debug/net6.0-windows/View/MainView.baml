   M S B A M L   `   `   `  ????D  @NORTHWIND, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null5clr-namespace:bdInterfaces.ViewbdInterfaces.View  5   	        bdInterfaces.View.MainView   5   	   W SPresentationCore, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35^ ZWindowsFormsIntegration, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35H 9http://schemas.microsoft.com/winfx/2006/xaml/presentation      5   	   R NSystem.Xaml, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   X TFontAwesome.Sharp, Version=6.2.1.0, Culture=neutral, PublicKeyToken=d16d1e4e568ec10fFfo=http://schemas.awesome.incremented/wpf/xaml/fontawesome.sharp  5   	   +localclr-namespace:bdInterfaces.View  5   	   -   5          ? Title$  MainView??5	   	   $	??450??6   $	??800??6'    ? WindowStyle$
 None=?5
   	    ? Icon$ ../IMG/bd.png??5   	    ? WindowStartupLocation$ CenterScreen=?5   	   
??????  ? 
ResizeMode$ NoResize=?5   	    ? AllowsTransparency$
 True??5   	   .??5      ??  ?? CornerRadius$ 20??6    	  Negro#??[  5      #??[  5      $??5q?5      ._?5   
   ? .+?5      ?  ? ColumnDefinitions 5      ?? 5      $	??200 ?6'   ?? 5      $??* ?6'   .+?5       ?? $??0??6   $ 	20,0,0,20??5!       	 Verde#??[ 5"      ._?5#      ?  ? RowDefinitions 5%      ?? 5&      $	??400 ?6,   ?? 5'      $??* ?6,   .+?5*      ?? $??0??6%   .+?5.      ?? 	 ?? Orientation$	 
Horizontal=?6)   $??35??5/   )   $??10, 25, 0, 40q?50   )   .+?51   "   ?? $??	NORTHWIND??6,   #??[  52   ,   $??23(?53   ,   $
??Bold"?54   ,   $??
MontSerrat)?55   ,   $??Bottom=?56   ,   
 ?? Padding$
 0,0,0,0q?57   ,    J? Effect 58   &   3  -System.Windows.Media.Effects.DropShadowEffect  59   *      ShadowDepth$ 0Q?6;      Color$ #333333??5:   ;      Opacity$	 0.5Q?5;   ;      
BlurRadius$ 10Q?5<   ;   5>   #   ?? 5?   "   $??../IMG/bd.png??6(   $??Bottom=?5@   (   $??10,0,0,5q?5A   (    5B   &     5C   *   $ 0Q?6;   $ White??5D   ;   $	 0.5Q?5E   ;   $ 10Q?5F   ;   5H   #   5J      	? 5N      -   5         	?Name$ 	RbtInicio??5N   *     BotMenu#??[ 5O   *   
 ? Tag# [  5P   *    d? 	IsChecked$
 TrueY?5Q   *   .??5S   "   ?? $	 
Horizontal=?6-   .+?5T   &   !  FontAwesome.Sharp.IconImage  ?  ?FontAwesome.Sharp.IconImageBase`1[[FontAwesome.Sharp.IconChar, FontAwesome.Sharp, Version=6.2.1.0, Culture=neutral, PublicKeyToken=d16d1e4e568ec10f]]   Icon$
 Home=?63     MenuBotonIcono#??[ 6?   ?? 5U   &   $??INICIO??60     MenuBotonText#??[ 6>   6g   5V   #   5X      	? 5Z      -   5        $ RbtCrud??5Z   *   #??[ 5[   *   # [  5\   *   .??5^   "   ?? $	 
Horizontal=?6-   .+?5_   &     $	 Pen=?63   #??[ 6>   ?? 5`   &   $
??CRUD??60   #??[ 6<   6e   5a   #   5b      	? 5d      -   5        $ RbtConsulta??5d   *   #??[ 5e   *   # [  5f   *   .??5h   "   ?? $	 
Horizontal=?6-   .+?5i   &     $
 List=?63   #??[ 6?   ?? 5j   &   $??	CONSULTAS??60   #??[ 6A   6j   5k   #   5l      	? 5n      -   5        $ RbtAcercaDe??5n   *   #??[ 5o   *   # [  5p   *   .??5r   "   ?? $	 
Horizontal=?6-   .+?5s   &     $ 
InfoCircle=?63   #??[ 6E   ?? 5t   &   $??	ACERCA DE??60   #??[ 6A   6j   5u   #   5v      5x      ?? 5{      $??1??6%   .+?5|      ?? -   5         ??Name$ Volver??5|   %   $??25??65   $
??Left=?5}   %   $??40,0,0,0q?5~   %   $??0q?5?   %     BotIcono#??[ 5?   %   .??5?   "     $ SignOut=?6/      
Foreground# [  6>   5?      5?      5?      5?      ?? 5?      $??1??6   $ 	0,20,20,0??5?      #??[  5?      ._?5?      ?  5?      ?? 5?      $??25 ?6,   ?? 5?      $??* ?6,   .+?5?      ?? -   5         ??Name$ pnlControlBar??5?   %   $??0??5?   %   $	 
Horizontal=?5?   %   $??RightToLeft=?5?   %   
?????? $??0,5,0,0q?5?   %   .+?5?      ?? -   5        $ 	BtnCerrar??5?   %   $??X??5?   %   $
??Bold"?5?   %   
???????$??0q?5?   %   $??5,0,0,0q?5?   %     BotColorVerde#??[ 5?   %     
BotRedondo#??[ 5?   %   ?? 5?      -	   5        $ BtnMinimizar??5?   %   $??-??5?   %   
???????$
??Bold"?5?   %   $??0q?5?   %   $??10,0,0,0q?5?   %   #??[ 5?   %   #??[ 5?   %   5?       ? 5?      -
   5          ?Name$ Menus??5?       $??1??5?         ? Source$ ../Pages/Inicio.xaml??5?         ? NavigationUIVisibility$ Hidden=?5?       6B   5?      5?      5?      5?      5?      5?      
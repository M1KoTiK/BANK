   M S B A M L   `   `   `  ????F  BBANK_Kargin, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null3clr-namespace:BANK_Kargin.ViewBANK_Kargin.View  5   	   =#clr-namespace:BANK_Kargin.ViewModelBANK_Kargin.ViewModel  5      $    BANK_Kargin.View.Authorization   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   0localclr-namespace:BANK_Kargin.View     5   	   2vm#clr-namespace:BANK_Kargin.ViewModel     5        ? 
ResizeMode$  	CanResize=?5   	   $	??700??5	   	   $
??1100??5
   	    ? WindowStartupLocation$ CenterScreen=?5   	    ? Title$ 
MainWindow??5   	   $	??720??6   $
??1280??6)    ? DataContext 5      7   1BANK_Kargin.ViewModel.ViewModelDepositCalculators  5   
   .??5      ?  ? ColumnDefinitions 5   
   ?? 5      ?? 5      ?? 5       ? RowDefinitions 5   
   ?? 5      $	??69* ?6   ?? 5      $	??69* ?6   ?? 5      $	??69* ?6   ?? 5      $	??69* ?6   ?? 5      $??69 ?6   ?? 5      $	??69* ?6   ?? 5      $	??68* ?6   ?? 5       $	??69* ?6   ?? 5!      $	??69* ?6   ?? 5"      $	??69* ?6   .+?5$   
   ?? $??1??6   $??0??6$   $??2??62   $??2??6F   $	??Top=?6W   $??Right=?6o   $??
0,20,110,0q?6?   $/??)Деньги в каждый карман??6?   ???#1e2f42$??40(?6?   ?? 5%   
   $??ph1.PNG??6   $??2??6!   $??2??61   $??2??6E   $??0??6V   $??70??6c   $??70??6o   $??	0,15,20,0q?6z   $??Right=?6?   $	??Top=?6?   ?? 5&   
   $??0??6   $??3??6%   $??2??69   $??7??6F   
????ح?$??350,10,350,0q?6h    J? Effect 5'      3  -System.Windows.Media.Effects.DropShadowEffect  5(         Color$ Black??6#      
BlurRadius$	 150Q?61   5*      ?? 5+   
   $??2??6   $??0??6"   $??3??62   $??7??6F   
???????$??350,10,350,0q?6j   .+?5,      ?? $??Авторизация??6   $??28(?6+   $??Center=?69   $??0,20,0,0q?6V   ?? 5-      $??
Логин??6   $??28(?6%   $
??Left=?63   $??	20,20,0,0q?6N   ?? 5.      $??50??6-   $??	20,0,20,0q?69   $??26(?6L   
?????? ??6   ?? *Login+.??6t   ??5/      O Kmscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e0891&clr-namespace:System;assembly=mscorlibSystem 50   1   ?? 6   6sys&clr-namespace:System;assembly=mscorlib     61   	 ?? 
TargetType"	 ??6   
 ?? 	Resources
 51         CueBannerBrush j? 
AlignmentX j? 
AlignmentY j? Stretch !? Visual??%?   &	        !? 52      $
 Left=?6A   $ Center=?6S   $
 None=?6g    53   "   ?? 54   &   $??Введите логин??6,   
???????$??22(?6[   56      57       ?? Triggers 58      P? 59       P? Property ? ?? ?? Empty P? Value# Z 66   . ?5:   "   ??  ?? Property ? ?? ?? Value# [  6?   5;      P? 5<       ? ?? 66   Z? . ?5=   "   ??  ? ??# [  6?   5>      P? 5?       ?@J?IsKeyboardFocused . . ?5@   "   ??  ? ??
 ?????6?   5A      5C      .??5D   !   5E      ?? 5F      	 ?? X1$ 30??6   	 ?? Y1$ 5??6   	 ?? X2$	 550??6"   	 ?? Y2$ 5??6+   ???#2C7DE062   ?? 5G      $??Пароль??6   $??28(?6&   $
??Left=?64   $??	20,20,0,0q?6O   ?? 5H      $??50??60   $??	20,0,20,0q?6<   $??26(?6O   
?????? ??6   ?? *
Password+.??6w   ??5I      1&clr-namespace:System;assembly=mscorlibSystem 5J   1   ?? 6   6sys&clr-namespace:System;assembly=mscorlib     61   "	 ??6   
 5K      ??%?   &	        !? 5L      $
 Left=?6A   $ Center=?6S   $
 None=?6g    5M   "   ?? 5N   &   $??Введите логин??6,   
???????$??22(?6[   5P      5Q       5R      P? 5S       ? ??# Z 66   . ?5T   "   ??  ? ??# [  6?   5U      P? 5V       ? ?? 66   Z? . ?5W   "   ??  ? ??# [  6?   5X      P? 5Y       ?@J?IsKeyboardFocused . . ?5Z   "   ??  ? ??
 ?????6?   5[      5]      .??5^   !   5_      ?? 5`      $ 30??6   $ 5??6   $	 550??6"   $ 5??6+   ???#2C7DE062   ?? 5a      ???#2C7DE0$??25,100,25,0q?6*   ??6?   ?? *
OnClikcLog+.??5b      ?? $??Вход??6   $??26(?6(   
???????66   5c      5d      5e      5f      
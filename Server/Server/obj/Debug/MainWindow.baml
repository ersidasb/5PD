   M S B A M L   `   `   `  ����A  =Server, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullclr-namespace:ServerServer  5   	       Server.MainWindow   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   &localclr-namespace:Server     5   	     � Title$  Server��5   	   $��259.6��6   $��613.6��6'   .��5	      � .+�5
   
   �� -   5         ��Name$ btnStart��5
      $��Start Server��6#   $
��Left=�6:   $��226,195,0,0q�6U   $	��Top=�6j   $��75��6�   6�   �� 5   
   -   5        $ btnSend��5      $
��Send��6"   $
��Left=�61   $��306,195,0,0q�6L   $	��Top=�6a   $��75��6y   6�   �� 5   
   $
��Left=�6   $��	10,10,0,0q�6/   $
��Wrap=�6B   $��Public key: ��6V   $	��Top=�6j   $
��Bold"�6�   �� 5   
   -   5         ��Name$ tblPublicKey��5      $
��Left=�6*    �� TextAlignment$
 Left=�6E   $��	79,10,0,0q�6Z   $
��Wrap=�6m   $	��Top=�6�   $	��163��6�   �� 5   
   $
��Left=�6   $��	10,31,0,0q�6/   $
��Wrap=�6B   $��Message��6V   $	��Top=�6e   $
��Bold"�6}   �� 5   
   $
��Left=�6   $	��138��6,   $��	10,52,0,0q�69   $	��Top=�6L   $	��291��6d   $��1q�6p   
���   �._�5      �� .��5      �� -   5        $ 
tblMessage��5      $
��Wrap=�60   6F   5      5      �� 5   
   $
��Left=�6   $	��138��6,   $��
306,52,0,0q�69   $	��Top=�6M   $	��291��6e   $��1q�6q   
���   �._�5      �� .��5      �� -   5        $ tblSignature��5      $
��Wrap=�62   6H   5      5      �� 5   
   $
��Left=�6   $��
306,31,0,0q�6/   $
��Wrap=�6C   $��	Signature��6W   $	��Top=�6h   $
��Bold"�6�   �� 5   
   -   5        $ btnRandomizeAll��5      $��Randomize all��6*   $
��Left=�6B   $��
504,29,0,0q�6]   $	��Top=�6q   $��93��6�    J� RenderTransformOrigin$ 
2.445,0.49&�6�   6�   �� 5   
   -   5        $ btnRandomizeOne��5      $��Randomize one��6*   $
��Left=�6B   $��
405,28,0,0q�6]   $	��Top=�6q   $��94��6�   $ 0.5,0.5&�6�   6�   5      5      
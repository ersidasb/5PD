   M S B A M L   `   `   `  ����C  ?Receiver, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null#clr-namespace:ReceiverReceiver  5   	       Receiver.MainWindow   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   (localclr-namespace:Receiver     5   	     � Title$  Receiver��5   	   $	��260��6   $	��614��6'   .��5	      � .+�5
   
   �� -   5         ��Name$ btnStart��5
      $��Start Receiver��6#   $
��Left=�6<   $��226,195,0,0q�6W   $	��Top=�6l   $��75��6�   6�   �� 5   
   $
��Left=�6   $��	10,10,0,0q�6/   $
��Wrap=�6B   $��Public key: ��6V   $	��Top=�6j   $
��Bold"�6�   �� 5   
   -   5         ��Name$ tblPublicKey��5      $
��Left=�6*    �� TextAlignment$
 Left=�6E   $��	79,10,0,0q�6Z   $
��Wrap=�6m   $	��Top=�6�   $	��163��6�   �� 5   
   $
��Left=�6   $��	10,31,0,0q�6/   $
��Wrap=�6B   $��Message��6V   $	��Top=�6e   $
��Bold"�6}   �� 5   
   $
��Left=�6   $	��138��6,   $��	10,52,0,0q�69   $	��Top=�6L   $	��291��6d   $��1q�6p   
���   �._�5      �� .��5      �� -   5        $ 
tblMessage��5      $
��Wrap=�60   6F   5      5      �� 5   
   $
��Left=�6   $	��138��6,   $��
306,52,0,0q�69   $	��Top=�6M   $	��291��6e   $��1q�6q   
���   �._�5      �� .��5      �� -   5         ��Name$ tbxSignature��5       �� 
IsReadOnly .  J� IsHitTestVisible .  $
��Left=�6_   . �5      /� .T�5      J� .*�6$   5      5      5      5      5      �� 5   
   $
��Left=�6   $��
306,31,0,0q�6/   $
��Wrap=�6C   $��	Signature��6W   $	��Top=�6h   $
��Bold"�6�   �� 5   
   -   5        $ btnValidate��5      $��Validate��6&   $
��Left=�69   $��306,195,0,0q�6T   $	��Top=�6i   $��75��6�    J� RenderTransformOrigin$ 0.643,0.448&�6�   6�   5!      5"      
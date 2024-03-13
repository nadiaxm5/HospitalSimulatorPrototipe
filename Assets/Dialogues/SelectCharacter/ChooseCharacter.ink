INCLUDE ../globals.ink

-> main

===main===
Elige personaje
+[Hombre]
    -> chosen(0)
+[Mujer]
    -> chosen(1)
    
===chosen(election)===
~ personaje = election 
->END
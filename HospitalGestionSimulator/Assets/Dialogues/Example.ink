-> main

=== main ===
Hola, soy el doctor
Esto es otro texto de ejemplo
Elige un animal
+ [Perro]
    -> chosen("perro")
+ [Gato]
    -> chosen("gato")
    
=== chosen(color) ===
Has elegido el {color}
-> END
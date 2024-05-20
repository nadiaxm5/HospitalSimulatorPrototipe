INCLUDE ../globals.ink

->main

===main===
#speaker: Recepcionista
¡Hola! Tu debes ser {personaje == 0: el nuevo enfermero supervisor. | la nueva enfermera supervisora.}

Ve al despacho de la directora del hospital, te espera.

~ talked_with_recepcionist = true
~ current_mission = "Habla con la directora"
->END
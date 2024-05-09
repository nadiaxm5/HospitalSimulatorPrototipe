INCLUDE ../globals.ink

{task_protocol == false:
    ¿Por qué nos has reunido? Estamos hasta arriba de trabajo.

    Vamos a cambiar los apósitos que tenemos por otros igual de buenos y más baratos. ¿Os parece bien?

    ~ talked_with_nurse_reunion = true
    
    ->END
  - else:
    ¿Qué ocurre? ¿Por qué nos has reunido?
    
     ~ player_talking = true
     Os he reunido para hacer un protocolo. En el orden del día de hoy, nos enfocaremos exclusivamente en llegar a un acuerdo sobre cómo implementar las citas no presenciales.
      ~ player_talking = false
      ¿Qué problema hay con las citas presenciales?
       ~ player_talking = true
      Si damos citas no presenciales a los casos que no necesitan ser visitados físicamente, habrá menos saturación en el hospital. 
      
      ¿Tenéis alguna propuesta de cómo implementarlas?
       ~ player_talking = false
       
       Podríamos ofrecer consultas por mensajería.
       
       Pues yo creo que sería mejor por videollamada.
       
        +[Mensajería]
        ->a0("mensajeria")
        
        +[Videollamada]
        ->a0("videollamada")
        
        +[Ninguna de las dos opciones]
        ~ player_talking = true
            No me convence. Ya pensaré algo más adelante.
        ~ player_talking = false
        ~ protocol_election = 1
        ->END

}

===a0(opcion)===
Aunque las dos son buenas ideas, vamos a implementar la de {opcion}. ¿Os parece bien?
~ protocol_election = 0


->END
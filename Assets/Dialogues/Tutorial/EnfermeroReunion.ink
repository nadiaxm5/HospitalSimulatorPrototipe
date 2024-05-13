INCLUDE ../globals.ink

{task_protocol: //aqui es false, si está a true es porque es un testeo
    ¿Por qué nos has reunido? Estamos hasta arriba de trabajo.

    Vamos a cambiar los apósitos que tenemos por otros igual de buenos y más baratos. ¿Os parece bien?

    ~ talked_with_nurse_reunion = true
    
    ->END
  - else:
    {talked_with_director_phone == false:
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
            Aunque las dos son buenas ideas, vamos a implementar la de mensajería.¿Os parece bien?
            ->a0("mensajeria")
            
            +[Videollamada]
            ->a0("videollamada")
            
            +[Ninguna de las dos opciones]
            ~ player_talking = true
                No me convence. Ya pensaré algo más adelante.
            ~ player_talking = false
            ~ protocol_election = 1
            ->END
        -else:
        ¿Cuál es la emergencia?
        ~ player_talking = true
        Me han dado una mala noticia desde dirección, y os la tengo que comunicar. A partir de ahora, no se permiten vacaciones en fechas especiales.
        ~ player_talking = false
        ¡Será posible! Queréis que dediquemos la vida entera a este trabajo, no es justo.
        ¿Y no necesitan preguntarnos primero? Esto es una vergüenza.
        ¿Ni siquiera por navidad? No tenéis corazón.
            +[Es lo que hay. Os aguantáis]
            ->a1
            +[Es una decisión de la directora, y tenemos que cumplirla]
            ->a1
            +[Lo siento, a mí me afecta igual que a vosotras]
            ->a1

    }
}

===a0(opcion)===
Aunque las dos son buenas ideas, vamos a implementar la de {opcion}. ¿Os parece bien?
~ protocol_election = 0
->END

===a1===
~talked_with_nurse_reunion_director = true
->END
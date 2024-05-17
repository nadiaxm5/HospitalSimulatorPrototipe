INCLUDE ../globals.ink

#Speaker: Enferemero
{task_protocol == false: //aqui es false, si está a true es porque es un testeo
    ¿Por qué nos has reunido? Estamos hasta arriba de trabajo.
    ~ player_talking = true
    #Speaker: Tú
    Vamos a cambiar los apósitos que tenemos por otros igual de buenos y más baratos. ¿Os parece bien?
     ~ player_talking = false
    ~ talked_with_nurse_reunion = true
    
    ->END
  - else:
    {talked_with_director_phone == false:
        #Speaker: Enferemero
        ¿Qué ocurre? ¿Por qué nos has reunido?
         ~ player_talking = true
         #Speaker: Tú
         Os he reunido para hacer un protocolo. En el orden del día de hoy, nos enfocaremos exclusivamente en llegar a un acuerdo sobre cómo implementar las citas no presenciales.
          ~ player_talking = false
          #Speaker: Enferemero
          ¿Qué problema hay con las citas presenciales?
           ~ player_talking = true
           #Speaker: Tú
          Si damos citas no presenciales a los casos que no necesitan ser visitados físicamente, habrá menos saturación en el hospital. 
          
          ¿Tenéis alguna propuesta de cómo implementarlas?
           ~ player_talking = false
           #Speaker: Enferemero
           Podríamos ofrecer consultas por mensajería.
           #Speaker: Enferemera
           Pues yo creo que sería mejor por videollamada.
           
            +[Mensajería]
            ->a0("mensajeria")
            
            +[Videollamada]
            ->a0("videollamada")
            
            +[Ninguna de las dos opciones]
            ~ player_talking = true
                #Speaker: Tú
                No me convence. Ya pensaré algo más adelante.
            ~ player_talking = false
            ~ protocol_election = 1
            ->END
        -else:
        #Speaker: Enferemero
        ¿Cuál es la emergencia?
        #Speaker: Tú
        ~ player_talking = true
        Me han dado una mala noticia desde dirección, y os la tengo que comunicar. A partir de ahora, no se permiten vacaciones en fechas especiales.
        ~ player_talking = false
        #Speaker: Enferemero
        ¡Será posible! Queréis que dediquemos la vida entera a este trabajo, no es justo.
        #Speaker: Enferemera
        ¿Y no necesitan preguntarnos primero? Esto es una vergüenza.
        #Speaker: Enferemero
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
#Speaker: Tú
Aunque las dos son buenas ideas, vamos a implementar la de {opcion}. ¿Os parece bien?
~ protocol_election = 0
->END

===a1===
~talked_with_nurse_reunion_director = true
->END
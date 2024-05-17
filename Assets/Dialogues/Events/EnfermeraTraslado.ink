INCLUDE ../globals.ink
#Speaker: Enferemera
{talked_wtih_nurse_transfer == false:
    Hay que trasladar a un paciente a otro hospital, y debe acompañarlo una enfermera. A lo mejor alguna de las que tienen el día libre pueden hacerlo.
    ~ talked_wtih_nurse_transfer = true
  - else:
    ->a0
}
->END

-(a0)
{times_talked_with_nurses >= 3:
    Si ninguna de las que no están aquí puede, ¿a quién mandarás?
    +[La enfermera que está dando medicinas a los pacientes]->ELECCION
    +[La enfermera que está sacando sangre a un paciente]->ELECCION
    +[La enfermera que está hablando contigo]->ELECCION
    
  - else:
    Sigue intentando contactar con las enfermeras que libran hoy.
}

===ELECCION===
~ emergency = false
->END



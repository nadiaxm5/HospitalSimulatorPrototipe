INCLUDE ../globals.ink
#Speaker: Enferemera
{talked_with_nurse_1 == false:
    No voy a poder, tengo a los niños todo el día y nadie los puede cuidar. Inténtalo con otra enfermera.
    ~ talked_with_nurse_1 = true
    ~ times_talked_with_nurses += 1
  - else:
  #Speaker: Tú
    Creo que no deberia llamarla otra vez.
}
->END

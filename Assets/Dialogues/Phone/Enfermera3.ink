INCLUDE ../globals.ink

#Speaker: Enferemera
{talked_with_nurse_3 == false:
    Imposible, no estoy en la ciudad. Tendrá que hacerlo otra persona.
    ~ talked_with_nurse_3 = true
    ~ times_talked_with_nurses += 1
  - else:
  #Speaker: Tú
    Creo que no deberia llamarla otra vez.
}

->END
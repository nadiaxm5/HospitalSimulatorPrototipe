INCLUDE ../globals.ink

{talked_with_nurse_2 == false:
    Lo siento, es mi día libre y no me podéis obligar a venir. Que lo haga otro.
    ~ talked_with_nurse_2 = true
    ~ times_talked_with_nurses += 1
  - else:
    Creo que no deberia llamarla otra vez.
}

->END
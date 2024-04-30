INCLUDE ../globals.ink
{talked_with_salesman == false:
    Hola, ¿habéis decidido si compráis los apósitos?

    Aún no. Llamo para pedirte un informe detallado de los apósitos.

    Claro, ahora te lo mando.
    
    ~ talked_with_salesman = true
  - else:
    No creo que deba llamarlo ahora.
}

->END
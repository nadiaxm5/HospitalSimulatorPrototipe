INCLUDE ../globals.ink
#Speaker: Comercial
{talked_with_salesman == false:
    Hola, ¿habéis decidido si compráis los apósitos?
    ~player_talking = true
    #Speaker: Tú
    Aún no. Llamo para pedirte un informe detallado de los apósitos.
    ~player_talking = false
    #Speaker: Enferemera
    Claro, ahora te lo mando.
    
    ~ talked_with_salesman = true
  - else:
    #Speaker: Tú
    No creo que deba llamarlo ahora.
}

->END
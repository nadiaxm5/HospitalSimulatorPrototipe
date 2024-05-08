INCLUDE ../globals.ink

{talked_with_angryman == false:
    No he podido venir a la reunión, y ahora me entero de que cambiamos los apósitos. ¿Y si estos son peores? No me fío.
    ~ player_talking = true
    Llamaré al vendedor y le pediré un informe detallado de los apósitos, para que veas que son igual de buenos.
    ~ player_talking = false
    ~ talked_with_angryman = true

    ->END
  - else:
    ¿Y bien? ¿Te ha mandado el informe?
    ~ player_talking = true
   Sí, aquí lo tienes. Como puedes ver, es la misma comodidad y facilidad de uso, pero con un precio menor.
   ~ player_talking = false
    Bueno. Te tendré que creer. Pero no tomes más decisiones así si no estamos TODOS.

}

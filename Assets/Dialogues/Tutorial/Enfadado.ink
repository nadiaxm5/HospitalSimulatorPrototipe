INCLUDE ../globals.ink

{talked_with_angryman == false:
    No he podido venir a la reunión, y ahora me entero de que cambiamos los apósitos. ¿Y si estos son peores? No me fío.

    <color=\#00ff00>Llamaré al vendedor y le pediré un informe detallado de los apósitos, para que veas que son igual de buenos.

    ~ talked_with_angryman = true

    ->END
  - else:
    ¿Y bien? ¿Te ha mandado el informe?
    
    <color=\#00ff00>Sí, aquí lo tienes. Como puedes ver, es la misma comodidad y facilidad de uso, pero con un precio menor.
    
    Bueno. Te tendré que creer. Pero no tomes más decisiones así si no estamos TODOS.

}

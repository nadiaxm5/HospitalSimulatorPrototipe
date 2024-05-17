INCLUDE ../globals.ink

#speaker: Directora
{talked_with_director_phone == false:
    {talked_with_director == false: Encantada, soy la directora del hospital. Si quieres aprender sobre tus funciones, vuelve a hablar conmigo. Pero ahora, ve a la sala de reuniones a conocer al equipo.| Tus funciones serán coordinar y supervisar al personal de enfermería y colaborar con otros departamentos como los médicos, administración y RRHH para la gestión de recursos y la coordinación de personal. }

~ talked_with_director = true
~ current_mission = "Habla con el enfermero"
->END
  - else:
    Gracias por venir. La dirección ha decidido que no se va a permitir hacer vacaciones en fechas especiales. 
    Necesito que se lo comuniques al equipo de enfermeras.
    ~ talked_with_director_reunion = true
    ->END
}
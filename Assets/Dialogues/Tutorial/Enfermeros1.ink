INCLUDE ../globals.ink


{emergency == false: {personaje == 1:Bienvenida |Bienvenido} al equipo de enfermería. ¡Espero que tengas un primer día tranquilo! ->FIN |Se acabó la tranquilidad. Nuestro compañero se ha ido por una emergencia personal. Era responsable de administrar medicamentos críticos a un paciente en estado grave.} 
->NEXT

===NEXT===

Yo termino ahora mi turno, y las otras enfermeras tienen otras tareas. ¿Quién se encarga de hacerlo? 
+[La enfermera que prepara el informe de turno]
    Tus acciones tienen consecuencias. Con tu elección has disminuido el caos del hospital sin afectar a la felicidad de los pacientes o del equipo. ¡Enhorabuena!
    ->END
+[La enfermera que entrega alimentos a los pacientes]
    Tus acciones tienen consecuencias. Con tu elección has disminuido el caos del hospital, pero has afectado a la felicidad de los pacientes.
    ->END
+[El enfermero que iba a terminar el turno]
    Tus acciones tienen consecuencias. Con tu elección has disminuido el caos del hospital, pero has afectado a la felicidad del equipo. 
    ->END

===FIN===
~ emergency = true
->END
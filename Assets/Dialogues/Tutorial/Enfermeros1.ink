INCLUDE ../globals.ink

#Speaker: Enferemero
{emergency == false: {personaje == 1:Bienvenida |Bienvenido} al equipo de enfermería. ¡Espero que tengas un primer día tranquilo! ->FIN |Se acabó la tranquilidad. Nuestro compañero se ha ido por una emergencia personal. Era responsable de administrar medicamentos críticos a un paciente en estado grave.} 
->NEXT

===NEXT===
#Speaker: Enferemero
Yo termino ahora mi turno, y las otras enfermeras tienen otras tareas. ¿Quién se encarga de hacerlo? 

+[La enfermera que prepara el informe de turno]
    ¿La enfermera que prepara el informe de turno?
    ->FINEMERGENCIA(0)
+[La enfermera que entrega alimentos a los pacientes]
    ¿La enfermera que entrega alimentos a los pacientes?
    ->FINEMERGENCIA(1)
+[El enfermero que iba a terminar el turno]
    ¿El enfermero que iba a terminar el turno?
    ->FINEMERGENCIA(2)

===FIN===
~ emergency = true
->END

===FINEMERGENCIA(election)===
~ emergency = false
~ emergency_election = election
~ emergency_ended = true
->END
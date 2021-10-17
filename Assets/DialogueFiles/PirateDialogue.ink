VAR resource = "Pirate"
VAR correct = false

Gasto: I am Gasto, a plague on this sector where you have wondered in. In order to pass, I require you pay me homage or play a little game of riddles with me.
AstroNaut: Well, we can't lose our cargo. We need it for our homeplanet.
Gasto: Then it appears your have no choice but to play... Let us Begin!
->Riddle

==Riddle==
Twigs, but no roots. Faring forever over the sand. Filmmakers love me, but ranchers hate me. I came here form the Motherland, isn't life grand?
***A Toxic weed
->Incorrect
***A Moss tent
->Incorrect
***A Rake Tumbleweed
->Correct
***A Wild Flower
->Incorrect

==Incorrect==
Gasto: How shameful it must be to lose all those resources you need so very much... Farewell, and I wish you... the best.
->DONE

==Correct==
Gasto: It appears you have beaten me at my own game. You may pass, but I am sure out paths will cross again... the exit is behind you.
->DONE
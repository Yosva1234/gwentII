using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using gwentii;
using Unity.Collections.LowLevel.Unsafe;
using Unity.VisualScripting;
using UnityEngine;


namespace gwentii{
public class compila : MonoBehaviour
{
    public string texto="", errors=""; 
     metodosauxiliares metodos = new metodosauxiliares();
     comprobaciones comprobarerrores = new comprobaciones();
     hacerefect parcerdeefectro = new hacerefect();
     hacercartas parcearcartas = new hacercartas();

      public static  List<Effect> effectlist = new List<Effect>();
      public static  List<Card> cardlist = new List<Card>();


     
    public void RUN()
    {
        errors="";

      List <Token> tokenlist = metodos.codigoconverttotoken(texto);  

     if(comprobarerrores.comprobardelimitadores(tokenlist,errors)) return ; 

        

     if(parcerdeefectro.asignacion(tokenlist,effectlist,errors)) return;


     if(parcearcartas.asignacion(tokenlist,cardlist,errors)) return;   

      codigogenerator.sobrescribiracrcivo(effectlist);
   
    }   

}
}








/*   
        effect
        {
            Name: "Draw"
            Action: (targets, context) =>
            {
                topCard = context.Deck.Pop();
                context.Hand.Add(topCard);
                context.Hand.Shuffle();
            }
        }

       
        effect
        {
            Name: "Damage",
            Params:
            {
                Amount: Number
            },
            Action: (targets, context) =>
            {
                for target in targets
                {
                    i = 0;
                    while (i < Amount)
                    {
                        target.Power -= 1;
                        i+=1;
                    }
                };

            }
        }

           effect
        {
            Name: "ReturnToDeck"
            Action: (targets, context) =>
            {
                for target in targets
                {
                    owner = target.Owner;
                    deck = context.DeckOfPlayer(owner);
                    deck.Push(target);
                    deck.Shuffle();
                    context.Board.Remove(target);
                };
            }
        }


        card {
            Type: "Oro",
            Name: "el lindo 3323",
            Faction: "Northern Realms",
            Power: 10,
            Range: ["Melee", "Ranged"],
            OnActivation: [
                {
                    Effect: {
                        Name: "Damage",
                        Amount:2,
                    },


                    Selector: {
                        Source: "otherfield",
                        Single: false,
                        Predicate: (unit) => unit.Faction == "Northern Realms"
                    
                    
                    },
                },
            ]
        }
         card {
            Type: "Oro",
            Name: "mi belleza 56",
            Faction: "Northern Realms",
            Power: 10,
            Range: ["Melee", "Ranged"],
            OnActivation: [
                {
                    Effect: {
                        Name: "Damage",
                        Amount: 1,
                    },


                    Selector: {
                        Source: "board",
                        Single: false,
                        Predicate: (unit) => unit.Faction == "Northern Realms"
                    },
                },
            ]
        }

 card {
            Type: "Oro",
            Name: "perrisima",
            Faction: "Northern Realms",
            Power: 10,
            Range: ["Melee", "Ranged"],
            OnActivation: [
                {
                    Effect: {
                        Name: "Draw",
                    },


                    Selector: {
                        Source: "board",
                        Single: false,
                        Predicate: (unit) => unit.Faction == "Northern Realms"
                    },
                
                    
                },
            ]
        }



card
    {
        Type: "Oro",
        Name: "El lindo",
        Faction: "Elementales",
        Power: 10,
        Range: ["Melee", "Ranged"],
        OnActivation:
        [
            {
                Effect:
                {
                    Name: "Damage",
                    Amount: 2,
                },
                Selector:
                {
                    Source: "board",
                    Single: false,
                    Predicate: (unit) => unit.Faction == "Celestial"
                },
            },
        ]
    }  

     card {
            Type: "Oro",
            Name: "Beluga",
            Faction: "Northern Realms",
            Power: 10,
            Range: ["Melee", "Ranged"],
            OnActivation: [
                {
                    Effect: {
                        Name: "Damage",
                        Amount: 5,
                    },


                    Selector: {
                        Source: "board",
                        Single: false,
                        Predicate: (unit) => unit.Faction == "Northern Realms"
                    },
                },
            ]
        }



    card
    {
        Type: "Oro",
        Name: "El feo",
        Faction: "Elementales",
        Power: 10,
        Range: ["Melee", "Ranged"],
        OnActivation:
        [
            {
                Effect:
                {
                    Name: "Damage",
                    Amount: 2,
                },
                Selector:
                {
                    Source: "otherfield",
                    Single: false,
                    Predicate: (unit) => unit.Faction == "Dark"
                },
            },
        ]
    }  
    card
    {
        Type: "Oro",
        Name: "El lindo 45",
        Faction: "Elementales",
        Power: 10,
        Range: ["Melee", "Ranged"],
        OnActivation:
        [
            {
                Effect:
                {
                    Name: "Draw",
                },
            },
        ]
    }  
    card
    {
        Type: "Oro",
        Name: "El feo+",
        Faction: "Elementales",
        Power: 10,
        Range: ["Melee", "Ranged"],
        OnActivation:
        [
            {
                Effect:
                {
                    Name: "Draw",
                },
            },
        ]
    }   
    card
    {
        Type: "Oro",
        Name: "El lindo++",
        Faction: "Elementales",
        Power: 10,
        Range: ["Melee", "Ranged"],
        OnActivation:
        [
            {
                Effect:
                {
                    Name: "ReturnToDeck",
                },
                Selector:
                {
                    Source: "board",
                    Single: false,
                    Predicate: (unit) => unit.Power  < 4 
                },
            },
        ]
    }  

  

    card
    {
        Type: "Oro",
        Name: "El feo++",
        Faction: "Elementales",
        Power: 10,
        Range: ["Melee", "Ranged"],
        OnActivation:
        [
            {
                Effect:
                {
                     Name: "ReturnToDeck",
                },
                Selector:
                {
                    Source: "board",
                    Single: false,
                    Predicate: (unit) =>  unit.Power  < 4
                }, 
            },
        ]
    }  
  

 */
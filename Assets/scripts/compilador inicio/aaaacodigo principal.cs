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

   
//
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

    /*foreach( Card carta in cardlist)
     {
         Debug.Log(carta.Name);

        foreach( Effect ecefto in carta.efectosdelacarta)
        {
            Debug.Log(ecefto.name);
            foreach(var param in ecefto.Params)
            {
                Debug.Log(param.Key);
                Debug.Log(param.Value.ToString());
            }
           
        }
     }
     */
     

     

       //codigogenerator.sobrescribiracrcivo(effectlist);


/*
            Debug.Log("yes");

        // cambiar camara para la posicion del campo de juego      
      
        for (int x = 0; x<effectlist.Count; x++)
        {
          Debug.Log(effectlist[x].name);
          
          foreach (var param in effectlist[x].Params)
          {
            Debug.Log(param.Key);
            Debug.Log(param.Value.ToString());
          }

        }

       // Debug.Log(cardlist.Count);

        for (int x = 0; x<cardlist.Count; x++)
        {

          Debug.Log(cardlist[x].Name);
          Debug.Log(cardlist[x].Power);
          Debug.Log(cardlist[x].Type.ToString());
          Debug.Log(cardlist[x].Faction);

        }
        
*/






   
    }


    

}
}








/*
effect
{
Name:"hola",

Params : 
{
Amount : Number
}
}

card 
{
  Name:"carta1",
  Power: 10,
  Type: "Oro",
  Faction: " la morronga 33 ",
  Range: ["Melee ",  "Ranged" , "Sieged"],
}

      
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


        card {
            Type: "Oro",
            Name: "Beluga",
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
                    PostAction: {
                        Effect: {
                            Name: "ReturnToDeck",
                        },
                        Selector: {
                            Source: "parent",
                            Single: false,
                            Predicate: (unit) => unit.Power < 1
                        },
                        PostAction: {
                            Effect: {
                                Name: "Draw",
                            },
                        },
                    },
                },
            ]
        }
         card {
            Type: "Oro",
            Name: "Draw",
            Faction: "Northern Realms",
            Power: 10,
            Range: ["Melee", "Ranged"],
            OnActivation: [
                {
                    Effect: {
                        Name: "Damage",
                    },


                    Selector: {
                        Source: "board",
                        Single: false,
                        Predicate: (unit) => unit.Faction == "Northern Realms"
                    },
                    PostAction: {
                        Effect: {
                            Name: "ReturnToDeck",
                        },
                        Selector: {
                            Source: "parent",
                            Single: false,
                            Predicate: (unit) => unit.Power < 1
                        },
                        PostAction: {
                            Effect: {
                                Name: "Draw",
                            },
                        },
                    },
                },
            ]
        }

 card {
            Type: "Oro",
            Name: "perra33",
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
                    PostAction: {
                        Effect: {
                            Name: "ReturnToDeck",
                        },
                        Selector: {
                            Source: "parent",
                            Single: false,
                            Predicate: (unit) => unit.Power < 1
                        },
                        PostAction: {
                            Effect: {
                                Name: "Draw",
                            },
                        },
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
                    PostAction: {
                        Effect: {
                            Name: "ReturnToDeck",
                        },
                        Selector: {
                            Source: "parent",
                            Single: false,
                            Predicate: (unit) => unit.Power < 1
                        },
                        PostAction: {
                            Effect: {
                                Name: "Draw",
                            },
                        },
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
                    Source: "board",
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
                    context.Hand.Remove(target);
                };
            }
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
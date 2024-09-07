
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using System;
using UnityEngine.SceneManagement;
using UnityEngine.EventSystems;

namespace gwentii{
public class hacertokens : MonoBehaviour
{

   

    public TMP_Text texto, errors; 
    
    

    public void RUN()
    {
        errors.text="";

     metodosauxiliares metodos = new metodosauxiliares();
     comprobaciones comprobarerrores = new comprobaciones();
     hacerefect parcerdeefectro = new hacerefect();
     hacercartas parcearcartas = new hacercartas();

     List <Token> tokenlist = metodos.codigoconverttotoken(texto.text);  
     List<Effect> effectlist = new List<Effect>();
     List<Card> cardlist = new List<Card>();

     if(comprobarerrores.comprobardelimitadores(tokenlist,errors)) return ; 
     if(parcerdeefectro.asignacion(tokenlist,effectlist,errors)) Debug.Log("hay error");
     if(parcearcartas.asignacion(tokenlist,cardlist,errors)) Debug.Log("hay error");


      
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

          Debug.Log(cardlist[x].name);
          Debug.Log(cardlist[x].power);
          Debug.Log(cardlist[x].tipo.ToString());
          Debug.Log(cardlist[x].faction);

        }



   
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




 */
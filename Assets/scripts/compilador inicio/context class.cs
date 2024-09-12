using System.Collections;
using System.Collections.Generic;
using gwentii;
using UnityEngine;
namespace gwentii{
public class contextclass : MonoBehaviour
{
    
    public bool TriggerPlayer{get;}
    public List<Card> Deckplayer1 {get; set;}
    public List<Card> Deckplayer2 {get; set;}
    public List<Card> Handplayer1 {get; set;}
    public List<Card> Handplayer2 {get; set;}
    public List<Card> Fieldplayer1 {get; set;}
    public List<Card> Fieldplayer2 {get; set;}

    public contextclass( List <Card> Hand1 , List <Card> Hand2, List <Card> Deck1, List <Card> Deck2, List <Card> Field1, List <Card> field2)
    {
        Handplayer1 = Hand1;
        Handplayer2 = Hand2;
        Deckplayer1 = Deck1;
        Deckplayer2 = Deck2;
        Fieldplayer1 = Field1;
        Fieldplayer2 = field2;           

    }



   public List <Card> HandOfPlayer( bool player )
   {
    if(player) return Handplayer1;
    return Handplayer2;
   }


    public List <Card> FieldOfPlayer( bool player )
   {
    if(player) return Fieldplayer1;
    return Fieldplayer2;
   }

    public List <Card> DeckOfPlayer( bool player )
   {
    if(player) return Deckplayer1;
    return Deckplayer2;
   }

    public List <Card> Hand( )
    {
        return HandOfPlayer(TriggerPlayer);
    }

   public List <Card> Deck(  )
    {
        return DeckOfPlayer(TriggerPlayer);
    }

    public List <Card> Field(  )
    {
        return FieldOfPlayer(TriggerPlayer);
    }

    public List<Card> Board ()
    {
        List <Card> newlist = new List<Card>();

        for(int x =0; x<Fieldplayer1.Count; x++) newlist.Add(Fieldplayer1[x]);
        for(int x =0; x<Fieldplayer2.Count; x++) newlist.Add(Fieldplayer2[x]);

        return newlist;

    }



}

public static class ListException
{
    public static void Push<Card>(this List<Card> list, Card carta)
    {
        list.Insert(0,carta);
    }

    public static Card Pop(this List<Card> list)
    {
        Card newcard = list[0];
        list[0].Power = -1;
        return newcard;
    }

    public static void SendBottom( this List<Card> list, Card carta)
    {
        list.Add(carta);
    }

    public static void Shuffle(this List<Card> list)
    {
            Debug.Log("sfufle");
    }

    public static void Removeitem(this List<Card> list, Card card)
    {
        card.Power = -1;
    }

    public static void Additem(this List<Card> list, Card card)
    {

     VisualCard cartavisual = check(card);

     Debug.Log(cartavisual.card.name);

     GameObject padre = Card.correspondencia[list];

     Debug.Log(padre.transform.childCount);

     cartavisual.transform.SetParent(padre.transform);

    }

    static VisualCard check(Card carta)
    {
        VisualCard visualcard = new VisualCard();

        for(int x = 0; x<GameManager.Instancia.hand1.transform.GetComponentsInChildren<VisualCard>().Length; x++)
        {
            if(GameManager.Instancia.hand1.transform.GetComponentsInChildren<VisualCard>()[x].card == carta)
            {
              return  GameManager.Instancia.hand1.transform.GetComponentsInChildren<VisualCard>()[x];
            }
        }    

        for(int x = 0; x<GameManager.Instancia.hand2.transform.GetComponentsInChildren<VisualCard>().Length; x++)
        {
            if(GameManager.Instancia.hand2.transform.GetComponentsInChildren<VisualCard>()[x].card == carta)
            {
              return  GameManager.Instancia.hand2.transform.GetComponentsInChildren<VisualCard>()[x];
            }
        }  

        for(int x = 0; x<GameManager.Instancia.rowM1.transform.GetComponentsInChildren<VisualCard>().Length; x++)
        {
            if(GameManager.Instancia.rowM1.transform.GetComponentsInChildren<VisualCard>()[x].card == carta)
            {
              return  GameManager.Instancia.rowM1.transform.GetComponentsInChildren<VisualCard>()[x];
            }
        }  

        for(int x = 0; x<GameManager.Instancia.rowM2.transform.GetComponentsInChildren<VisualCard>().Length; x++)
        {
            if(GameManager.Instancia.rowM2.transform.GetComponentsInChildren<VisualCard>()[x].card == carta)
            {
              return  GameManager.Instancia.rowM2.transform.GetComponentsInChildren<VisualCard>()[x];
            }
        }  

        for(int x = 0; x<GameManager.Instancia.rowR1.transform.GetComponentsInChildren<VisualCard>().Length; x++)
        {
            if(GameManager.Instancia.rowR1.transform.GetComponentsInChildren<VisualCard>()[x].card == carta)
            {
              return  GameManager.Instancia.rowR1.transform.GetComponentsInChildren<VisualCard>()[x];
            }
        }  

        for(int x = 0; x<GameManager.Instancia.rowR2.transform.GetComponentsInChildren<VisualCard>().Length; x++)
        {
            if(GameManager.Instancia.rowR2.transform.GetComponentsInChildren<VisualCard>()[x].card == carta)
            {
              return  GameManager.Instancia.rowR2.transform.GetComponentsInChildren<VisualCard>()[x];
            }
        }  

        for(int x = 0; x<GameManager.Instancia.rowS1.transform.GetComponentsInChildren<VisualCard>().Length; x++)
        {
            if(GameManager.Instancia.rowS1.transform.GetComponentsInChildren<VisualCard>()[x].card == carta)
            {
              return  GameManager.Instancia.rowS1.transform.GetComponentsInChildren<VisualCard>()[x];
            }
        }  

        
        for(int x = 0; x<GameManager.Instancia.rowS2.transform.GetComponentsInChildren<VisualCard>().Length; x++)
        {
            if(GameManager.Instancia.rowS2.transform.GetComponentsInChildren<VisualCard>()[x].card == carta)
            {
              return  GameManager.Instancia.rowS2.transform.GetComponentsInChildren<VisualCard>()[x];
            }
        }  

        for(int x = 0; x<GameManager.Instancia.deck1.transform.GetComponentsInChildren<VisualCard>().Length; x++)
        {
            if(GameManager.Instancia.deck1.transform.GetComponentsInChildren<VisualCard>()[x].card == carta)
            {
              return  GameManager.Instancia.deck1.transform.GetComponentsInChildren<VisualCard>()[x];
            }
        }  

         for(int x = 0; x<GameManager.Instancia.deck2.transform.GetComponentsInChildren<VisualCard>().Length; x++)
        {
            if(GameManager.Instancia.deck2.transform.GetComponentsInChildren<VisualCard>()[x].card == carta)
            {
              return  GameManager.Instancia.deck2.transform.GetComponentsInChildren<VisualCard>()[x];
            }
        }  


        return visualcard;
    }

    


}
}
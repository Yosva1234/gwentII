using System.Collections;
using System.Collections.Generic;
using gwentii;
using UnityEngine;
namespace gwentii{
public class contextclass : MonoBehaviour
{
    
    public bool TriggerPlayer{get;}
    public List<Card> Deckplayer1 = new List<Card>();
    public List<Card> Deckplayer2 = new List<Card>();
    public List<Card> Handplayer1 = new List<Card>();
    public List<Card> Handplayer2 = new List<Card>();
    public List<Card> Fieldplayer1 = new List<Card>();
    public List<Card> Fieldplayer2 = new List<Card>();



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
        list.RemoveAt(0);
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

    



}
}
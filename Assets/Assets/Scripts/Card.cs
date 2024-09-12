using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using gwentii;
using Unity.VisualScripting;
using UnityEngine;

namespace gwentii{
public enum CardType {oro,plata,clima,aumento,despeje,senuelo,lider,error}
public enum Faction {Elementales , Oscuridad}
public enum Range {M,R,S}
public enum CardEffects{oro,plata,senuelo,despeje,clima,aumento,No_Effect}
public enum LiderEffects{Destruccion,Recuperacion}

[CreateAssetMenu(fileName = "New Card" , menuName = "Card")]
public class Card : MonoBehaviour
{
    public string Name;
    public int Power;
    public bool IsCreated;
    public Sprite CardPhoto;
    public bool Owner;
    public CardType Type;
    public Faction Faction;
    public Range [] ranges = {Range.M}; 
    public CardEffects EffectType;
    public LiderEffects EffectLeader;
    public List <Effect> efectosdelacarta = new List<Effect>();
    public Selector selectorcard;

    public Card (string name, int power, CardType tipo, string faction, List <rangetype> rangos )
    {
            this.Name = name;

            this.Power = power;

            this.Type = tipo;

            //this.selectorcard = selectorcard;

            ranges = new Range[rangos.Count];
            for (int x = 0; x<rangos.Count; x++)
            {
                if(rangos[x] == rangetype.Melee) ranges[x] = Range.M;
                if(rangos[x] == rangetype.Siege) ranges[x] = Range.S;
                if(rangos[x] == rangetype.Ranged) ranges[x] = Range.R;
            }

    }

    public void addefect( Effect effectforthis)
    {

            

    }


    public Card ()
    {

    }


     public List<Card> ObtenerListaDeHijosDeTipoCard(GameObject objetoPadre)
    {
        List<Card> listaDeHijosDeTipoCard = new List<Card>();
       
       VisualCard [] hijos = objetoPadre.transform.GetComponentsInChildren<VisualCard>();

            for(int x = 0; x<hijos.Length; x++)
            {
                listaDeHijosDeTipoCard.Add(hijos[x].card);
            }

            correspondencia.Add(listaDeHijosDeTipoCard,objetoPadre);

       return listaDeHijosDeTipoCard;
    }

    public List <Card> makeboard(List <Card> list1, List<Card> list2, List<Card>lista3)
    {
        List <Card> Board = new List<Card>();

        foreach(Card carta in list1)
        Board.Add(carta);

        foreach(Card carta in list2)
        Board.Add(carta);

        foreach(Card carta in lista3)
        Board.Add(carta);

//        Debug.Log(Board.Count);

       Debug.Log(list1.Count+list2.Count+lista3.Count);

       return Board;

    }

    public static Dictionary<List<Card>,GameObject> correspondencia; 

        public void ActivateEffect(GameObject DroppedCard)
    {

        if (DroppedCard.transform.GetComponent<VisualCard>().card.IsCreated)
        {
            correspondencia = new Dictionary<List<Card>, GameObject>();

           contextclass contexto = new contextclass(ObtenerListaDeHijosDeTipoCard(GameManager.Instancia.hand1),ObtenerListaDeHijosDeTipoCard(GameManager.Instancia.hand2), ObtenerListaDeHijosDeTipoCard(GameManager.Instancia.deck1), ObtenerListaDeHijosDeTipoCard(GameManager.Instancia.deck2), makeboard(ObtenerListaDeHijosDeTipoCard(GameManager.Instancia.rowM1),ObtenerListaDeHijosDeTipoCard(GameManager.Instancia.rowR1),ObtenerListaDeHijosDeTipoCard(GameManager.Instancia.rowS1)), makeboard(ObtenerListaDeHijosDeTipoCard(GameManager.Instancia.rowM2),ObtenerListaDeHijosDeTipoCard(GameManager.Instancia.rowR2),ObtenerListaDeHijosDeTipoCard(GameManager.Instancia.rowS2)));
            
            foreach(Effect efectoactual in efectosdelacarta)
            {
                actions.start(efectoactual.name,selectorcard.filtrar(contexto),contexto,efectoactual.Params);
                Debug.Log("efecto activado");
            }

            return ;

        }


        if(EffectType == CardEffects.aumento)
        {
            Effects.Aumento(DroppedCard.transform);
        }
        else if(EffectType == CardEffects.clima)
        {
            Effects.ClimaResta(DroppedCard.transform.parent);
        }
        else if(EffectType == CardEffects.senuelo)
        {
            Effects.Senuelo(DroppedCard.transform.parent);
        }
        else if(EffectType == CardEffects.despeje)
        {
            Effects.Despeje(DroppedCard.transform.parent);
        }
        else if(EffectType == CardEffects.oro)
        {
            Effects.Oro(DroppedCard.transform);
        }
        else if(EffectType == CardEffects.plata)
        {
            Effects.Plata(DroppedCard.transform);
        }
    }
      
}
}
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
public class Card : ScriptableObject
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

    public Card (string name, int power, CardType tipo, string faction, List <rangetype> rangos )
    {
            this.Name = name;

            this.Power = power;

            this.Type = tipo;

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
        public void ActivateEffect(GameObject DroppedCard)
    {

        if (DroppedCard.transform.GetComponent<VisualCard>().card.IsCreated)
        {
            
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

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using System;
using UnityEngine.SceneManagement;
using UnityEngine.EventSystems;

namespace gwentii{
public class Card
{
  public cardtype tipo {get ;}
  public string name {get ;}
  public int power {get ; set;}
  public string faction{get;}
  public List<rangetype> ranges{get ;}

  public Card(string name, int power, cardtype tipo, string faction)
  {
    this.name = name;
    this.power = power;
    this.tipo = tipo;
    this.faction = faction;
    ranges = new List<rangetype>();
  }

  public void addrange( rangetype newrange)
  {
    ranges.Add(newrange);
  }
    

}

// ---------------------------------------------------------------- CREO LAS CARATS
public class hacercartas
{

   

}
}
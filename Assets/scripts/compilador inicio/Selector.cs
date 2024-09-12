using System;
using System.Collections;
using System.Collections.Generic;
using gwentii;
using UnityEngine;


public enum Source 
{
    board,
    hand,
    otherhand,
    field,
    otherfield,
    deck,
    otherdeck,
    vacio
}
public class Selector 
{
  public bool single;
  List<Token> predicate;
  Source sourse;

  public Selector (bool single, Source sourse, List<Token>predicate)
  {
    this.single = single;
    this.sourse = sourse;
    this.predicate = predicate;
  }

  public List<Card> filtrar (contextclass contexto)
  {

   List<Card> devolucion = new List<Card>();

    if(sourse == Source.board)
    devolucion = contexto.Board();

    if(sourse == Source.hand)
    devolucion = contexto.Hand();

    if(sourse == Source.deck) 
    devolucion = contexto.Deck();

    if(sourse == Source.field) 
    devolucion = contexto.Field();

    if(sourse == Source.otherhand)
    devolucion = contexto.HandOfPlayer(!contexto.TriggerPlayer);

    if(sourse == Source.otherdeck) 
    devolucion = contexto.DeckOfPlayer(!contexto.TriggerPlayer);

    if(sourse == Source.otherfield)
    devolucion = contexto.FieldOfPlayer(!contexto.TriggerPlayer);

    Debug.Log(devolucion.Count);


   return devolucion;

  }
  
}

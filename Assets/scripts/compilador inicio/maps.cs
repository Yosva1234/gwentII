using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using System;
using UnityEngine.SceneManagement;
using UnityEngine.EventSystems;
using System.Linq;
using Unity.VisualScripting.Antlr3.Runtime;
using Unity.VisualScripting;


namespace Gwentii{
public  class maps : MonoBehaviour
{

     public List<char> Especialcharacters = new List<char>();
    public List<string> WordReservated = new List<string>();
    public List <string> Funtions = new List<string>();
   public List <string> variables = new List<string>();
   public List <string> variablestype = new List<string>();
    public maps()
    {
        asiganrcaracteres(this.Especialcharacters, this.WordReservated, this.Funtions);
    }
    
    public void decirword()
    {
        Debug.Log("hello");
    }

     void asiganrcaracteres(List <char> CharactersEspecial,List <string> WordReservated, List <string> funtions)
    {

    aux('=');
    aux('-');
    aux('*');
    aux('+');  
    aux(';');
    aux('(');
    aux(')');
    aux('[');
    aux(']');
    aux('{');
    aux('}');
    aux('/');
    aux('&');
    aux('>');
    aux('<');
    aux('"');
    aux(':');
    aux(',');
    aux('@');

    aux2("effect");
    aux2("Effect");
    aux2("Name");
    aux2("Params");
    aux2("Amount");
    aux2("Number");
    aux2("targets");
    aux2("context");
    aux2("for");
    aux2("in");
    aux2("while");
    aux2("Action");
    aux2("card");
    aux2("Type");
    aux2("Faction");
    aux2("Power");
    aux2("Range");
    aux2("OnActivation");
    aux2("Selector");
    aux2("Sourse");
    aux2("Single");
    aux2("Predicate");
    aux2("unit");

    


    aux3("Hand");
    aux3("Add");
    aux3("Shuffle");
    aux3("Owner");
    aux3("DeckOfPlayer");
    aux3("Push");
    aux3("Board");
    aux3("Remove");

    aux4 ("int");
    aux4("double");
    aux4("string");
    aux4("float");
    aux4("char");


    void aux (char c)
    {
        CharactersEspecial.Add(c);
    }

    void aux2(string s)
    {
        WordReservated.Add(s);
    }


    void aux3(string s)
    {
        funtions.Add(s);
    }

    void aux4(string s)
    {
        variablestype.Add(s);
    }

    }



}
}
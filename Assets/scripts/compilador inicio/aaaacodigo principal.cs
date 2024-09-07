
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

     List <Token> tokenlist = metodos.codigoconverttotoken(texto.text);  
     List<Effect> effectlist = new List<Effect>();

     if(comprobarerrores.comprobardelimitadores(tokenlist,errors)) return ; 
     if(parcerdeefectro.asignacion(tokenlist,effectlist,errors)) Debug.Log("hay error");

    //Debug.Log(tokenlist.Count);


     for (int x = 0; x< effectlist.Count; x++)
     {
       
       foreach(var objeto in effectlist[x].Params)
       {
        Console.WriteLine(objeto.Key);
       }

     }
   
    }


    

}
}








/*
Effect
{
Name:"hola"

Params : 
{
Amount : Number
}

}
 */
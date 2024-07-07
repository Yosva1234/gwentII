using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using System;
using UnityEngine.SceneManagement;
using UnityEngine.EventSystems;
using System.Linq;

namespace Gwentii{
public class codigomatriz : MonoBehaviour
{
    maps dictionaries = new maps();   // creo un objeto que cuenta con una funcion para rellenar todos los diccionarios   
     
     
    
   
             
  public  TMP_Text compilador; // de donde extraigo el texto del compilador;
  public  TMP_Text interfazerrors;
       
        ArrayList Aminitokens = new ArrayList();
  
  public void runbutton ()
 {

        string word = "";   
        int cendl = 0;
       int pos = 0;
         
           
         bool verificarendl(char c)
         {
            if(c == '\n') 
            {
                cendl++;
                pos = 0;
                return true;
            }
            else return false;
         }


        for (int x = 0; x < compilador.text.Length; x++)
        {
            pos++;

            if(compilador.text[x] == ' ' || verificarendl(compilador.text[x]))
            {
                if(word.Length !=0)
                {
                    Aminitokens.Add(new minitoken(pos, cendl,word));
                    word="";
                }
            }

            else 
            {

                if (dictionaries.Especialcharacters.Contains(compilador.text[x]))
                {
                      if(word.Length !=0)   Aminitokens.Add(new minitoken(pos,cendl,word));
                        word ="";
                        Aminitokens.Add(new minitoken(pos, cendl, ""+compilador.text[x]));
                }
                else
                word+=compilador.text[x];
            }

        }
       if(word.Length !=0)  Aminitokens.Add(new minitoken(pos,cendl,word));

        tokenizacionclass tokenizacion = new tokenizacionclass(dictionaries, Aminitokens);
        
        interfazerrors.text = tokenizacion.verificarerrordecompilacion();

        

 }


}
}
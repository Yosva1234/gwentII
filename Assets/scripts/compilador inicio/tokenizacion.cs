using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Unity.VisualScripting.Antlr3.Runtime;
using UnityEngine;


namespace Gwentii{
public class tokenizacionclass : MonoBehaviour
{
    
    maps dictionaries;

    ArrayList Aminitokens = new ArrayList();

   public ArrayList tokens = new ArrayList();

    public tokenizacionclass(maps dictionaries, ArrayList Aminitokens)
    {
        this.dictionaries = dictionaries;
        this.Aminitokens = Aminitokens;
        convertir();
    }


    void convertir ()
    {

        foreach (minitoken firstswords in Aminitokens)
        {

            TokenType tipo = new TokenType();
            bool pass = false;

            if(dictionaries.Especialcharacters.Contains(firstswords.name[0])) { tipo = TokenType.CharactersEspecial;  pass = true; }

            if(dictionaries.Funtions.Contains(firstswords.name)) { tipo = TokenType.funtions; pass = true; }

            if(dictionaries.WordReservated.Contains(firstswords.name)) { tipo = TokenType.WordReservated; pass = true;}

            if(dictionaries.variablestype.Contains(firstswords.name)) {tipo = TokenType.variablestype; pass = true; }
            

                // falta codigo de los demas tokentype que aparezcan por el camino


            if(!pass)
            {
                dictionaries.variables.Add(firstswords.name);
            }

            tokens.Add(new token(firstswords, tipo));
            

        }


        

    }


  public string verificarerrordecompilacion ()
  {

    errorsclass errores = new errorsclass(tokens);

     return errores.errorsms;
  }
    


}
}

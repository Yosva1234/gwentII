using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace gwentii{
public class Listasdepalabras 
{//
   
   public List <string> delimitadores = new List<string>();
   public List <string> operadoreslogicos = new List<string>();
   public List <string> boolianos = new List<string>();
    public List <string> operadoresaritmeticos = new List<string>();
    public List <string> asignacion = new List<string>();



    public Listasdepalabras()
    {

        delimitadores.Add("{");
        delimitadores.Add("}");
        delimitadores.Add(";");
        delimitadores.Add(",");
        delimitadores.Add(".");
        delimitadores.Add("[");
        delimitadores.Add("]");
        delimitadores.Add(":");
        delimitadores.Add( '"'.ToString());

        boolianos.Add("true");
        boolianos.Add("false");

        operadoresaritmeticos.Add("+");
         operadoresaritmeticos.Add("-");
          operadoresaritmeticos.Add("*");
           operadoresaritmeticos.Add("/");
            operadoresaritmeticos.Add("^");
               operadoreslogicos.Add("|");
                operadoreslogicos.Add("&");
                operadoreslogicos.Add("<");
                 operadoreslogicos.Add(">");
                    asignacion.Add("@");
                     asignacion.Add("@@");
                      asignacion.Add("=");

                   


    }





    
   

   
   
}
}
using System.Collections;
using System.Collections.Generic;
using gwentii;
using UnityEngine;

namespace gwentii{
public class Token 
{
   
   public string name{get;}
   int fila {get;}
   int columna{get;}
  public tokentype tipo{get;}

   public Token(string name, int fila, int columna, tokentype tipo)
   {
    this.name = name;
    this.fila = fila;
    this.tipo = tipo;
    this.columna = columna;
   }

        public override string ToString()
        {
           
           return $" fila:{fila}  columna: {columna} " + tipo.ToString();

        }

        public string error()
        {
         return "error en " + ToString();
        }


    }
}
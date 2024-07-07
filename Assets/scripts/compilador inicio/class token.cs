using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Gwentii{


public class token : minitoken,Itoken
{


 TokenType tipoaux;

 public token (minitoken Base,  TokenType tipo) : base(Base.fila,Base.columna,Base.name)
 {
   
    tipoaux = tipo;

 }

 public TokenType tipo {get {return tipoaux; }}


 public string error( TokenType tipoesperado )
 {
    
    return $"error se esperaba " + tipoesperado.ToString() + $"( {fila} , {columna} )";

 }

  public override string ToString()
  {
      return $" fila: {fila} , columna {columna} , name : " + name + ", tipo :" + tipo.ToString();
  }

}




}
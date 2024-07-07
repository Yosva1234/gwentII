using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Gwentii{

public interface Iminitoken 
{
    int fila{get ; }
    int columna{get ;}
    string name{ get;}
}

public interface Itoken : Iminitoken
{

 string error(TokenType t);

 TokenType tipo{get;}

}

public enum TokenType
{
    CharactersEspecial,
    WordReservated,
    funtions,
    variables,
    variablestype
}

}
using System.Collections;
using System.Collections.Generic;
using Gwentii;
using Unity.VisualScripting;
using UnityEngine;

namespace Gwentii{
public class minitoken : Iminitoken
{
    
 public int filaaux, columnaaux;

 public string nombreaux;

 public minitoken (int filaaux, int columnaaux, string name)
 {
    this.filaaux = filaaux;
    this.columnaaux = columnaaux;
    this.nombreaux = name; 
 }


 public int fila { get {return filaaux;}}

 public int columna {get {return columnaaux ;}}

 public string name { get {return nombreaux;}}




}
}

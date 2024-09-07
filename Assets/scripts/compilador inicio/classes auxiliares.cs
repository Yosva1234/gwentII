
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using System;
using UnityEngine.SceneManagement;
using UnityEngine.EventSystems;
//
namespace gwentii{
public class Param 
{
    public string name {get ;}
    public object Value {get;}

    public Param (string name, object Value)
    {
        this.name = name;
        this.Value = Value;
    }
}




}

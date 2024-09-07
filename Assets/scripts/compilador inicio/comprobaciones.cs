
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using System;
using UnityEngine.SceneManagement;
using UnityEngine.EventSystems;
using System.Linq;

namespace gwentii{
public class comprobaciones 
{

    //---------------------------------------------------------------- COMPROBANDO LOS DELIMITADORES
    public bool comprobardelimitadores( List <Token> tokenlist, TMP_Text errors)
    {

            string error = "";

            int cc = 0, cp = 0, cy = 0;

            for (int x = 0; x<tokenlist.Count ; x++)
            {
                    if(tokenlist[x].name == "{") cy++;
                    if(tokenlist[x].name == "}") cy--;
                    if(tokenlist[x].name == "[") cc++;
                    if(tokenlist[x].name == "]") cc--;
                    if(tokenlist[x].name == "(") cp++;
                    if(tokenlist[x].name == ")") cy--;

                    if(comprobacionmenorquecero(cc,cy,cp)) { error = tokenlist[x].error();   break;}

            }

            if(error == "" && comprobarmayorquecero(cc,cy,cp)) return false;

        if(!comprobarmayorquecero(cc,cy,cp) && !comprobacionmenorquecero(cc,cy,cp) ) error = tokenlist.Last().error();

        errors.text = error;

        return true;


    }
    bool comprobacionmenorquecero(int x, int y, int z)
    {
        if(x<0) return true;
        if(y<0) return true;
        if(z<0) return true;

        return false;
    }

    bool comprobarmayorquecero(int x, int y, int z)
    {
        if(x!=0) return false;
        if(y!=0) return false;
        if(z!=0) return false;

        return true;
    }



    // ----------------------------------------------------------------------------- TERMINAR DE COMPROBAR DELIMITADORES


  

}
}

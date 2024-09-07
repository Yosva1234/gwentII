
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using System;
using UnityEngine.SceneManagement;
using UnityEngine.EventSystems;
using Unity.VisualScripting;
using System.Runtime.CompilerServices;

namespace gwentii{
public class Card
{
  public cardtype tipo {get ;}
  public string name {get ;}
  public int power {get ; set;}
  public string faction{get;}
  public List<rangetype> ranges{get ;}

  public Card(string name, int power, cardtype tipo, string faction)
  {
    this.name = name;
    this.power = power;
    this.tipo = tipo;
    this.faction = faction;
    ranges = new List<rangetype>();
  }

  public void addrange( rangetype newrange)
  {
    ranges.Add(newrange);
  }
    

}

// ---------------------------------------------------------------- CREO LAS CARATS
public class hacercartas
{

    public bool asignacion ( List <Token> tokenlist, List <Card> cardlist, TMP_Text errors )
      {
        
        int ccorchetes = 0, cparentesis = 0, cllaves  = 0;

        for (int x = 0; x<tokenlist.Count; x++)
        {
          if(tokenlist[x].name == "[") ccorchetes++;
          if(tokenlist[x].name == "]") ccorchetes--;
          if(tokenlist[x].name == "{") cllaves++;
          if(tokenlist[x].name == "}") cllaves--;
          if(tokenlist[x].name == "(") cparentesis++;
          if(tokenlist[x].name == ")") cparentesis++;

          if(tokenlist[x].name == "card")
          {
            if(ccorchetes != 0 || cparentesis!=0 || cllaves!=0) 
            {
              errors.text = tokenlist[x].error();
              return true;
            }

            int endeffect = generarcard(cardlist,tokenlist,x);

            if(endeffect == -1) 
            {
              errors.text = tokenlist[x].error();
              return true;
            }

            x=endeffect-1;

          }

        }

        return false;
      }


      public int generarcard (List <Card> cardlist, List <Token> tokenlist, int pos )
      {

          
          if(tokenlist[pos+1].name != "{")  return -1;
          
          pos++;
          int endcard = -1, ccaux=0;

          for (int x = pos; x<tokenlist.Count; x++)
          {
          if(tokenlist[x].name == "{") ccaux++;
          if(tokenlist[x].name == "}") ccaux--;

          if(ccaux == 0)
          {
            endcard = x+1;
            break;
          }
          
          }

          if(endcard == -1) return -1;


            // --------------------------------- vamos a buscar el nombre de la carta

           int ccorchetes = 0, cparentesis = 0, cllaves  = 0, posname = 0, endname = 0; 

          string name = "";
          string carname;

          for (int x = pos; x<endcard; x++)
          {

          if(tokenlist[x].name == "[") ccorchetes++;
          if(tokenlist[x].name == "]") ccorchetes--;
          if(tokenlist[x].name == "{") cllaves++;
          if(tokenlist[x].name == "}") cllaves--;
          if(tokenlist[x].name == "(") cparentesis++;
          if(tokenlist[x].name == ")") cparentesis--;

           if(tokenlist[x].name == "Name")
          {
            posname = x+3;
            if(ccorchetes != 0 || cparentesis!=0 || cllaves!=1 || tokenlist[x+1].name!=":" || tokenlist[x+2].name!='"'.ToString()) return -1;

            for (int i =  posname; i<endcard; i++)
            {

              if(tokenlist[i].name =='"'.ToString()) 
              {
                endname = i;
                break;
              }

              name+=tokenlist[i].name;
            }

            if(name == "" ) return -1;
            
            if( tokenlist[endname].name!=",") endname++;
            break;
          }
          }
        
            //Debug.Log(name);
            carname = name;

          //------------------------------------------------------------------ vamos a buscar el tipo

        
            ccorchetes = 0; cparentesis = 0; cllaves  = 0; posname = 0; endname = 0; 

           cardtype tipodecarta = cardtype.error;
           name = "";

          for (int x = pos; x<endcard; x++)
          {

          if(tokenlist[x].name == "[") ccorchetes++;
          if(tokenlist[x].name == "]") ccorchetes--;
          if(tokenlist[x].name == "{") cllaves++;
          if(tokenlist[x].name == "}") cllaves--;
          if(tokenlist[x].name == "(") cparentesis++;
          if(tokenlist[x].name == ")") cparentesis--;

           if(tokenlist[x].name == "Type")
          {
            posname = x+3;
            if(ccorchetes != 0 || cparentesis!=0 || cllaves!=1 || tokenlist[x+1].name!=":" || tokenlist[x+2].name!='"'.ToString()) return -1;

            for (int i =  posname; i<endcard; i++)
            {

              if(tokenlist[i].name =='"'.ToString()) 
              {
                endname = i;
                break;
              }

              name+=tokenlist[i].name;
            }

            if(name == "" ) return -1;
            
            if( tokenlist[endname].name!=",") endname++;
            break;
          }
          }
          
          if (name == "Oro") tipodecarta = cardtype.oro;
          if (name == "Plata") tipodecarta = cardtype.plata;
          if( name == "Clima") tipodecarta = cardtype.clima;
          if ( name == "Lider") tipodecarta = cardtype.lider;
          if ( name == "Aumento") tipodecarta = cardtype.aumento;

          if(tipodecarta == cardtype.error) return -1;
          //Debug.Log(tipodecarta.ToString());

          //---------------------------------------------------------------------------- vamos a buscar la faccion

          string faction = "";
           ccorchetes = 0; cparentesis = 0; cllaves  = 0; posname = 0; endname = 0; 

           name = "";

          for (int x = pos; x<endcard; x++)
          {

          if(tokenlist[x].name == "[") ccorchetes++;
          if(tokenlist[x].name == "]") ccorchetes--;
          if(tokenlist[x].name == "{") cllaves++;
          if(tokenlist[x].name == "}") cllaves--;
          if(tokenlist[x].name == "(") cparentesis++;
          if(tokenlist[x].name == ")") cparentesis--;

           if(tokenlist[x].name == "Faction")
          {
            posname = x+3;
            if(ccorchetes != 0 || cparentesis!=0 || cllaves!=1 || tokenlist[x+1].name!=":" || tokenlist[x+2].name!='"'.ToString()) return -1;

            for (int i =  posname; i<endcard; i++)
            {

              if(tokenlist[i].name =='"'.ToString()) 
              {
                endname = i;
                break;
              }

              name+=tokenlist[i].name;
            }

            if(name == "" ) return -1;
            
            if( tokenlist[endname].name!=",") endname++;
            break;
          }
          }

          faction = name;
        
           // Debug.Log(faction);

           //------------------------------- VAMOS A BUSCAR LOS RANGOS

           ccorchetes = 0; cparentesis = 0; cllaves  = 0; posname = 0; endname = 0; 

           name = "";
           List <string> rangos = new List<string> ();
           bool stringon = false;

          for (int x = pos; x<endcard; x++)
          {

          if(tokenlist[x].name == "[") ccorchetes++;
          if(tokenlist[x].name == "]") ccorchetes--;
          if(tokenlist[x].name == "{") cllaves++;
          if(tokenlist[x].name == "}") cllaves--;
          if(tokenlist[x].name == "(") cparentesis++;
          if(tokenlist[x].name == ")") cparentesis--;

           if(tokenlist[x].name == "Range")
          {
            posname = x+3;
            if(ccorchetes != 0 || cparentesis!=0 || cllaves!=1 || tokenlist[x+1].name!=":" || tokenlist[x+2].name!='['.ToString()) return -1;

              

            for (int i =  posname; i<endcard; i++)
            {
              

              if(tokenlist[i].name =='"'.ToString() && name.Length>0) 
              {
                 //Debug.Log(name);

                if (name != "Melee" && name != "Ranged" && name != "Sieged") return -1;
                
                endname = i;
                stringon = false;
                rangos.Add(name);
                name = "";

                //Debug.Log(name);

                if(tokenlist[i+1].name == ",") continue;
                if(tokenlist[i+1].name == "]") break;

                  

                return -1;
              }
                

               if(tokenlist[i].name =='"'.ToString() && name.Length==0)
               {
                stringon = true;
                continue;
               } 
              
                if (tokenlist[i].name == "," && name.Length == 0) continue;

                if (!stringon) return -1;

              name+=tokenlist[i].name;
             
            }

            if( rangos.Count == 0 ) return -1;
            
            if( tokenlist[endname].name!=",") endname++;
            break;
          }
          }

          
// ----------------------------------------------------- a buscar el poder


   ccorchetes = 0; cparentesis = 0; cllaves  = 0; posname = 0; endname = 0; 

        int power = 0;


          for (int x = pos; x<endcard; x++)
          {

          if(tokenlist[x].name == "[") ccorchetes++;
          if(tokenlist[x].name == "]") ccorchetes--;
          if(tokenlist[x].name == "{") cllaves++;
          if(tokenlist[x].name == "}") cllaves--;
          if(tokenlist[x].name == "(") cparentesis++;
          if(tokenlist[x].name == ")") cparentesis--;

           if(tokenlist[x].name == "Power")
          {

           if(ccorchetes != 0 || cparentesis!=0 || cllaves!=1 || tokenlist[x+1].name!=":" || !int.TryParse(tokenlist[x+2].name, out power) ||  tokenlist[x+3].name!="," ) return -1;

              break;
          }

          }



           
           Card nuevacarta = new Card(carname,power,tipodecarta,faction);


          for (int x = 0; x<rangos.Count; x++)
          {
            if(rangos[x] == "Melee") nuevacarta.addrange(rangetype.Melee);
            if(rangos[x] == "Ranged")nuevacarta.addrange(rangetype.Ranged);
            if(rangos[x] == "Siege") nuevacarta.addrange(rangetype.Siege);
          }

          cardlist.Add(nuevacarta);








        return endcard;
      }




}
}

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
public class SCard
{
  public cardtype tipo {get ;}
  public string name {get ;}
  public int power {get ; set;}
  public string faction{get;}
  public List<rangetype> ranges{get ;}

  public SCard(string name, int power, cardtype tipo, string faction)
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

    public bool asignacion ( List <Token> tokenlist, List <Card> cardlist, string errors )
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
              errors = tokenlist[x].error();
              return true;
            }

            int endeffect = generarcard(cardlist,tokenlist,x);

            if(endeffect == -1) 
            {
              errors = tokenlist[x].error();
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
        
           
            carname = name;

          //------------------------------------------------------------------ vamos a buscar el tipo

        
            ccorchetes = 0; cparentesis = 0; cllaves  = 0; posname = 0; endname = 0; 

           CardType tipodecarta = CardType.error;
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
          
          if (name == "Oro") tipodecarta = CardType.oro;
          if (name == "Plata") tipodecarta = CardType.plata;
          if( name == "Clima") tipodecarta = CardType.clima;
          if ( name == "Lider") tipodecarta = CardType.lider;
          if ( name == "Aumento") tipodecarta = CardType.aumento;

          if(tipodecarta == CardType.error) return -1;
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



           
           


            List <rangetype> rang = new List<rangetype>();

          for (int x = 0; x<rangos.Count; x++)
          {
            if(rangos[x] == "Melee") rang.Add(rangetype.Melee);
            if(rangos[x] == "Ranged")rang.Add(rangetype.Ranged);
            if(rangos[x] == "Siege") rang.Add(rangetype.Siege);
          }

          Card nuevacarta = new Card(carname,power,tipodecarta,faction,rang);



         ccorchetes = 0; cparentesis = 0; cllaves  = 0;

                  
                
        for (int x = pos; x<endcard; x++)
        {


          //Debug.Log(tokenlist[x].name);
          if(tokenlist[x].name == "[") ccorchetes++;
          if(tokenlist[x].name == "]") ccorchetes--;
          if(tokenlist[x].name == "{") cllaves++;
          if(tokenlist[x].name == "}") cllaves--;
          if(tokenlist[x].name == "(") cparentesis++;
          if(tokenlist[x].name == ")") cparentesis++;

          

          if(tokenlist[x].name == "Effect")
          {
            if(ccorchetes != 1 || cparentesis!=0 || cllaves!=2 || tokenlist[x+2].name != "{" || tokenlist[x+1].name != ":") 
            {

              //Debug.Log("partido");
              
             continue;

            }
                
             int posaux = x+2;

            int endeffect = -1; ccaux=0;

          for (int j = posaux; j<tokenlist.Count; j++)
          {
          if(tokenlist[j].name == "{") ccaux++;
          if(tokenlist[j].name == "}") ccaux--;

          if(ccaux == 0)
          {
            endeffect = j+1;
            break;
          }
          }

          if (endeffect == -1) return -1;
                
         

            // \\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\ buscamos el nombre del efecto

            int  ccorchetesaux = 0, cparentesisaux = 0, cllavesaux  = 0, posnameaux = 0;

           name = "";

          for (int j = posaux; j<endeffect; j++)
          {

          if(tokenlist[j].name == "[") ccorchetesaux++;
          if(tokenlist[j].name == "]") ccorchetesaux--;
          if(tokenlist[j].name == "{") cllavesaux++;
          if(tokenlist[j].name == "}") cllavesaux--;
          if(tokenlist[j].name == "(") cparentesisaux++;
          if(tokenlist[j].name == ")") cparentesisaux--;

           if(tokenlist[j].name == "Name")
          {
            posnameaux = j+3;
            if(ccorchetesaux != 0 || cparentesisaux!=0 || cllavesaux!=1 || tokenlist[j+1].name!=":" || tokenlist[j+2].name!='"'.ToString()) return -1;

                // Debug.Log("yes");

            for (int i =  posnameaux; i<endeffect; i++)
            {

              if(tokenlist[i].name =='"'.ToString()) 
              {
                break;
              }

              name+=tokenlist[i].name;
            }

            if(name == "" ) return -1;

             posaux+=7;

            break;

             

          }
          }

          //\=============================================================oooo====================oooooooooooo============oooooo


              

            Effect efectoparceado = null;

           // Debug.Log(compila.effectlist.Count);


            foreach ( Effect effectcreated in compila.effectlist)
            {

                if(effectcreated.name == name)
                {
                  efectoparceado = new Effect(effectcreated);
                  break;
                }

            }

            //Debug.Log(posaux);
            //Debug.Log(endeffect);

            for (int j = posaux; j < endeffect; j+=4 )
            {

              if (tokenlist[j].name == "}") break;
              
             // Debug.Log(tokenlist[j].name);

              if(tokenlist[j].tipo!= tokentype.identificadores || tokenlist[j+1].name!=":" || tokenlist[j+2].tipo!= tokentype.identificadores || tokenlist[j+3].name!= ",") return -1;
             

              if(!efectoparceado.Params.ContainsKey(tokenlist[j].name)) return -1;

              
              if(efectoparceado.Params[tokenlist[j].name] is bool )
              {
               bool b =  (bool)efectoparceado.Params[tokenlist[j].name];
               if (!bool.TryParse(tokenlist[j+2].name, out b)) return -1;
               efectoparceado.Params[tokenlist[j].name] = b;
              }

              if(efectoparceado.Params[tokenlist[j].name] is int )
              {
               int b =  (int)efectoparceado.Params[tokenlist[j].name];
               if (!int.TryParse(tokenlist[j+2].name, out b)) return -1;
               efectoparceado.Params[tokenlist[j].name] = b;
              }

              

            }


           if(efectoparceado == null) return -1;
 

           nuevacarta.efectosdelacarta.Add(efectoparceado);
           


           name = "";

        }
        }


        





          cardlist.Add(nuevacarta);






          

        return endcard;
      }




}
}
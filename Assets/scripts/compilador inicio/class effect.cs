
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using System;
using UnityEngine.SceneManagement;
using UnityEngine.EventSystems;
using Unity.VisualScripting;

namespace gwentii{
public class Effect 
{
      public string name  {get ;}

    public Effect (string name)
    {
        this.name = name;
    }
//

   public Dictionary <string,object> Params = new Dictionary<string, object>();


        public override string ToString()
        {
          
            string resp = "";

            resp+=name;
            resp+='\n';

            foreach (var objetos in Params)
            {
              resp+=objetos.Key+'\n';
              resp+=objetos.Value.ToString()+'\n';
              
            }

            return resp;

        }

        public void addparams( string s, object variable)
  {
     Params[s] = variable;
  }

}

// ----------------------------¿¿¿¿¿¿¿¿¿¿¿¿¿¿¿¿¿¿¿¿¿¿¿¿¿¿¿¿¿¿¿¿¿----------------------- CREO LOS EFECTOS 
  public class hacerefect
  {

      public bool asignacion ( List <Token> tokenlist, List <Effect> effectlist, TMP_Text errors )
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

          if(tokenlist[x].name == "effect")
          {
            if(ccorchetes != 0 || cparentesis!=0 || cllaves!=0) 
            {
              errors.text = tokenlist[x].error();
              return true;
            }

            int endeffect = generareffect(tokenlist,effectlist,x);

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

      int generareffect( List <Token> tokenlist, List<Effect> effectlist, int pos)
      {

          if(tokenlist[pos+1].name != "{")
          {
            return -1;
          }
          pos++;
          int endeffect = -1, ccaux=0;

          for (int x = pos; x<tokenlist.Count; x++)
          {
          if(tokenlist[x].name == "{") ccaux++;
          if(tokenlist[x].name == "}") ccaux--;

          if(ccaux == 0)
          {
            endeffect = x+1;
            break;
          }
          
          }

          if(endeffect == -1) return -1;

          // ------------------------------------------------------ encontrar nombre del effecto actual
          int ccorchetes = 0, cparentesis = 0, cllaves  = 0, posname = 0, endname = 0; 

          string name = "";

          for (int x = pos; x<endeffect; x++)
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

            for (int i =  posname; i<endeffect; i++)
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
            
        Effect nuevoefecto = new Effect(name);
//------------------------------------------------------------------------------- termine el parcer del nombre del efecto
// ----------------------------------------------------------------------------- parcer de los Params 

 ccorchetes = 0; cparentesis = 0; cllaves  = 0; posname = 0; endname = 0; 

for (int x = pos; x<endeffect; x++)
          {

          if(tokenlist[x].name == "[") ccorchetes++;
          if(tokenlist[x].name == "]") ccorchetes--;
          if(tokenlist[x].name == "{") cllaves++;
          if(tokenlist[x].name == "}") cllaves--;
          if(tokenlist[x].name == "(") cparentesis++;
          if(tokenlist[x].name == ")") cparentesis--;

            if(tokenlist[x].name == "Params")
          {
            
            if(ccorchetes != 0 || cparentesis!=0 || cllaves!=1 || tokenlist[x+1].name!=":" || tokenlist[x+2].name!='{'.ToString()) return -1;

            //Debug.Log("llegooooooo");

            string paramname= "";
            object value = new object();

            for (int i = x+3; i<endeffect; i++)
            {

              if( tokenlist[i].tipo != tokentype.identificadores && paramname == "" ) return -1;

              paramname = tokenlist[i].name;


              
              
              if( (tokenlist[i+1].name!=":" || tokenlist[i+2].tipo!=tokentype.identificadores ) && tokenlist[i+2].name!=""+'"') return -1;
              
             // Debug.Log("llega");

              i+=2;

              //  Debug.Log(tokenlist[i].name);

              if(tokenlist[i].name == "Number") value=0;
              if(tokenlist[i].name == "Bool" || tokenlist[i].name=="false")  value = false;
              if(tokenlist[i].name == "String") value = "";
              if(tokenlist[i].name=="true") value = true;


                int posiblevalor ;
              if(int.TryParse(tokenlist[i].name,out posiblevalor))
              {
                value = posiblevalor;
              }

              string posiblestring="";

              if (tokenlist[i].name == ""+'"')
              {
                
                  for(int j=i+1; j<endeffect; j++)
                  {
                    if(tokenlist[j].name == ""+'"')
                    {
                      i=j;
                      value = posiblestring;
                      break;
                    }
                    posiblestring+=tokenlist[j].name;
                  }
              }

                  if(value == null) return -1;

                 // Debug.Log(value);

                  nuevoefecto.addparams(paramname,value);


                  if(tokenlist[i+1].name== ",")
                  {
                    paramname="";
                    value = new object();
                    i++;
                    continue;
                  }

                  if(tokenlist[i+1].name== "}") break;

                      return -1;
            }

                break;
          }
          }


        effectlist.Add(nuevoefecto);

          
      

      return endeffect;

  }


}

  }


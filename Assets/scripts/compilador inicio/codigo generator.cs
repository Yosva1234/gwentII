using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Unity.Mathematics;
using Unity.VisualScripting;
using UnityEngine;

namespace gwentii{
public class codigogenerator
{
        public static void sobrescribiracrcivo( List <Effect> effects)
        {
            using (StreamWriter writer = new StreamWriter("Assets/scripts/compilador inicio/actions.cs"))
            {
                    writer.Write("using System.Collections; \n using System.IO; \n using Unity.VisualScripting; \n using System.Collections.Generic; \n using System.Linq; \n using UnityEngine; \n namespace gwentii{ \n public class actions { \n public static void start(string name , List<Card> tarjets, contextclass context, Dictionary<string,object> Param) { \n ");
                    writer.WriteLine(" using (StreamWriter writer = new StreamWriter("+'"'+"Assets/scripts/compilador inicio/empezaractions.cs"+'"'+")){" );
                    writer.WriteLine ("writer.Write("+'"'+"using System.Collections;  using System.Collections.Generic;  using UnityEngine;  namespace gwentii{ public class empezaractions {   public static void codigoescrito(List <Card> targets, contextclass context , Dictionary<string,object> Param){ actions." + '"' + " + name +" + '"' +"(targets,context,Param);}}}" + '"' + ");");
                    writer.WriteLine("}");
                    writer.WriteLine("empezaractions.codigoescrito(tarjets,context,Param);\n");
                    writer.WriteLine("}");
                    foreach(Effect effect in effects)
                  {// creamos los metodos de cada efecto
                        writer.WriteLine(" public static void " + effect.name + " ( List <Card> targets, contextclass context , Dictionary<string,object> Param )  ");
                        // vamos a crear todas las variables params del efecto en el metodo para acceder a ellas mas facilmente.  
                        bool b = false,  b2 = true;;
                        for( int x = 0; x<effect.tokenactions.Count; x++)
                        {
                            if(b && b2)
                            {
                                foreach( var param in effect.Params)
                                {
                                 if(param.Value is bool) writer.WriteLine(" bool " + param.Key + " = (" + "bool)Param[" +'"'+ param.Key +'"'+"] ; \n" );
                                 if(param.Value is int) writer.WriteLine(" int " + param.Key + " = " + "(int)Param[" +'"'+ param.Key +'"'+"] ; \n" );
                                 if(param.Value is string) writer.WriteLine(" string " + param.Key + " = " + "(string)Param[" +'"'+ param.Key +'"'+"] ; \n" );
                                }
                                 b = b2 = false;
                            }
                            Debug.Log(effect.tokenactions[x].name);
                                if(effect.tokenactions[x].name == "{" || effect.tokenactions[x].name == "}") { b = true; writer.WriteLine(effect.tokenactions[x].name + "\n"); continue; }
                                if(effect.tokenactions[x].name == ";") { writer.Write(";\n"); continue; }
                                if(effect.tokenactions[x].name == "for")
                                {
                                    writer.WriteLine("foreach( Card " + effect.tokenactions[x+1].name + " " + effect.tokenactions[x+2].name + " "+  effect.tokenactions[x+3].name+ " )");
                                    x+=3;
                                    continue;
                                }

                                 if(x <effect.tokenactions.Count-3  && effect.tokenactions[x].tipo == tokentype.identificadores && effect.tokenactions[x+2].tipo == tokentype.identificadores && effect.tokenactions[x+1].name == "=")
                                {
                                    writer.Write(" var ");
                                }

                                if (isadd(effect.tokenactions[x].name,"Add")) 
                                {
                                    writer.Write("a"+effect.tokenactions[x].name.Substring(1));
                                    continue;
                                }
                                if (isadd(effect.tokenactions[x].name,"Rem")) 
                                {
                                    writer.Write("r"+effect.tokenactions[x].name.Substring(1));
                                    continue;
                                }
                                if (isadd(effect.tokenactions[x].name,"Pop")) 
                                {
                                    writer.Write("p"+effect.tokenactions[x].name.Substring(1));
                                    continue;
                                }
                                writer.Write(effect.tokenactions[x].name);        
                                if(effect.tokenactions[x].name == "Pop") writer.Write("item");    
                                if(effect.tokenactions[x].name == "Board"||effect.tokenactions[x].name == "Hand" ||  effect.tokenactions[x].name == "Deck" || effect.tokenactions[x].name == "Field") writer.Write("()"); 
                                if(effect.tokenactions[x].name == "Remove") writer.Write("item");     
                                        
                                 
                        }
                  }
                    writer.WriteLine("}}");

}}

 public static bool isadd(string s, string s2)
   {
            string s1="";

            for(int x = 0; x<Math.Min(3,s.Length);x++)
            {
                s1+=s[x];
            }

            return(s1==s2);
   }

}

}
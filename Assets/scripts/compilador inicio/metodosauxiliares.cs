using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using UnityEngine;

namespace gwentii
{
public class metodosauxiliares 
{


// -------------------------------------------------------------------------- CREAR TOKENS JEJEJEJEJEJJEJEJEJE

        public List <Token> codigoconverttotoken( string codigo)
        {
          List <Token> tokenlist = new List<Token>();

          Listasdepalabras listas = new Listasdepalabras();


            int columna = 1;
            int fila = 0;

            string palabraactual = "";

            for (int x = 0 ; x < codigo.Length; x++)
            {

              if((int)codigo[x] == 13) continue;

                    if(codigo[x]=='\n' || codigo[x]==' ' || listas.delimitadores.Contains(codigo[x].ToString()) ||  listas.operadoresaritmeticos.Contains(codigo[x].ToString()) || listas.asignacion.Contains(codigo[x].ToString()) || listas.operadoreslogicos.Contains(codigo[x].ToString()))
                    {
                      
                        if(palabraactual.Length>0)
                        {

                                guardar(palabraactual,tokenlist,listas,fila,columna);
                                fila++;
                                palabraactual="";
                               
                        }

                        if(codigo[x]=='\n')
                         {
                            columna++;
                            fila = 0;
                            continue;
                          }

                          if(codigo[x] == ' ') continue;

                            guardar(codigo[x].ToString(),tokenlist,listas,fila,columna);
                                
                           continue ;
                        
                    }


                      palabraactual+=codigo[x];
                      fila++;
            }

            return tokenlist;
    
        }

        void guardar ( string s , List<Token> tokenlist, Listasdepalabras listas, int fila,int columna)
        {

           tokentype tipodetoken = tokentype.identificadores;

            
           

           if(listas.operadoreslogicos.Contains(s)) tipodetoken = tokentype.operadoreslogicos;
           if(listas.operadoresaritmeticos.Contains(s)) tipodetoken = tokentype.operadoresaritmeticos;
           if(listas.delimitadores.Contains(s)) tipodetoken = tokentype.delimitadores;
           if(listas.boolianos.Contains(s)) tipodetoken = tokentype.boolianos;
           if(listas.asignacion.Contains(s)) tipodetoken = tokentype.asignaciones;
           if(listas.operadoreslogicos.Contains(s))tipodetoken = tokentype.operadoreslogicos;

            

            Token actualtoken = new Token(s,fila,columna,tipodetoken);

            tokenlist.Add(actualtoken);

        }

        // ---------------------------------------------------------- TERMINO DE GENERAR TOKENS



       


         

       
        }
}




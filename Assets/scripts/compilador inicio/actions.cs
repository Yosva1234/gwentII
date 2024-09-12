using System.Collections; 
 using System.IO; 
 using Unity.VisualScripting; 
 using System.Collections.Generic; 
 using System.Linq; 
 using UnityEngine; 
 namespace gwentii{ 
 public class actions { 
 public static void start(string name , List<Card> tarjets, contextclass context, Dictionary<string,object> Param) { 
  using (StreamWriter writer = new StreamWriter("Assets/scripts/compilador inicio/empezaractions.cs")){
writer.Write("using System.Collections;  using System.Collections.Generic;  using UnityEngine;  namespace gwentii{ public class empezaractions {   public static void codigoescrito(List <Card> targets, contextclass context , Dictionary<string,object> Param){ actions." + name +"(targets,context,Param);}}}");
}
empezaractions.codigoescrito(tarjets,context,Param);

}
 public static void Draw ( List <Card> targets, contextclass context , Dictionary<string,object> Param )  
{

 var topCard=context.Deck().pop();
context.Hand().add(topCard);
context.Hand().Shuffle();
}

 public static void Damage ( List <Card> targets, contextclass context , Dictionary<string,object> Param )  
{

 int Amount = (int)Param["Amount"] ; 

foreach( Card target in targets )
{

 var i=0;
while(i<Amount){

target.Power-=1;
i+=1;
}

}

;
}

 public static void ReturnToDeck ( List <Card> targets, contextclass context , Dictionary<string,object> Param )  
{

foreach( Card target in targets )
{

 var owner=target.Owner;
 var deck=context.DeckOfPlayer(owner);
deck.Push(target);
deck.Shuffle();
context.Board().remove(target);
}

;
}

}}

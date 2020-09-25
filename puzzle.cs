using System.Collections;
using System.Collections.Generic;
//using UnityEngine;
using System;
using System.Linq;
using System.Text;

namespace rompecabezas
{
   class puzzle 
  {
         static void Main(string[] args){
         int[] puzz = {     //Este es el estado INICIAL
         1, 2, 4,
         3, 0, 5,
         7, 6, 8  
         };

         Nodo nodo_inicial = new Nodo(puzz); //Se genera el nodo inicial
         busqueda_uniforme bu = new busqueda_uniforme(); 
         List<Nodo> res = bu.primero_amplitud(nodo_inicial); //Se efectúa la búsqueda

         if(res.Count >0){ //Si el camino tiene elementos es porque se encontró solución
         for(int i = 0; i < res.Count; i++){
         res[i].mostrar(); //Se enseña cada uno de los nodos del camino
         }
         }
         else{
           //Debug.Log("No se encontró solución");
           Console.WriteLine("No se encontró solución.");
         }
         //Console.Read();
      }
  }
}

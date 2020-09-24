using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.Linq;
using System.Text;

namespace rompecabezas
{
   class puzzle
  {
         static void Main(string[] args){
         int[] puzz = {
         1, 2, 4,
         3, 0, 5,
         7, 6, 8  
         };

         Nodo nodo_inicial = new Nodo(puzz);
         busqueda_uniforme bu = new busqueda_uniforme();
         List<Nodo> res = bu.primero_amplitud(nodo_inicial);

         if(res.Count >0){
         for(int i = 0; i < res.Count; i++){
         res[i].mostrar();
         }
         }
         else{
           Console.WriteLine("No hay solución.");
         }
         Console.Read();
      }
  }
}

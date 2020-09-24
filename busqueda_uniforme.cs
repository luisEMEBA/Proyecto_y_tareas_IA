using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.Linq;
using System.Text;

namespace rompecabezas
{
   class busqueda_uniforme 
   {
       public List<Nodo> primero_amplitud(Nodo root){
       List<Nodo> Camino = new List<Nodo>();
       List<Nodo> Lista_completa = new List<Nodo>();
       List<Nodo> Lista_expandidos = new List<Nodo>();

       Lista_completa.Add(root);
       bool meta = false;

       while(Lista_completa.Count > 0 && !meta){  //Nótese que lo que aquí estamos adelantando es una estructura del tipo cola o FIFO
       Nodo nodo_actual = Lista_completa[0]; 
       Lista_expandidos.Add(nodo_actual);
       Lista_completa.RemoveAt(0);

       nodo_actual.expancion();

       for(int i = 0; i < nodo_actual.hijos.Count; i++){
       Nodo hijo_actual = nodo_actual.hijos[i];
       if(hijo_actual.comprobacion()){
       Console.WriteLine("Se encontró la solución");
       meta = true;
       Rehacer_camino(Camino, hijo_actual);
       }
       if(!Contiene(Lista_completa, hijo_actual) && !Contiene(Lista_expandidos, hijo_actual)){
       Lista_completa.Add(hijo_actual);
       }
       }
       }
       return Camino;
       }
       public static bool Contiene(List<Nodo> lista, Nodo n){
        bool contiene = false;
        for(int i = 0; i < lista.Count; i++){
        if(lista[i].comparacion(n.puzzle)){
        contiene = true;
        }
        }
        return contiene;
       }
       public void Rehacer_camino(List<Nodo> cam, Nodo n){
       Console.WriteLine("Rehaciendo el camino");
       Nodo actual = n;
       cam.Add(actual);
       while(actual.madre != null){
       actual = actual.madre;
       cam.Add(actual);
       }
       }
   } 

}


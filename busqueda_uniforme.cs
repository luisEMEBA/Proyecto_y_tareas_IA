using System.Collections;
using System.Collections.Generic;
//using UnityEngine;
using System;
using System.Linq;
using System.Text;

namespace rompecabezas
{
   class busqueda_uniforme 
   {
       public List<Nodo> primero_amplitud(Nodo root){  //Lista comformada por el árbol de búsqueda para éste método (anchura)
       List<Nodo> Camino = new List<Nodo>(); //Camino de operaciones realizadas
       List<Nodo> Lista_completa = new List<Nodo>(); // Esta lista contiene a todos los nodos que se almacenan en memoria
       List<Nodo> Lista_expandidos = new List<Nodo>(); //Esta lista contiene a los nodos que ya se han analizado

       Lista_completa.Add(root); //Se añade el estado inicial a la lista total de nodos
       bool meta = false;

       while(Lista_completa.Count > 0 && !meta){  //Nótese que lo que aquí estamos adelantando es una estructura del tipo cola o FIFO
       Nodo nodo_actual = Lista_completa[0]; //Primero que entra primero que sale
       Lista_expandidos.Add(nodo_actual); 
       Lista_completa.RemoveAt(0); //Primero que entra primero que sale 

       nodo_actual.expancion(); //Se almacenan en memoria los nodos hijo correspondientes al nodo ne cuestión

       for(int i = 0; i < nodo_actual.hijos.Count; i++){  //Se comprueba que ninguno de los hijos sea solución
       Nodo hijo_actual = nodo_actual.hijos[i];
       if(hijo_actual.comprobacion()){ //Si el hijo i es igual al estado meta se encontró la solución
       //Debug.Log("Se encontró la solución");
       Console.WriteLine("Se encontró la solución");
       meta = true;
       Rehacer_camino(Camino, hijo_actual); //De modo que se muestra el camino recorrido para alcanzar ese estado
       }
       if(!Contiene(Lista_completa, hijo_actual) && !Contiene(Lista_expandidos, hijo_actual)){ //ATENCIÓN Éste orden 
       Lista_completa.Add(hijo_actual); //depende directamente del tipo de búsqueda que estemos efectuando, de modo que será distinto para un método primero en profundidad
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
       //Debug.Log("Rehaciendo el camino");
       Console.WriteLine("Rehaciendo el camino");
       Nodo actual = n;
       cam.Add(actual);
       while(actual.madre != null){ //Se retornan todos los nodos madre en la estructura
       actual = actual.madre;
       cam.Add(actual);
       }
       }
   } 

}


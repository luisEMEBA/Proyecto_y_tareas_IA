using System.Collections;
using System.Collections.Generic;
//using UnityEngine;
using System;
using System.Linq;
using System.Text;

namespace rompecabezas  //Todos los códigos correspondientes a la búsqueda deben estar con el mismo namespace
{
    class Nodo 
    {
    int[] puzz_final = {  //Estado FINAL del rompecabezas
         0, 2, 4,
         1, 6, 5,
         3, 7, 8  
         }; 
    public List<Nodo> hijos = new List<Nodo>();  //Lista de hijos del tipo Nodo pertenecientes a un nodo
    public Nodo madre; //Progrenitor del nodo en cuestión
    public int[] puzzle = new int[9]; //Truchos con el tamaño; Este viene determinado por la variable "rango" del slider
    public int x = 0; //Indice de posición 
    public int nivel = 0; //Cantidad de niveles para el control de profundidad
    public int columnas = 3; //Una vez más, esta y filas pueden reemplazarse con el rango del slider
    public int filas = 3; //x2
    public Nodo(int[] p){ //Cada que se crea un nodo se construye con el método setPuzzle
    setPuzzle(p);
    }

    public void setPuzzle(int[] p){ //Dado un estado inicial se asigna éste al "puzzle" que tiene cada elemento de tipo nodo
    for(int i = 0; i < puzzle.Length; i++){
    this.puzzle [i] = p[i];
    }
    }
    
    public void copiar(int[] a, int[] b){ //Éste método es escencial para el movimiento de fichas
        for(int i = 0; i<b.Length; i++){  //Pues evita la pérdida de datos al hacer un movimiento
        a[i] = b[i];
        }
    }
    
    public void crear_hijo(int[] h, Nodo m){ //IMPORTANTE; Aquí yace la optimización ante redundancias
    Nodo hijo = new Nodo(h); //Se crea el hijo de m como resultado de un movimiento aplicado a m
    if(nivel > 1){//Si se trata del estado inicial ó de la primera generación no puede haber redundancia
    if(hijo.puzzle != m.madre.puzzle){ //Sin embargo cuando el nivel es superior a 1 tiene lugar la redundancia
    hijos.Add(hijo);  //Simplemente se compara que los vectores del hijo y de la abuela sean distintos 
    hijo.madre = m;  //De ser iguales implica que se trata del mismo estado y en consecuencia no
    }                //Se generan nodos
    else{
        Console.WriteLine("redundancia");
    }
    }  
    if(nivel <= 1){  //Mientras que si se trata del estado inicial o la primera generación
    hijos.Add(hijo); //Se crean los nodos nuevos sin problema
    hijo.madre = m; 
    }      
    
    }

    public void expancion(){ //Cada que se obtiene una nueva posición se evalúa y ejecutan los posibles movimientos de una ficha
        for(int i = 0; i < puzzle.Length; i++){
        if(puzzle[i] == 0){ //Nótese que al buscar al número 0 es éste la ficha que se moverá
        x = i;              //Se  almacena la posición del número cero dentro del vector
        }
        }
        nivel++;   //cada que se evalúan movimientos se aumenta en uno el nivel
        derecha(puzzle, x); //movimientos
        izquierda(puzzle, x);//movimientos
        arriba(puzzle, x);//movimientos
        abajo(puzzle, x);//movimientos

    }

    public void derecha(int[] p, int i){ //de donde p es el "puzzle" que contiene cada elemento Nodo
    if(i % columnas < columnas-1){  //restricción al movimiento dado el tamaño del rompecabezas
    int[] MoPo = new int[9];  //MoPo es movimiento posible, si se cumple con la restricción es posible ejecutarlo
    copiar(MoPo, p); //Se copia el vector para hacer el cambio de posición

    int temporal = MoPo[i+1]; //Se asigna la nueva posición
    MoPo[i+1] = MoPo[i];
    MoPo[i] = temporal;

    //Nodo hijo = new Nodo(MoPo);
    //hijos.Add(hijo);     //Este es otro tipo de generación de hijos, se puso en una función para optimizar
    //hijo.madre = this;
    Nodo mama = this;
    crear_hijo(MoPo, mama);
    }
    }
    
    public void izquierda(int[] p, int i){  //Funciona de manera análoga al método "derecha"
    if(i % columnas > 0){
    int[] MoPo = new int[9];
    copiar(MoPo, p);

    int temporal = MoPo[i-1];
    MoPo[i-1] = MoPo[i];
    MoPo[i] = temporal;
    
    Nodo mama = this;
    crear_hijo(MoPo, mama);
    }
    }
    public void arriba(int[] p, int i){   //Funciona de manera análoga al método "derecha"
    if(i - columnas >= 0){
          
    int[] MoPo = new int[9];
    copiar(MoPo, p);

    int temporal = MoPo[i-columnas];
    MoPo[i-columnas] = MoPo[i];
    MoPo[i] = temporal;

    Nodo mama = this;
    crear_hijo(MoPo, mama);
    }
    }
    public void abajo(int[] p, int i){      //Funciona de manera análoga al método "derecha"
    if(i + columnas <= ((columnas*filas)-1)){  
    int[] MoPo = new int[9];
    copiar(MoPo, p);

    int temporal = MoPo[i+columnas];
    MoPo[i+columnas] = MoPo[i];
    MoPo[i] = temporal;
    
    Nodo mama = this;
    crear_hijo(MoPo, mama);
    }
    }

    public void mostrar(){  //Para desplegar en consola los valores de un arreglo  (estado)
      //Debug.Log("");
      Console.WriteLine();
      int m = 0;
      for(int i = 0; i < columnas; i++){
      for(int j = 0; j < filas; j++){   //Se recorre el arreglo
      //Debug.Log(puzzle[m] + " ");    
      Console.Write(puzzle[m] + " ");
      m++;
      }
      //Debug.Log("");
      Console.WriteLine();
      }  
    }
    
    public bool comparacion(int[] p){   //Éste método se utiliza a la hora de ejecutar la búsqueda
       bool comparado = true;           //Y consiste en comparar al padre con su hijo
        for(int i = 0; i < p.Length; i++){
          if(puzzle[i] != p[i]){
            comparado = false;
          }
        }      
       return comparado;
    }
      //OJO comprobación y comparación son dos métodos distintos, uno para validar el estado objetivo
      //y otro para ejecutar la búsqueda de una u otra forma
    public bool comprobacion(){
    bool comprobado = true;
    int valor = puzzle[0];
    for(int i = 0; i < puzzle.Length; i++){ 
       if(puzzle[i] != puzz_final[i]){  //Si son distintas las ubicaciones de las fichas en el Nodo actual
       comprobado = false;    //y el nodo final significa que no se está en el objetivo.
       valor = puzzle[i];
       }
    }
    return comprobado;
    }

    }
}


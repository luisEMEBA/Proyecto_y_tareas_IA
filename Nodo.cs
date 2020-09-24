﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.Linq;
using System.Text;

namespace rompecabezas
{
    class Nodo
    {
    public List<Nodo> hijos = new List<Nodo>();
    public Nodo madre;
    public int[] puzzle = new int[9];
    public int x = 0;
    public int columnas = 3;
    public int filas = 3;
    public Nodo(int[] p){
    setPuzzle(p);
    }

    public void setPuzzle(int[] p){
    for(int i = 0; i < puzzle.Length; i++){
    this.puzzle [i] = p[i];
    }
    }
    
    public void copiar(int[] a, int[] b){
        for(int i = 0; i<b.Length; i++){
        a[i] = b[i];
        }
    }
    
    public void crear_hijo(int[] h, Nodo m){
    Nodo hijo = new Nodo(h);
    hijos.Add(hijo);
    hijo.madre = m; //Trucho con esto porque seguramente nos de problemas al relacionar con la madre
    }

    public void expancion(){
        for(int i = 0; i < puzzle.Length; i++){
        if(puzzle[i] == 0){
        x = 1;
        }
        }
        derecha(puzzle, x);
        izquierda(puzzle, x);
        arriba(puzzle, x);
        abajo(puzzle, x);
    }

    public void derecha(int[] p, int i){
    if(i % columnas < columnas-1){
    int[] MoPo = new int[9];
    copiar(MoPo, p);

    int temporal = MoPo[i+1];
    MoPo[i+1] = MoPo[i];
    MoPo[i] = temporal;

    //Nodo hijo = new Nodo(MoPo);
    //hijos.Add(hijo);
    //hijo.madre = this;
    Nodo mama = this;
    crear_hijo(MoPo, mama);
    }
    }
    
    public void izquierda(int[] p, int i){
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
    public void arriba(int[] p, int i){
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
    public void abajo(int[] p, int i){
    if(i + columnas <= (columnas*filas)){  //Intentar reemplazar columnas*filas por p.Lenght ó p.Lenght-1 y verificar si funciona
    int[] MoPo = new int[9];
    copiar(MoPo, p);

    int temporal = MoPo[i+columnas];
    MoPo[i+columnas] = MoPo[i];
    MoPo[i] = temporal;
    
    Nodo mama = this;
    crear_hijo(MoPo, mama);
    }
    }

    public void mostrar(){
      Console.WriteLine();
      int m = 0;
      for(int i = 0; i < columnas; i++){
      for(int j = 0; j < filas; j++){
      Console.Write(puzzle[m] + " ");
      m++;
      }
      Console.WriteLine();
      }  
    }
    
    public bool comparacion(int[] p){
       bool comparado = true;
       for(int i = 0; i < p.Length; i++){
       if(puzzle[i] != p[i]){
    comparado = false;
       }
       }
       return comparado;
    }

    public bool comprobacion(){
    bool comprobado = true;
    int valor = puzzle[0];
    for(int i = 1; i < puzzle.Length; i++){
       if(valor > puzzle[i]){
       comprobado = false;
       valor = puzzle[i];
       }
    }
    return comprobado;
    }

    }
}

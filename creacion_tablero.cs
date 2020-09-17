using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class creacion_tablero : MonoBehaviour
{
    public float tamano;
    public GameObject ficha;
    GameObject g;
    int espaciado_x=0;
    int espaciado_y=0;
    int espaciado_x_huecos=0;
    int espaciado_y_huecos=0;
    int espaciado_x_num=0;
    int espaciado_y_num=0;
    int estado = 0; 
    GameObject hueco;
    public GameObject ranura;
    public List<GameObject> huecos = new List<GameObject>();
    public List<GameObject> objetos = new List<GameObject>();
    public List<Text> numeros = new List<Text>();
    public Text numero;
    Text texto;
    public Canvas lienzo;
    int contador = 0;
    string mat;
    Vector3 posicion_ficha;
    Vector3 posicion_hueco;
    Vector2 posicion_numero;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    public void empezar(){
        if(estado == 0){
        tamano = slider.rango;
        Debug.Log("El tamaño del tablero será de: " + tamano + " x " + tamano);
        for (int i = 1; i <= tamano; i++)
        {
         for(int j = 1; j <= tamano; j++){
         contador++;
         posicion_hueco = new Vector3(-7.68f+ espaciado_x_huecos, 5.7f- espaciado_y_huecos,-2f);
         hueco = Instantiate(ranura, posicion_hueco, Quaternion.identity);
         posicion_ficha = new Vector3(-1.15f + espaciado_x,1.28f - espaciado_y,-2f);
         g = Instantiate(ficha, posicion_ficha, Quaternion.identity);
         //posicion_numero = new Vector2(-26.5f+espaciado_x_num,-9.9f-espaciado_y_num);
         //texto = Instantiate(numero, posicion_numero, Quaternion.identity) as Text;
         g.transform.Rotate(-90,0,0);
         objetos.Add(g);
         hueco.transform.Rotate(-90,0,0);
         huecos.Add(hueco);
         //texto.text = contador.ToString();
         //numeros.Add(texto);
         espaciado_x++;
         espaciado_x_huecos+=2;
        // espaciado_x_num+=27;
         if(j == tamano){
         espaciado_y++;
         espaciado_x=0;
         //espaciado_x_num = 0;
         //espaciado_y_num+=27;
         espaciado_x_huecos=0;
         espaciado_y_huecos+=2;
         }
         //texto.transform.SetParent(lienzo.transform, false);
         mat = ("materiales/"+contador);
         g.GetComponent<Renderer>().material = Resources.Load<Material>(mat);
         }
        }
        espaciado_x = 0;
        espaciado_y = 0;
        espaciado_x_huecos=0;
        espaciado_y_huecos=0;
        //espaciado_x_num = 0;
        //espaciado_y_num = 0;
        estado = 1;
        contador = 0;
    }
    else{
        foreach (GameObject g in objetos){
     GameObject.Destroy(g);
    }
    foreach (Text texto in numeros){
     GameObject.Destroy(texto);
    }
    objetos.Clear();
    numeros.Clear();
    estado = 0;
    }
    }
}

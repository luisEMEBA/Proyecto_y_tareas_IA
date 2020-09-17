using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class slider : MonoBehaviour
{
    public static float rango;
    public Slider deslizador;
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    public void agarrar_valor(){
    rango = deslizador.value;
    //Debug.Log(rango);
    }
}

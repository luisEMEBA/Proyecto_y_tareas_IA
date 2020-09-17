using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class arrastre_fichas : MonoBehaviour
{
    //empieza variables ensayo arrastre.
    private Camera cam;
    private GameObject go;
    public static string btnName;
    private Vector3 screenSpace;
    private Vector3 offset;
    private bool isDrage = false;
    int control = 0;
    Vector3 vector_control;
    Vector3 calculo_dist = new Vector3(10f,10f,10f);
    Vector3 distancia_min;
    Vector3 posicion_antes_de_mover;
    //finaliza variables ensayo arrastre.
    // Start is called before the first frame update
    void Start()
    {
        //inicializamos cámara ensayo movimiento
        cam = Camera.main;
        //finaliza cámara ensayo movimiento
    }

    // Update is called once per frame
    void Update()
    {
        //empieza arrastre
        //Overall initial position
        Ray ray = cam.ScreenPointToRay(Input.mousePosition);
        //Ray from camera to click coordinate
        RaycastHit hitInfo;
        if (isDrage == false)
        {
            if (Physics.Raycast(ray, out hitInfo))
            {
                //The scribed rays can only be seen in the scene view
                Debug.DrawLine(ray.origin, hitInfo.point);
                go = hitInfo.collider.gameObject;
                //print(btnName);
                screenSpace = cam.WorldToScreenPoint(go.transform.position);
                offset = go.transform.position - cam.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, Input.mousePosition.z));
                //The name of the object
                btnName = go.name;
                //Name of component
            }
            else
            {
                btnName = null;
            }
            if (control == 1 && vector_control != null)
            {
             //EMPIEZA CALCULAR DISTANCIA MÍNIMA}
            foreach (GameObject hueco in GetComponent<creacion_tablero>().huecos)
            {
                Vector3 v_hueco = hueco.gameObject.GetComponent<Transform>().position;
                Vector3 v_ficha = go.gameObject.GetComponent<Transform>().position;
                distancia_min = new Vector3(Mathf.Abs(v_ficha.x-v_hueco.x),Mathf.Abs(v_ficha.y-v_hueco.y),Mathf.Abs(v_ficha.z-v_hueco.z));
                if(distancia_min.magnitude<=calculo_dist.magnitude && distancia_min.magnitude <= 2){
                go.gameObject.GetComponent<Transform>().position = distancia_min;
                calculo_dist = distancia_min;
                }
                else{
                go.gameObject.GetComponent<Transform>().position = posicion_antes_de_mover;
                }
            }
            //FINALIZA CALCULAR DISTANCIA MÍNIMA
            }
        }
        if (Input.GetMouseButton(0))
        {
            Vector3 currentScreenSpace = new Vector3(Input.mousePosition.x, Input.mousePosition.y, screenSpace.z);
            Vector3 currentPosition = cam.ScreenToWorldPoint(currentScreenSpace) + offset;
            if (btnName != null)
            {
                if (btnName == "ficha(Clone)")
                {
                    posicion_antes_de_mover = go.gameObject.GetComponent<Transform>().position;
                    Vector3 posicion_ficha = go.gameObject.GetComponent<Transform>().position;
                    Vector3 restablecer = new Vector3(0, 0, -3.5f);
                    restablecer.y = currentPosition.y;
                    restablecer.x = currentPosition.x;
                    go.transform.position = restablecer;
                    go.gameObject.GetComponent<Transform>().position = restablecer;
                    control = 1; // estado uno = almacenaje de posición
                }
            }
            isDrage = true;
        }
        else
        {
            isDrage = false;
        }
        //finaliza arrastre
    }
}

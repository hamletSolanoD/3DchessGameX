using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Casilla : MonoBehaviour
{
 
    public Vector2 PosicionReal;
    [SerializeField]
    private PiezaAjedrez OcupadaPorPieza;
    [SerializeField]
    private float multiplicadorTam ;

    
         
    // Start is called before the first frame update
    void Start()
    {
        
    }
    public PiezaAjedrez getPiezaQueLaOcupa() {
        return OcupadaPorPieza;
    }
    public void setPiezaQueLaOcupa(PiezaAjedrez pieza)
    {
       
        Debug.Log("pieza ingresada");
        OcupadaPorPieza = pieza;
      
    }
    public void MostrarPosibilidad() {
        gameObject.layer = 9;// habilitada
    }
    public void OcultarCasilla()
    {
        gameObject.layer = 8;// no habilitada
    }
    public void OnTriggerEnter(Collider other)
    {
        if (other.tag == "PiezaAjedrez") {
            OcupadaPorPieza = other.GetComponent<PiezaAjedrez>();
            other.GetComponent<PiezaAjedrez>().CasillaActual = this;
        }
    }
    public void OnTriggerExit(Collider other)
    {
        if (other.tag == "PiezaAjedrez") {
            OcupadaPorPieza = null;
            other.GetComponent<PiezaAjedrez>().CasillaActual = null;
        }
    }


    // Update is called once per frame
    void Update()
    {
        
        
    }
}

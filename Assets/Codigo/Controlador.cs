using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Controlador : MonoBehaviour
{
    public Jugador JugadorEnJuego;
    public Jugador JugadorEnEspera;
    private Jugador Jugador1;
    private Jugador Jugador2;

    // Start is called before the first frame update
    void Start()
    {

        Jugador1 = GameObject.FindGameObjectWithTag("Jugador1").GetComponent<Jugador>();
        Jugador2 = GameObject.FindGameObjectWithTag("Jugador2").GetComponent<Jugador>();
        JugadorEnJuego = Jugador1;
        JugadorEnEspera = Jugador2;
        if (GameObject.FindGameObjectWithTag("ImageTarget") == null) // iniciar solo si no hay nada o nadie de AR
        {
            FindObjectOfType<SpawnCasillas>().IniciarSpawneo();
        }
      
    }
    private void ComprobarSiJaque() {
        bool Jaque = false;
        PiezaAjedrez ReyActual = null;


        foreach (PiezaAjedrez p in JugadorEnJuego.Piezas)
        {
            if (p.getTipoDePieza() == PiezaAjedrez.pieza.Rey)
            {
                ReyActual = p;
                break;
            }
        }

        foreach(PiezaAjedrez p in JugadorEnEspera.Piezas){
            p.CalcularMovimientos();
            foreach (Casilla c in p.getCasillasValidas()) {
               
                if (c .getPiezaQueLaOcupa() != null && c.getPiezaQueLaOcupa().Equals(ReyActual)) {
                     GameObject.FindGameObjectWithTag("JaqueGameObject").GetComponent<MeshRenderer>().enabled = true;
                    Jaque = true;
                    break;
                }
            }
            if (Jaque) { break; }
        }


        foreach (Casilla c in GameObject.FindObjectsOfType<Casilla>()) {
            c.OcultarCasilla();
        }
        if (!Jaque) {
            GameObject.FindGameObjectWithTag("JaqueGameObject").GetComponent<MeshRenderer>().enabled = false;
        }
       }
    public void CambiarTurno()
    {
        if (Jugador1 == JugadorEnJuego) { JugadorEnJuego = Jugador2; JugadorEnEspera = Jugador1; ComprobarSiJaque(); }
        else { JugadorEnJuego = Jugador1; JugadorEnEspera = Jugador2; ComprobarSiJaque(); }





    }
   

    

    // Update is called once per frame
    void Update()
    {
        
    }
}

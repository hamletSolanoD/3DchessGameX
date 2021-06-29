using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mirror;
public class ControladorOnline : NetworkManager
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
    public void CambiarTurno()
    {
        if (Jugador1 == JugadorEnJuego) { JugadorEnJuego = Jugador2; JugadorEnEspera = Jugador1; }
        else { JugadorEnJuego = Jugador1; JugadorEnEspera = Jugador2; }





    }



}

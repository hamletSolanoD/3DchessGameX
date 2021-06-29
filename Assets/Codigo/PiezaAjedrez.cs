using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PiezaAjedrez : MonoBehaviour
{
    public enum pieza { Peon, Alfil, Torre, Caballo, Rey, Reina }
    public enum Bando { Negro, Blanco }

    [SerializeField]
    private pieza TipoDePieza;
    [SerializeField]
    private Bando BandoDePieza;

    public Casilla CasillaActual;
    private Vector3 DestinoMovimiento;
    private bool moverseActivo;
    private bool primerJugada = true;

    private string Nombre;

    private List<Casilla> casillasValidas = new List<Casilla>();




    [SerializeField]
    private float velocidad = 25;
    [SerializeField]
    private float Altura = 30;


    public pieza getTipoDePieza() { return TipoDePieza; }
    public List<Casilla> getCasillasValidas() {
        return casillasValidas;
    }
    // Start is called before the first frame update
    void Start()
    {
        switch (TipoDePieza) {
            case pieza.Torre: Nombre = "Torre"; break;
            case pieza.Peon: Nombre = "Peon"; break;
            case pieza.Alfil: Nombre = "Alfil"; break;
            case pieza.Rey: Nombre = "Rey"; break;
            case pieza.Reina: Nombre = "Reina"; break;
            case pieza.Caballo: Nombre = "Caballo"; break;

        }

    }


  
    

    public void CalcularMovimientos() {

        Casilla[] CasillasEnJuego = FindObjectsOfType<Casilla>();
        
        int MultiplicadorBando = (this.BandoDePieza == Bando.Blanco ? 1 : -1);
        casillasValidas.Clear();// vaciar casillas validas cada nuevo movimiento
        switch (TipoDePieza)
        {
            case pieza.Peon:
                
               
                foreach (Casilla casilla in CasillasEnJuego)
                {

                    //realmente es la variable z pero en el tablero lo tengo por X y Y
                   
                    //primer juego
                    if (primerJugada) {

                        //Comparar la casillaEnFrente
                        if (((casilla.PosicionReal.x < (transform.position.x + (20 * MultiplicadorBando) + 1)) && (casilla.PosicionReal.x > (transform.position.x + (40 * MultiplicadorBando) - 1)))
                         &&
                        (casilla.PosicionReal.y < transform.position.z + 1 && casilla.PosicionReal.y > transform.position.z - 1))
                        {
                            Debug.Log(casilla.name);
                            if (casilla.getPiezaQueLaOcupa() == null)
                            {  //mover solo si la casilla de enfrente es vacia
                                casilla.MostrarPosibilidad(); //mostrarla
                                casillasValidas.Add(casilla);
                            }
                        }
                       
                        if (((casilla.PosicionReal.x < (transform.position.x + (40 * MultiplicadorBando) + 1)) && (casilla.PosicionReal.x > (transform.position.x + (20 * MultiplicadorBando) - 1)))
                         &&
                        (casilla.PosicionReal.y < transform.position.z + 1 && casilla.PosicionReal.y > transform.position.z - 1))
                        {
                            Debug.Log(casilla.name);
                            if (casilla.getPiezaQueLaOcupa() == null)
                            {  //mover solo si la casilla de enfrente es vacia
                                casilla.MostrarPosibilidad(); //mostrarla
                                casillasValidas.Add(casilla);
                            }
                        }

                    }
                    
                    //Comparar la casillaEnFrente
                   else  if(((casilla.PosicionReal.x < (transform.position.x + (20*MultiplicadorBando)+1)) && (casilla.PosicionReal.x > (transform.position.x + (20 * MultiplicadorBando) - 1)))
                        &&
                       ( casilla.PosicionReal.y < transform.position.z +1  && casilla.PosicionReal.y > transform.position.z - 1))
                    {
                        if (casilla.getPiezaQueLaOcupa() == null)
                        {  //mover solo si la casilla de enfrente es vacia

                            casilla.MostrarPosibilidad(); //mostrarla
                            casillasValidas.Add(casilla);
                        }
                    }



                    if((casilla.PosicionReal.x < transform.position.x + (20*MultiplicadorBando)+1 && casilla.PosicionReal.x > transform.position.x + (20 * MultiplicadorBando) - 1)
                        &&
                        (casilla.PosicionReal.y < transform.position.z+20+1 && casilla.PosicionReal.y > transform.position.z + 20 -1 )){ 
                        if (casilla.getPiezaQueLaOcupa() != null && casilla.getPiezaQueLaOcupa().BandoDePieza != this.BandoDePieza)
                        {// mover si es para comer
                        
                            casilla.MostrarPosibilidad(); //mostrarla
                            casillasValidas.Add(casilla);
                        }
                    }
                    // CasillaendiagonalIzquierda
                    if ((casilla.PosicionReal.x < transform.position.x + (20 * MultiplicadorBando) + 1 && casilla.PosicionReal.x > transform.position.x + (20 * MultiplicadorBando) - 1)
                       &&
                       (casilla.PosicionReal.y < transform.position.z - 20 + 1 && casilla.PosicionReal.y > transform.position.z - 20 - 1))
                    {
                        if (casilla.getPiezaQueLaOcupa() != null && casilla.getPiezaQueLaOcupa().BandoDePieza != this.BandoDePieza)
                        {
                     
                            casilla.MostrarPosibilidad(); //mostrarla
                            casillasValidas.Add(casilla);
                        }
                    }
                }
                break;
            case pieza.Alfil:
                {
                    float DiagonalContX = transform.position.x, DiagonalContY = transform.position.z;
                    Casilla Casillabuscada = null;
                    /// DiagonalDerecha Superior
                    while (DiagonalContX <= 141 && DiagonalContY <= 141)
                    {
                        Casillabuscada = null;
                        foreach (Casilla cas in CasillasEnJuego)
                        {
                            if (cas.PosicionReal.x == DiagonalContX && cas.PosicionReal.y == DiagonalContY)
                            {
                                Casillabuscada = cas;

                                break;
                            }
                        }
                        if (Casillabuscada != null)
                        {
                            if (Casillabuscada.getPiezaQueLaOcupa() == null) { Casillabuscada.MostrarPosibilidad(); casillasValidas.Add(Casillabuscada); }
                            else if (Casillabuscada.getPiezaQueLaOcupa().BandoDePieza != this.BandoDePieza) { Casillabuscada.MostrarPosibilidad(); casillasValidas.Add(Casillabuscada); break; }
                            else if (Casillabuscada.getPiezaQueLaOcupa() != this) { break; }
                        }
                        DiagonalContY += 20; DiagonalContX += 20;
                    }

                    DiagonalContX = transform.position.x;
                    DiagonalContY = transform.position.z;

                    /// DiagonalIzqu Superior
                    while (DiagonalContX <= 141 && DiagonalContY >= -1)
                    {
                        Casillabuscada = null;
                        foreach (Casilla cas in CasillasEnJuego)
                        {
                            if (cas.PosicionReal.x == DiagonalContX && cas.PosicionReal.y == DiagonalContY)
                            {
                                Casillabuscada = cas; break;
                            }
                        }
                        if (Casillabuscada != null)
                        {
                            if (Casillabuscada.getPiezaQueLaOcupa() == null) { Casillabuscada.MostrarPosibilidad(); casillasValidas.Add(Casillabuscada); }
                            else if (Casillabuscada.getPiezaQueLaOcupa().BandoDePieza != this.BandoDePieza) { Casillabuscada.MostrarPosibilidad(); casillasValidas.Add(Casillabuscada); break; }
                            else if (Casillabuscada.getPiezaQueLaOcupa() != this) { break; }
                        }
                        DiagonalContY -= 20; DiagonalContX += 20;
                    }

                    DiagonalContX = transform.position.x;
                    DiagonalContY = transform.position.z;
                    /// DiagonalDerech Inferior
                    while (DiagonalContX >= -1 && DiagonalContY >= -1)
                    {
                        Casillabuscada = null;
                        foreach (Casilla cas in CasillasEnJuego)
                        {
                            if (cas.PosicionReal.x == DiagonalContX && cas.PosicionReal.y == DiagonalContY)
                            {
                                Casillabuscada = cas; break;
                            }
                        }
                        if (Casillabuscada != null)
                        {
                            if (Casillabuscada.getPiezaQueLaOcupa() == null) { Casillabuscada.MostrarPosibilidad(); casillasValidas.Add(Casillabuscada); }
                            else if (Casillabuscada.getPiezaQueLaOcupa().BandoDePieza != this.BandoDePieza) { Casillabuscada.MostrarPosibilidad(); casillasValidas.Add(Casillabuscada); break; }
                            else if (Casillabuscada.getPiezaQueLaOcupa() != this) { break; }
                        }
                        DiagonalContY -= 20; DiagonalContX -= 20;
                    }


                    DiagonalContX = transform.position.x;
                    DiagonalContY = transform.position.z;

                    /// DiagonalIzqu Inferior
                    while (DiagonalContX >= -1 && DiagonalContY <= 141)
                    {
                        Casillabuscada = null;
                        foreach (Casilla cas in CasillasEnJuego)
                        {
                            if (cas.PosicionReal.x == DiagonalContX && cas.PosicionReal.y == DiagonalContY)
                            {
                                Casillabuscada = cas; break;
                            }
                        }
                        if (Casillabuscada != null)
                        {
                            if (Casillabuscada.getPiezaQueLaOcupa() == null) { Casillabuscada.MostrarPosibilidad(); casillasValidas.Add(Casillabuscada); }
                            else if (Casillabuscada.getPiezaQueLaOcupa().BandoDePieza != this.BandoDePieza) { Casillabuscada.MostrarPosibilidad(); casillasValidas.Add(Casillabuscada); break; }
                            else if (Casillabuscada.getPiezaQueLaOcupa() != this) { break; }
                        }
                        DiagonalContY += 20; DiagonalContX -= 20;
                    }
                }
                break;

            case pieza.Caballo:
                foreach (Casilla cas in CasillasEnJuego) {
                    float hipotenusa = Vector2.Distance(cas.PosicionReal, new Vector2(transform.position.x, transform.position.z));

                    Debug.Log("Casilla: " + cas + " " + hipotenusa);

                    if (hipotenusa <= 46 && hipotenusa >= 42)// numero calculado en la practica 
                    {
                        if (cas.getPiezaQueLaOcupa() == null) { casillasValidas.Add(cas); cas.MostrarPosibilidad(); }
                        else if (cas.getPiezaQueLaOcupa().BandoDePieza != this.BandoDePieza) { casillasValidas.Add(cas); cas.MostrarPosibilidad(); }

                    }
                        }
                break;

            case pieza.Torre:
                { /// Vertical arriba
                    for (float posicionXArriba = transform.position.x + 20; posicionXArriba <= 141; posicionXArriba += 20)
                    {
                        Casilla casBuscada = null;
                        foreach (Casilla cas in CasillasEnJuego)
                        {
                            if (cas.PosicionReal.x == posicionXArriba && cas.PosicionReal.y == transform.position.z)
                            {
                                casBuscada = cas;
                            }
                        }
                        if (casBuscada != null)
                        {
                            if (casBuscada.getPiezaQueLaOcupa() == null) { casillasValidas.Add(casBuscada); casBuscada.MostrarPosibilidad(); }
                            else if (casBuscada.getPiezaQueLaOcupa().BandoDePieza != this.BandoDePieza) { casillasValidas.Add(casBuscada); casBuscada.MostrarPosibilidad(); break; }
                            else { break; }
                        }
                    }
                    //vertical hacia abajo
                    for (float posicionXAbajo = transform.position.x - 20; posicionXAbajo >= -1; posicionXAbajo -= 20)
                    {
                        Casilla casBuscada = null;
                        foreach (Casilla cas in CasillasEnJuego)
                        {
                            if (cas.PosicionReal.x == posicionXAbajo && cas.PosicionReal.y == transform.position.z)
                            {
                                casBuscada = cas;
                            }
                        }
                        if (casBuscada != null)
                        {
                            if (casBuscada.getPiezaQueLaOcupa() == null) { casillasValidas.Add(casBuscada); casBuscada.MostrarPosibilidad(); }
                            else if (casBuscada.getPiezaQueLaOcupa().BandoDePieza != this.BandoDePieza) { casillasValidas.Add(casBuscada); casBuscada.MostrarPosibilidad(); break; }
                            else { break; }
                        }
                    }
                    //Horizontal hacia izq
                    for (float posicionZIsq = transform.position.z + 20; posicionZIsq <= 141; posicionZIsq += 20)
                    {
                        Casilla casBuscada = null;
                        foreach (Casilla cas in CasillasEnJuego)
                        {
                            if (cas.PosicionReal.y == posicionZIsq && cas.PosicionReal.x == transform.position.x)
                            {
                                casBuscada = cas;
                            }
                        }
                        if (casBuscada != null)
                        {
                            if (casBuscada.getPiezaQueLaOcupa() == null) { casillasValidas.Add(casBuscada); casBuscada.MostrarPosibilidad(); }
                            else if (casBuscada.getPiezaQueLaOcupa().BandoDePieza != this.BandoDePieza) { casillasValidas.Add(casBuscada); casBuscada.MostrarPosibilidad(); break; }
                            else { break; }
                        }
                    }
                    for (float posicionZDER = transform.position.z - 20; posicionZDER >= -1; posicionZDER -= 20)
                    {
                        Casilla casBuscada = null;
                        foreach (Casilla cas in CasillasEnJuego)
                        {
                            if (cas.PosicionReal.y == posicionZDER && cas.PosicionReal.x == transform.position.x)
                            {
                                casBuscada = cas;
                            }
                        }
                        if (casBuscada != null)
                        {
                            if (casBuscada.getPiezaQueLaOcupa() == null) { casillasValidas.Add(casBuscada); casBuscada.MostrarPosibilidad(); }
                            else if (casBuscada.getPiezaQueLaOcupa().BandoDePieza != this.BandoDePieza) { casillasValidas.Add(casBuscada); casBuscada.MostrarPosibilidad(); break; }
                            else { break; }
                        }
                    }
                }
                break;
            case pieza.Reina:
                //Torre
                { /// Vertical arriba
                    for (float posicionXArriba = transform.position.x + 20; posicionXArriba <= 141; posicionXArriba += 20)
                    {
                        Casilla casBuscada = null;
                        foreach (Casilla cas in CasillasEnJuego)
                        {
                            if (cas.PosicionReal.x == posicionXArriba && cas.PosicionReal.y == transform.position.z)
                            {
                                casBuscada = cas;
                            }
                        }
                        if (casBuscada != null)
                        {
                            if (casBuscada.getPiezaQueLaOcupa() == null) { casillasValidas.Add(casBuscada); casBuscada.MostrarPosibilidad(); }
                            else if (casBuscada.getPiezaQueLaOcupa().BandoDePieza != this.BandoDePieza) { casillasValidas.Add(casBuscada); casBuscada.MostrarPosibilidad(); break; }
                            else { break; }
                        }
                    }
                    //vertical hacia abajo
                    for (float posicionXAbajo = transform.position.x - 20; posicionXAbajo >= -1; posicionXAbajo -= 20)
                    {
                        Casilla casBuscada = null;
                        foreach (Casilla cas in CasillasEnJuego)
                        {
                            if (cas.PosicionReal.x == posicionXAbajo && cas.PosicionReal.y == transform.position.z)
                            {
                                casBuscada = cas;
                            }
                        }
                        if (casBuscada != null)
                        {
                            if (casBuscada.getPiezaQueLaOcupa() == null) { casillasValidas.Add(casBuscada); casBuscada.MostrarPosibilidad(); }
                            else if (casBuscada.getPiezaQueLaOcupa().BandoDePieza != this.BandoDePieza) { casillasValidas.Add(casBuscada); casBuscada.MostrarPosibilidad(); break; }
                            else { break; }
                        }
                    }
                    //Horizontal hacia izq
                    for (float posicionZIsq = transform.position.z + 20; posicionZIsq <= 141; posicionZIsq += 20)
                    {
                        Casilla casBuscada = null;
                        foreach (Casilla cas in CasillasEnJuego)
                        {
                            if (cas.PosicionReal.y == posicionZIsq && cas.PosicionReal.x == transform.position.x)
                            {
                                casBuscada = cas;
                            }
                        }
                        if (casBuscada != null)
                        {
                            if (casBuscada.getPiezaQueLaOcupa() == null) { casillasValidas.Add(casBuscada); casBuscada.MostrarPosibilidad(); }
                            else if (casBuscada.getPiezaQueLaOcupa().BandoDePieza != this.BandoDePieza) { casillasValidas.Add(casBuscada); casBuscada.MostrarPosibilidad(); break; }
                            else { break; }
                        }
                    }
                    for (float posicionZDER = transform.position.z - 20; posicionZDER >= -1; posicionZDER -= 20)
                    {
                        Casilla casBuscada = null;
                        foreach (Casilla cas in CasillasEnJuego)
                        {
                            if (cas.PosicionReal.y == posicionZDER && cas.PosicionReal.x == transform.position.x)
                            {
                                casBuscada = cas;
                            }
                        }
                        if (casBuscada != null)
                        {
                            if (casBuscada.getPiezaQueLaOcupa() == null) { casillasValidas.Add(casBuscada); casBuscada.MostrarPosibilidad(); }
                            else if (casBuscada.getPiezaQueLaOcupa().BandoDePieza != this.BandoDePieza) { casillasValidas.Add(casBuscada); casBuscada.MostrarPosibilidad(); break; }
                            else { break; }
                        }
                    }
                }
                //alfil
                {
                        float DiagonalContX = transform.position.x, DiagonalContY = transform.position.z;
                        Casilla Casillabuscada = null;
                        /// DiagonalDerecha Superior
                        while (DiagonalContX <= 141 && DiagonalContY <= 141)
                        {
                            Casillabuscada = null;
                            foreach (Casilla cas in CasillasEnJuego)
                            {
                                if (cas.PosicionReal.x == DiagonalContX && cas.PosicionReal.y == DiagonalContY)
                                {
                                    Casillabuscada = cas;

                                    break;
                                }
                            }
                            if (Casillabuscada != null)
                            {
                                if (Casillabuscada.getPiezaQueLaOcupa() == null) { Casillabuscada.MostrarPosibilidad(); casillasValidas.Add(Casillabuscada); }
                                else if (Casillabuscada.getPiezaQueLaOcupa().BandoDePieza != this.BandoDePieza) { Casillabuscada.MostrarPosibilidad(); casillasValidas.Add(Casillabuscada); break; }
                                else if (Casillabuscada.getPiezaQueLaOcupa() != this) { break; }
                            }
                            DiagonalContY += 20; DiagonalContX += 20;
                        }

                        DiagonalContX = transform.position.x;
                        DiagonalContY = transform.position.z;

                        /// DiagonalIzqu Superior
                        while (DiagonalContX <= 141 && DiagonalContY >= -1)
                        {
                            Casillabuscada = null;
                            foreach (Casilla cas in CasillasEnJuego)
                            {
                                if (cas.PosicionReal.x == DiagonalContX && cas.PosicionReal.y == DiagonalContY)
                                {
                                    Casillabuscada = cas; break;
                                }
                            }
                            if (Casillabuscada != null)
                            {
                                if (Casillabuscada.getPiezaQueLaOcupa() == null) { Casillabuscada.MostrarPosibilidad(); casillasValidas.Add(Casillabuscada); }
                                else if (Casillabuscada.getPiezaQueLaOcupa().BandoDePieza != this.BandoDePieza) { Casillabuscada.MostrarPosibilidad(); casillasValidas.Add(Casillabuscada); break; }
                                else if (Casillabuscada.getPiezaQueLaOcupa() != this) { break; }
                            }
                            DiagonalContY -= 20; DiagonalContX += 20;
                        }

                        DiagonalContX = transform.position.x;
                        DiagonalContY = transform.position.z;
                        /// DiagonalDerech Inferior
                        while (DiagonalContX >= -1 && DiagonalContY >= -1)
                        {
                            Casillabuscada = null;
                            foreach (Casilla cas in CasillasEnJuego)
                            {
                                if (cas.PosicionReal.x == DiagonalContX && cas.PosicionReal.y == DiagonalContY)
                                {
                                    Casillabuscada = cas; break;
                                }
                            }
                            if (Casillabuscada != null)
                            {
                                if (Casillabuscada.getPiezaQueLaOcupa() == null) { Casillabuscada.MostrarPosibilidad(); casillasValidas.Add(Casillabuscada); }
                                else if (Casillabuscada.getPiezaQueLaOcupa().BandoDePieza != this.BandoDePieza) { Casillabuscada.MostrarPosibilidad(); casillasValidas.Add(Casillabuscada); break; }
                                else if (Casillabuscada.getPiezaQueLaOcupa() != this) { break; }
                            }
                            DiagonalContY -= 20; DiagonalContX -= 20;
                        }


                        DiagonalContX = transform.position.x;
                        DiagonalContY = transform.position.z;

                        /// DiagonalIzqu Inferior
                        while (DiagonalContX >= -1 && DiagonalContY <= 141)
                        {
                            Casillabuscada = null;
                            foreach (Casilla cas in CasillasEnJuego)
                            {
                                if (cas.PosicionReal.x == DiagonalContX && cas.PosicionReal.y == DiagonalContY)
                                {
                                    Casillabuscada = cas; break;
                                }
                            }
                            if (Casillabuscada != null)
                            {
                                if (Casillabuscada.getPiezaQueLaOcupa() == null) { Casillabuscada.MostrarPosibilidad(); casillasValidas.Add(Casillabuscada); }
                                else if (Casillabuscada.getPiezaQueLaOcupa().BandoDePieza != this.BandoDePieza) { Casillabuscada.MostrarPosibilidad(); casillasValidas.Add(Casillabuscada); break; }
                                else if (Casillabuscada.getPiezaQueLaOcupa() != this) { break; }
                            }
                            DiagonalContY += 20; DiagonalContX -= 20;
                        }
                    }
                break;
            case pieza.Rey:
                foreach (Casilla cas in CasillasEnJuego) {
                   
                    if (Vector2.Distance(cas.PosicionReal, new Vector2(transform.position.x, transform.position.z)) >= 20 && Vector2.Distance(cas.PosicionReal, new Vector2(transform.position.x, transform.position.z)) <= 29)
                    {
                        if (cas.getPiezaQueLaOcupa() == null) { casillasValidas.Add(cas); cas.MostrarPosibilidad(); }
                        else if (cas.getPiezaQueLaOcupa().BandoDePieza != this.BandoDePieza) { casillasValidas.Add(cas); cas.MostrarPosibilidad();

                        }
                    }
                 
                }
                break;

        }
       
    }
    public  void Moverse(Casilla Casilla) {

        if (GameObject.FindObjectOfType<TimerContador>().contador > 1)
        {
            if (casillasValidas.Contains(Casilla))
            {
                DestinoMovimiento = new Vector3(Casilla.PosicionReal.x, transform.position.y, Casilla.PosicionReal.y);
                moverseActivo = true;
                primerJugada = false;
                Debug.Log("Turno Valido");
                GameObject.FindObjectOfType<TimerContador>().CambioDeTurno();
                GameObject.FindObjectOfType<InteraccionCamara>().setSeleccionActivada(false);
            }
            else
            {

                Debug.Log("Turno Invaldo");
                GameObject.FindObjectOfType<ConsolaControlador>().ImprimirTexto("Movimiento Invaldo", Color.yellow);

            }
        }
    }
    public void MoverseAutomata(Casilla Casilla)
    {

        
            if (casillasValidas.Contains(Casilla))
            {
                DestinoMovimiento = new Vector3(Casilla.PosicionReal.x, transform.position.y, Casilla.PosicionReal.y);
                moverseActivo = true;
                primerJugada = false;
                Debug.Log("Turno Valido");
            GameObject.FindObjectOfType<InteraccionCamara>().setSeleccionActivada(false);
           


        }
        else
            {

                Debug.Log("Turno Invaldo");
                GameObject.FindObjectOfType<ConsolaControlador>().ImprimirTexto("Movimiento Invaldo", Color.yellow);

            }
        
    }
    public List<Casilla> getPosiblesMovimientos() {
        return casillasValidas;
    }
  
    public void Atacar(PiezaAjedrez piezaEnemiga) {

        if (GameObject.FindObjectOfType<TimerContador>().contador > 1)
        {

            if (casillasValidas.Contains(piezaEnemiga.CasillaActual))
            {
                DestinoMovimiento = new Vector3(piezaEnemiga.CasillaActual.PosicionReal.x, transform.position.y, piezaEnemiga.CasillaActual.PosicionReal.y);
                moverseActivo = true;
                primerJugada = false;
                Debug.Log("Turno Valido");
                GameObject.FindObjectOfType<TimerContador>().CambioDeTurno();
                GameObject.FindObjectOfType<Controlador>().JugadorEnEspera.Piezas.Remove(piezaEnemiga);
                Destroy(piezaEnemiga.gameObject);
                GameObject.FindObjectOfType<InteraccionCamara>().setSeleccionActivada(false);
                GameObject.FindObjectOfType<ConsolaControlador>().ImprimirTexto(FindObjectOfType<Controlador>().JugadorEnJuego.Nombre + " ha comido " + piezaEnemiga.Nombre + " de " + FindObjectOfType<Controlador>().JugadorEnEspera.Nombre, Color.blue);

            }
            else
            {
                Debug.Log("Turno Invaldo");
                GameObject.FindObjectOfType<ConsolaControlador>().ImprimirTexto("Movimiento Invaldo", Color.yellow);

            }
        }

    }
    public void AtacarAutomata(PiezaAjedrez piezaEnemiga)
    {

        if (GameObject.FindObjectOfType<TimerContador>().contador > 1)
        {

            if (casillasValidas.Contains(piezaEnemiga.CasillaActual))
            {
                DestinoMovimiento = new Vector3(piezaEnemiga.CasillaActual.PosicionReal.x, transform.position.y, piezaEnemiga.CasillaActual.PosicionReal.y);
                moverseActivo = true;
                primerJugada = false;
                Debug.Log("Turno Valido");
                GameObject.FindObjectOfType<Controlador>().JugadorEnEspera.Piezas.Remove(piezaEnemiga);
                Destroy(piezaEnemiga.gameObject);
                GameObject.FindObjectOfType<InteraccionCamara>().setSeleccionActivada(false);
                GameObject.FindObjectOfType<ConsolaControlador>().ImprimirTexto(FindObjectOfType<Controlador>().JugadorEnJuego.Nombre + " ha comido " + piezaEnemiga.Nombre + " de " + FindObjectOfType<Controlador>().JugadorEnEspera.Nombre , Color.blue);

            }
            else
            {
                Debug.Log("Turno Invaldo");
                GameObject.FindObjectOfType<ConsolaControlador>().ImprimirTexto("Movimiento Invaldo", Color.yellow);

            }
        }

    }
    private void AnimacionMoverse()
    {
        if (moverseActivo) {
            if ((transform.position.x < DestinoMovimiento.x + 1 && transform.position.x > DestinoMovimiento.x - 1) && (transform.position.z < DestinoMovimiento.z + 1 && transform.position.z > DestinoMovimiento.z - 1))
            {
                transform.position = Vector3.MoveTowards(transform.position, DestinoMovimiento, velocidad * Time.deltaTime);

                if (transform.position.y > DestinoMovimiento.y - 1 && transform.position.y < DestinoMovimiento.y + 1)
                {
                    moverseActivo = false;
                    transform.position = new Vector3(Mathf.Round(transform.position.x), transform.position.y, Mathf.Round(transform.position.z));
                    GameObject.FindGameObjectWithTag("Controlador").GetComponent<Controlador>().CambiarTurno();
                    GameObject.FindObjectOfType<InteraccionCamara>().setSeleccionActivada(true);

                }

            }
            else
            {
                transform.position = Vector3.MoveTowards(transform.position, new Vector3(DestinoMovimiento.x, DestinoMovimiento.y + Altura, DestinoMovimiento.z), velocidad * Time.deltaTime);
            }

        }

    }
    // Update is called once per frame
    void Update()
    {
        AnimacionMoverse();
      
    }
}

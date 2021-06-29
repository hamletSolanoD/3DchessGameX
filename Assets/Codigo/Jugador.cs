using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Jugador : MonoBehaviour
{

    public List<PiezaAjedrez> Piezas = new  List<PiezaAjedrez>();
    [SerializeField]
    private bool prueba;
    private GameObject ObjetoSeleccionado;
    public string Nombre;

  




    // Start is called before the first frame update
    void Start()
    {
        
    }
 
    
    public void SeleccionHecha(GameObject Seleccion)
    {

        //Resetear casillas en cada seleccion
        
            foreach (Casilla casilla in FindObjectsOfType<Casilla>())
            {
                casilla.OcultarCasilla(); //ocultar antes de mostrar
            }

            if (ObjetoSeleccionado == Seleccion) // seleccionar 2 veces la misma pieza deselecciona
            {
                if (prueba) Debug.Log("ObjetoRepetido");
                ObjetoSeleccionado = null;
            }

            else if (Seleccion.transform.tag == "PiezaAjedrez")
            { //seleccionar una pieza de ajedrez
                if (Piezas.Contains(Seleccion.GetComponent<PiezaAjedrez>()))// seleccionar una pieza de ajedrez propia
                {
                    if (prueba) Debug.Log("Pieza Seleccionada");
                    ObjetoSeleccionado = Seleccion;
                    Seleccion.GetComponent<PiezaAjedrez>().CalcularMovimientos();
                }
                else if (ObjetoSeleccionado != null && ObjetoSeleccionado.transform.tag == "PiezaAjedrez")
                {// seleccionar una pieza de ajedrez del otro jugador para comer
                    if (prueba) Debug.Log("Ordenando Ataque");
                    Debug.Log(Seleccion.name);
                    ObjetoSeleccionado.GetComponent<PiezaAjedrez>().Atacar(Seleccion.GetComponent<PiezaAjedrez>());
                    ObjetoSeleccionado = null;
                }
                else// seleccionar otra pieza sin ningun sentido :v
                {
                    if (prueba) Debug.Log("Pieza de otro jugador, INVALIDO");
                    GameObject.FindObjectOfType<ConsolaControlador>().ImprimirTexto("Pieza de otro jugador", Color.red);
                    ObjetoSeleccionado = null;
                }

            }
            else if (Seleccion.transform.tag == "Casilla")
            {
                if (prueba) Debug.Log("Casilla Seleccionada");
                if (ObjetoSeleccionado != null && ObjetoSeleccionado.transform.tag == "PiezaAjedrez")
                {// SeleccionarUnaCasillaParaMover
                    if (prueba) Debug.Log("Camino Trazado");
                    ObjetoSeleccionado.GetComponent<PiezaAjedrez>().Moverse(Seleccion.GetComponent<Casilla>());
                    ObjetoSeleccionado = null;
                }
                else
                {
                    ObjetoSeleccionado = Seleccion;
                }
            }
            else
            {
                if (prueba) Debug.Log("Objeto Indistinguible: " + Seleccion.transform.name);
                if (prueba) Debug.Log("Objeto tag: " + Seleccion.transform.tag);
            }

        }
    
    public void AgregarPiezas(PiezaAjedrez piezaNueva) {
        Piezas.Add(piezaNueva);
    }
    public void TurnoNoJugado() {
        bool PiezaEncontrada = false;
          do
         {
            PiezaAjedrez pieza = Piezas[Random.Range(0, Piezas.ToArray().Length - 1)];
            pieza.CalcularMovimientos();
            foreach (Casilla casilla in FindObjectsOfType<Casilla>())
            {
                casilla.OcultarCasilla(); //ocultar antes de mostrar
            }
            if (pieza.getPosiblesMovimientos().ToArray().Length >= 1)
            {
                PiezaEncontrada = true;
                Casilla ObjetivoCasilla = pieza.getPosiblesMovimientos()[Random.Range(0, pieza.getPosiblesMovimientos().ToArray().Length - 1)];

                if (ObjetivoCasilla.getPiezaQueLaOcupa() != null)  pieza.AtacarAutomata(ObjetivoCasilla.getPiezaQueLaOcupa()); 
                else pieza.MoverseAutomata(ObjetivoCasilla);
            }
        } while (PiezaEncontrada == false);

    }



    // Update is called once per frame
    void Update()
    {
        
    }
}

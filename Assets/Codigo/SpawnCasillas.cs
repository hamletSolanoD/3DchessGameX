using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnCasillas : MonoBehaviour
{

    private enum  piezas { peon, torre, alfil, caballo, reina, rey, };
    // Start is called before the first frame update
    [SerializeField]
    private GameObject Casilla;
    [SerializeField]
    private float CuadroMedida = 20;
    [SerializeField]
    private float CasillaMedida = 15;

    [SerializeField]
    GameObject[] ArrayPiezasBlancas = new GameObject[6];
    [SerializeField]
    GameObject[] ArrayPiezasNegras = new GameObject[6];

    private bool primerSpawn = false;

    public void Start()
    {
        if (GameObject.FindGameObjectWithTag("ImageTarget") != null) //apagar inicio si hay algo de AR
        {
            this.gameObject.SetActive(false);
          
        }
    }
    public void IniciarSpawneo() // si hay algo de AR activarlo con el tracker
    {
        if (!primerSpawn)
        {
            primerSpawn = true;
            Jugador Jugador1 = GameObject.FindGameObjectWithTag("Jugador1").GetComponent<Jugador>();
            Jugador Jugador2 = GameObject.FindGameObjectWithTag("Jugador2").GetComponent<Jugador>();
            int IDCasilla = 1;
            for (int x = 0; x < 8; x++)
            {
                for (int y = 0; y < 8; y++)
                {
                    GameObject CasillaInstanciada = Instantiate(Casilla, new Vector3((CuadroMedida * x) + ((5 * CasillaMedida) / 8), 0, (CuadroMedida * y) + ((5 * CasillaMedida) / 8)), transform.rotation, this.transform);
                    switch (IDCasilla)
                    {
                        case 1: Jugador1.AgregarPiezas(Instantiate(ArrayPiezasBlancas[(int)piezas.torre], new Vector3(x * CuadroMedida, 0, y * CuadroMedida), transform.rotation, this.transform).GetComponent<PiezaAjedrez>()); break;
                        case 2: Jugador1.AgregarPiezas(Instantiate(ArrayPiezasBlancas[(int)piezas.caballo], new Vector3(x * CuadroMedida, 0, y * CuadroMedida), transform.rotation, this.transform).GetComponent<PiezaAjedrez>()); break;
                        case 3: Jugador1.AgregarPiezas(Instantiate(ArrayPiezasBlancas[(int)piezas.alfil], new Vector3(x * CuadroMedida, 0, y * CuadroMedida), transform.rotation, this.transform).GetComponent<PiezaAjedrez>()); break;
                        case 4: Jugador1.AgregarPiezas(Instantiate(ArrayPiezasBlancas[(int)piezas.rey], new Vector3(x * CuadroMedida, 0, y * CuadroMedida), transform.rotation, this.transform).GetComponent<PiezaAjedrez>()); break;
                        case 5: Jugador1.AgregarPiezas(Instantiate(ArrayPiezasBlancas[(int)piezas.reina], new Vector3(x * CuadroMedida, 0, y * CuadroMedida), transform.rotation, this.transform).GetComponent<PiezaAjedrez>()); break;
                        case 6: Jugador1.AgregarPiezas(Instantiate(ArrayPiezasBlancas[(int)piezas.alfil], new Vector3(x * CuadroMedida, 0, y * CuadroMedida), transform.rotation, this.transform).GetComponent<PiezaAjedrez>()); break;
                        case 7: Jugador1.AgregarPiezas(Instantiate(ArrayPiezasBlancas[(int)piezas.caballo], new Vector3(x * CuadroMedida, 0, y * CuadroMedida), transform.rotation, this.transform).GetComponent<PiezaAjedrez>()); break;
                        case 8: Jugador1.AgregarPiezas(Instantiate(ArrayPiezasBlancas[(int)piezas.torre], new Vector3(x * CuadroMedida, 0, y * CuadroMedida), transform.rotation, this.transform).GetComponent<PiezaAjedrez>()); break;
                        case 9:
                        case 10:
                        case 11:
                        case 12:
                        case 13:
                        case 14:
                        case 15:
                        case 16: Jugador1.AgregarPiezas(Instantiate(ArrayPiezasBlancas[(int)piezas.peon], new Vector3(x * CuadroMedida, 0, y * CuadroMedida), transform.rotation, this.transform).GetComponent<PiezaAjedrez>()); break;


                        /// Desfaces aplicados

                        case 49:
                        case 50:
                        case 51:
                        case 52:
                        case 53:
                        case 54:
                        case 55:
                        case 56: Jugador2.AgregarPiezas(Instantiate(ArrayPiezasNegras[(int)piezas.peon], new Vector3(x * CuadroMedida, 0, y * CuadroMedida), transform.rotation, this.transform).GetComponent<PiezaAjedrez>()); break;
                        case 57: Jugador2.AgregarPiezas(Instantiate(ArrayPiezasNegras[(int)piezas.torre], new Vector3((x * CuadroMedida), 0, (y * CuadroMedida)), transform.rotation, this.transform).GetComponent<PiezaAjedrez>()); break;
                        case 58: Jugador2.AgregarPiezas(Instantiate(ArrayPiezasNegras[(int)piezas.caballo], new Vector3((x * CuadroMedida), 0, (y * CuadroMedida)), transform.rotation, this.transform).GetComponent<PiezaAjedrez>()); break;
                        case 59: Jugador2.AgregarPiezas(Instantiate(ArrayPiezasNegras[(int)piezas.alfil], new Vector3((x * CuadroMedida), 0, (y * CuadroMedida)), transform.rotation, this.transform).GetComponent<PiezaAjedrez>()); break;
                        case 60: Jugador2.AgregarPiezas(Instantiate(ArrayPiezasNegras[(int)piezas.rey], new Vector3((x * CuadroMedida), 0, (y * CuadroMedida)), transform.rotation, this.transform).GetComponent<PiezaAjedrez>()); break;
                        case 61: Jugador2.AgregarPiezas(Instantiate(ArrayPiezasNegras[(int)piezas.reina], new Vector3((x * CuadroMedida), 0, (y * CuadroMedida)), transform.rotation, this.transform).GetComponent<PiezaAjedrez>()); break;
                        case 62: Jugador2.AgregarPiezas(Instantiate(ArrayPiezasNegras[(int)piezas.alfil], new Vector3((x * CuadroMedida), 0, (y * CuadroMedida)), transform.rotation, this.transform).GetComponent<PiezaAjedrez>()); break;
                        case 63: Jugador2.AgregarPiezas(Instantiate(ArrayPiezasNegras[(int)piezas.caballo], new Vector3((x * CuadroMedida), 0, (y * CuadroMedida)), transform.rotation, this.transform).GetComponent<PiezaAjedrez>()); break;
                        case 64: Jugador2.AgregarPiezas(Instantiate(ArrayPiezasNegras[(int)piezas.torre], new Vector3((x * CuadroMedida), 0, (y * CuadroMedida)), transform.rotation, this.transform).GetComponent<PiezaAjedrez>()); ; break;
                    }


                    CasillaInstanciada.transform.name = "Casilla" + IDCasilla;
                    CasillaInstanciada.GetComponent<Casilla>().PosicionReal.x = x * 20;
                    CasillaInstanciada.GetComponent<Casilla>().PosicionReal.y = y * 20;
                    IDCasilla++;


                }

            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

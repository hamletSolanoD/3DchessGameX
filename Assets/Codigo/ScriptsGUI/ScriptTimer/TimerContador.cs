using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class TimerContador : MonoBehaviour
{
    [SerializeField]
    private float TiempoLimite = 60;
    public float contador;
    public bool contadorActivado;
    [SerializeField]
    private Image Fill;
    [SerializeField]
    private Image BackGround;

    private bool TimmerPausado = false;
    // Start is called before the first frame update
    void Start()
    {
        if (!contadorActivado) { this.gameObject.SetActive(false); }
        else {
            contador = TiempoLimite;
            Fill.color = Color.black;
            BackGround.color = Color.white;
            GetComponent<Slider>().maxValue = TiempoLimite;

        }
    }
    public void CambioDeTurno()
    {
      
        if (Fill.color == Color.black) {
            Fill.color = Color.white;
            BackGround.color = Color.black;
        }
        else {
            Fill.color = Color.black;
            BackGround.color = Color.white;
        }
        contador = TiempoLimite;
    }

    public void TimmerPausa(bool Timmer) {
        TimmerPausado = Timmer;
    }
// Update is called once per frame
void Update()
    {

        if(!TimmerPausado){
            GetComponent<Slider>().value = contador;
            if (contador <= 3) {
                GameObject.FindObjectOfType<InteraccionCamara>().setSeleccionActivada(false);
                GameObject.FindObjectOfType<Controlador>().JugadorEnJuego.TurnoNoJugado();
                CambioDeTurno();
            }
            else {
                contador -= Time.deltaTime;
            }

        }



    }
}

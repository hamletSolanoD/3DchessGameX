using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ConsolaControlador : MonoBehaviour
{
    [SerializeField]
    private Text Mensaje;
    private ScrollRect scroll;

    [SerializeField]
    List<Text> Mensajes = new List<Text>();
    // Start is called before the first frame update
    void Start()
    {
        scroll = FindObjectOfType<ScrollRect>();



    }

    public void ImprimirTexto(string Texto, Color clrLetra) {
        if (Mensajes.ToArray().Length > 30) {
            Mensajes.RemoveAt(0);
        }

        Text nuevoMensaje = Instantiate(Mensaje,this.transform);
        nuevoMensaje.color = clrLetra;
        nuevoMensaje.text = Texto;
       scroll.verticalScrollbar.value = 0;
        Mensajes.Add(nuevoMensaje);
    }
    // Update is called once per frame
    void Update()
    {
      
        
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ConsolaBarraTexto : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }
    public void MandarTextoEscrito() {
        GameObject.FindObjectOfType<ConsolaControlador>().ImprimirTexto(GetComponent<InputField>().text, Color.blue);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

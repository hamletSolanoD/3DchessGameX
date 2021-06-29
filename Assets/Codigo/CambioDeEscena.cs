using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CambioDeEscena : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }
    public void CambiarEscena(string Escena) {
        SceneManager.LoadScene(Escena);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

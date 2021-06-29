using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Camera))]
public class InteraccionCamara : MonoBehaviour
{

    private Controlador ControladorJuego;
    private bool SeleccionActivada;

    private float PosicionX;
    private float PosicionY;

    // Start is called before the first frame update
    void Start()
    {
        ControladorJuego = FindObjectOfType<Controlador>();
        SeleccionActivada = true;
    }
    public void setSeleccionActivada(bool seleccion) {
        SeleccionActivada = seleccion;
    }

    void Interaccion(Ray Dedo)
    {
        if (SeleccionActivada)
        {
            RaycastHit Trayecto;
            if (Physics.Raycast(Dedo, out Trayecto))
            {

                Debug.Log("Jugador : " + ControladorJuego.JugadorEnJuego.name);
                ControladorJuego.JugadorEnJuego.SeleccionHecha(Trayecto.transform.gameObject);

            }
        }
    }

    private void MoverCamara(float X,float Y) {
        // Las y de lectura son las x de la rotacion y viceversa 
        GameObject EpicentroDeVista = this.transform.parent.gameObject;
        float Aceleracion = 7;
         PosicionX  += Aceleracion * X;
         PosicionY += Aceleracion * Y;

          PosicionY = Mathf.Clamp(PosicionY, -30, 20);
        Debug.Log(X + " " + Y);
        EpicentroDeVista.transform.localEulerAngles = new Vector3(PosicionY,PosicionX,0);
    }


    // Update is called once per frame
    void Update()
    {

        if (Input.touchCount > 0 && Input.touches[0].phase == TouchPhase.Canceled)
        {
            Ray Dedo = GetComponent<Camera>().ScreenPointToRay(Input.GetTouch(0).position);
            Interaccion(Dedo);
        }
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            Ray click = GetComponent<Camera>().ScreenPointToRay(Input.mousePosition);
            Interaccion(click);
        }

        if (GetComponent<DefaultInitializationErrorHandler>() == null)
        {
            if (Input.GetKey(KeyCode.Mouse1))
            {
                MoverCamara(Input.GetAxis("Mouse X"), Input.GetAxis("Mouse Y"));
               
                //transform.RotateAround(GameObject.Find("Controlador").transform.position, Vector3.up, Input.GetAxis("Mouse X") * 4);
            /*
                if (!(transform.position.y <= 55 && Input.GetAxis("Mouse Y") < 0 && Input.GetAxis("Mouse X") != 0 && transform.localEulerAngles.x <= 15 )) {// si esta en el borde ya no puede moverse mas 
                    transform.LookAt(GameObject.Find("Controlador").transform);
                    transform.RotateAround(GameObject.Find("Controlador").transform.position, new Vector3(1, 0, 0), Input.GetAxis("Mouse Y") * 4);
                    transform.RotateAround(GameObject.Find("Controlador").transform.position, Vector3.up, Input.GetAxis("Mouse X") * 4);
                    float rotationX = Mathf.Clamp(transform.localEulerAngles.x, 10, 90);
                    transform.localEulerAngles = new Vector3(rotationX, transform.localEulerAngles.y, 0);///limita la rotacion por grados
                    transform.position = new Vector3(transform.position.x, Mathf.Clamp(transform.position.y, 54, 360), transform.position.z); /// limita la rotaacion por movimiento
                */
                }

            // transform.rotation = Quaternion.Euler(Time.deltaTime*3,0,0);



            /// transform.rotation = Quaternion.Slerp(transform.rotation, transformY.rotation, transformY.rotation.y);




            //  transform.rotation = new Quaternion( 0, transform.rotation.y + Input.GetAxis("Mouse Y") * 4 * Time.deltaTime, 0));
            //  transform.RotateAround(GameObject.Find("Controlador").transform.position, new Vector3(1,0,0), Input.GetAxis("Mouse Y") * 4);
            // Rotate the cube by converting the angles into a quaternion.



            //Quaternion target = Quaternion.Euler(0, 0, Input.GetAxis("Mouse Y") * 60);// 60 representa el angulo maximo, es como decir un slerp desde 0 

            // Dampen towards the target rotation
            if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Moved)
            {
                Vector2 TouchDirection = Input.GetTouch(0).deltaPosition;
                MoverCamara(TouchDirection.x * Time.deltaTime, TouchDirection.y*Time.deltaTime);


              /*  if (!(transform.position.y <= 5 && TouchDirection.x < 0 && TouchDirection.x != 0 && transform.localEulerAngles.x <= 15))
                {// si esta en el borde ya no puede moverse mas 
                    transform.LookAt(GameObject.Find("Controlador").transform);
                    transform.RotateAround(GameObject.Find("Controlador").transform.position, (new Vector3(worldVector.y, 0, 0.0f)), TouchDirection.y * 0.37f);
                    transform.RotateAround(GameObject.Find("Controlador").transform.position, (new Vector3(0.0f, worldVector.y, 0.0f)), TouchDirection.x * 0.37f);
                    float rotationX = Mathf.Clamp(transform.localEulerAngles.x, 10, 90);
                    transform.localEulerAngles = new Vector3(rotationX, transform.localEulerAngles.y, 0);///limita la rotacion por grados
                    transform.position = new Vector3(transform.position.x, Mathf.Clamp(transform.position.y, 54, 360), transform.position.z); /// limita la rotaacion por movimiento
                }*/






            }

        }
            

        }
    }



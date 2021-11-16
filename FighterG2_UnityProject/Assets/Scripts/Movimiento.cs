using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Movimiento : MonoBehaviour
{
    [SerializeField]

    [Header("Salto")]
    public float fuerzasalto;
    public int nsaltos = 0;
    public int saltostotales = 2;
    private bool canJump = true;
    public float stiempo = 0.3f;

    [Header("Movimiento")]
    public float velocidad;

    [Header("Varios")]
    private Controls1 Input1;
    private Rigidbody2D rb;

    void Start()///////////////////////////////////////COSAS QUE SE EJECUTAN AL EMPEZAR//////////////////////////////////////////////
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void FixedUpdate() ///////////////////////////////////////COSAS QUE SE EJECUTAN EN CADA FRAME///////////////////////////////////////////////
    {

        Move();
    }

    ////////////////////////////                           A PARTIR DE AQUI VAN LAS ACCIONES AAAAAAAAAAAAAA                ////////////////////////

    private void Move()         ///////////MOVERSE
    {
        float mve = Input1.Player1.Move.ReadValue<float>();
        Vector2 x = new Vector2(mve, 0f);
        rb.AddForce(x * velocidad, ForceMode2D.Force);

    }
    private void Jump(InputAction.CallbackContext c)///////////////////////////SALTAR//////////////////////////////////////////////////////
    {

        if (nsaltos < saltostotales && canJump == true)
        {
            if (Input1.Player1.Jump.ReadValue<float>() > 0.5f)
            {
                Vector2 saltito = new Vector2(0f, 1f);
                rb.AddForce(saltito * fuerzasalto, ForceMode2D.Impulse);
                nsaltos = nsaltos + 1;
                DisableS(stiempo);
            }
        }


    }
    private void Crouch(InputAction.CallbackContext c)///////////////AGACHARSE  ??? ///////////////////////////////////////////////////////////
    {

    }
    private void Punch(InputAction.CallbackContext c)////////////////GOLPE NORMAL/////////////////////////////////////////////////////////////
    {

    }
    private void PunchF(InputAction.CallbackContext c)///////////////GOLPE FUERTE/////////////////////////////////////////////////////
    {

    }
    private void PunchE(InputAction.CallbackContext c)////////////////////ESPECIAL//////////////////////////////////////////////////////
    {

    }
    ///////////////////////////                          HASTA AQUI VAN LAS ACCIONES AAAAAAAAAAAAAA                     //////////////////////////

    private void OnCollisionEnter2D(Collision2D collision) ///////////DETECTA COLISIONES/////////////////////////////////////////////////
    {
        if (collision.collider.tag == "Ground")
        {
            nsaltos = 0;
        }
    }


    void DisableS(float t)//////////////////ACTIVAR Y DESACTIVAR TIEMPO ENTRE SALTOS//////////////////////////////////////////////////////////
    {
        canJump = false;
        CancelInvoke("EnableS");
        Invoke("EnableS", t);
    }
    void EnableS()
    {
        canJump = true;
    }
    public void Awake()//////////////////////////////////COSAS DEL INPUT QUE TAMPOCO ENTIENDO DEMASIADO Y MEJOR NO TOCAR P2//////////////////////////
    {
        Input1 = new Controls1();
        Input1.Player1.Jump.started += Jump;
        Input1.Player1.Jump.performed += Jump;
        Input1.Player1.Jump.canceled += Jump;
        Input1.Player1.Crouch.started += Crouch;
        Input1.Player1.Crouch.performed += Crouch;
        Input1.Player1.Crouch.canceled += Crouch;
        Input1.Player1.Punch.started += Punch;
        Input1.Player1.Punch.performed += Punch;
        Input1.Player1.Punch.canceled += Punch;
        Input1.Player1.PunchE.started += PunchE;
        Input1.Player1.PunchE.performed += PunchE;
        Input1.Player1.PunchE.canceled += PunchE;
        Input1.Player1.PunchF.started += PunchF;
        Input1.Player1.PunchF.performed += PunchF;
        Input1.Player1.PunchF.canceled += PunchF;
    }
    public void OnEnable()//////////////////////COSAS RARAS DEL INPUT QUE TAMPOCO ENTIENDO DEMASIADO Y MEJOR NO TOCAR P2////////////////////////////
    {
        Input1.Enable();
    }

    public void OnDisable()
    {
        Input1.Disable();
    }

}////////////////////////////////////ya dejo de gritar :)/////////////////////////////////////////////////////////////////////////////////////////////


using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Movimiento2 : MonoBehaviour
{
    [SerializeField]

    [Header("Salto")]
    public float fuerzasalto;
    public int nsaltos = 0;
    public int saltostotales = 2;
    private bool canJump = true;
    public float stiempo = 0.3f;
    public bool mirandoderecha = false;
    public bool jumpared = false;

    [Header("Movimiento")]
    public float velocidad;

    [Header("Varios")]
    public Controls1 Input1;
    public Rigidbody2D rb;

    public string currentControlScheme { get; }
    void Start()///////////////////////////////////////COSAS QUE SE EJECUTAN AL EMPEZAR//////////////////////////////////////////////
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void FixedUpdate() ///////////////////////////////////////COSAS QUE SE EJECUTAN EN CADA  0.02 segundos///////////////////////////////////////////////
    {


        Move();
    }

    ////////////////////////////                           A PARTIR DE AQUI VAN LAS ACCIONES AAAAAAAAAAAAAA                ////////////////////////

    private void Move()         ///////////MOVERSE
    {
        float mve = Input1.Player2.Move.ReadValue<float>(); ;

        Vector2 x = new Vector2(mve, 0f);
        rb.AddForce(x * velocidad, ForceMode2D.Force);
        if (mve > 0 && mirandoderecha == false)
        {
            transform.Rotate(0.0f, 180.0f, 0.0f, Space.World);
            mirandoderecha = true;
        }
        else if (mve < 0 && mirandoderecha == true)
        {
            transform.Rotate(0.0f, -180.0f, 0.0f, Space.World);
            mirandoderecha = false;
        }

    }
    private void Jump(InputAction.CallbackContext c)///////////////////////////SALTAR//////////////////////////////////////////////////////
    {
        Vector2 saltito = new Vector2();
        float salt = Input1.Player2.Jump.ReadValue<float>();

        if (nsaltos < saltostotales && canJump == true)
        {
            if (salt > 0.5f)
            {
                if (jumpared == true)
                {
                    if (mirandoderecha == true)
                        saltito = new Vector2(-0.5f, 1f);
                    else
                    {
                        saltito = new Vector2(0.5f, 1f);
                    }

                }
                else
                {
                    saltito = new Vector2(0f, 1f);

                }
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

    private void StartB(InputAction.CallbackContext c)////////////////////ESPECIAL//////////////////////////////////////////////////////
    {

    }
    ///////////////////////////                          HASTA AQUI VAN LAS ACCIONES AAAAAAAAAAAAAA                     //////////////////////////

    private void OnCollisionEnter2D(Collision2D collision) ///////////DETECTA COLISIONES/////////////////////////////////////////////////
    {
        if (collision.collider.tag == "Ground" || collision.collider.tag == "Pared")
        {
            nsaltos = 0;
        }
        if (collision.collider.tag == "Pared")
        {
            rb.gravityScale = 5f;
            velocidad = velocidad / 2;
            jumpared = true;
        }
    }
    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.collider.tag == "Pared")
        {
            rb.gravityScale = 10f;
            velocidad = velocidad * 2;
            jumpared = false;
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

        Input1.Player2.Jump.started += Jump;
        Input1.Player2.Jump.performed += Jump;
        Input1.Player2.Jump.canceled += Jump;
        Input1.Player2.Crouch.started += Crouch;
        Input1.Player2.Crouch.performed += Crouch;
        Input1.Player2.Crouch.canceled += Crouch;
        Input1.Player2.Punch.started += Punch;
        Input1.Player2.Punch.performed += Punch;
        Input1.Player2.Punch.canceled += Punch;
        Input1.Player2.PunchE.started += PunchE;
        Input1.Player2.PunchE.performed += PunchE;
        Input1.Player2.PunchE.canceled += PunchE;
        Input1.Player2.PunchF.started += PunchF;
        Input1.Player2.PunchF.performed += PunchF;
        Input1.Player2.PunchF.canceled += PunchF;
        Input1.Player2.StartB.started += StartB;
        Input1.Player2.StartB.performed += StartB;
        Input1.Player2.StartB.canceled += StartB;

    }
    void OnEnable()//////////////////////COSAS RARAS DEL INPUT QUE TAMPOCO ENTIENDO DEMASIADO Y MEJOR NO TOCAR P2////////////////////////////
    {
        Input1.Enable();
    }

    void OnDisable()
    {
        Input1.Disable();
    }

}////////////////////////////////////ya dejo de gritar :)/////////////////////////////////////////////////////////////////////////////////////////////


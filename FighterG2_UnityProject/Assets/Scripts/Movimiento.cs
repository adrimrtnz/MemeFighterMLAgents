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
    public bool pared;
    public float gpared;
    public bool mirandoderecha=true;
    public float gravedad;
    public float diagonal = 1f;

    [Header("Varios")]
    private Controls1 Input1;
    private Rigidbody2D rb;

    [Header("SFX")]
    public SFXScript sfx;

    public Animator plAnim;

    //variables para las animaciones

    public bool volando = false;
    public float velovutyY = 0f;

    public float timeRate = 2f;

    private float nextjumpTime = 0f;
    private float nextPuñoTime = 0f;
    private float nextPatadaTime = 0f;



    void Start()///////////////////////////////////////COSAS QUE SE EJECUTAN AL EMPEZAR//////////////////////////////////////////////
    {
        rb = GetComponent<Rigidbody2D>();
        gravedad = rb.gravityScale;
        if (sfx == null) sfx = GameObject.Find("SFXManager").GetComponent<SFXScript>();
    }

    void FixedUpdate() ///////////////////////////////////////COSAS QUE SE EJECUTAN EN CADA FRAME///////////////////////////////////////////////
    {

        Move();
    }

    //Comprobar si esta volando o tocando el suelo.
    private void Update()
    {
        velovutyY = rb.velocity.y;
        //Poner la velocidad en positivo
        if (rb.velocity.y < 0)
        {
            velovutyY = velovutyY * -1;
        }

        if (velovutyY > 0.1f)
        {

            plAnim.SetBool("volando", true);
        }
        else
        {
            plAnim.SetBool("volando", false);
        }

    }

    ////////////////////////////                           A PARTIR DE AQUI VAN LAS ACCIONES AAAAAAAAAAAAAA                ////////////////////////

    private void Move()         ///////////MOVERSE
    {
        float mve = Input1.Player1.Move.ReadValue<float>();
        if (mirandoderecha ==true && mve < 0)
        {
            transform.Rotate(0f, 180f, 0f, Space.World);
            mirandoderecha = false;
        }
        else if (mirandoderecha == false && mve > 0)
        {
            transform.Rotate(0f, -180f, 0f, Space.World);
            mirandoderecha = true;
        }
        Vector2 x = new Vector2(mve, 0f);
        rb.AddForce(x * velocidad, ForceMode2D.Force);

        //Poner animación correr
        plAnim.SetBool("correr",true);

        //Quitar animación correr
        if (mve == 0)
        {
            plAnim.SetBool("correr", false);
        }

    }
    private void Jump(InputAction.CallbackContext c)///////////////////////////SALTAR//////////////////////////////////////////////////////
    {
        //Animación saltar Solo poner la animación de saltar cuando se haya acabado la animación
        if (Time.time >= nextjumpTime) 
        {
            if (velovutyY <= 0.1f)
            {
                plAnim.SetTrigger("saltar");

                nextjumpTime = Time.time + 1f / timeRate;
            }
        }

        

        float salto = Input1.Player1.Jump.ReadValue<float>();

        Vector2 saltito;
        if (nsaltos < saltostotales && canJump == true)
        {
            
            if (salto > 0.5f)
            {
                saltito = new Vector2(0f, 1f);
                if (pared)
                {
                    if (mirandoderecha)
                    {
                        saltito = new Vector2(-diagonal, 1f);
                    }
                    else
                    {
                        saltito = new Vector2(diagonal, 1f);
                    }

                }
                //Aquí el sonido
                sfx.PlaySound("Jump1");
                //Aquí la fuerza aplicada
                rb.AddForce(saltito * fuerzasalto, ForceMode2D.Force);
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
        //Animación patada 
        if(Time.time >= nextPatadaTime)
        {
            if (velovutyY <= 0.1f)
            {
                plAnim.SetTrigger("patada");

                nextPatadaTime = Time.time + 1f / timeRate;
            }
        }

    }

    private void PunchF(InputAction.CallbackContext c)///////////////GOLPE FUERTE/////////////////////////////////////////////////////
    {
        //Animación puño 
 
        if (Time.time >= nextPuñoTime)
        {
            if (velovutyY <= 0.1f)
            {
                plAnim.SetTrigger("Puño");

                nextPuñoTime = Time.time + 1f / timeRate;
            }
        }
    }
    private void PunchE(InputAction.CallbackContext c)////////////////////ESPECIAL//////////////////////////////////////////////////////
    {

    }

    ///////////////////////////       HASTA AQUI VAN LAS ACCIONES AAAAAAAAAAAAAA     //////////////////////////

    private void OnCollisionEnter2D(Collision2D collision) ///////////DETECTA COLISIONES/////////////////////////////////////////////////
    {
        if (collision.collider.tag == "Ground" || collision.collider.tag == "Pared")
        {
            nsaltos = 0;
            if (collision.collider.tag == "Pared")
            {
                rb.gravityScale = gpared;
                pared = true;
            }
        }
    }
    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.collider.tag == "Pared")
        {
            rb.gravityScale = gravedad ;
            pared = false;
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


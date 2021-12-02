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

    [Header("Movimiento")]
    public float velocidad;
    public bool pared;
    public float gpared;
    public bool mirandoderecha = false;
    public float gravedad;
    public float diagonal = 1f;

    [Header("Varios")]
    private Controls1 Input1;
    private Rigidbody2D rb;
    public Animator a;

    [Header("Golpes")]
    public float td = 0.3f;
    public float tf = 0.3f;
    public float te = 0.5f;

    [Header("SFX")]
    public SFXScript sfx;

    void Start()///////////////////////////////////////COSAS QUE SE EJECUTAN AL EMPEZAR//////////////////////////////////////////////
    {
        rb = GetComponent<Rigidbody2D>();
        gravedad = rb.gravityScale;
        if (sfx == null) sfx = GameObject.Find("SFXManager").GetComponent<SFXScript>();
    }

    void FixedUpdate() ///////////////////////////////////////COSAS QUE SE EJECUTAN EN CADA FRAME///////////////////////////////////////////////
    {
        if (rb.velocity.y == 0)
        {
            a.SetBool("Ground", true);
        }
        else
        {
            a.SetBool("Ground", false);
        }
        if (rb.velocity.x != 0)
        {
            a.SetBool("Hmove", true);
        }
        else
        {
            a.SetBool("Hmove", false);
        }
        if (rb.gravityScale == 0)
        {
            a.SetBool("pared", true);

        }
        else
        {
            if (pared == false)
            {
                a.SetBool("Pared", false);
            }
            else
            {
                a.SetBool("Pared", true);
            }
        }
        a.SetFloat("VSpeed", rb.velocity.y);
        Move();
    }

    ////////////////////////////                           A PARTIR DE AQUI VAN LAS ACCIONES AAAAAAAAAAAAAA                ////////////////////////

    private void Move()         ///////////MOVERSE
    {
        float mve = Input1.Player2.Move.ReadValue<float>();
        if (mirandoderecha == true && mve < 0)
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

    }
    private void Jump(InputAction.CallbackContext c)///////////////////////////SALTAR//////////////////////////////////////////////////////
    {
        float salto = Input1.Player2.Jump.ReadValue<float>();
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
                //Aquí la fuerza
                rb.AddForce(saltito * fuerzasalto, ForceMode2D.Force);
                nsaltos = nsaltos + 1;
                a.SetBool("Ground", false);
                DisableS(stiempo);
            }
        }


    }
    private void Crouch(InputAction.CallbackContext c)///////////////AGACHARSE  ??? ///////////////////////////////////////////////////////////
    {

    }
    private void Punch(InputAction.CallbackContext c)////////////////GOLPE NORMAL/////////////////////////////////////////////////////////////
    {
        OnDisable();
        a.SetBool("GolpeD", true);
        CancelInvoke("fpunch");
        Invoke("fpunch", td);

    }
    private void PunchF(InputAction.CallbackContext c)///////////////GOLPE FUERTE/////////////////////////////////////////////////////
    {
        OnDisable();
        a.SetBool("GolpeF", true);
        CancelInvoke("fpunchf");
        Invoke("fpunchf", tf);
    }
    private void PunchE(InputAction.CallbackContext c)////////////////////ESPECIAL//////////////////////////////////////////////////////
    {

        transform.localScale = new Vector3(1.2f, 1f, 1f);
        a.SetBool("GolpeE", true);
        OnDisable();
        CancelInvoke("fpunche");
        Invoke("fpunche", te);


    }
    ///////////////////////////                          HASTA AQUI VAN LAS ACCIONES AAAAAAAAAAAAAA                     //////////////////////////

    private void OnCollisionEnter2D(Collision2D collision) ///////////DETECTA COLISIONES/////////////////////////////////////////////////
    {
        if (collision.collider.tag == "Ground" || collision.collider.tag == "Pared")
        {
            nsaltos = 0;
            if (collision.collider.tag == "Pared")
            {
                rb.gravityScale = gpared;
                pared = true;
                a.SetBool("Pared", true);
            }
        }
    }
    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.collider.tag == "Pared")
        {
            rb.gravityScale = gravedad;
            pared = false;
            a.SetBool("Pared", false);
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
    }
    public void OnEnable()//////////////////////COSAS RARAS DEL INPUT QUE TAMPOCO ENTIENDO DEMASIADO Y MEJOR NO TOCAR P2////////////////////////////
    {
        Input1.Enable();
    }

    public void OnDisable()
    {
        Input1.Disable();
    }
    private void fpunch()
    {
        a.SetBool("GolpeD", false);
        OnEnable();
    }
    private void fpunchf()
    {
        a.SetBool("GolpeF", false);
        OnEnable();

    }
    private void fpunche()
    {

        //GetComponent<GameObject>().transform.localScale = Vector3.one;

        a.SetBool("GolpeE", false);
        transform.localScale = new Vector3(0.6f, 0.6f, 0.6f);
        OnEnable();
    }
}////////////////////////////////////ya dejo de gritar :)/////////////////////////////////////////////////////////////////////////////////////////////
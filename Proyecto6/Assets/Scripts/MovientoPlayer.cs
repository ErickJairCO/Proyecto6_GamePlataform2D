using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovientoPlayer : MonoBehaviour
{
    private Vector2 dirMov;
    public float VelMov, VelSalto;
    public Rigidbody2D rb;
    public Animator anim;

    private float movX = 0;
    public static int dirIdle = 1; 

    private int numSaltos;

    [Header("Rebote")]
    [SerializeField] private float velocidadRebote;
    private Rigidbody2D rb2D;


    private void Start()
    {
        rb2D = GetComponent<Rigidbody2D>();
        anim.SetBool("saltando", false);
        anim.SetBool("saltandoIzq", false);
        numSaltos = 0;
        anim.SetBool("saltando" ,false);
    }

    private void FixedUpdate()
    {
        Movimiento();
    }

    private void Update()
    {
        


        if (Input.GetButtonDown("Jump")){
            //anim.SetBool("saltando", true);

            if (numSaltos <= 1) {
                numSaltos++;
                ColisionSuelo.estaEnSuelo = false;
                anim.SetBool("estaEnSuelo", false);
                rb.velocity = new Vector2(rb.velocity.x, VelSalto);
                if(dirIdle >= 1)
                {
                    anim.SetBool("saltando", true);
                }else if (dirIdle <= -1){
                    anim.SetBool("saltandoIzq", true);
                }
            }
        }else
        {
            anim.SetBool("saltando", false);
            anim.SetBool("saltandoIzq", false);
            if(ColisionSuelo.estaEnSuelo == true){
                numSaltos = 0;
                anim.SetBool("estaEnSuelo", true);
            }
            if (ColisionParedes.EstaEnPared == true)
            {
                numSaltos = 0;
            }
            
        }
      
    }
    private void Movimiento()
    {
        movX = Input.GetAxisRaw("Horizontal");
        if (Mathf.Abs(movX) < 0.01f)
        {
            movX = 0;
        }

        dirMov = new Vector2(movX, 0);
        rb.velocity = new Vector2(dirMov.x * VelMov, rb.velocity.y);

        if (movX < 0.0f) { transform.localScale = new Vector3(-1.0f, 1.0f, 1.0f); }
        else if (movX > 0.0f) transform.localScale = new Vector3(1.0f, 1.0f, 1.0f);
        anim.SetBool("corriendo", movX != 0.0f);

        if (movX != 0)
        {
            anim.SetBool("corriendo", true);
            AnimacionesPlayer(dirMov.x);
            if(movX > 0)
            {
                dirIdle = 1;
            }
            else
            {
                dirIdle = -1;
            }
        }
        else if ( movX == 0)
        {
            anim.SetBool("corriendo", false);
            
            if(dirIdle > 1)
            {
                AnimacionesPlayer(0);
            }
            else if (dirIdle < -1)
            {
                AnimacionesPlayer(0);
            }
        }
       
    }
    void AnimacionesPlayer(float n )
    {
        anim.SetFloat("movX", n);
    }

    public void Rebote(){
        rb2D.velocity = new Vector2(rb2D.velocity.x, velocidadRebote);
    }
}

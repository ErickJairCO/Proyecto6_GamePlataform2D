using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CombateAD : MonoBehaviour
{
    [SerializeField] private GameObject piedra;
    [SerializeField] private float VelDisparo = 1;
    private float Disparo = -1f;
    public Transform salidaPiedra;
    public static int DirPiedra = 1;
    private Animator anim;
    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>(); 
    }

    // Update is called once per frame
    void Update()
    {
        if( Input.GetButtonDown("Fire2")&& Time.time > Disparo)
        {
            Dispara();
        }
    }
    void Dispara()
    {
        if( MovientoPlayer.dirIdle == 1)
        {
            anim.SetTrigger("ataqueP");
        }
        else if (MovientoPlayer.dirIdle == -1)
        {
            anim.SetTrigger("ataquePIzq");
        }
    }
    private void LanzaProyectil()
    {
        DirPiedra = MovientoPlayer.dirIdle;
        Disparo = Time.time + VelDisparo;
        Instantiate(piedra, salidaPiedra.position, transform.rotation);
    }
}

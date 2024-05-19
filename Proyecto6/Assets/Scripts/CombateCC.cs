using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CombateCC : MonoBehaviour
{
    public Transform controladorGolpe;
    public int da�oGolpe;
    public float radioGolpe;
    public float golpeDelay;
    public float TSigAtaque;
    private Animator anim;

    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if(TSigAtaque > 0)
        {
            TSigAtaque -= Time.deltaTime;
        }
        if(Input.GetButtonDown("Fire1")&& TSigAtaque<= 0)
        {
            Golpe();
            TSigAtaque = golpeDelay;
        }
    }

    private void Golpe()
    {
        if(MovientoPlayer.dirIdle == 1 || MovientoPlayer.dirIdle == -1)
        {
            anim.SetTrigger("Pu�o");
        }
    }

    private void Hit()
    {
        Collider2D[] objs = Physics2D.OverlapCircleAll(controladorGolpe.position, radioGolpe);
        foreach (Collider2D colisionador in objs)
        {
            if (colisionador.CompareTag("Enemigo")) {
               // colisionador.transform.GetComponent<Enemigo>().TomarDa�o(da�oGolpe);
            }
            if (colisionador.CompareTag("Jefe"))
            {
               // colisionador.transform.GetComponent<Jefe>().TomarDa�o(da�oGolpe);
            }
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(controladorGolpe.position, radioGolpe);
    }
}

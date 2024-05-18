using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Proyectil : MonoBehaviour
{
    [SerializeField] private float velocidad = 8.0f;

    private void FixedUpdate()
    {
        if(MovientoPlayer.dirIdle == 1)
        {
            transform.eulerAngles = new Vector3(0, 0, 0);
            transform.position += CombateAD.DirPiedra * transform.right * Time.deltaTime * velocidad;
        }
        else if (MovientoPlayer.dirIdle == -1) 
        {
            transform.eulerAngles = new Vector3(0, 180, 0);
            transform.position -= CombateAD.DirPiedra * transform.right * Time.deltaTime * velocidad;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "limite")
        {
            Destroy(this.gameObject);
        }
        if (collision.gameObject.tag == "Enemigo")
        {
            //collision.transform.GetComponent<Enemigo>().TomarDaño(1);
            Destroy(this.gameObject);
        }
        if(collision.gameObject.tag == "Jefe")
        {
            //collision.transform.GetComponent<Jefe>().TomarDaño(1);
            Destroy(this.gameObject);
        }

    }

}

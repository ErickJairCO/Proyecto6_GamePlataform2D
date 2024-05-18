using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ColisionesJugador : MonoBehaviour
{
    public static int nivel;
    public GameObject FinLv1, FinLv2, FinLv3, FinLv4, FinLv5, FinJuego, congrats;
    public Image UIjefe;
    

    private void Start()
    {
        nivel = 1;
        OcultaPantallas();
    }

    private void OnTriggerEnter2D(Collider2D obj)
    {
        if (obj.gameObject.tag == "Vacio")
        {
            VidasPlayer.vida = 0;
            GetComponent<VidasPlayer>().daño(5);
            GetComponent<VidasPlayer>().DibujaVidas(VidasPlayer.vida);
            transform.position = new Vector2(-12, 2);
        }
        if (obj.gameObject.tag == "AguaPeligrosa")
        {
            GetComponent<VidasPlayer>().daño(1);
        }
        if(obj.gameObject.tag == "Edebil")
        {
            GetComponent<VidasPlayer>().daño(1);
            Damage();
        }
        if (obj.gameObject.tag == "puerta") {
            StartCoroutine(PantallaFinDelJuego());
        }
        if(obj.gameObject.tag == "Lvl2")
        {
            nivel = 2;
        }
        if (obj.gameObject.tag == "Picos")
        {
           
            GetComponent<VidasPlayer>().daño(1);
            Damage();
        }

    }

    IEnumerator PantallaFinDelJuego()
    {
        yield return new WaitForSeconds(0.12f);
        switch (nivel)
        {
            case 1:
                OcultaPantallas();
                FinLv1.SetActive(true);
                break;
            case 2:
                OcultaPantallas();
                FinLv2.SetActive(true);
                break;
            case 3:
                OcultaPantallas();
                FinLv3.SetActive(true);
                break;
            case 4:
                OcultaPantallas();
                FinLv4.SetActive(true);
                break;
            case 5:
                OcultaPantallas();
                FinLv5.SetActive(true);
                break;
        }
        StartCoroutine(MuestrasigNivel());
    }

    private void OcultaPantallas()
    {
        FinJuego.SetActive(false);
        FinLv1.SetActive(false);
        FinLv2.SetActive(false);
        FinLv3.SetActive(false);
        FinLv4.SetActive(false);
        FinLv5.SetActive(false);
        congrats.SetActive(false);

    }

    IEnumerator MuestrasigNivel()
    {
        yield return new WaitForSeconds(10.0f);
        switch (nivel)
        {
            case 1:
                SceneManager.LoadScene("Nivel1");
                transform.position = new Vector2(-5.5f, -40);
                //ControladorSonido.reproduceClip = 1;
                break;
            case 2:
                transform.position = new Vector2(74, -71);
                break;
            case 3:
                transform.position = new Vector2(78, -160);
                break;



        }
        
        OcultaPantallas();
        if (nivel == 5)
        {
            UIjefe.gameObject.SetActive(true);
        }
        nivel++;
        Debug.Log("Nivel: " + nivel);
    }

    private void Damage()
    {
        GetComponent<VidasPlayer>().inmune = true;
        GetComponent<MovientoPlayer>().anim.SetBool("Inmune", true);
        GetComponent<MovientoPlayer>().sprite.color = new Color(156, 0, 0, 1);
    }
}
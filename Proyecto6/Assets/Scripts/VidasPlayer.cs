using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class VidasPlayer : MonoBehaviour
{
    public static int vida;
    public Image[] imgVidas;
    private bool Muerto;
    public GameObject gameOver;
    public bool inmune = false;

    private void Start()
    {
        Muerto = false;
        vida = 5;
        for (int i = 0; i < vida; i++)
        {
            imgVidas[i].enabled = true;
        }
        gameOver.SetActive(false);
    }

    public void daño(int daño)
    {
        if (inmune == false)
        {
            if (vida > 0)
            {
                if (MovientoPlayer.dirIdle == 1)
                {
                    GetComponent<Animator>().SetTrigger("daño");
                }
                else if (MovientoPlayer.dirIdle == -1)
                {
                    GetComponent<Animator>().SetTrigger("dañoIzq");
                }
                else if (MovientoPlayer.dirIdle == 0)
                {
                    GetComponent<Animator>().SetTrigger("Daño");
                }

                vida -= daño;
                StartCoroutine(InmunidadGolpe());
                DibujaVidas(vida);
            }
            if (vida <= 0 && !Muerto)
            {
                Muerto = true;
                GetComponent<Animator>().SetBool("muerte", true);
                StartCoroutine(EjecutaMuerte());
            }
        }
    }

    public void DibujaVidas(int n)
    {
        for (int i = 0; i < 5; i++)
        {
            imgVidas[i].enabled = false;
        }
        for (int i = 0; i < n; i++)
        {
            imgVidas[i].enabled = true;
        }
    }

    IEnumerator EjecutaMuerte()
    {
        yield return new WaitForSeconds(2.1f);
        gameOver.SetActive(true);
        StartCoroutine(RegresaMenu());
    }
    IEnumerator RegresaMenu()
    {
        yield return new WaitForSeconds(2.7f);
        SceneManager.LoadScene("DEMO");

    }

    IEnumerator InmunidadGolpe()
    {
        yield return new WaitForSeconds(2.7f);
        inmune = false;
        GetComponent<MovientoPlayer>().anim.SetBool("Inmune", false);
        GetComponent<MovientoPlayer>().sprite.color = new Color(255, 255, 255, 1);
    }

    
}
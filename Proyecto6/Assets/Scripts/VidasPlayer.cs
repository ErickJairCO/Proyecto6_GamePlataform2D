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

    public void da�o(int da�o)
    {
        if (vida > 0)
        {
            if (MovientoPlayer.dirIdle == 1)
            {
                GetComponent<Animator>().SetTrigger("da�o");
            }
            else if (MovientoPlayer.dirIdle == -1)
            {
                GetComponent<Animator>().SetTrigger("da�oIzq");
            }
            else if (MovientoPlayer.dirIdle == 0)
            {
                GetComponent<Animator>().SetTrigger("Da�o");
            }
            vida -= da�o;
            DibujaVidas(vida);
        }
        if (vida <= 0 && !Muerto)
        {
            Muerto = true;
            GetComponent<Animator>().SetBool("muerte", true);
            StartCoroutine(EjecutaMuerte());
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
}
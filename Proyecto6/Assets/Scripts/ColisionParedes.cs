using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColisionParedes : MonoBehaviour
{
    public static bool EstaEnPared = false;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "pared")
        {
            EstaEnPared = true;

        }
    }
}

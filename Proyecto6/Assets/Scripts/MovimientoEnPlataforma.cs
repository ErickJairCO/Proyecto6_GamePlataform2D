using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovimientoEnPlataforma : MonoBehaviour
{
    public Rigidbody2D rb2D;
    public float velocidadDeMovimiento;
    public LayerMask capaAbajo;
    public LayerMask capaEnfrente;
    public float distanciaAbajo;
    public float distaciaEnfrente;
    public Transform ControladorAbajo;
    public Transform ControladorLateral;
    public bool informacionAbajo;
    public bool informacionLateral;
    private bool mirandoAlaDerecha = true;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        rb2D.velocity = new Vector2(velocidadDeMovimiento, rb2D.velocity.y);

        informacionLateral = Physics2D.Raycast(ControladorLateral.position, transform.right, distaciaEnfrente, capaEnfrente);
        informacionAbajo = Physics2D.Raycast(ControladorAbajo.position, transform.up * -1, distanciaAbajo, capaAbajo);

        if(informacionLateral || informacionAbajo) {
            Girar();
        }

    }

    private void Girar()
    {
        mirandoAlaDerecha = !mirandoAlaDerecha;
        transform.eulerAngles = new Vector3(0, transform.eulerAngles.y + 180, 0);
        velocidadDeMovimiento *= -1;
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawLine(ControladorAbajo.transform.position, ControladorAbajo.transform.position + transform.up * -1 * distanciaAbajo);
        
        Gizmos.DrawLine(ControladorLateral.transform.position, ControladorLateral.transform.position + transform.right * distaciaEnfrente);
    }

}

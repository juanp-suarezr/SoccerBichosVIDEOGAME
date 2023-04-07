using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class balon : MonoBehaviour
{
    public float speed = 1;
    public Rigidbody2D rb;
    private Vector2 startPos;

    //contador reset after goal
    public float num = 5;
    void Start()
    {
        transform.position = startPos;
        Launch();
    }

    public void Reset() {
        transform.position = startPos;
        rb.velocity = Vector2.zero;

        Launch();
        

        
    }

    public void Launch()
    {
        //lanzar bola para un lado u otro --- lo de la derecha es un if resumido.
        //if Random.range = 0 -> -1 else 1
        float x = Random.Range(0,2) == 0 ? -1 : 1;
        

        rb.velocity = new Vector2(speed*x, 0);
    }

    private void OnCollisionEnter2D(Collision2D other) {
        
        if (other.gameObject.tag == "borderUp")
        {

            float x = Random.Range(0,2) == 0 ? -5 : 5;
            
        

            rb.velocity = new Vector2(speed*x, -1*speed);
            
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class collider_mitad : MonoBehaviour
{
    
    public AI ai;
    public GameObject ball;

    private void OnTriggerEnter2D(Collider2D other) {
        
        if (other.CompareTag("alien") && ball.transform.position.x < transform.position.x)
        {
            ai.tocoMitad = true;
            
        }
        else {
            ai.tocoMitad = false;
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cabezaAI : MonoBehaviour
{
    public balon balon;

    private void OnTriggerEnter2D(Collider2D other) {
        
        if (other.CompareTag("ball"))
        {
            balon.rb.velocity = new Vector2(-5, 3);
            
        }
    }

}

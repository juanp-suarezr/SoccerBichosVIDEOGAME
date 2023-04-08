using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class goal : MonoBehaviour
{
    
    public bool playerGoal;

    public GameObject alien;
    public AI ai;

    public GameManager gameManager;

    private void OnTriggerEnter2D(Collider2D other) 
    {
        if (other.CompareTag("ball"))
        {
            if (playerGoal)
            {
                gameManager.PlayerScored();
            }
            else 
            {
                gameManager.NpcScored();
            }
        }

        if (other.CompareTag("alien"))
        {
            if (playerGoal)
            {
                Debug.Log("coll with arqueria");
                ai.tocoMitad = false;
                alien.transform.position += new Vector3(-ai.speed*Time.deltaTime, 0, 0);
            }
            
        }
    }
}

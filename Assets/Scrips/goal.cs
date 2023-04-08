using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class goal : MonoBehaviour
{
    
    public bool playerGoal;

    public GameObject alien;
    public AI ai;

    public GameManager gameManager;

    //sonido goal
    [SerializeField] private SoundController audio;

    [SerializeField] private AudioClip soundGoal;
    [SerializeField] private AudioClip soundRivalGoal;

    private void OnTriggerEnter2D(Collider2D other) 
    {
        if (other.CompareTag("ball"))
        {
            if (playerGoal)
            {
                audio.EjecutarSonido(soundGoal);
                gameManager.PlayerScored();

            }
            else 
            {
                audio.EjecutarSonido(soundRivalGoal);
                gameManager.NpcScored();
            }
        }

        if (other.CompareTag("alien"))
        {
            if (playerGoal)
            {
                
                ai.tocoMitad = false;
                alien.transform.position += new Vector3(-ai.speed*Time.deltaTime, 0, 0);
            }
            
        }
    }
}

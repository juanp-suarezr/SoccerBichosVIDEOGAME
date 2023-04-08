using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;


public class GameManager : MonoBehaviour
{
    // Start is called before the first frame update
    
    public GameObject character;

    public GameObject ball;
    public GameObject NPC;

    public GameObject playerGoal;
    public GameObject NpcGoal;

    

    public TextMeshProUGUI playerText;
    public TextMeshProUGUI NpcText;

    private int playerScore;
    private int NpcScore;

    public int num_scene = 0;

    

    public GameObject portada;

    public GameObject GameWin;
    public GameObject GameOver;

    public GameObject GameDraw;

    //instancia objeto tipo timer
    public timer timerScript;
    
    private int num_escena;

    //mobile ajust
    public bool ismobile = true;

    public personaje personaje;

    //sound Game Win GameOver
    [SerializeField] private SoundController audio;

    [SerializeField] private AudioClip soundWin;
    [SerializeField] private AudioClip soundLose;

    private int num_Rep;


    public void PlayerScored()
    {
        playerScore ++;
        playerText.text = playerScore.ToString();
        ResetPosition();
    }

    public void NpcScored()
    {
        NpcScore ++;
        NpcText.text = NpcScore.ToString();
        ResetPosition();
    }

    public void ResetPosition()
    {
        
        ball.GetComponent<balon>().Reset();
        character.transform.position = new Vector3(-5, -2, 0);
        NPC.transform.position = new Vector3(5, -2, 0);

    }

    

    void Start()
    {
        if (SceneManager.GetActiveScene().name == "Game")
        {
            Time.timeScale = 0f;
        } else {
            Time.timeScale = 1f;
        }
        
        num_Rep = 0;
        portada.SetActive(true);
        character.transform.position = new Vector3(-5, -2, 0);
        NPC.transform.position = new Vector3(5, -2, 0);
        

        

        
        
        
    }

    // Update is called once per frame
    void Update()
    {

        

        if (SceneManager.GetActiveScene().name == "Game")
        {
            if (timerScript.isTimeOver) 
            {
                Time.timeScale = 0f;

                if (playerScore > NpcScore)
                {
                    if (num_Rep == 0)
                    {
                        audio.EjecutarSonido(soundWin);
                        num_Rep ++;
                    }
                    
                    GameOver.SetActive(false);
                    GameWin.SetActive(true);
                    GameDraw.SetActive(false);
                } else if (playerScore < NpcScore)
                {
                    if (num_Rep == 0)
                    {
                        audio.EjecutarSonido(soundLose);
                        num_Rep ++;
                    }
                    
                    GameOver.SetActive(true);
                    GameWin.SetActive(false);
                    GameDraw.SetActive(false);
                } else {
                    if (num_Rep == 0)
                    {
                        audio.EjecutarSonido(soundLose);
                        num_Rep ++;
                    }
                    
                    GameDraw.SetActive(true);
                    GameOver.SetActive(false);
                    GameWin.SetActive(false);
                }

                
            } else
            {
                
            }
        }

        

        
        
        
    }



    

    public void ContinuegameBtn()
    {
        portada.SetActive(false);
        Time.timeScale = 1f;
        
        

    }



    public void Up() {
        
        personaje.num = 1;
        
        
        
    }


    public void Left() {
        
        personaje.num = 2;
        
    }

    public void Right() {
        
        personaje.num = 3;
        
    }

    public void power() {
        
        personaje.num = 4;
        
    }

    public void stop() {
        personaje.num = 0;
    }


}

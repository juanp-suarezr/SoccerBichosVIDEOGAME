using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class menuManager : MonoBehaviour
{

    //home sets
    public GameObject playStart;
    public GameObject MenuHome;

    bool isMenuPause = false;

    public bool isPaused;

    public GameObject pauseMenu;
    public GameObject pauseBtn;
    public GameObject continueBtn;

    

    //mobile ajust

    
    public GameManager GameManager;

    public dialogueManager dialogueManager;

    public int num = 0;

    public GameObject botonesM;

    

    
    //scene home
    public void PlayGame(int num) 
    {
        Time.timeScale = 1f;
        

        if (dialogueManager.cronometro <= 0)
                {

                    switch (num)
                    {
                        case 0: 
                            MenuHome.SetActive(true);
                            playStart.SetActive(false);
                        break;
                        //cambion de avatars
                        case 1: 
                            MenuHome.SetActive(false);
                            SceneManager.LoadScene(GameManager.num_scene);
                            playStart.SetActive(true);
                        break;
                        case 2: 
                            MenuHome.SetActive(false);
                            SceneManager.LoadScene(GameManager.num_scene);
                            playStart.SetActive(true);
                        break;
                        case 3: 
                            MenuHome.SetActive(false);
                            SceneManager.LoadScene(GameManager.num_scene);
                            playStart.SetActive(true);
                        break;
                        
                    }
                    
                    
        } else {
                    dialogueManager.cronometro -= Time.deltaTime;
        }
        
    }

    

    //scene game
    public void PauseMenuBtn()
    {
        if (isPaused) {
            isMenuPause = false;
            pauseMenu.SetActive(false);
            
            UpdateGameState();

        } else {
            isMenuPause = true;
            GameManager.GameWin.SetActive(false);
            GameManager.GameOver.SetActive(false);
            GameManager.portada.SetActive(false);
            pauseMenu.SetActive(true);
            
            UpdateGameState();
        }
        

    }

    public void ContinueMenuBtn()
    {

        if (isPaused) {
            
            isMenuPause = false;
            pauseMenu.SetActive(false);
            UpdateGameState();

        } else {
            UpdateGameState();
        }
        

    }

    public void Reiniciar() 
    {
        Time.timeScale = 1f;
        
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void ExitBtnLevel() 
    {
        GameManager.num_scene = 0;
        SceneManager.LoadScene(0);
    }

    private void Update() {
        
        if (Input.GetKeyDown(KeyCode.Escape) && isMenuPause)
        {
            isMenuPause = false;
            pauseMenu.SetActive(false);
            
            UpdateGameState();
        } else if (Input.GetKeyDown(KeyCode.Escape)) {
            isMenuPause = true;
            pauseMenu.SetActive(true);
            
            UpdateGameState();
        }

        
    }

    private void UpdateGameState() 
    {
        isPaused = !isPaused;

        if (isPaused) {
            Time.timeScale = 0f;
            pauseBtn.SetActive(false);
            

        } else {
            Time.timeScale = 1f;
            pauseBtn.SetActive(true);
            
        }
    }

    


}

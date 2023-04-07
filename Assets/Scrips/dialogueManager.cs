using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class dialogueManager : MonoBehaviour
{

    //sonido siuu
    [SerializeField] private AudioClip sonidoSiu;
    
    public GameManager gameManager;
    [SerializeField] private GameObject dialoguePanel;
    [SerializeField] private TextMeshProUGUI dialogueText;
    [SerializeField, TextArea(4,6)] private string[] dialogueLines;
    private float typingTime = 0.05f;
    public bool Dialogueistrue;
    private int lineIndex;
    
    public float cronometro = 5;
        

    private void StartDialogue()
    {
        Dialogueistrue = true;
        dialoguePanel.SetActive(true);
        lineIndex = 0;
        StartCoroutine(ShowLine());
    }

    public void NextDialogueLine() {
        lineIndex++;
        cronometro = 6;
        Debug.Log(lineIndex);
        if (lineIndex < dialogueLines.Length)
        {
            StartCoroutine(ShowLine());
        } else {
            Dialogueistrue = false;
            dialoguePanel.SetActive(false);
        }
    }

    //corrutina
    private IEnumerator ShowLine() 
    {
        dialogueText.text = string.Empty;

        foreach (char letter in dialogueLines[lineIndex])
        {
            Debug.Log(dialogueText.text);
            dialogueText.text += letter;
            yield return new WaitForSecondsRealtime(typingTime);
        }
    }

    

    // Update is called once per frame
    void Update()
    {
        if (cronometro <= 0)
                {

                    if (gameManager.num_scene == 0)
                    {
                        SoundController.Instance.EjecutarSonido(sonidoSiu);
                        gameManager.num_scene = 1;
                    }
                    
                    if (Input.GetKeyDown(KeyCode.Return)) 
                    {
            
                        NextDialogueLine();
                    }
                    
                } else {
                    cronometro -= Time.deltaTime;
                }
        
        
    }

    void Start() {
        if (!Dialogueistrue)
            {
                StartDialogue();
                Debug.Log(dialogueText.text);
                Debug.Log(dialogueLines[lineIndex]);
            } else if (dialogueText.text == dialogueLines[lineIndex])
            {
                NextDialogueLine();
            } else {
                StopAllCoroutines();
                dialogueText.text = dialogueLines[lineIndex]; 
            }
    }
    
    
}

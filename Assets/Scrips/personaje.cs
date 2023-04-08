using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class personaje : MonoBehaviour
{
    private Rigidbody2D rb;

    //salto
    public float fuerzaUp;

    private bool tocandoSuelo;

    private bool tocandoBalon;
    Vector2 input;
    
    //touch
    Vector2 Touchmove;
    public Transform playerTransform;

    public float touchSpeed;

    //variable de movimiento
    public float speed;
    public float dirX;
    public float dirY;

    public float dirXM;
    public float dirYM;

    public Animator animator;

    //mobile ajust
    public menuManager menuManager;

    public GameManager GameManager;

    public int num;

    //efecto potencia
    public GameObject ball;
    public balon balon;

    public GameObject btn_power;

    public timer timer;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        
        animator = GetComponent<Animator>();
        btn_power.SetActive(false);
    }



    // Update is called once per frame
    void Update()
    {
        switch (num)
                {
                    //saltar
                    case 1: 
                        
                        input.x = dirX;
                        input.y = dirY;

                        if (tocandoSuelo == true)
                        {
                            rb.AddForce(Vector2.up * fuerzaUp, ForceMode2D.Impulse);
                            animator.SetBool("moving", false);
                            animator.SetBool("up", true);
                            tocandoSuelo = false;
                        }
                        
                        
                        
                    break;
                    //left
                    case 2: 
                        speed = 150;
                        dirX -= 0.03f;
                        dirY = 0;
                        
                        input.x = dirX;
                        input.y = dirY;
                        
                    break;
                    //right
                    case 3: 
                        speed = 150;
                        dirX += 0.03f;
                        dirY = 0;
                        input.x = dirX;
                        input.y = dirY;
                        
                    break;
                    case 4:
                        animator.SetBool("moving", false);
                        animator.SetBool("up", true);
                        tocandoSuelo = false;
                        Time.timeScale = 0f;
                        transform.position = new Vector3(transform.position.x, 1, 0);
                        ball.transform.position = new Vector3(transform.position.x, 1, 0);
                        Time.timeScale = 1f;
                        balon.rb.velocity = new Vector2(15, -1);
                    break;

                    default:
                    
                    speed = 250;
                    dirX = Input.GetAxis("Horizontal");
                    dirY = 0;
                    input.x = dirX;
                    input.y = dirY;
                    
                    

                break;
                }

                if (dirX != 0)
                {
                    animator.SetBool("moving", true);
                    animator.SetBool("start", false);
                    animator.SetBool("up", false);
                    
                } else if(dirY == 0 || dirX == 0) {
                    
                    animator.SetBool("moving", false);
                    animator.SetBool("start", true);
                    animator.SetBool("up", false);
                    

                }

                if (timer.isActivePower)
                {
                    btn_power.SetActive(true);
                }
    }

    private void FixedUpdate() {
            if (dirX != 0 && tocandoSuelo == true)
            {
                rb.velocity = input * speed * Time.fixedDeltaTime;
            }

            

            if (Input.GetAxis("Vertical") == 1 && tocandoSuelo == true)
                    {
                        animator.SetBool("moving", false);
                        animator.SetBool("up", true);
                        rb.AddForce(Vector2.up * fuerzaUp, ForceMode2D.Impulse);
                        tocandoSuelo = false;
                    }
            
            if (Input.GetKeyDown(KeyCode.S) && tocandoBalon && timer.isActivePower)
                    {
                        animator.SetBool("moving", false);
                        animator.SetBool("up", true);
                        tocandoSuelo = false;
                        Time.timeScale = 0f;
                        transform.position = new Vector3(transform.position.x, 1, 0);
                        ball.transform.position = new Vector3(transform.position.x, 1, 0);
                        Time.timeScale = 1f;
                        balon.rb.velocity = new Vector2(15, -1);
                        
                    }
            
    }

    public void OnCollisionEnter2D(Collision2D other) 
    {
        if (other.gameObject.tag == "piso")
        {
            tocandoSuelo = true;
        }

        if (other.gameObject.tag == "supBall")
        {
            tocandoSuelo = true;
        }

        if (other.gameObject.tag == "ball")
        {
            tocandoBalon = true;
        }
    }

    

    


}

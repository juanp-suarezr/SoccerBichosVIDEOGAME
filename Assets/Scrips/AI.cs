using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AI : MonoBehaviour
{

    public float speed = 4.6f;

    public GameObject ball;

    private Vector2 ballpos;
    private float middle = Screen.width/2;
    
    public bool tocoMitad = false;

    //salto
    private Rigidbody2D rb;
    public float fuerzaUp;

    private bool tocandoSuelo;

    public Animator animator;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        
        animator = GetComponent<Animator>();
    }
    void Update()
    {
        Move();
    }

    void Move()
    {
        ballpos = ball.transform.position;

        if (transform.position.x > ballpos.x)
        {
            
            
            if (tocoMitad)
            {
                transform.position += new Vector3(+speed*Time.deltaTime, 0, 0);
                animator.SetBool("move", true);
                animator.SetBool("stop", false);
            } else 
            {
                
                transform.position += new Vector3(-speed*Time.deltaTime, 0, 0);
                animator.SetBool("move", true);
                animator.SetBool("stop", false);
            }
            
        }

        if (transform.position.x < ballpos.x)
        {
            
            transform.position += new Vector3((+speed*1.5f)*Time.deltaTime, 0, 0);
            animator.SetBool("move", true);
            animator.SetBool("stop", false);
            
        }

    }

    



}

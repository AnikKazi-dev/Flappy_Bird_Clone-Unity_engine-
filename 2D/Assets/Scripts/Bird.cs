using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;

public class Bird : MonoBehaviour
{
    public Rigidbody2D rb;
    public float speed = 0.0f;
    public ScoreTxT score;
    public GameManager gameManager;
    public Animator parentBirdAnim;
    public Animator getReadyAnim;
    public Sprite birdDied;
    SpriteRenderer sp;
    Animator anim;
    bool touchGround = false;
    int angle = 0;
    int maxAngle = 20;
    int minAngle = -90;
    int flag = 0;
    public Animator cameraShakeAnim;
    public AudioSource wingSound;
    public AudioSource pointSound;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        sp = GetComponent<SpriteRenderer>();
        anim = GetComponent<Animator>();
        
    }

    // Update is called once per frame
    void Update()
    {
        if (GameManager.tapBut == false)
        {

            rb.gravityScale = 0.0f;

            rb.velocity = Vector2.zero;

        }

        if (Input.GetMouseButtonDown(0) && flag == 0)
        {
            getReadyAnim.SetTrigger("GetReady");
            wingSound.Play();
            GameManager.tapBut = true;
            gameManager.TapObjFunction();
           
            flag = 1;
        }
        if ((GameManager.pauseBool == false)) 
        {
            if (Input.GetMouseButtonDown(0) && (GameManager.gameOver == false) && (GameManager.tapBut == true))
            {

                wingSound.Play();
                parentBirdAnim.enabled = false;
                
                rb.gravityScale = 0.8f;
                rb.velocity = Vector2.zero;
                rb.velocity = new Vector2(rb.velocity.x, speed);
            }
        }
        birdRotation();
    }

    void birdRotation()
    {
        if (rb.velocity.y > 0)
        {
            rb.gravityScale = 0.8f;
            if (angle <= maxAngle)
            {
                angle = angle + 4;
            }

        }
        else if (rb.velocity.y < 0)
        {
            rb.gravityScale = 0.6f;
            if (rb.velocity.y < -1.3f)
            {
                if (angle >= minAngle)
                {
                    angle = angle - 3;
                }

            }

           
        }
        if (touchGround == false)
        {
            transform.rotation = Quaternion.Euler(0, 0, angle);

        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("obs"))
        {
            pointSound.Play();
            score.Scored();
            
            //Debug.Log("scored "+ score++);
        }
        else if(collision.CompareTag("pipe"))
        {
            cameraShakeAnim.SetTrigger("Shake");
            gameManager.GameOver();
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.CompareTag("ground"))
        {
            if (GameManager.gameOver == false) {
                cameraShakeAnim.SetTrigger("Shake");
                GameOverBird();
                gameManager.GameOver();
            }
            else
            {
                cameraShakeAnim.SetTrigger("Shake");
                touchGround = true;
                GameOverBird();
            }
            
            
        }
        if (collision.gameObject.CompareTag("pipe"))
        {
            cameraShakeAnim.SetTrigger("Shake");
            gameManager.GameOver();
            GameOverBird();
            touchGround = true;
        }
    }


        public void GameOverBird()
    {
        touchGround = true;
        anim.enabled = false;
        sp.sprite = birdDied;
        
        transform.rotation = Quaternion.Euler(0,0,-90f);
    }





}

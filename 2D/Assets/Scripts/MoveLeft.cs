using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class MoveLeft : MonoBehaviour
{
    public float speed;
    BoxCollider2D box;
    float groundWidth;
    float pipeWidth;
    // Start is called before the first frame update
    void Start()
    {
        if(gameObject.CompareTag("ground"))
        {
            box = GetComponent<BoxCollider2D>();
            groundWidth = box.size.x;
             
        }

        if (gameObject.CompareTag("obs"))
        {
            pipeWidth = GameObject.FindGameObjectWithTag("pipe").GetComponent<BoxCollider2D>().size.x;
        }

        //Debug.Log(box.size.x);
    }

    // Update is called once per frame
    void Update()
    {
        if ((GameManager.gameOver == false) && (GameManager.tapBut == true))
        {
            transform.position = new Vector2(transform.position.x - speed * Time.deltaTime, transform.position.y);
        }

        if (gameObject.CompareTag("ground"))
        {
           // Debug.Log(GameManager.bottomLeft.x);
           // Debug.Log(GameManager.bottomLeft.y);

            if (transform.position.x <= -groundWidth)
        {
            transform.position = new Vector2(transform.position.x+2*groundWidth,transform.position.y);
        }

        }
        if(gameObject.CompareTag("obs"))
        {
            if (transform.position.x < GameManager.bottomLeft.x - pipeWidth*3)
            {
                //Debug.Log(transform.position.x);
                //Debug.Log(GameManager.bottomLeft.x);
                //Debug.Log(pipeWidth);
                Destroy(gameObject);
            }
        }
    }
}

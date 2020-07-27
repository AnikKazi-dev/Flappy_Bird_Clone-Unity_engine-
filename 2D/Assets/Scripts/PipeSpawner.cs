using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PipeSpawner : MonoBehaviour
{
    public GameObject pipe;
    public float maxTime;
    float timer;
    public float maxY;
    public float minY;
    float randY;
    void Start()
    {
        
        InstantiateObstacle();
    }

   
    void Update()
    {
        if ((GameManager.gameOver == false) && (GameManager.tapBut == true))
        {

            timer += Time.deltaTime;

            if (timer >= maxTime)
            {
                InstantiateObstacle();
                timer = 0;
            }

        }
    }
    public void InstantiateObstacle()
    {

        randY =Random.Range(minY,maxY);
        GameObject newPipe = Instantiate(pipe);
       
        newPipe.transform.position = new Vector2(transform.position.x,randY);
        

    }


}

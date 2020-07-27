using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameOverUIAnim : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject madel;


    public void OnGameOverAnimEnds()
    {
        madel.SetActive(true);
    }
}

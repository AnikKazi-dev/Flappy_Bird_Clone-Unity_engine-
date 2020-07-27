using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Madel : MonoBehaviour
{
    // Start is called before the first frame update

    public Sprite normalMadel;
    public Sprite branzaMadel;
    public Sprite silverMadel;
    public Sprite goldMadel;

    Image img;

    void Start()
    {

        img = GetComponent<Image>();

        int GameScore = GameManager.gameScoreForMadel;

        if (GameScore > 0 && GameScore <= 2)
        {
            img.sprite = normalMadel;
        }

        else if (GameScore > 2 && GameScore <= 4)
        {
            img.sprite = branzaMadel;
        }

        else if (GameScore > 4 && GameScore <= 6)
        {
            img.sprite = silverMadel;
        }

        else if (GameScore > 6)
        {
            img.sprite = goldMadel;
        }

    }

    void Update ()
        {


        }
}

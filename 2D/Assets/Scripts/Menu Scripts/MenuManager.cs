using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{
    // Start is called before the first frame update
    public AudioSource audioOnMenuPlayButtonPressed;

    public Animator blackFadeAnim; 
    void Start()
    {
        GameManager.gameOver = false;
        //GameManager.tapBut == true;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnPlayButtonPressed()
    {
        //SceneManager.LoadScene(0);
        blackFadeAnim.SetTrigger("FadeIn");
        audioOnMenuPlayButtonPressed.Play();
    }
}

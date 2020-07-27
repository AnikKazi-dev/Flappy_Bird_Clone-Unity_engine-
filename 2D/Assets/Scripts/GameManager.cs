using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.SocialPlatforms.Impl;

public class GameManager : MonoBehaviour
{
    public static Vector2 bottomLeft;
    public static bool gameOver;
    public static bool tapBut;
    public GameObject gameOverUi;
    public GameObject tapButobj;
    public GameObject scoreTxt;
    public Animator afterGetReady;
    public static bool pauseBool = false;
    public GameObject pauseMenu;
    public GameObject resumeGame;
    public GameObject menuUI;
    public Animator blackFadeAnim;
    public Animator gameOverAnim;

    public static int gameScoreForMadel;

    public AudioSource hitSound;
    public AudioSource dieSound;
    public AudioSource okButtPressSound;

    private void Awake()
    {
        bottomLeft = Camera.main.ScreenToWorldPoint(new Vector2(0, 0));

       

    }
    void Start()
    {
        gameOver = false;
        tapBut = false;
    }

    // Update is called once per frame
    void Update()
    {
       
    }
    public void GameOver()
    {
        gameOver = true;
        hitSound.Play();
        gameScoreForMadel = scoreTxt.GetComponent<ScoreTxT>().GetScore();

        pauseMenu.SetActive(false);

        gameOverUi.SetActive(true);

        Invoke("afterOneSec",0.5f);        
       


    }
    void afterOneSec()
    { 
        gameOverAnim.SetTrigger("UpToDown");
        dieSound.Play();
    }


    public void OKBtnPressed()
    {
        okButtPressSound.Play();
        pauseMenu.SetActive(true);

        SceneManager.LoadScene("GameScene");
    }


    public void TapObjFunction()
    {
        scoreTxt.SetActive(true);

        

        //  tapButobj.SetActive(false);

    }

    public void PauseButtonPressed()
    {
        // pauseMenu.SetActive(true);

        pauseBool = true;
        resumeGame.SetActive(true);
        Time.timeScale = 0f;

    }
    public void ResumeButtonPressed()
    {
        pauseBool = false;
        resumeGame.SetActive(false);
        Time.timeScale = 1f;
        
    }

   public void OnMenuButtonPressed()
    {
        //SceneManager.LoadScene("Menu");
        blackFadeAnim.SetTrigger("FadeIn");
        okButtPressSound.Play();

    }

   
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Score : MonoBehaviour
{
  public static Score Instance{get;private set;}
      public static int Highscore; 
     public static int score=1;
    
    [SerializeField] TextMesh ScoreText;

    [Header("GameScore")]
     [SerializeField] Text CurrentScore;
     [SerializeField] Text HighScore;
     public static Animator Anime;
     public  Animator Animes;
     [SerializeField] private GameObject Panel;
     [SerializeField] private GameObject PauseMenu;
     [SerializeField] private Text Name;
      
    bool probled=false;
    
      
      void Awake()
    {
        Name.text = PlayFabManager.Instance.Name;
        Highscore = PlayFabManager.Instance.HighScore;
      Instance=this;
      Anime=GetComponent<Animator>();
      Anime=Animes;

        HighScore.text = "HIGHSCORE:" + Highscore;
      
    	StartCoroutine(Deads());
    	//CODE HELL BECAUSE IT WAS 3 am JUST I WAS NEED SOME SLEEP SLEEP SLEEEP SLEEP SLe....

    }

    void Update()
  	{
      CurrentScoreTHing();
  	}

  	 IEnumerator Deads()

    {  
     

    	while(score>0 && Move.Life > 0)
    	{
            score++;

            ScoreText.text=score.ToString();
    		yield return new WaitForSeconds(1f);
       
        
    	  
      }


    	Debug.Log("DOne");
    	yield return new WaitForSeconds(1f);
    }

    public static void AddScore()
    {
       score+=20;
       
    }


    void CurrentScoreTHing()
    {
      if(Move.Life==0)
      {
           
      if(score>Highscore)
      {
                PlayFabManager.Instance.UploadHighScore(score);
                Highscore = score;
      }

            
          Panel.SetActive(true);
            HighScore.text = "HIGHSCORE:" + Highscore;
          CurrentScore.text="Score:"+score.ToString();
        } 


    }

    public void PauseGame()
    {
      Time.timeScale=0f;
      PauseMenu.SetActive(true);
    }

    public void UnPauseGame()
    {
      Time.timeScale=1f;
      PauseMenu.SetActive(false);
    }

    public void Home()
    {
      Time.timeScale=1f;
      SceneManager.LoadScene("MainMenu");
    }
    public void ScoreReset()
    {
        Move.Life = 3;
        score = 1;
        GameControl.globalSpeedMultiplier = 0.5f;
    }

    public void LeaderboardUICall() => PlayFabManager.Instance.LinkLeaderboardtoUI();
    public void LeaderboardGetCall() => PlayFabManager.Instance.GetLeaderboard();
}

         
     
  



    


using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System;

public class Button : MonoBehaviour
{
	public Animator Anim;
    AudioSource audioSource;
     [SerializeField] private AudioClip ButtonSound;
   
   void Start()
   {
    audioSource=GetComponent<AudioSource>();
      Anim=GetComponent<Animator>();
   }

   public void PlayGame() => StartCoroutine(Starte());


   public void ExitFromGame()
   {
    audioSource.PlayOneShot(ButtonSound);
   	Application.Quit();
   }
    public void HowToPlay() => StartCoroutine(FromMenuToHTP());

    IEnumerator FromMenuToHTP()
    {
        audioSource.PlayOneShot(ButtonSound);
        Anim.SetTrigger("Start");
        yield return new WaitForSeconds(1f);
        SceneManager.LoadScene("HowToPlay");
    }

    public void FromMenuToAbout() => StartCoroutine(About());
    

	public void Settings() => StartCoroutine(Settingse());
   

   public void ExitFromGameToMenus() => StartCoroutine(ExitFromGameToMenu());


    IEnumerator About()
    {
        audioSource.PlayOneShot(ButtonSound);
        Anim.SetTrigger("Start");
        yield return new WaitForSeconds(1f);
        SceneManager.LoadScene("About");
    }
   IEnumerator Starte()
   {
    audioSource.PlayOneShot(ButtonSound);
   	 Anim.SetTrigger("Start");
   	 yield return new WaitForSeconds(1f);
   	 SceneManager.LoadScene("Select");

   	}

    IEnumerator Settingse()
   {
    audioSource.PlayOneShot(ButtonSound);
   	 Anim.SetTrigger("Start");
   	 yield return new WaitForSeconds(1f);
   	 SceneManager.LoadScene("Settings");
   	}

   	 IEnumerator ExitFromGameToMenu()
   {
     audioSource.PlayOneShot(ButtonSound);
 
   	 Anim.SetTrigger("Start");
   	 yield return new WaitForSeconds(1f);
   	 SceneManager.LoadScene("MainMenu");
   	}

    public void TwitterURL() =>
        Application.OpenURL("https://twitter.com/ChroniclesNFT");
    public void DiscodeURL() =>
        Application.OpenURL("https://discord.gg/SHgZgdSZtc");
    
    

    public void RestartGames()
    {
    	
    	audioSource.PlayOneShot(ButtonSound);
    	SceneManager.LoadScene("SampleScene");
        Score.Instance.ScoreReset();
    }




}

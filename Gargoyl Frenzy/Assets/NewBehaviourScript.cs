using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class NewBehaviourScript : MonoBehaviour
{
	[SerializeField] GameObject InputField;
    [SerializeField] GameObject TextDisplay;
    [SerializeField] GameObject Panels;
     [SerializeField] GameObject EnterName;
    public static string Name;
		
     void Awake()
    {
    	
    	if(PlayerPrefs.GetInt("firstTime",0)==0)
    	{
    		print("Frick you PlayerPrefs");
    		PlayerPrefs.SetInt("firstTime",1);
    		PlayerPrefs.SetInt("C_Level",1);
    		EnterName.SetActive(true);
    		
    	}
    	
    }

    void Update()
    {
    
    }
    //WHUT?

    public void SaveInput(){

    	StartCoroutine(SomeTimeWait());
   		
    }

    IEnumerator SomeTimeWait()
    {
        Name=InputField.GetComponent<InputField>().text;
        TextDisplay.GetComponent<Text>().text="HI "+Name+" WELCOME TO THE GAME";
        yield return new WaitForSeconds(1.5f);
        Panels.SetActive(false);
        PlayerPrefs.SetString("Name",Name);
    }

}

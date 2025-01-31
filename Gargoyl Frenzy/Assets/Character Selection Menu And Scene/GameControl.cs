using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameControl : MonoBehaviour
{
    public static float globalSpeedMultiplier =0.5f;
    public float maxspeed;
    public GameObject[] characters;
    public Transform playerStartPosition;
    public string menuScene = "Character Selection Menu";
    private string selectedCharacterDataName = "SelectedCharacter";
    int selectedCharacter;
    public GameObject playerObject;
    // Start is called before the first frame update
    void Start()
    {
        selectedCharacter = PlayerPrefs.GetInt(selectedCharacterDataName,0);
        playerObject = Instantiate(characters[selectedCharacter],playerStartPosition.position,characters[selectedCharacter].transform.rotation);
    }

    // Update is called once per frame
    void Update()
    {
        if(globalSpeedMultiplier<maxspeed)
        globalSpeedMultiplier += 0.02f * Time.deltaTime;
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            ReturnToMainMenu();
        }
    }

    public void ReturnToMainMenu()
    {
        SceneManager.LoadScene(menuScene);

    }

}

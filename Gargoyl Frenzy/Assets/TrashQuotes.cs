using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrashQuotes : MonoBehaviour
{
	   public List<string> trashQuotes;
      public TextMesh trashTalk;
	 

    // Start is called before the first frame update
    void Start()
    {
       trashTalk.text=trashQuotes[Random.Range(0,trashQuotes.Count)];   
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

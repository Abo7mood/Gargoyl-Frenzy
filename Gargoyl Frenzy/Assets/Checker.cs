using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Checker : MonoBehaviour
{
	public Score Scores;
    // Start is called before the first frame update
    void Start()
    {
        Scores=GetComponent<Score>();
    }

    // Update is called once per frame
    void Update()
    {
       if(Move.Life==0)
       {
       	 StartCoroutine(wow());
       }
    }

    IEnumerator wow()
    {
    	yield return new WaitForSeconds(0.7f);
    	Scores.enabled=false;
    }
}

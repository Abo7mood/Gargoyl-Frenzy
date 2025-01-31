using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Check : MonoBehaviour
{
   private Enemy Move;
   private Roads Road ;
	
	
    // Start is called before the first frame update
    void Start()
    {
        Move=GetComponent<Enemy>();
       Road=GetComponent<Roads>();
        

    }

    // Update is called once per frame
   
     private void OnCollisionEnter2D(Collision2D other)
	{
	  
        if (other.gameObject.CompareTag("Ground"))
        {
          
          Road.enabled=false;
          Move.enabled=false;  
        }



	}
       
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
	[Header("Player")]
	private Roads Moves;
	private Rigidbody2D Meenemy;
    private BoxCollider2D enemy;
	private Animator Animation;
  private int enemything;
  [Header("Pop up Text")]
  public GameObject PopUp;

	
    // Start is called before the first frame update
    void Start()
    {
      
        enemy=GetComponent<BoxCollider2D>();
        Moves=GetComponent<Roads>();
        Meenemy=GetComponent<Rigidbody2D>();
        Animation=GetComponent<Animator>();

    }

    // Update is called once per frame
    void Update()
    {
      /*if(enemything==1)
      {
transform.position+=Vector3.left*13*Time.deltaTime;
      }*/
    }
     private void OnCollisionEnter2D(Collision2D other)
	{
	  if (other.gameObject.CompareTag("Player"))
        {
           Move.Life-=1;
       
          Animation.Play("Jump");
          Moves.enabled=false;
        }
     

        
        if (other.gameObject.CompareTag("Bullet"))
        {
          Score.Anime.Play("Effect");
         	Instantiate(PopUp,transform.position,Quaternion.identity);
           Score.AddScore();
          Animation.SetBool("Kill",true);
          enemy.enabled=false;
          Meenemy.isKinematic=false;
          Moves.enabled=false;  
          
        
        }

        if (other.gameObject.CompareTag("Ground"))
        {
          
          Moves.enabled=false;  
        }

	}

  void OnCollisionExit2D(Collision2D col)
  {
    Moves.enabled=true;
    Animation.Play("EnemyMove");
  
  }
        
    
}
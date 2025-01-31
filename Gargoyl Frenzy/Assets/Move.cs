using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move : MonoBehaviour
{

	//
    public static Move Instance{get;private set;}
	private Rigidbody2D rigid;
    private bool isGrounded;
    [Header("CheckGrounded")]
    public Transform Groundcheck;
    public float checkRadius;
    public LayerMask whatIsGround;
    private float moveInput;
    private int extraJumps;
    public int extraJumpValue;
    [Header("PlayerSpeed")]
	[SerializeField] private float Speed;
    [SerializeField] private Animator Anim;
    [Header("AimSpeedOtherGarbage")]
    private Transform handPos;
    private Transform firePos1,firePos2;
    public GameObject Bullet;
    [SerializeField] private float rotateSpeed ;
      [SerializeField] private float bulletspeed ;
      private BoxCollider2D Player;
      [HideInInspector]public static int Life=3;
      
      [SerializeField] private Move PlayerMOce;
 		public  GameObject DeadEffect;
      //
     [SerializeField] private AudioClip PlayerHurts;
     [SerializeField] private AudioClip PlayerJumps;
       [SerializeField] private AudioClip PlayerFires;
    [SerializeField] private float SoundScale;
     //
     AudioSource audioSource;

    private void Awake()
    {
          Instance=this;
    	Life=3;
        handPos=GameObject.Find("Arm").transform;
        firePos1=GameObject.Find("firePos1").transform;
        firePos2=GameObject.Find("firePos2").transform;

    }
    // Start is called before the first frame update
     void Start()
    {
       
        audioSource=GetComponent<AudioSource>();
    	//
    	PlayerMOce=GetComponent<Move>();
    	Player=GetComponent<BoxCollider2D>();
        extraJumps=extraJumpValue;
        Anim=GetComponent<Animator>();
        rigid=GetComponent<Rigidbody2D>();
        
    }

    

    // Update is called once per frame
     void FixedUpdate()
    {
        
        isGrounded=Physics2D.OverlapCircle(Groundcheck.position,checkRadius,whatIsGround);
        /*moveInput=Input.GetAxis("Horizontal");
        rigid.velocity=new Vector2(moveInput*Speed,rigid.velocity.y);*/
       
    }

    void Update()
    {

            AIM();
        
        Vector3 pos=transform.position;
            pos.x=Mathf.Clamp(-6,-7,pos.z);
         if(isGrounded==true)
        {
            extraJumps=extraJumpValue;
        }

        if(Input.GetKeyDown(KeyCode.Space) && extraJumps>0)
        {
        	JumpPlayer();
            rigid.velocity=Vector2.up*Speed;
            extraJumps--;
        }
        else if(Input.GetKeyDown(KeyCode.Space) && isGrounded==true && extraJumps==0)
        {
        	JumpPlayer();
            rigid.velocity=Vector2.up*Speed;
        }

        if(rigid.velocity.y>0)
        {
            Anim.SetBool("walk",true);
        }
        else
        {
            Anim.SetBool("walk",false);
        }

        //////
        if(Life==0)
        {
            StartCoroutine(Dead());
        }
    


        //////TRANSFORMING WALLS
        if(transform.position.x<-1.9f)
        {
           Anim.Play("Shadow");
           Vector3 go=new Vector3(-1f,transform.position.y,transform.position.z*10*Time.deltaTime);
           rigid.MovePosition(go);
        }
    }

void AIM()
{
    Vector2 direction=Camera.main.ScreenToWorldPoint(Input.mousePosition)-handPos.position;
    float angle=Mathf.Atan2(direction.y,direction.x)*Mathf.Rad2Deg;
    Quaternion rotation=Quaternion.AngleAxis(angle,Vector3.forward);
    handPos.rotation=Quaternion.Slerp(transform.rotation,rotation,rotateSpeed*Time.deltaTime);
        if (Input.GetMouseButtonDown(0))
        {
            GameObject b = Instantiate(Bullet, firePos1.position, Quaternion.identity);

                b.GetComponent<Rigidbody2D>().AddForce(direction.normalized * bulletspeed, ForceMode2D.Impulse);
            PlayerFire();
            Anim.Play("Attack");
            Destroy(b, 2);
        }
}


	private void OnTriggerEnter2D(Collider2D other)
	{

		if (other.gameObject.CompareTag("Spike"))
	{
		HurtPlayer();
		rigid.AddForce(Vector2.up*5,ForceMode2D.Impulse);
        rigid.AddTorque(200);
        StartCoroutine(Hurt());
      	Anim.Play("PlayerHurt");
        Life-=1;       
	}
	else if (other.gameObject.CompareTag("Axe"))
	{
		HurtPlayer();
		rigid.AddForce(Vector2.up*5,ForceMode2D.Impulse);
        rigid.AddTorque(200);
        StartCoroutine(Hurt());
      	Anim.Play("PlayerHurt");
        Life-=1;       
	}

	else
	{
		Anim.Play("Walk");
	}
}

private void OnCollisionEnter2D(Collision2D other)
	{
		if (other.gameObject.CompareTag("Enemy"))
	{
		     Instantiate(DeadEffect,transform.position,Quaternion.identity);
	}
	}

	IEnumerator Dead()
	{
       		Instantiate(DeadEffect,transform.position,Quaternion.identity);
		CameraShake.ShakeOnce(0.4f,0.6f);
			Anim.Play("PlayerDead");
        	rigid.AddForce(Vector2.up*0.2f,ForceMode2D.Impulse);
        rigid.AddTorque(100);
	
		yield return new WaitForSeconds(1f);
        Player.enabled=false;
        PlayerMOce.enabled=false;
  

        
	}

	IEnumerator Hurt()
	{
		Instantiate(DeadEffect,transform.position,Quaternion.identity);
		CameraShake.ShakeOnce(0.3f,0.2f);
		Player.enabled=false;	
		yield return new WaitForSeconds(0.2f);
        Player.enabled=true;
        
	}

	//Garbage 

	void HurtPlayer()
	{
		audioSource.PlayOneShot(PlayerHurts,0.8f);
	}

	void JumpPlayer()
	{
		audioSource.PlayOneShot(PlayerJumps,0.3f);
	}

	void PlayerFire()
	{
		audioSource.PlayOneShot(PlayerFires,0.3f);
	}



	
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
	
	public GameObject Particle;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update() 
    {
        transform.Rotate(0,0,360*Time.deltaTime);
    }

     private void OnCollisionEnter2D(Collision2D other)
	{
		if(other.gameObject.CompareTag("Enemy"))
		{
			CameraShake.ShakeOnce(0.4f,0.2f);
			Destroy(other.gameObject,1);
			Destroy(this.gameObject);
			Instantiate (Particle,transform.position,Quaternion.identity);
		}

		if(other.gameObject.CompareTag("Player"))
		{
			Destroy(this.gameObject);
			
		}

		if(other.gameObject.CompareTag("Ground"))
		{
			Destroy(this.gameObject);
			
		}
	}

	



}

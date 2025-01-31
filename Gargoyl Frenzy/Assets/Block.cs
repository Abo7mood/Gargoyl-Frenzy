using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Block : MonoBehaviour
{
      private  float time;
	 public  float Maxtime=1;
	[SerializeField] private GameObject Pipe;
	[SerializeField] private float height;


    // Update is called once per frame
    void Update()
    {
        if(time>Maxtime)
        {
        	GameObject pipe=Instantiate(Pipe);
        	pipe.transform.position=transform.position+ new Vector3(0,Random.Range(-height,height),0);
        	Destroy(pipe,25);
        	time=0;
        }
        time+=Time.deltaTime;
    } 

}

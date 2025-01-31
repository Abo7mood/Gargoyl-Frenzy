using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{

    public float speed;
    public float endx;
    public float start;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector2.left * speed * Time.deltaTime * GameControl.globalSpeedMultiplier);

        if (transform.position.x <= endx)
        {
            Vector2 pos = new Vector2(start, transform.position.y);
            transform.position = pos;
        }
    }
}

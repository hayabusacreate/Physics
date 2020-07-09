using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Phcsys3 : MonoBehaviour
{
    public float m;
    public float x,y;
    private Vector3 v;
    private Vector3 savev;
    private float savem;
    public GameObject gameObject;
    private float distance;
    public bool lr;
    public bool check;
    // Start is called before the first frame update
    void Start()
    {
        //savev = v;
        if(check)
        {
            v.x = x;
            v.y = y;
        }else
        {
            v.x = x;
            v.y = y;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position.x> 10&&!lr)
        {
            v *= -1;
        }
        if (transform.position.x < -10&&!lr)
        {
            v *= -1;
            
        }
        if (transform.position.y < -5 && !lr)
        {
            v *= -1;

        }
        if (transform.position.y > 5 && !lr)
        {
            v *= -1;

        }
        distance = Vector3.Distance(gameObject.transform.position, transform.position);

        if(check)
        {
            if (distance <= 1 && distance > 0.75f)
            {
                Vector3 a = gameObject.transform.position - transform.position;
                Vector3 n = (gameObject.transform.position - transform.position) / (a.magnitude);
                Vector3 savev = -(Vector3.Dot((v - gameObject.GetComponent<Phcsys3>().v), n)) * (n + v)/2;

                gameObject.GetComponent<Phcsys3>().v = -(Vector3.Dot((gameObject.GetComponent<Phcsys3>().v - v), n)) * (n + gameObject.GetComponent<Phcsys3>().v)/2;
                v =savev;
            }
        }

        
        transform.position += new Vector3(v.x, v.y, 0);
    }
}

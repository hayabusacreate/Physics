using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Phcsys2 : MonoBehaviour
{
    public float m;
    public float v,x;
    public GameObject gameObject;
    private float distance;
    public bool lr;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (x > 10&&lr)
        {
            v *= -1;
            lr = false;
        }
        if (x < -10&&!lr)
        {
            v *= -1;
            lr = true;
        }
        x =x+m*v;


        distance = Vector3.Distance(transform.position, gameObject.transform.position);

        if(distance<=1)
        {

                v = ((m - gameObject.GetComponent<Phcsys2>().m) * v + 2 * gameObject.GetComponent<Phcsys2>().m  * gameObject.GetComponent<Phcsys2>().v) / (m + gameObject.GetComponent<Phcsys2>().m);
                gameObject.GetComponent<Phcsys2>().v = ((gameObject.GetComponent<Phcsys2>().m-m) * gameObject.GetComponent<Phcsys2>().v + 2 * m * v) / (m + gameObject.GetComponent<Phcsys2>().m);
            
            Debug.Log(distance);
           // v = ((m - gameObject.GetComponent<Phcsys2>().m) * v + 2 * gameObject.GetComponent<Phcsys2>().m * 2 * gameObject.GetComponent<Phcsys2>().v) / (m +  gameObject.GetComponent<Phcsys2>().m);
        }
        transform.position = new Vector3(x, 0, 0);
    }
}

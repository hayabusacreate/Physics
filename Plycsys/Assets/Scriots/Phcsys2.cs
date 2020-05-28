using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Phcsys2 : MonoBehaviour
{
    public float m;
    public float v,x;
    private float savev, savem;
    public GameObject gameObject;
    private float distance;
    public bool lr;
    public bool check;
    // Start is called before the first frame update
    void Start()
    {
        savev = v;
    }

    // Update is called once per frame
    void Update()
    {
        if (x > 10&&lr)
        {
            v *= -1;
        }
        if (x < -10&&!lr)
        {
            v *= -1;
            
        }



        distance = Vector3.Distance(gameObject.transform.position, transform.position);

        if(check)
        {
            if (distance <= 1.1&&distance>0.9f)
            {

                savev = ((m - gameObject.GetComponent<Phcsys2>().m) * v + 2 * gameObject.GetComponent<Phcsys2>().m * gameObject.GetComponent<Phcsys2>().v) / (m + gameObject.GetComponent<Phcsys2>().m);
                gameObject.GetComponent<Phcsys2>().v = ((gameObject.GetComponent<Phcsys2>().m - m) * gameObject.GetComponent<Phcsys2>().v + 2 * m * v) / (m + gameObject.GetComponent<Phcsys2>().m);
                v = savev;
                //v *= -1;
                //gameObject.GetComponent<Phcsys2>().v *= -1;
                Debug.Log(distance);
                // v = ((m - gameObject.GetComponent<Phcsys2>().m) * v + 2 * gameObject.GetComponent<Phcsys2>().m * 2 * gameObject.GetComponent<Phcsys2>().v) / (m +  gameObject.GetComponent<Phcsys2>().m);
            }
        }
        x = x + m * v;
        transform.position = new Vector3(x, 0, 0);
    }
}

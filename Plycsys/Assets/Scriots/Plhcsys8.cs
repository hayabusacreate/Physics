using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Plhcsys8 : MonoBehaviour
{
    public float maxvel;
    public float vel;
    public float acc;
    private float time;
    private float savevel;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKey(KeyCode.D))
        {
            vel += Time.deltaTime;
            savevel = vel;
            time = 0;
        }
        else
        {

            if(vel<=0)
            {
                vel=0;
            }else
            {
                time += Time.deltaTime;
                vel = ease_in(time, savevel, 0 - savevel, 1);
            }


        }


        transform.position += new Vector3(vel, 0, 0);
    }
    float ease_in(float t,float b, float c, float d)
    {
        float x = t / d;
        float v = x * x * x;
        float ret = c * v + b;
        return ret;
    }
}

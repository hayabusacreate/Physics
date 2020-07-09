using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Phicsys9 : MonoBehaviour
{
    public float maxvel;
    public float vel;
    public float acc;
    private float time;
    private float savevel;
    public AudioSource audio1, audio2;
    private bool flag;
    private bool a;
    // Start is called before the first frame update
    void Start()
    {
        savevel = 0;
        flag = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if(!a)
            {
                flag = !flag;
                a = true;
                time = 0;
            }
        }

        if(flag)
        {
            if (vel >= 1)
            {
                vel = 1;
                savevel = 1;
                a = false;
            }
            else
            {
                time += Time.deltaTime;
                vel = ease_in(time, savevel, 1 - savevel, 1);
            }
        }
        else
        {
            if (vel <= 0)
            {
                vel = 0;
                savevel = 0;
                a = false;
            }
            else
            {
                time += Time.deltaTime;
                vel = ease_in(time, savevel, 0 - savevel, 1);
            }
        }
        audio2.volume = vel;
        audio1.volume = 1 - vel;
    }
    float ease_in(float t, float b, float c, float d)
    {
        float x = t / d;
        float v = x * x * x;
        float ret = c * v + b;
        return ret;
    }
}


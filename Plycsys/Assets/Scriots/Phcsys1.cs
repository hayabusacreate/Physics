using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public enum Serect
{
    AirResistance,
    Spring,
    Parabola,
    UniversalGravity
}

public class Phcsys1 : MonoBehaviour
{
    public float ax,ay, kv, m, g,vx,vy,px,py,kx,fx,fy,rx,ry,G;
    public Serect serect;
    public GameObject vs;
    public Phcsys1 phcsys;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(serect==Serect.AirResistance)
        {
            ax = g - kv / m;
            kv = kv + ax;
            py = py + kv;
            transform.position = new Vector3(0, -py, 0);
            if (transform.position.y < -10)
            {
                transform.position = new Vector3(0, 5, 0);
                py = -5;
            }
        }
        if(serect==Serect.Spring)
        {
            ax =  kx / m ;
            kv = kv - ax;
            kx = kx + kv;
            transform.position = new Vector3(0, kx, 0);
            if (transform.position.y < -10)
            {
                transform.position = new Vector3(10, 10, 0);
                py = 10;
                px = 10;
            }
            if (transform.position.y > 10)
            {
                transform.position = new Vector3(-10, -10, 0);
                py = -10;
                px = -10;
            }
        }
        if(serect==Serect.Parabola)
        {
            ax = ax + fx / m;

            vx = vx + ax;

            px = px + vx;

            if(Input.GetKey(KeyCode.Space))
            {
                ay = 0.01f;
            }
            ay = -g + ay + fy / m;
            vy = vx + ay;
            py = py + vy;
            transform.position = new Vector3(px, py, 0);
            if (transform.position.x < -10)
            {
                transform.position = new Vector3(10, 0, 0);
                px = 10;
            }
            if (transform.position.x > 10)
            {
                transform.position = new Vector3(-10, 0, 0);
                px = -10;
            }
        }
        if(serect==Serect.UniversalGravity)
        {
            
            rx = (transform.position.x-vs.transform.position.x);
            ax = (m*phcsys.m)/(rx*rx);
            kv = kv + ax;
            px = px + kv;
            ry = (transform.position.y - vs.transform.position.y);
            ay = (m * phcsys.m) / (ry * ry);
            kv = kv + ay;
            py = py + kv;
            transform.position = new Vector3(px, py, 0);
        }

    }
}

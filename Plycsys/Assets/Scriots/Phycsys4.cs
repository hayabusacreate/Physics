using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Phycsys4 : MonoBehaviour
{
    public float ax, ay, kv, m, g, vx, vy, px, py, kx, fx, fy, rx, ry, G;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        kv = kv + ax;
        py = py + kv;


        var angles = transform.rotation.eulerAngles;
        angles.z += ax;
        transform.rotation = Quaternion.Euler(angles);
    }
}

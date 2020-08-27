using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class body : MonoBehaviour
{
    private GameObject oya;
    private float x, y;
    public float far;
    public float speed;
    // Start is called before the first frame update
    void Start()
    {
        oya = gameObject.transform.root.gameObject;
        gameObject.transform.parent = null;
    }

    // Update is called once per frame
    void Update()
    {
        x = gameObject.transform.position.x - oya.transform.position.x;
        y = gameObject.transform.position.y - oya.transform.position.y;
        if ((x < -far || x > far) || (y < -far || y > far))
        {
            transform.position -= new Vector3(x / 10, y / 10);
        }
    }
}

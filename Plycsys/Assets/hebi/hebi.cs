using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class hebi : MonoBehaviour
{
    public int body;
    public GameObject bady;
    private Vector3 position;
    // Start is called before the first frame update
    void Start()
    {
        GameObject oya = gameObject;
        for(int i=0;i<body;i++)
        {
            GameObject body= Instantiate(bady, gameObject.transform.position, Quaternion.identity);
            body.transform.parent = oya.transform;
            oya = body;
        }
    }

    // Update is called once per frame
    void Update()
    {
        position = Input.mousePosition;
        position.z -= -10;
        gameObject.transform.position= Camera.main.ScreenToWorldPoint(position);

    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public enum Check
{
    Ball,
    Line
}

public class Phcsys6 : MonoBehaviour
{
    public Check check;
    private float bax;
    private bool aa;
    private float dist;
    public GameObject Ball;
    private Vector3 a, b;
    // Start is called before the first frame update
    void Start()
    {
        bax = -5;
    }

    // Update is called once per frame
    void Update()
    {
        if(check==Check.Ball)
        {
            if(bax<-10||bax>10)
            {
                aa = !aa;
            }
            if(aa)
            {
                bax += Time.deltaTime*10;
            }else
            {
                bax -= Time.deltaTime*10;
            }
            transform.position = new Vector3(bax, 0, 0);
        }else
        {
            LineRenderer renderer = gameObject.GetComponent<LineRenderer>();
            // 線の幅
            renderer.SetWidth(0.1f, 0.1f);
            // 頂点の数
            renderer.SetVertexCount(2);
            // 頂点を設定
            renderer.SetPosition(0, Vector3.zero);
            renderer.SetPosition(1, new Vector3(3f, 3f, 0f));
            dist =Mathf.Abs( (3 * Ball.transform.position.y - 3 * Ball.transform.position.x)/new Vector2(3,3).magnitude);
            if (dist < 0.2f)
            {
                Ball.transform.gameObject.GetComponent<Phcsys6>().aa = !Ball.transform.gameObject.GetComponent<Phcsys6>().aa;
                Ball.transform.gameObject.GetComponent<Renderer>().material.color = Color.red;
            }else
            {
                Ball.transform.gameObject.GetComponent<Renderer>().material.color = Color.white;
            }

        }
    }
}

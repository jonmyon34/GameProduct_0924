using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjeckMoveSimple : MonoBehaviour
{

    public float speed = 1.0f;
    public Vector3 direction = new Vector3(1.0f, 0.0f, 0.0f);

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        Vector3 n_dire = direction.normalized;
        transform.position += speed * n_dire * Time.deltaTime;


    }
}


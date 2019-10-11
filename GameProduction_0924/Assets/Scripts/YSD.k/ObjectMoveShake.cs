using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectMoveShake : MonoBehaviour
{
    public bool isSin = true;
    //public Vector3 idouryou = Vector3.one;
    public Vector3 idousokudo = Vector3.one;
    //public float idouzikann = 1.0f;
    public Vector3 idouzikann = Vector3.one;

    //private Vector3 default_position;
    //private float zikann;//backup
    private Vector3 zikann = Vector3.one;
    private Vector3 angle = Vector3.zero;
    private Vector3 angle_per_frame;
    private Vector3 sin3;
    // Use this for initialization
    void Start()
    {
        //default_position = transform.position;
        zikann = idouzikann;

        Vector3 temple = new Vector3(180 / idouzikann.x, 180 / idouzikann.y, 180 / idouzikann.z);
        angle_per_frame = temple * Time.deltaTime;
    }

    // Update is called once per frame
    void Update()
    {
        sin3 = new Vector3(
            Mathf.Sin(angle.x * Mathf.Deg2Rad), Mathf.Sin(angle.y * Mathf.Deg2Rad), Mathf.Sin(angle.z * Mathf.Deg2Rad));

        if (isSin)
        {
            Part_of_X_Sin();
            Part_of_Y_Sin();
            Part_of_Z_Sin();
        }
        else
        {
            Part_of_X();
            Part_of_Y();
            Part_of_Z();
        }

    }

    void Part_of_X()
    {
        transform.position += new Vector3(idousokudo.x * Time.deltaTime, 0, 0);
        idouzikann.x -= Time.deltaTime;


        //切り替え条件
        if (idouzikann.x < 0.0f)
        {
            idouzikann.x = zikann.x;
            idousokudo.x *= -1;
        }

    }


    void Part_of_Y()
    {
        transform.position += new Vector3(0, idousokudo.y * Time.deltaTime, 0);
        idouzikann.y -= Time.deltaTime;


        //切り替え条件
        if (idouzikann.y < 0.0f)
        {
            idouzikann.y = zikann.y;
            idousokudo.y *= -1;
        }

    }

    void Part_of_Z()
    {
        transform.position += new Vector3(0, 0, idousokudo.z * Time.deltaTime);
        idouzikann.z -= Time.deltaTime;


        //切り替え条件
        if (idouzikann.z < 0.0f)
        {
            idouzikann.z = zikann.z;
            idousokudo.z *= -1;
        }

    }

    void Part_of_X_Sin()
    {

        transform.position += new Vector3(idousokudo.x * sin3.x * Time.deltaTime, 0, 0);
        idouzikann.x -= Time.deltaTime;
        angle += angle_per_frame;

        while (angle.x >= 360)
        {
            angle.x -= 360;
        }

        if (idouzikann.x < 0.0f)
        {
            idouzikann.x = zikann.x;
        }

    }
    void Part_of_Y_Sin()
    {


        transform.position += new Vector3(0, idousokudo.y * sin3.y * Time.deltaTime, 0);
        idouzikann.y -= Time.deltaTime;
        angle += angle_per_frame;

        while (angle.y >= 360)
        {
            angle.y -= 360;
        }

        if (idouzikann.y < 0.0f)
        {
            idouzikann.y = zikann.y;
        }

    }
    void Part_of_Z_Sin()
    {
        transform.position += new Vector3(0, 0, idousokudo.z * sin3.z * Time.deltaTime);
        idouzikann.z -= Time.deltaTime;
        angle += angle_per_frame;

        while (angle.z >= 360)
        {
            angle.z -= 360;
        }
        if (idouzikann.z < 0.0f)
        {
            idouzikann.z = zikann.z;
        }
    }
}


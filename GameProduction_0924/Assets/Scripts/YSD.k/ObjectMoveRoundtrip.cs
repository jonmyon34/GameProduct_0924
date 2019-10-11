using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//往復ムーブ

public class ObjectMoveRoundtrip : MonoBehaviour
{
    //public float time;
    public float angle = 0.0f;
    public float angle_rise = 1.0f;//1往復までにかかる時間//大きくすれば
    public float speed = 1.0f;
    public Vector3 direction = Vector3.right;
    //private Vector3 defaultPos;

    // Use this for initialization
    void Start()
    {
        //defaultPos = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        //フレーム当たりの移動量を算出してから移動させる

        Vector3 n_dire = direction.normalized;
        angle += angle_rise * Time.deltaTime;
        while (angle >= 360)
        {
            angle -= 360;
        }

        float sin;
        sin = Mathf.Sin(angle * Mathf.Deg2Rad);
        sin = Mathf.Max(sin, -0.3f);
        sin = Mathf.Min(sin, 0.3f);




        Vector3 move_amount;//= new Vector3(defaultPos.x, defaultPos.y + Mathf.PingPong(Time.time, 2), defaultPos.z);
        move_amount = new Vector3(
            n_dire.x * speed * sin * Time.deltaTime,
            n_dire.y * speed * sin * Time.deltaTime,
            n_dire.z * speed * sin * Time.deltaTime);
        transform.position += move_amount;
    }
}

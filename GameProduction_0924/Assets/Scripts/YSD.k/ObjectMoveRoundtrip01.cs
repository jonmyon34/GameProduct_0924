using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectMoveRoundtrip01 : MonoBehaviour
{
    public float speed = 10.0f;//最高速度
    public float move_width = 100.0f;//移動幅
    public Vector3 direction = Vector3.right;//移動方向
    public float curve_time = 1.0f;//加速減速にかける時間

    private uint state = 0;
    private Vector3 default_position;//オブジェクト生成時点の初期位置
    private Vector3 start_position;//ステート変更時の位置
    private float start_angle = 0.0f;
    private float speed_origin = 0.0f;
    private float sine_angle = 0.0f;
    //あとで消す
    public float output_angle;//今の角度(degree角)
    public float output_sin;

    private const int RUN = 0;
    private const int SINE = 1;


    // Use this for initialization
    void Start()
    {
        default_position = transform.position;
        speed_origin = speed;
    }

    // Update is called once per frame
    void Update()
    {

        if (state == RUN)
        {
            Move_05();
        }
        if (state == SINE)
        {
            Move_01();
        }
        output_angle = sine_angle;

        transform.position += default_position + direction * speed;

    }

    void ChangeState(int next_state)
    {
        if (next_state == SINE)
        {
            while (sine_angle >= 360)
            {
                sine_angle -= 360;
            }

            start_angle = sine_angle;
            state = SINE;
        }
        else if (next_state == RUN)
        {
            start_position = transform.position;
            state = RUN;
        }
    }

    void Move_01()//90度分動くまで回し続ける
    {
        float sin = output_sin = Mathf.Sin(sine_angle * Mathf.Deg2Rad);
        sine_angle += (90 / curve_time) * Time.deltaTime;

        speed *= sin;



        if (sine_angle > start_angle + 90)
        {
            ChangeState(RUN);
        }
        // transform.position = default_position + (direction * speed * sin) / 4 ;
    }

    void Move_02()//1 to 0
    {

    }

    void Move_03()//0 to -1
    {

    }

    void Move_04()//-1 to 0
    {

    }

    void Move_05()//keep 1 or -1
    {
        //move_width分移動するまで移動し続ける
        //毎秒speedだけ移動する

        if (Vector3.Distance(start_position, transform.position) > move_width)
        {
            ChangeState(SINE);
        }


    }
}

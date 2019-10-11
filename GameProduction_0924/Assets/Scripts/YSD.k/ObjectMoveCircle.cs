using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectMoveCircle : MonoBehaviour
{

    public float sec_per_lap = 3.0f;
    public float radius = 3.0f;
    public float angle = 0;

    private Vector3 defaultposition;
    


    // Use this for initialization
    void Start()
    {
        defaultposition = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        while (angle >= 360) { angle -= 360; }
        while (angle < 0) { angle += 360; }
        if (sec_per_lap == 0.0f) { sec_per_lap = 0.1f; }
        transform.position = defaultposition;
        transform.position += new Vector3(Mathf.Sin(angle * Mathf.Deg2Rad) * radius, Mathf.Cos(angle * Mathf.Deg2Rad) * radius, 0); 


        angle += (360.0f / sec_per_lap) * Time.deltaTime;
    }
}

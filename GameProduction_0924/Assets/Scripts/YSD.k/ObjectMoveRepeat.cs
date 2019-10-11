using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectMoveRepeat : MonoBehaviour
{

    public float speed = 2.0f;
    public float max_life = 3.0f;
    public Vector3 direction = new Vector3(1, 0, 0);

    private Vector3 defaultposition;


    public float lifetime;
    // Use this for initialization
    void Start()
    {
        direction = Vector3.Normalize(direction);
        defaultposition = transform.position;
        lifetime = max_life;
    }

    // Update is called once per frame
    void Update()
    {
        if (lifetime <= 0.0f)
        {
            transform.position = defaultposition;
            lifetime = max_life;
        }

        transform.position += direction * speed * Time.deltaTime;



        lifetime -= Time.deltaTime;
    }
}

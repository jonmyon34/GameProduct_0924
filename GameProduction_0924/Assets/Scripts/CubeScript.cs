using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeScript : MonoBehaviour
{
    public GameObject particle;
    public Vector3 vec;
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        vec = new Vector3(gameObject.GetComponent<Transform>().position.x, gameObject.GetComponent<Transform>().position.y, gameObject.GetComponent<Transform>().position.z);
		if (vec.y < 0) {
			Instantiate(particle,vec,Quaternion.identity);
			//第三引数書いたら通った　謎
			Destroy(this.gameObject);
		}
    }

    void OnCollisionEnter(Collision collision)
    {
        Instantiate(particle,vec,Quaternion.identity);
        //第三引数書いたら通った　謎
        Destroy(this.gameObject);
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetYSD : MonoBehaviour
{

    private bool hitflg = false;

    private ParticleSystem myParticle;

    private Rigidbody myRigidbody;

    const float DESTROY_TIME = 10.0f;   //second
    private float duration;
    

    // Use this for initialization
    void Start()
    {
        //パーティクルを取得して
        myParticle = this.GetComponent<ParticleSystem>();
        myParticle.Stop();
        //即座に停止させる

        myRigidbody = this.GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        if (hitflg == true)
        {
            //パーティクルを出す


            //射貫いた方向に吹っ飛ばす
            
            //IsKinematic -> false
            myRigidbody.isKinematic = true;

            //IsKinematic==true の場合は mover を回す///////////////////////////////////////////////////
            
            //UseGravity -> true
            myRigidbody.useGravity = true;

            //collider.enable -> false
            this.GetComponent<MeshCollider>().enabled = false;
            

            //DestroyTimer();

        }
    }

    void OnTriggerEnter(Collider collider)
    {
        if (collider.tag == "projectile")
        {
            hitflg = true;
            /*
             * 矢の velocity を加算
             */
            Vector3 velocity = collider.GetComponent<Rigidbody>().velocity;
            GetComponent<Rigidbody>().AddForce(velocity, ForceMode.Impulse);//矢の速度分だけ、力を加える
            //処理の順番次第ではここにisKinematicの無効化書いた方がいいかもしれない


            //パーティクルを出す
            myParticle.Play();
        }
    }

    void DestroyTimer()
    {
        duration += Time.deltaTime;
        if(duration >= DESTROY_TIME)
            Destroy(this.gameObject);
    }
}

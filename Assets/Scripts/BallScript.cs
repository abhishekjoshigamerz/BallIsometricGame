using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallScript : MonoBehaviour
{
    public Rigidbody2D rbg;
    public CircleCollider2D col;

    public Vector3 BallPos{
        get {return transform.position;}
    }
    

    void Awake(){
        rbg = GetComponent<Rigidbody2D>();
        col = GetComponent<CircleCollider2D>();
    }

    public void PushBall(Vector2 force){
        rbg.AddForce(force,ForceMode2D.Impulse);
    }
    //to enable rigidbody so we can use projectile again
    public void ActivateRb(){
        rbg.isKinematic = false;
    }
    public void DeActivateRb(){
        rbg.velocity = Vector3.zero;
        rbg.angularVelocity = 0f;
        rbg.isKinematic = true;
    }

    
}

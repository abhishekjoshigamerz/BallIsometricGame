using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManagerScript : MonoBehaviour
{
    // using singleton pattern 
    Camera cam;
    public BallScript ball;
    public Trajectory trajectory;
    public static GameManagerScript Instance;
    void Awake(){
        if(Instance==null){
            Instance = this;
        }
    }

    
    [SerializeField] float pushForce = 4f;
    bool isDragging = false;

    Vector2 startPoint;
    Vector2 endPoint;
    Vector2 direction;
     Vector2 force;
    float distance;


    void Start(){
        cam = Camera.main;
        ball.DeActivateRb();
    }

    void Update(){
        if(Input.GetMouseButtonDown(0)){
            isDragging = true;
            OnDragStart();
        }
        if(Input.GetMouseButtonUp(0)){
            isDragging = false;
            OnDragEnd();
        }
        if(isDragging){
            OnDrag();
        }
    }

    void OnDragStart(){
        ball.DeActivateRb();
        startPoint = cam.ScreenToWorldPoint(Input.mousePosition);
        trajectory.Show();
    }

    void OnDrag(){
        endPoint = cam.ScreenToWorldPoint(Input.mousePosition);
        distance = Vector2.Distance(startPoint,endPoint);
        direction = (endPoint-startPoint).normalized;
        force = direction* distance * pushForce;

        trajectory.UpdateDots(ball.BallPos,force);
        
    }

    void OnDragEnd(){
        ball.ActivateRb();
        ball.PushBall(force);
        trajectory.Hide();
    }
}

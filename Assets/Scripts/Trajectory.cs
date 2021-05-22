using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trajectory : MonoBehaviour
{
    [SerializeField] int dotsNumbers;
    [SerializeField] GameObject dotsParent;
    
    [SerializeField] GameObject DotsPrefab;
    [SerializeField] float dotSpacing;
    Vector2 pos;
    float timeStamp;
    Transform[] dotsList;

    void Start(){
        //hide trajectory in the start
        Hide();

        PrepareDots();
    }

    void PrepareDots(){
        dotsList = new Transform[dotsNumbers];
        for(int i=0;i<dotsNumbers;i++){
            dotsList[i] = Instantiate(DotsPrefab,null).transform;
            dotsList[i].parent = dotsParent.transform;
        }
    }
    public void UpdateDots(Vector3 ballPos,Vector2 forceApplied){
        timeStamp = dotSpacing;
        for(int i=0;i<dotsNumbers;i++){
            pos.x = (ballPos.x + forceApplied.x * timeStamp);
            pos.y = (ballPos.y + forceApplied.y * timeStamp)-(Physics2D.gravity.magnitude * timeStamp * timeStamp)/2f;
            dotsList[i].position = pos;
            timeStamp += dotSpacing;
        }
    }


    public void Show(){
        dotsParent.SetActive(true);
    }
    public void Hide(){
        dotsParent.SetActive(false);
    }
}

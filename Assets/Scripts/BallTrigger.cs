using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallTrigger : MonoBehaviour
{
    void OnTriggerEnter(Collider ball)
    {
        if(ball.gameObject.tag == "Ball")
        {
            GetComponentInParent<ShotMechanics> ().ball = true;
        }
    }
    void OnTriggerStay(Collider ball)
    {
        if(ball.gameObject.tag == "Ball")
        {
            GetComponentInParent<ShotMechanics> ().ball = true;
        }
    }
    void OnTriggerExit(Collider ball)
    {
        if(ball.gameObject.tag == "Ball")
        {
            GetComponentInParent<ShotMechanics> ().ball = false;
        }
    }
}

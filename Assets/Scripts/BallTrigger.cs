using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallTrigger : MonoBehaviour
{
     // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnTriggerEnter(Collider ball)
    {
        if(ball.gameObject.tag == "Ball")
        {
            transform.root.gameObject.GetComponent<Character> ().ball = true;
        }
    }
    void OnTriggerStay(Collider ball)
    {
        if(ball.gameObject.tag == "Ball")
        {
            transform.root.gameObject.GetComponent<Character> ().ball = true;
        }
    }
    void OnTriggerExit(Collider ball)
    {
        if(ball.gameObject.tag == "Ball")
        {
            transform.root.gameObject.GetComponent<Character> ().ball = false    ;
        }
    }

}

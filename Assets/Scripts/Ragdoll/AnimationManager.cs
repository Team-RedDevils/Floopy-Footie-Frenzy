using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationManager : MonoBehaviour
{
    [SerializeField]
    private Animator animator;
    [SerializeField]
    private PlayerInput playerInput;
    // Start is called before the first frame update
    void Start()
    {
       animator = GetComponent<Animator>(); 
    }

    // Update is called once per frame
    void Update()
    {
        SetAnim();
        
    }
    void SetAnim(){
        if(playerInput._vertical == 0 && playerInput._horizontal == 0){
            animator.SetBool("walking",false);
        }
        else{
            animator.SetBool("walking",true);
        }
    }
}

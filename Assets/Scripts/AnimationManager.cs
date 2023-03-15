using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationManager : MonoBehaviour
{
    [SerializeField]
    private Transform targetLimb;

    private ConfigurableJoint cj;
    // Start is called before the first frame update
    void Start()
    {
        cj = GetComponent<ConfigurableJoint>();
    }

    // Update is called once per frame
    void Update()
    {
        cj.targetRotation = targetLimb.rotation;
    }
}

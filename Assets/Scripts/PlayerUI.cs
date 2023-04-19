using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PlayerUI : MonoBehaviour
{
    [SerializeField]
    private RagdollMovement rm;
    [SerializeField]
    private TMP_Text staminaText;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        staminaText.text =  "Stamina : " + rm.GetStamina().ToString();
        
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisableJumping : MonoBehaviour
{
    private static float normalJumpHeight = 0f;
    // Start is called before the first frame update
    void Start()
    {
        CharacterControls characterControls = this.gameObject.GetComponent<CharacterControls>();
        normalJumpHeight = characterControls.jumpHeight;
    }

    // Update is called once per frame
    void Update()
    {
        PowerUpTags powerUpTags = this.gameObject.GetComponent<PowerUpTags>();
        CharacterControls characterControls = this.gameObject.GetComponent<CharacterControls>();
        if (powerUpTags.HasTag("Water"))
        {
            characterControls.jumpHeight = 0;
        } else
        {
            characterControls.jumpHeight = normalJumpHeight;
        }
    }
}

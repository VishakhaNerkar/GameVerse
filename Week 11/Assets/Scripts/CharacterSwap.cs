using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class CharacterSwap : MonoBehaviour
{
    public Transform character;
    public List<Transform> possibleCharacters;
    public int whichCharacter = 0;
    private float originalSpeed = 0f;
    private float originalRotateSpeed = 0f;

    private float lastSwitchTime;
    private string lastActivePlayer;
    public int swapCount = 0;
    // Start is called before the first frame update

    public Analytics analytics;

    void Start()
    {
        if(character == null && possibleCharacters.Count >= 1)
        {
            analytics = this.gameObject.GetComponent<Analytics>();
            character = possibleCharacters[0];
            lastActivePlayer = character.gameObject.name;
            lastSwitchTime = 0.0f;
            originalSpeed = character.GetComponent<TopDownCharacterMover>().moveSpeed;
            originalRotateSpeed = character.GetComponent<TopDownCharacterMover>().rotateSpeed;
        }
        Swap();
    }

    // Update is called once per frame
    void Update()
    {

        if(Input.GetKeyDown(KeyCode.Space))
        {
            if(whichCharacter == possibleCharacters.Count - 1) 
            {
                whichCharacter = 0;
            } 
            else
            {
                whichCharacter += 1;
            }
            Swap();
        }

    }

    public void Swap()
    {
        character = possibleCharacters[whichCharacter];

        character.GetComponent<TopDownCharacterMover>().moveSpeed = originalSpeed;
        character.GetComponent<TopDownCharacterMover>().rotateSpeed = originalRotateSpeed;
        Rigidbody char_rigidbody = character.GetComponent<Rigidbody>();
        char_rigidbody.constraints = RigidbodyConstraints.None;
        char_rigidbody.constraints = RigidbodyConstraints.FreezeRotation;
        
        character.Find("Pointer").gameObject.SetActive(true);

        for (int i=0; i<possibleCharacters.Count; i++)
        {
            if (possibleCharacters[i] != character)
            {
                possibleCharacters[i].GetComponent<TopDownCharacterMover>().moveSpeed = 0f;
                possibleCharacters[i].GetComponent<TopDownCharacterMover>().rotateSpeed = 0f;
                possibleCharacters[i].Find("Pointer").gameObject.SetActive(false);
                Rigidbody possibleChar_rigidbody = possibleCharacters[i].GetComponent<Rigidbody>();
                possibleChar_rigidbody.constraints =  RigidbodyConstraints.FreezeAll;
            }
        }

        if(swapCount > 0){
            UpdateSwapInfo();
        } 

        swapCount += 1;

    }

    public void UpdateSwapInfo() {
        float newSwitchTime = gameObject.GetComponent<Timer>().timeTaken;
        lastActivePlayer = lastActivePlayer.Replace("Player ","P");
        analytics.PlayersActiveTime(lastActivePlayer, newSwitchTime - lastSwitchTime);
        lastActivePlayer = character.gameObject.name;
        lastSwitchTime = newSwitchTime;

    }
}

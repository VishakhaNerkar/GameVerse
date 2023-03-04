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

    // Start is called before the first frame update
    void Start()
    {
        if(character == null && possibleCharacters.Count >= 1)
        {
            character = possibleCharacters[0];
            originalSpeed = character.GetComponent<TopDownCharacterMover>().moveSpeed;
            originalRotateSpeed = character.GetComponent<TopDownCharacterMover>().rotateSpeed;
        }
        Swap();
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Q))
        {
            if(whichCharacter == 0)
            {
                whichCharacter = possibleCharacters.Count - 1;
            } 
            else 
            {
                whichCharacter -= 1;
            }
            Swap();
        }

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
        character.Find("Pointer").gameObject.SetActive(true);

        for (int i=0; i<possibleCharacters.Count; i++)
        {
            if (possibleCharacters[i] != character)
            {
                possibleCharacters[i].GetComponent<TopDownCharacterMover>().moveSpeed = 0f;
                possibleCharacters[i].GetComponent<TopDownCharacterMover>().rotateSpeed = 0f;
                possibleCharacters[i].Find("Pointer").gameObject.SetActive(false);
            }
        }


    }
}

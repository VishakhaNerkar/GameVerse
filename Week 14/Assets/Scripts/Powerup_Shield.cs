using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Powerup_Shield : MonoBehaviour
{
    // Start is called before the first frame update
    public Image powerupFillImg;
    public float currentPowerupTime;
    public float maxPowerupTime = 30.0f;
    public bool isPressed = false;
    public int powerupCost = 10;
    public Transform activeCharacter;

    void Start()
    {
        currentPowerupTime = 0.0f;
        powerupFillImg.fillAmount = currentPowerupTime;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1) && isPressed == false)
            {
                currentPowerupTime = maxPowerupTime;
                GameObject gameManager = GameObject.Find("GameManager");
                int currentMana = gameManager.GetComponent<Mana>().currentMana;
                if(currentMana - powerupCost < 0) {
                    return;
                }
                
                gameManager.GetComponent<Mana>().reduceMana(powerupCost);

                activeCharacter = gameManager.GetComponent<CharacterSwap>().activeCharacter;
                GameObject shield = activeCharacter.transform.Find("Shield").gameObject;
                shield.SetActive(true);
                isPressed = true;
            }
        
        if(isPressed == true) {
            if(currentPowerupTime <= 0) {
                currentPowerupTime = 0.0f;
                GameObject shield = activeCharacter.transform.Find("Shield").gameObject;
                shield.SetActive(false);
                isPressed = false;
            } else {
                currentPowerupTime -= Time.deltaTime;
                updatePowerupFillValue(maxPowerupTime, currentPowerupTime);
            }
        }
    }

    public void updatePowerupFillValue(float maxPowerupTime, float currentPowerupTime) {
        powerupFillImg.fillAmount = Mathf.InverseLerp(0, maxPowerupTime, currentPowerupTime);
    }

}

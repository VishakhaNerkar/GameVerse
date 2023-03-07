using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Analytics : MonoBehaviour
{

    public List<string> playerSwitchOrder;
    public List<float> playerActiveTimeOrder;
    // Update is called once per frame
    void Update()
    {

    }

    public void PlayersActiveTime(string playerName, float activeTime) {
        playerActiveTimeOrder.Add(activeTime);
        playerSwitchOrder.Add(playerName);
    }

    public void SendAnalytics() {
        for(int i=0; i<playerSwitchOrder.Count; i++){
            print(playerSwitchOrder[i].ToString() + " : " + playerActiveTimeOrder[i].ToString());
        }

    }
}

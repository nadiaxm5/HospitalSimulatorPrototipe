using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class PlayerData
{
    public float[] position; //Vector3 no funcionaria 
    public float chaos;

    public PlayerData(PlayerInfo player, BarManager chaosBar)
    {
        position = new float[3];
        position[0] = player.transform.position.x;
        position[1] = player.transform.position.y;
        position[2] = player.transform.position.z;
        chaos = chaosBar.getChaosValue();
    }
}

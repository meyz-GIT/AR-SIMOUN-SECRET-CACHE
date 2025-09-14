using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class Memory : MonoBehaviour
{
    private void Start()
    {
        /*PlayerData playerData = new PlayerData();
        playerData.level = 0;

        string json = JsonUtility.ToJson(playerData);
        Debug.Log(json);

        File.WriteAllText(Application.dataPath + "/PlayerData.json", json);
        */

        string json = File.ReadAllText(Application.dataPath + "/PlayerData.json");
        PlayerData loadedPlayerData = JsonUtility.FromJson<PlayerData>(json);
        Debug.Log(loadedPlayerData.level);


    }
    

    private class PlayerData
    {
        public int level;
    }
}

using System.Collections;
using System.Collections.Generic;
using System.IO;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UnlockedLevels : MonoBehaviour
{
    public TextMeshProUGUI two, three, four, five, six, seven, eight, nine, ten;
    public Image lock2, lock3, lock4, lock5, lock6, lock7, lock8, lock9, lock10;
    

    /*[System.Serializable]
    public class PlayerData
    {
        public int level;
    }
    */

    void Start()
    {
        /*//read file
        string jsonfile = File.ReadAllText(Application.dataPath + "/PlayerData.json");
        PlayerData loadedPlayerData = JsonUtility.FromJson<PlayerData>(jsonfile);
        Debug.Log(loadedPlayerData.level);
        
        //lock levels
        int level = loadedPlayerData.level;
        */

        /*TextAsset jsonTextAsset = Resources.Load<TextAsset>("PlayerData");

        if (jsonTextAsset == null)
        {
            Debug.LogError("PlayerData.json not found in Resources folder.");
            return;
        }

        // 2. Get the raw JSON string
        string jsonData = jsonTextAsset.text;

        // 3. Deserialize the JSON string into a PlayerData object
        PlayerData data = JsonUtility.FromJson<PlayerData>(jsonData);
        */
        if (LevelManager.Instance == null)
        {
            Debug.Log("Waiting for LevelManager...");
            return;
        }

        int level = LevelManager.Instance.getCurrentLevel();

        if (level < 2)
        {
            two.gameObject.SetActive(false);
            lock2.gameObject.SetActive(true);
            three.gameObject.SetActive(false);
            lock3.gameObject.SetActive(true);
            four.gameObject.SetActive(false);
            lock4.gameObject.SetActive(true);
            five.gameObject.SetActive(false);
            lock5.gameObject.SetActive(true);
            six.gameObject.SetActive(false);
            lock6.gameObject.SetActive(true);
            seven.gameObject.SetActive(false);
            lock7.gameObject.SetActive(true);
            eight.gameObject.SetActive(false);
            lock8.gameObject.SetActive(true);
            nine.gameObject.SetActive(false);
            lock9.gameObject.SetActive(true);
            ten.gameObject.SetActive(false);
            lock10.gameObject.SetActive(true);
        }
        else if (level == 2)
        {
            three.gameObject.SetActive(false);
            lock3.gameObject.SetActive(true);
            four.gameObject.SetActive(false);
            lock4.gameObject.SetActive(true);
            five.gameObject.SetActive(false);
            lock5.gameObject.SetActive(true);
            six.gameObject.SetActive(false);
            lock6.gameObject.SetActive(true);
            seven.gameObject.SetActive(false);
            lock7.gameObject.SetActive(true);
            eight.gameObject.SetActive(false);
            lock8.gameObject.SetActive(true);
            nine.gameObject.SetActive(false);
            lock9.gameObject.SetActive(true);
            ten.gameObject.SetActive(false);
            lock10.gameObject.SetActive(true);
        }else if (level == 3)
        {
            four.gameObject.SetActive(false);
            lock4.gameObject.SetActive(true);
            five.gameObject.SetActive(false);
            lock5.gameObject.SetActive(true);
            six.gameObject.SetActive(false);
            lock6.gameObject.SetActive(true);
            seven.gameObject.SetActive(false);
            lock7.gameObject.SetActive(true);
            eight.gameObject.SetActive(false);
            lock8.gameObject.SetActive(true);
            nine.gameObject.SetActive(false);
            lock9.gameObject.SetActive(true);
            ten.gameObject.SetActive(false);
            lock10.gameObject.SetActive(true);
        }
        else if (level == 4)
        {
            five.gameObject.SetActive(false);
            lock5.gameObject.SetActive(true);
            six.gameObject.SetActive(false);
            lock6.gameObject.SetActive(true);
            seven.gameObject.SetActive(false);
            lock7.gameObject.SetActive(true);
            eight.gameObject.SetActive(false);
            lock8.gameObject.SetActive(true);
            nine.gameObject.SetActive(false);
            lock9.gameObject.SetActive(true);
            ten.gameObject.SetActive(false);
            lock10.gameObject.SetActive(true);
        }
        else if (level == 5)
        {
            six.gameObject.SetActive(false);
            lock6.gameObject.SetActive(true);
            seven.gameObject.SetActive(false);
            lock7.gameObject.SetActive(true);
            eight.gameObject.SetActive(false);
            lock8.gameObject.SetActive(true);
            nine.gameObject.SetActive(false);
            lock9.gameObject.SetActive(true);
            ten.gameObject.SetActive(false);
            lock10.gameObject.SetActive(true);
        }
        else if (level == 6)
        {
            seven.gameObject.SetActive(false);
            lock7.gameObject.SetActive(true);
            eight.gameObject.SetActive(false);
            lock8.gameObject.SetActive(true);
            nine.gameObject.SetActive(false);
            lock9.gameObject.SetActive(true);
            ten.gameObject.SetActive(false);
            lock10.gameObject.SetActive(true);
        }
        else if (level == 7)
        {
            eight.gameObject.SetActive(false);
            lock8.gameObject.SetActive(true);
            nine.gameObject.SetActive(false);
            lock9.gameObject.SetActive(true);
            ten.gameObject.SetActive(false);
            lock10.gameObject.SetActive(true);
        }
        else if (level == 8)
        {
            nine.gameObject.SetActive(false);
            lock9.gameObject.SetActive(true);
            ten.gameObject.SetActive(false);
            lock10.gameObject.SetActive(true);
        }
        else if(level == 9)
        {
            ten.gameObject.SetActive(false);
            lock10.gameObject.SetActive(true);

        }
    }

    

    
}

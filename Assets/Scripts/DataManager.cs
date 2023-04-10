using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using UnityEngine.Events;
using System;

public class DataManager : MonoBehaviour
{
    public static DataManager instance;

    public UnityEvent onScoreBeated;

    public string userName;
    public string bestUserName;

    public int points;
    public int bestPoints;

    void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else Destroy(gameObject);
    }

    [Serializable]
    class Data
    {
        public string userName;
        public int points;
    }

    public void SaveData()
    {
        if (points > bestPoints)
        {
            Data data = new Data();
            data.userName = userName;
            data.points = points;

            string jsonData = JsonUtility.ToJson(data);
            File.WriteAllText(Application.persistentDataPath + "/savedata.json", jsonData);

            onScoreBeated.Invoke();
        }
    }

    public void LoadData() 
    {
        string path = Application.persistentDataPath + "/savedata.json";
        if (File.Exists(path))
        {
            string jsonData = File.ReadAllText(path);
            Data data = JsonUtility.FromJson<Data>(jsonData);

            bestUserName = data.userName;
            bestPoints = data.points;
        }
    }
}

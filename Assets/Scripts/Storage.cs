using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class Storage : MonoBehaviour
{
    public static Storage Instance;
    public string userName;
    public string bestUserName;
    public int bestScore;
    // Start is called before the first frame update
    private void Awake()
    {
        if (Instance != null)
        {
            Destroy(gameObject);
            return;
        }
        Instance = this;
        DontDestroyOnLoad(gameObject);
        LoadRecord();
    }

    public void SaveRecord()
    {
        Record data = new Record();
        data.userName = userName;
        data.bestUserName = bestUserName;
        data.bestScore = bestScore;
        string json = JsonUtility.ToJson(data);
        Debug.Log("save:" + json);
        File.WriteAllText(Application.persistentDataPath + "/savefile.json", json);
    }

    public void LoadRecord()
    {
        string path = Application.persistentDataPath + "/savefile.json";
        if (File.Exists(path))
        {
            string json = File.ReadAllText(path);
            Debug.Log("load:" + json);
            Record data = JsonUtility.FromJson<Record>(json);
            userName = data.userName;
            bestUserName = data.bestUserName;
            bestScore = data.bestScore;
        }
    }

    public void ChangeUserName(string value)
    {
        userName = value;
        SaveRecord();
    }
}

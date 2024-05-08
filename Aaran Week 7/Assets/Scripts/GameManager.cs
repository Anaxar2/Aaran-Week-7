using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class GameManager : MonoBehaviour
{
   public static GameManager Instance {get; private set;}

    public Color unitColor;

    private void Awake()
    {
      if(Instance != null)
        {
            Destroy(gameObject);
        }
      Instance = this;
      DontDestroyOnLoad(gameObject);

        LoadColor();

    }
    [System.Serializable]
    class SaveData
    {
        public Color unitColor;
    }
    public void SaveColor()
    {
        SaveData data = new SaveData();
        data.unitColor = unitColor;

        string json = JsonUtility.ToJson(data);

        File.WriteAllText(Application.persistentDataPath + "/savefile.json", json);
    }

    public void LoadColor()
    {
        string path = Application.persistentDataPath + "/savefile.json";
        if(File.Exists(path))
        {
            string json = File.ReadAllText(path);
            SaveData data = JsonUtility.FromJson<SaveData>(json);
            unitColor = data.unitColor;
        }
       
    }
}

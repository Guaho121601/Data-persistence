using UnityEngine;
using UnityEngine.UI;
using System.IO;

public class InstanceManager : MonoBehaviour
{
    public static InstanceManager Instance;
    public string _name;
    public int maxPoint;  

    private void Awake()
    {
        if (Instance!= null)
        {
            Destroy(gameObject);
            return;
        }
        Instance = this;
        DontDestroyOnLoad(gameObject);
    }

    [System.Serializable]
    class SaveData
    {
        public string input;
        public int points; 
    }

    public void SaveName(string name, int x)
    {
        SaveData data = new SaveData();
        data.input = name;
        data.points = x; 

        string json = JsonUtility.ToJson(data);
        File.WriteAllText(Application.persistentDataPath + "/savedata.json", json);
    }

    public string LoadName()
    {
        string path = Application.persistentDataPath + "/savedata.json";

        if (File.Exists(path))
        {
            string json = File.ReadAllText(path);

            SaveData data = JsonUtility.FromJson<SaveData>(json);
            return data.input;

        }
        else return null; 
        
    }

    public int LoadMaxPoint()
    {
        string path = Application.persistentDataPath + "/savedata.json";

        if (File.Exists(path))
        {
            string json = File.ReadAllText(path);

            SaveData data = JsonUtility.FromJson<SaveData>(json);
            return data.points;

        }
        else return 0;

    }
}

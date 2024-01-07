using UnityEngine;
using System.IO;

public class MainManager1 : MonoBehaviour
{
    public static MainManager1 Instance;

    public string _name;
    public int _score;
    
    private void Awake()
    {
        if (Instance != null)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;
        DontDestroyOnLoad(gameObject);

        LoadData();
    }


    [System.Serializable]
    class SaveData_CS
    {
        public string _name;
        public int _score;
    }

    public void SaveData()
    {
        SaveData_CS data = new SaveData_CS();
        data._name = _name;
        data._score = _score;

        string json = JsonUtility.ToJson(data);

        File.WriteAllText(Application.persistentDataPath + "/savefile.json", json);
    }

    public void LoadData()
    {
        string path = Application.persistentDataPath + "/savefile.json";
        if (File.Exists(path))
        {
            string json = File.ReadAllText(path);
            SaveData_CS data = JsonUtility.FromJson<SaveData_CS>(json);

            _name = data._name;
            _score = data._score;
        }
    }
}

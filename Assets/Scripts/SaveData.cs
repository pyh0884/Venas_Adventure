using System.IO;
using UnityEngine;
using System.Runtime.Serialization.Formatters.Binary;
public static class SaveData
{
    public static void saveHp(HealthBarControl health)
    {
        BinaryFormatter formatter = new BinaryFormatter();
        string path = Application.persistentDataPath + "/hp.binary";
        FileStream stream = new FileStream(path, FileMode.Create);

        SavedData data = new SavedData(health);
        formatter.Serialize(stream, data);
        stream.Close();
    }

    public static SavedData loadHp()
    {
        string path = Application.persistentDataPath + "/hp.binary";
        if (File.Exists(path))
        {
            BinaryFormatter formatter = new BinaryFormatter();
            FileStream stream = new FileStream(path, FileMode.Open);
            SavedData hp= formatter.Deserialize(stream) as SavedData;
            stream.Close();
            return hp;
        }
        else
        {
            Debug.Log("save data not found "+path);
            return null;
        }
    }
}

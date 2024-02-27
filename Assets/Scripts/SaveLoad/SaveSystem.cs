using UnityEngine;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

//info: https://www.youtube.com/watch?v=XOjd_qU2Ido
public static class SaveSystem 
{
    public static void SavePlayer(PlayerInfo player)
    {
        BinaryFormatter formatter = new();

        string path = Application.persistentDataPath + "/player.sav";
        FileStream stream = new(path, FileMode.Create);

        PlayerData data = new(player);

        formatter.Serialize(stream, data);
        stream.Close();
    }

    public static PlayerData LoadPlayer()
    {
        string path = Application.persistentDataPath + "/player.sav";
        if (File.Exists(path))
        {
            BinaryFormatter formatter = new();
            FileStream stream = new(path, FileMode.Open);

            PlayerData data = formatter.Deserialize(stream) as PlayerData;
            stream.Close();

            return data;
        }
        else
        {
            Debug.LogError("Save file not found: " + path);
            return null;
        }
    }
}

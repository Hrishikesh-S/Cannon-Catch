using UnityEngine;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

public static class SaveSystem
{
    public static void SavePlayer(Score player)
    {
        BinaryFormatter binaryFormatter = new BinaryFormatter();
        string filePath = Path.Combine(Application.persistentDataPath, "Player.save");
        FileStream fileStream = new FileStream(filePath, FileMode.Create);

        PlayerData playerData = new PlayerData(player);
        binaryFormatter.Serialize(fileStream, playerData);
        fileStream.Close();
    }

    public static PlayerData LoadPlayer()
    {
        string filePath = Path.Combine(Application.persistentDataPath, "Player.save");
        if (File.Exists(filePath))
        {
            BinaryFormatter binaryFormatter = new BinaryFormatter();
            FileStream fileStream = new FileStream(filePath, FileMode.Open);

            PlayerData playerData = binaryFormatter.Deserialize(fileStream) as PlayerData;
            fileStream.Close();

            return playerData;
        }
        else
        {
            UnityEngine.Debug.LogError("File not found");
            return null;
        }
    }
}
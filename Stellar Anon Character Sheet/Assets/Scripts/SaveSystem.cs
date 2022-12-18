using UnityEngine;
using System.IO;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.Serialization.Formatters.Binary;

public class SaveSystem
{
    // save the character data \\
    public static void SaveCharacterData(CharacterDataManager cDM) {
        BinaryFormatter formatter = new BinaryFormatter();
        string path = Application.persistentDataPath + "/characterData.txt";
        FileStream stream = new FileStream(path, FileMode.Create);

        CharacterData data = new CharacterData(cDM);

        formatter.Serialize(stream, data);
        stream.Close();
    }

    public static void SaveCharacterData(List<Character> charList) {
        BinaryFormatter formatter = new BinaryFormatter();
        string path = Application.persistentDataPath + "/characterData.txt";
        FileStream stream = new FileStream(path, FileMode.Create);

        CharacterData data = new CharacterData(charList);

        formatter.Serialize(stream, data);
        stream.Close();
    }

    // load the character data \\
    public static CharacterData LoadCharacterData() {
        string path = Application.persistentDataPath + "/characterData.txt";

        if (File.Exists(path)) {
            BinaryFormatter formatter = new BinaryFormatter();
            FileStream stream = new FileStream(path, FileMode.Open);

            CharacterData data = formatter.Deserialize(stream) as CharacterData;
            stream.Close();

            return data;
        }
        else {
            Debug.LogError("Save File not found in " + path);
            return null;
        }
    }

    // deletes data
    public static void DeleteData() {
        string characterDataPath = Application.persistentDataPath + "/characterData.txt";

        // delete the character data
        if (File.Exists(characterDataPath)) {
            File.Delete(characterDataPath);
        }
        else {
            Debug.LogError("File not found in " + characterDataPath);
        }
    }
}

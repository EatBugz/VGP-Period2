using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class CharacterData
{
    public List<Character> charList = new List<Character>();

    public CharacterData(CharacterDataManager cDM) {
        // list of characters
        for (int i = 0; i < cDM.characterList.Count; i++) {
            charList.Add(cDM.characterList[i]);
        }
    }

    public CharacterData(List<Character> list) { 
        for (int i = 0; i < list.Count; i++) {
            charList.Add(list[i]);
        }
    }
}
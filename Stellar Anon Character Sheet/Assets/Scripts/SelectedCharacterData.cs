using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class SelectedCharacterData
{
    public Character chara;
    public int charIndex;

    public SelectedCharacterData(Character c, int index) {
        this.chara = c;
        this.charIndex = index;
    }
}

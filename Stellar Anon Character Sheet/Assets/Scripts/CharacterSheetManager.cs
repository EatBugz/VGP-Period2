using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class CharacterSheetManager : MonoBehaviour
{
    private Character selectedCharacter;
    public int selectedCharacterIndex = -1;

    public TextMeshProUGUI nameTitleText;

    // Start is called before the first frame update
    void Start()
    {
        loadSelectedCharacter();
        updateSheet();
    }

    // update visuals
    public void updateSheet() {
        nameTitleText.text = ""+selectedCharacter.getName()+" | "+selectedCharacter.getSpeciesString()+" | "+selectedCharacter.getProfessionString()+" "+selectedCharacter.getLevel();
    }

    // methods that save an load the selected character
    public void saveSelectedCharacter() { SaveSystem.SaveSelectedCharacterData(selectedCharacter, selectedCharacterIndex); }
    public void loadSelectedCharacter() {
        SelectedCharacterData data = SaveSystem.LoadSelectedCharacterData();

        if (data != null) {
            selectedCharacter = data.chara;
            selectedCharacterIndex = data.charIndex;
        }
    }
}

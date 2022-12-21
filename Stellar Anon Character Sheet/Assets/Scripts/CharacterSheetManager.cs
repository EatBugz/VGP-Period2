using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class CharacterSheetManager : MonoBehaviour
{
    private Character selectedCharacter;
    public int selectedCharacterIndex = -1;

    [Header("Main Info Texts")]
    public TextMeshProUGUI nameTitleText;
    public TextMeshProUGUI movementText;
    public TextMeshProUGUI hitDieTypeText;
    public TextMeshProUGUI maxHitPointsText;
    public TextMeshProUGUI generalSkillText;
    public TextMeshProUGUI meleeSkillText;
    public TextMeshProUGUI firearmSkillText;
    public TextMeshProUGUI intelligenceSkillText;
    public TextMeshProUGUI dexteritySkillText;
    public TextMeshProUGUI generalDeterminationText;
    public TextMeshProUGUI determinationOfWillText;
    public TextMeshProUGUI determinationOfBodyText;
    public TextMeshProUGUI generalPowerText;
    public TextMeshProUGUI powerOfStrengthText;
    public TextMeshProUGUI powerOfCharismaText;
    public TextMeshProUGUI saveText;

    // Start is called before the first frame update
    void Start()
    {
        loadSelectedCharacter();
        updateSheet();
    }

    // update visuals
    public void updateSheet() {
        // update name
        nameTitleText.text = ""+selectedCharacter.getName()+" | "+selectedCharacter.getSpeciesString()+" | "+selectedCharacter.getProfessionString()+" "+selectedCharacter.getLevel();

        // show visuals
        movementText.text = ""+selectedCharacter.getMovement();
        hitDieTypeText.text = "d" + selectedCharacter.getHitDieType();
        maxHitPointsText.text = ""+selectedCharacter.getMaxHitPoints();
        generalSkillText.text = ""+selectedCharacter.getGeneralSkill();
        meleeSkillText.text = ""+selectedCharacter.getMeleeSkill();
        firearmSkillText.text = ""+selectedCharacter.getFirearmSkill();
        intelligenceSkillText.text = ""+selectedCharacter.getIntelligenceSkill();
        dexteritySkillText.text = ""+selectedCharacter.getDexteritySkill();
        generalDeterminationText.text = ""+selectedCharacter.getGeneralDetermination();
        determinationOfWillText.text = ""+selectedCharacter.getDeterminationOfWill();
        determinationOfBodyText.text = ""+selectedCharacter.getDeterminationOfBody();
        generalPowerText.text = ""+selectedCharacter.getGeneralPower();
        powerOfStrengthText.text = ""+selectedCharacter.getPowerOfStrength();
        powerOfCharismaText.text = ""+selectedCharacter.getPowerOfCharisma();
        saveText.text = ""+selectedCharacter.getSave();

        /* For later
        startingFeatureText.text = "Starting Feature: " + createdCharacter.getStartingFeature();
        weaponProfText.text = "Weapon Proficiencies: " + createdCharacter.getWeaponProfString();
        armorProfText.text = "Armor Proficiencies: " + createdCharacter.getArmorProfString();
        */
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

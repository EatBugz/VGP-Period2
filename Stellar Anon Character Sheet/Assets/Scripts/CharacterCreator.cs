using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.EventSystems;

public class CharacterCreator : MonoBehaviour
{
    private Character createdCharacter;

    // input fields
    [Header("Input Fields")]
    public GameObject nameInput;
    private TMP_InputField nameInputField;
    public GameObject speciesInput;
    private TMP_Dropdown speciesInputField;
    public GameObject classInput;
    private TMP_Dropdown classInputField;

    [Header("Stat Boxes")]
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
    public TextMeshProUGUI startingFeatureText;

    // user input saves
    [Header("User Input")]
    public string charName;
    public Character.SpeciesType charSpecies;
    public Character.ClassType charClass;
    
    // class bonuses
    [Header("Class Bonuses")]
    public int[] assaultBonuses = new int[14];
    public int[] scoutBonuses = new int[14];
    public int[] supportBonuses = new int[14];
    public int[] medicBonuses = new int[14];

    // get input fields
    void Start() {
        nameInputField = nameInput.GetComponent<TMP_InputField>();
        speciesInputField = speciesInput.GetComponent<TMP_Dropdown>();
        classInputField = classInput.GetComponent<TMP_Dropdown>();
    }

    // check which input field is selected so if the user presses enter
    // the proper input field 'get' method is called
    void Update() {
        if (Input.GetKeyDown(KeyCode.Return)) {
            if (EventSystem.current.currentSelectedGameObject == nameInput) getUserName();
        }
    }

    // method that saves the created character
    public void saveCharacter() {
        CharacterData data = SaveSystem.LoadCharacterData();

        if (data != null) {
            data.charList.Add(createdCharacter);
            SaveSystem.SaveCharacterData(data.charList);
        }
    }

    // method that updates the character when user inputs their desired choice
    public void updateCharacter() {
        if (charName != ""  && charSpecies != Character.SpeciesType.Null && charClass != Character.ClassType.Null) {
            // create the character
            createdCharacter = new Character(charName, charSpecies, charClass);

            if (createdCharacter.getProfessionString() == "Assault") createdCharacter.classBonus(assaultBonuses);
            else if (createdCharacter.getProfessionString() == "Scout") createdCharacter.classBonus(scoutBonuses);
            else if (createdCharacter.getProfessionString() == "Support") createdCharacter.classBonus(supportBonuses);
            else if (createdCharacter.getProfessionString() == "Medic") createdCharacter.classBonus(medicBonuses);

            // show visuals
            movementText.text = ""+createdCharacter.getMovement();
            hitDieTypeText.text = "d" + createdCharacter.getHitDieType();
            maxHitPointsText.text = ""+createdCharacter.getMaxHitPoints();
            generalSkillText.text = ""+createdCharacter.getGeneralSkill();
            meleeSkillText.text = ""+createdCharacter.getMeleeSkill();
            firearmSkillText.text = ""+createdCharacter.getFirearmSkill();
            intelligenceSkillText.text = ""+createdCharacter.getIntelligenceSkill();
            dexteritySkillText.text = ""+createdCharacter.getDexteritySkill();
            generalDeterminationText.text = ""+createdCharacter.getGeneralDetermination();
            determinationOfWillText.text = ""+createdCharacter.getDeterminationOfWill();
            determinationOfBodyText.text = ""+createdCharacter.getDeterminationOfBody();
            generalPowerText.text = ""+createdCharacter.getGeneralPower();
            powerOfStrengthText.text = ""+createdCharacter.getPowerOfStrength();
            powerOfCharismaText.text = ""+createdCharacter.getPowerOfCharisma();
            saveText.text = ""+createdCharacter.getSave();
            startingFeatureText.text = "Starting Feature: " + createdCharacter.getStartingFeature();
        }
    }
    
    // method that gets the character name that the user inputed
    public void getUserName() {
        charName = nameInputField.text;
        updateCharacter();
    }

    // method that gets the character species from the dropdown
    public void getSpecies() {
        if (speciesInputField.options[speciesInputField.value].text == "Bythir") charSpecies = Character.SpeciesType.Bythir;
        else if (speciesInputField.options[speciesInputField.value].text == "Corvaxx") charSpecies = Character.SpeciesType.Corvaxx;
        else if (speciesInputField.options[speciesInputField.value].text == "Eldurgy") charSpecies = Character.SpeciesType.Eldurgy;
        else if (speciesInputField.options[speciesInputField.value].text == "Graund") charSpecies = Character.SpeciesType.Graund;
        else if (speciesInputField.options[speciesInputField.value].text == "Human") charSpecies = Character.SpeciesType.Human;
        else if (speciesInputField.options[speciesInputField.value].text == "Ilid") charSpecies = Character.SpeciesType.Ilid;
        else if (speciesInputField.options[speciesInputField.value].text == "Numo") charSpecies = Character.SpeciesType.Numo;
        else if (speciesInputField.options[speciesInputField.value].text == "Stellos") charSpecies = Character.SpeciesType.Stellos;
        else charSpecies = Character.SpeciesType.Null;
        updateCharacter();
    }

    // method that gets the class from the dropdown
    public void getClass() {
        if (classInputField.options[classInputField.value].text == "Assault") charClass = Character.ClassType.Assault;
        else if (classInputField.options[classInputField.value].text == "Scout") charClass = Character.ClassType.Scout;
        else if (classInputField.options[classInputField.value].text == "Support") charClass = Character.ClassType.Support;
        else if (classInputField.options[classInputField.value].text == "Medic") charClass = Character.ClassType.Medic;
        else charClass = Character.ClassType.Null;
        updateCharacter();
    }
}

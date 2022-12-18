using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.EventSystems;

public class CharacterCreator : MonoBehaviour
{
    // input fields
    [Header("Input Fields")]
    public GameObject nameInput;
    private TMP_InputField nameInputField;
    public GameObject speciesInput;
    private TMP_Dropdown speciesInputField;
    public GameObject classInput;
    private TMP_Dropdown classInputField;

    // user input saves
    [Header("User Input")]
    public string charName;
    public Character.SpeciesType charSpecies;
    public Character.ClassType charClass;

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
    
    // method that gets the character name that the user inputed
    public void getUserName() {
        charName = nameInputField.text;
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
    }

    // method that gets the class from the dropdown
    public void getClass() {
        if (classInputField.options[classInputField.value].text == "Assault") charClass = Character.ClassType.Assault;
        else if (classInputField.options[classInputField.value].text == "Scout") charClass = Character.ClassType.Scout;
        else if (classInputField.options[classInputField.value].text == "Support") charClass = Character.ClassType.Support;
        else if (classInputField.options[classInputField.value].text == "Medic") charClass = Character.ClassType.Medic;
    }
}

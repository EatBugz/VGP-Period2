using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;
using UnityEngine.EventSystems;

public class CharacterDataManager : MonoBehaviour
{
    [HideInInspector] public List<Character> characterList = new List<Character>();

    public GameObject dataCardPrefab;
    public GameObject dataContents;
    public GameObject sureDeleteNotif;

    private int charIndexToDelete = -1;

    private SceneLoader sL;

    // Start is called before the first frame update
    void Start()
    {
        sL = GameObject.Find("Scene Loader").GetComponent<SceneLoader>();

        loadData();

        updateCharacterList();
    }

    // method that updates the contents of the character list
    public void updateCharacterList() {
        for (int i = 0; i < characterList.Count; i++) {
            // create data card in the contents of the slider
            GameObject foo = Instantiate(dataCardPrefab, dataContents.transform);

            // update data card information to match the character
            TextMeshProUGUI nameText = foo.transform.Find("Character Name").GetComponent<TextMeshProUGUI>();
            TextMeshProUGUI speciesText = foo.transform.Find("Character Species").GetComponent<TextMeshProUGUI>();
            TextMeshProUGUI classAndLevelText = foo.transform.Find("Class and Level").GetComponent<TextMeshProUGUI>();

            nameText.text = "" + characterList[i].getName();
            speciesText.text = "" + characterList[i].getSpeciesString();
            classAndLevelText.text = "" + characterList[i].getProfessionString() + " " + characterList[i].getLevel();

            // give buttons on click methods
            foo.transform.Find("Delete Button").GetComponent<Button>().onClick.AddListener(initializeCharacterDelete);
        }
    }

    // method that transfers the user to the character creation scene
    public void characterCreationScene() {
        saveData();
        StartCoroutine(sL.loadScene(1));
    }

    // method that quits the game
    public void quitGame() { Application.Quit(); }

    // method that shows and hides the "Are you sure notification" for deleting a character
    public void showSureDeleteNotif() { sureDeleteNotif.SetActive(true); }
    public void hideSureDeleteNotif() { sureDeleteNotif.SetActive(false); }

    // methods that "deletes" an individual character data
    public void initializeCharacterDelete() {
        GameObject dataCard = EventSystem.current.currentSelectedGameObject.transform.parent.gameObject;
        charIndexToDelete = dataCard.transform.GetSiblingIndex();
        showSureDeleteNotif();
    }
    public void deleteCharacter() {
        characterList.RemoveAt(charIndexToDelete);
        Destroy(dataContents.transform.GetChild(charIndexToDelete).gameObject);
        saveData();
        charIndexToDelete = -1;
        hideSureDeleteNotif();
    }

    // methods that saves, loads, and deletes character data \\
    public void saveData() { SaveSystem.SaveCharacterData(this); }
    public void loadData() {
        CharacterData data = SaveSystem.LoadCharacterData();

        if (data != null) {
            for (int i = 0; i < data.charList.Count; i++) {
                characterList.Add(data.charList[i]);
            }
        }
    }
    public void deleteAllData() { SaveSystem.DeleteData(); }
}

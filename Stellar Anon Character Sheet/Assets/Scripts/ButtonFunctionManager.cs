using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ButtonFunctionManager : MonoBehaviour
{
    private SceneLoader sL;

    // get the scene loader
    void Start() {
        sL = GameObject.Find("Scene Loader").GetComponent<SceneLoader>();
    }

    // method that goes back to the main menu
    public void mainMenuScene() {
        StartCoroutine(sL.loadScene(0));
    }

    // method that goes to the character sheet
    public void characterSheetScene() {
        StartCoroutine(sL.loadScene(2));
    }
}

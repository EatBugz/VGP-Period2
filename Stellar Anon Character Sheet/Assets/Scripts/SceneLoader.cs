using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEditor;

public class SceneLoader : MonoBehaviour
{
    // scene change event
    public delegate void SceneChanged();
    public static event SceneChanged sceneChanged;

    // loading screen and scene loader variables \\
    public bool changeScene = false;
    
    // method that loads the next scene in the build setting \\
    public void nextScene() {
        // stop loading coroutines
        StopAllCoroutines();
        // load the next scene in the build settings
        int nextScene = SceneManager.GetActiveScene().buildIndex + 1;
        if (nextScene > SceneManager.sceneCountInBuildSettings-1) nextScene = 0;
        StartCoroutine(loadScene(nextScene));
    }

    // method that reloads the current scene \\
    public void reloadScene() {
        StopAllCoroutines();
        StartCoroutine(loadScene(SceneManager.GetActiveScene().buildIndex));
    }

    // method that loads the next scene based on the build index given \\
    public IEnumerator loadScene(int index) {
        // load the scene
        AsyncOperation aO = SceneManager.LoadSceneAsync(index);

        // switch the loading screen back off when the new scene loads
        while (!aO.isDone) yield return null;

        // invoke the sceneChanged event
        if (sceneChanged != null) sceneChanged.Invoke();

        // update the camera
        GameObject mc = GameObject.FindWithTag("MainCamera");

        /*
        while (!aO.isDone) {
            if (changeScene) {
                aO.allowSceneActivation = true;
            }
            yield return null;
        }
        */
    }
}

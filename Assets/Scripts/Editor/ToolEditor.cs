using UnityEditor;
using UnityEngine;
using UnityEditor.SceneManagement;

public class ToolEditor : Editor
{
    [MenuItem("Tools/Clear Prefs")]
    public static void ClearPrefs()
    {
        PlayerPrefs.DeleteAll();
        Debug.Log("PlayerPrefs cleared successfully!");
    }

    [MenuItem("Tools/Go Starter Scene")]
    public static void StarterScene()
    {
        // Replace "NewSceneName" with the name of the scene you want to load.
        string sceneName = "StarterScene";

        if (EditorSceneManager.SaveCurrentModifiedScenesIfUserWantsTo())
        {
            EditorSceneManager.OpenScene("Assets/Scenes/" + sceneName + ".unity");
        }
    }

    [MenuItem("Tools/Go Game Scene")]
    public static void GameScene()
    {
        // Replace "NewSceneName" with the name of the scene you want to load.
        string sceneName = "GameScene";

        if (EditorSceneManager.SaveCurrentModifiedScenesIfUserWantsTo())
        {
            EditorSceneManager.OpenScene("Assets/Scenes/" + sceneName + ".unity");
        }
    }


}
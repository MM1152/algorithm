using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEditor.SceneManagement;
using UnityEngine;

[InitializeOnLoad]
public class StartScene 
{
    static StartScene()
    {
        var FirstScene = EditorBuildSettings.scenes[0].path;
        var sceneAsset = AssetDatabase.LoadAssetAtPath<SceneAsset>(FirstScene);
        EditorSceneManager.playModeStartScene = sceneAsset;
    }
}

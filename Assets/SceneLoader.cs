using NUnit.Framework;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class SceneLoader : MonoBehaviour
{
    public string mainScene, generatedScene;
    public List<string> playListScenes;
    public GameObject player;

    public static void LoadScene(GameObject player, string scene)
    {
        string sceneAddress = "Scenes/Playlist/Map" + scene+"/Map"+scene;
        print(sceneAddress);
        SceneManager.MoveGameObjectToScene(player, SceneManager.GetSceneByName(sceneAddress));
        SceneManager.LoadScene(sceneAddress);
        
    }
}

using NUnit.Framework;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class SceneLoader : MonoBehaviour
{
    public string mainScene, generatedScene;
    public List<string> playListScenes;
    public GameObject player;

    public void LoadScene(string scene)
    {
        string sceneAddress = "Scenes/PlayList/Map" + scene+"Map";
        SceneManager.MoveGameObjectToScene(player, SceneManager.GetSceneByName(sceneAddress));
        SceneManager.LoadScene(sceneAddress);
        
    }
}

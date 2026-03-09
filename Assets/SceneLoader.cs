using NUnit.Framework;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class SceneLoader : MonoBehaviour
{
    public string mainScene, generatedScene;
    public List<string> playListScenes;

    public void LoadScene(string scene)
    {
        SceneManager.LoadScene(scene);
    }
}

using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadMap : MonoBehaviour
{
    public string map;

    public void OnLoad()
    {
        Debug.LogError("path");
        if (map != "")
        {
            Scene scene = SceneManager.GetSceneByPath(map+".unity");
            SceneManager.LoadScene(map);

        }
        else
        {
            string map = transform.name.Substring(transform.name.Length - 1);
            string sceneAddress = "Scenes/Playlist/Map" + map + "/Map" + map;
            print(sceneAddress);
            SceneManager.LoadScene(sceneAddress);
        }
    }
}

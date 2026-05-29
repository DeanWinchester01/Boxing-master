using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadMap : MonoBehaviour
{
    public string map;
    public GameObject player;

    public void OnClick()
    {
        print(map);
        if (map != "")
        {
            StartCoroutine(LoadScene(map));
            SceneManager.LoadScene(map);
        }
        else
        {
            string map = transform.name.Substring(transform.name.Length - 1);
            string sceneAddress = "Scenes/Playlist/Map" + map + "/Map" + map;
            print(sceneAddress);
            //Scene scene = SceneManager.GetSceneByBuildIndex(int.Parse(map));
            //print(scene);
            StartCoroutine(LoadScene(map));
            /*AsyncOperation operation = SceneManager.LoadSceneAsync(int.Parse(map));
            while(!operation.isDone) 
            SceneManager.MoveGameObjectToScene(player, scene);
            //SceneManager.LoadScene(sceneAddress);*/
        }
    }

    IEnumerator LoadScene(string map)
    {
        Scene scene = SceneManager.GetSceneByBuildIndex(int.Parse(map));
        AsyncOperation operation = SceneManager.LoadSceneAsync(int.Parse(map));
        while (!operation.isDone)
        {
            yield return null;
        }
        SceneManager.MoveGameObjectToScene(player, scene);
    }
}

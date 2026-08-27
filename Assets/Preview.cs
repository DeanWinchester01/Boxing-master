using TMPro;
using UnityEngine;
using UnityEditor;
using System.IO;
using UnityEngine.Networking;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class Preview : MonoBehaviour
{
    public int map;
    static Coroutine process;
    public static string mapFolder;
    Button button;
    GameObject info;

    private string ReadSong(int map)
    {
        string sceneAddress = "Scenes/Playlist/Map" + map;
        string unityAdress = Application.dataPath;//gets unitys path to assets
        string[] files = Directory.GetFiles(unityAdress + "/" + sceneAddress);
        string songAddress = "";
        for (int i = 0; i < files.Length; i++)
        {
            if (!files[i].Contains("mp3")) continue;
            if (files[i].Contains(".meta")) continue;
            songAddress = files[i];
        }
        return songAddress;
    }

    static private string CalculateMinutes(float time)
    {
        int minutes = 0;
        float seconds = 0;
        for(int i = 0; i < time-60; i += 60)
        {
            minutes++;
        }
        seconds = Mathf.Floor(time - minutes*60);

        return minutes.ToString()+" min "+seconds.ToString()+" seconds";
    }
    //function to display information about selected map, including the song
    //it reads in the file using C# input functionality and Unity web request
    //after file is found and read in, it plays the clip
    private IEnumerator PlayPreview(int map)
    {
        mapFolder = "Scenes/Playlist/Map" + map+"/Map"+map;
        RectTransform infoTab = GameObject.Find("Canvas").transform.Find("Playlist").Find("Info").GetComponent<RectTransform>();
        AudioSource audioSource = GameObject.Find("platform").GetComponent<AudioSource>();
        Transform name = infoTab.Find("SongName");
        Transform length = infoTab.Find("Length");
        print("got items");

        /*
        string sceneAddress = "Scenes/Playlist/Map" + map;
        string unityAdress = Application.dataPath;//gets unitys path to assets
        string[] files = Directory.GetFiles(unityAdress+"/"+sceneAddress);
        string songName = "";
        string songAddress = "";
        for(int i = 0; i < files.Length; i++)
        {
            if (!files[i].Contains("mp3")) continue;
            if (files[i].Contains(".meta")) continue;
            songAddress = files[i];
            songName = songAddress.Split("\\")[1];
            songName = songName.Substring(0, songName.Length - 4);
        }*/
        string songAddress = ReadSong(map);
        string songName = songAddress.Split("\\")[1];
        songName = songName.Substring(0, songName.Length - 4);
        //read in audio clip when it's outside resource folder
        AudioClip clip;
        using (UnityWebRequest request = UnityWebRequestMultimedia.GetAudioClip("file://" +songAddress, AudioType.MPEG))
        {
            yield return request.SendWebRequest();

            if(request.result != UnityWebRequest.Result.Success)
            {
                Debug.LogError(request.error);
                yield break;
            }

            clip = DownloadHandlerAudioClip.GetContent(request);

        }
        print("got clip");
        name.GetComponent<TextMeshProUGUI>().text = /*"Map " + map.ToString() + "\n" + */songName;
        length.GetComponent<TextMeshProUGUI>().text = CalculateMinutes(clip.length);

        audioSource.clip = clip;
        audioSource.time = 15;
        audioSource.Play();
        info.SetActive(true);

        yield return new WaitForSeconds(10);
        audioSource.Stop();
        audioSource.clip = Resources.Load<AudioClip>("morgan-ambient-calm-ambient-dreamscape-529861");
        audioSource.Play();
    }

    public void Play()
    {
        if(process != null)
        {
            StopCoroutine(process);
        }
        process = StartCoroutine(PlayPreview(map));
    }

    void DisplaySong()
    {
        TextMeshProUGUI buttonText = transform.Find("Text").GetComponent<TextMeshProUGUI>();
        string songAddress = ReadSong(map);
        string songName = songAddress.Split("\\")[1];
        songName = songName.Substring(0, songName.Length - 4);
        buttonText.text = songName;
    }

    private void Start()
    {
        info = transform.parent.Find("Info").gameObject;
        DisplaySong();
    }
}

using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PauseScreen : MonoBehaviour
{
    Transform panel;
    Button back, play, reset;
    public AudioSource music;

    private void Start()
    {
        panel = transform.Find("Panel");
        back = panel.Find("Back").GetComponent<Button>();
        play = panel.Find("Play").GetComponent<Button>();
        reset = panel.Find("Reset").GetComponent<Button>();

        back.onClick.AddListener(Back);
        play.onClick.AddListener(Play);
        reset.onClick.AddListener(ResetScene);
    }
    void OnOpen()
    {
        if(Time.timeScale < 1)
        {
            Play();
            return;
        }
        panel.gameObject.SetActive(true);
        Time.timeScale = 0;
        GameObject.FindGameObjectWithTag("Laser").gameObject.GetComponent<MeshRenderer>().enabled = true;
        if(music)
            music.Pause();
    }

    public void Back()
    {
        transform.GetComponent<LoadMap>().OnLoad();
    }

    public void Play()
    {
        Time.timeScale = 1;
        panel.gameObject.SetActive(false);
        GameObject.FindGameObjectWithTag("Laser").gameObject.GetComponent<MeshRenderer>().enabled = false;
        if (music)
            music.UnPause();
    }

    public void ResetScene()
    {
        LoadMap load = transform.GetComponent<LoadMap>();
        Scene scene = SceneManager.GetActiveScene();
        string path = scene.path;
        load.map = path;
        load.OnLoad();
    }
}

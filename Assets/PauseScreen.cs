using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PauseScreen : MonoBehaviour
{
    Transform panel;
    Button back, play, reset;

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
        panel.gameObject.SetActive(true);
        Time.timeScale = 0;
    }

    public void Back()
    {
        transform.GetComponent<LoadMap>().OnLoad();
    }

    public void Play()
    {
        Time.timeScale = 1;
        panel.gameObject.SetActive(false);
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

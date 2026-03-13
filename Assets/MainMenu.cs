using UnityEngine;
using UnityEngine.UIElements;

public class MainMenu : MonoBehaviour
{
    public GameObject settings;
    public GameObject playList;

    public static UserProfile profile;
    public void Quit()
    {
        Application.Quit();
    }

    private void Start()
    {
        profile = new UserProfile();
    }

    public void Settings()
    {
        settings.SetActive(true);
        settings.GetComponent<Settings>().Initialize(profile);
        gameObject.SetActive(false);
    }

    public void PlayList()
    {
        playList.SetActive(true);
        gameObject.SetActive(false);
    }
}

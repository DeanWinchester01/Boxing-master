using UnityEngine;
using UnityEngine.UIElements;

public class MainMenu : MonoBehaviour
{
    public GameObject settings;
    public GameObject playList;
    UserProfile profile;
    public void Quit()
    {
        Application.Quit();
    }

    public void Settings()
    {
        settings.SetActive(true);
        UserProfile profile = new UserProfile();
        settings.GetComponent<Settings>().Initialize(profile);
        gameObject.SetActive(false);
    }

    public void PlayList()
    {
        playList.SetActive(true);
        gameObject.SetActive(false);
    }
}

using UnityEngine;
using UnityEngine.UIElements;

public class MainMenu : MonoBehaviour
{
    public GameObject settings;
    public GameObject playList;

    public static UserProfile profile;
    public void Quit()
    {
        Database.Save("Player", profile);
        Application.Quit();
    }

    private void Start()
    {
        if (profile == null)
        {
            if (PlayerPrefs.HasKey("Player"))
            {
                profile = Database.LoadUser("Player");
            }
            else
            {
                print("created new");
                profile = new UserProfile();
            }
        }
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

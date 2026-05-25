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
        string newProfile = Database.LoadUser("Player");
        if(newProfile == null)
        {
            print("no data");
            profile = new UserProfile();
        }
        else
        {
            print(newProfile);
            profile = JsonUtility.FromJson<UserProfile>(newProfile);
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

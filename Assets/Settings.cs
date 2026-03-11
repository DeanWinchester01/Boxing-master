using TMPro;
using UnityEngine;

public class Settings : MonoBehaviour
{
    public GameObject mainMenu;
    public TextMeshProUGUI speed, random, volume, hand;
    //public TextMeshPro speed, random, volume, hand;

    public float minSpeed, maxSpeed;
    public float minRandom, maxRandom;
    public float maxVolume;
    bool rightHand;

    public float speedIncrement, randomIncrement, volumeIncrement;

    static UserProfile profile;

    public void Initialize(UserProfile prof)
    {
        profile = prof;
    }

    private void Start()
    {
        profile = new UserProfile();
    }
    
    public void Back()
    {
        mainMenu.SetActive(true);
        gameObject.SetActive(false);
    }

    public void IncreaseSpeed()
    {
        if(profile.speed < maxSpeed)
        {
            profile.speed += speedIncrement;
            profile.speed = Mathf.Round(profile.speed * 10) / 10;
            speed.text = "Speed: " + profile.speed.ToString();
        }
    }

    public void DecreaseSpeed()
    {
        if(profile.speed > minSpeed)
        {
            profile.speed -= speedIncrement;
            profile.speed = Mathf.Round(profile.speed * 10) / 10;
            speed.text = "Speed: " + profile.speed.ToString();
        }
    }

    public void IncreaseRandom()
    {
        if(profile.random < maxRandom)
        {
            profile.random += randomIncrement;
            random.text = "Randomness: " + profile.random.ToString();
        }
    }

    public void DecreaseRandom()
    {
        if(profile.random > minRandom)
        {
            profile.random -= randomIncrement;
            random.text = "Randomness: " + profile.random.ToString();
        }
    }

    public void IncreaseVolume()
    {
        if(profile.volume < maxVolume)
        {
            profile.volume += volumeIncrement;
            volume.text = "Volume: " + profile.random.ToString();
        }
    }

    public void DecreaseVolume()
    {
        if(profile.random > volumeIncrement)
        {
            profile.random -= volumeIncrement;
            volume.text = "Volume: " + profile.random.ToString();
        }
    }

    public void SetMainHand()
    {
        profile.hand = !profile.hand;
        hand.text = profile.hand ? "Main hand: Right" : "Main hand: Left";
    }
}

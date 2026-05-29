using NUnit.Framework;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Playlist : MonoBehaviour
{
    List<int> levels;
    public GameObject levelButton;
    public int levelsAvailable;
    public GameObject player;

    void AddMap()
    {
        levels = MainMenu.profile.levelsComplete;
        float x = 0;
        float y = 0;

        for (int i = 1; i < levelsAvailable; i++)
        {
            GameObject level = Instantiate(levelButton);
            level.GetComponent<LoadMap>().player = player;

            //level.GetComponent<Button>().onClick.AddListener(() => SceneLoader.LoadScene(player, level.name.Substring(level.name.Length-1)));
            print(level.name.Substring(level.name.Length - 1));
            if (levels.Contains(i))
            {
                level.GetComponent<Image>().color = Color.green;
            }
            else
            {
                level.GetComponent<Image>().color = Color.red;
            }
            level.transform.SetParent(transform, false);
            level.GetComponent<RectTransform>().localPosition = new Vector3(x - 6, -y + 5, 0);
            level.name = "Map" + i.ToString();
            x+= level.GetComponent<RectTransform>().localScale.x + 0.5f;

            if(x >= 13)
            {
                y+= level.GetComponent<RectTransform>().localScale.y + 0.5f;
                x = 0;
            }
            level.transform.Find("Text").GetComponent<TextMeshProUGUI>().text = "Level " + i.ToString();
            //level.GetComponent<RectTransform>().Find("Text").GetComponent<TextMeshPro>().text = "Level " + i.ToString();
            //level.transform.parent = transform;
        }
    }

    void Start()
    {
        AddMap();
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

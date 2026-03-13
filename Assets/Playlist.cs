using NUnit.Framework;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Playlist : MonoBehaviour
{
    List<int> levels;
    public GameObject levelButton;
    public int levelsAvailable;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void AddMap()
    {
        levels = MainMenu.profile.levelsComplete;
        float x = 1;
        float y = 0;

        for (int i = 0; i < levelsAvailable; i++)
        {
            GameObject level = Instantiate(levelButton);
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

            if(x >= 11)
            {
                y+= level.GetComponent<RectTransform>().localScale.y + 0.5f;
                x = 1;
            }
            //level.transform.parent = transform;
        }
    }

    void PositionMap(int x, int y, GameObject map)
    {
        
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

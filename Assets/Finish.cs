using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Finish : MonoBehaviour
{
    public TextMeshProUGUI textContent;
    public Button backButton;
    public GameObject player;
    private void Start()
    {
        //backButton = transform.Find("Button").GetComponent<Button>();
        //textContent = transform.Find("Information").GetComponent<TextMeshPro>();
        transform.parent.GetComponent<Canvas>().worldCamera = Camera.current;

        backButton.onClick.AddListener(GoBack);
    }

    public void Display(Generate map)
    {
        textContent.text = "Blocks missed: " + map.blocksMissed.ToString();
        textContent.text += "\nConsequtive hits: " + map.consequtive.ToString();
        textContent.text += "\nCorrect hits: " + map.blocksHitCorrect.ToString();
        textContent.text += "\nTotal accuracy: " + map.blocksHitCorrect.ToString();
    }
    public void Display(Map info)
    {
        textContent.text = "Blocks missed: "+info.blocksMissed.ToString();
        textContent.text += "\nConsequtive hits: " + info.consequtive.ToString();
        textContent.text += "\nCorrect hits: " + info.blocksHitCorrect.ToString();
        textContent.text += "\nTotal accuracy: " + info.blocksHitCorrect.ToString();
    }

    public void GoBack()
    {
        GetComponent<LoadMap>().OnLoad();
    }
}

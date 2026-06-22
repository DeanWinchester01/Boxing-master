using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Finish : MonoBehaviour
{
    public TextMeshProUGUI textContent;
    public Button backButton;
    public GameObject laser;
    private void Start()
    {
        //backButton = transform.Find("Button").GetComponent<Button>();
        //textContent = transform.Find("Information").GetComponent<TextMeshPro>();
        transform.parent.GetComponent<Canvas>().worldCamera = Camera.current;

        backButton.onClick.AddListener(GoBack);
        laser = GameObject.FindGameObjectWithTag("Laser");
    }

    public void Display(Generate map)
    {
        laser.GetComponent<MeshRenderer>().enabled = true;
        textContent.text = "Blocks missed: " + map.blocksMissed.ToString();
        textContent.text += "\nConsequtive hits: " + map.consequtive.ToString();
        textContent.text += "\nCorrect hits: " + map.blocksHitCorrect.ToString();
        textContent.text += "\nTotal accuracy: " + (map.blocksHitCorrect/(map.blocksMissed+map.blocksHitCorrect+map.blocksHitWrong) * 100).ToString()+"%";
    }
    public void Display(Map info)
    {
        laser.GetComponent<MeshRenderer>().enabled = true;
        textContent.text = "Blocks missed: "+info.blocksMissed.ToString();
        textContent.text += "\nConsequtive hits: " + info.consequtive.ToString();
        textContent.text += "\nCorrect hits: " + info.blocksHitCorrect.ToString();
        textContent.text += "\nTotal accuracy: " + (info.blocksHitCorrect / (info.blocksMissed + info.blocksHitCorrect) * 100).ToString() + "%";
    }

    public void GoBack()
    {
        GetComponent<LoadMap>().OnLoad();
    }
}

using UnityEngine;

public class Rainbow : MonoBehaviour
{
    float h = 0;
    float s, v;
    void Start()
    {
        Material mat;
        mat = GetComponent<MeshRenderer>().material;
        Color.RGBToHSV(mat.color, out h, out s, out v);
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        
        h += 0.001f;
        Color newColor = Color.HSVToRGB(h, s, v);
        GetComponent<MeshRenderer>().material.color = newColor;
        //print(h);
        if (h >= 1)
            h = 0;
    }
}

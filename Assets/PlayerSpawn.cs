using System.Collections;
using UnityEngine;

public class PlayerSpawn : MonoBehaviour
{
    public Canvas finalScreen;
    void Start()
    {
        StartCoroutine(Spawn());
    }

    IEnumerator Spawn()
    {
        while(GameObject.Find("XR Origin (XR Rig)") == null)
        {
            yield return null;
        }

        GameObject player = GameObject.Find("XR Origin (XR Rig)");
        player.transform.position = transform.position;
        player.transform.rotation = Quaternion.identity;

        finalScreen.worldCamera = Camera.main;
    }
}

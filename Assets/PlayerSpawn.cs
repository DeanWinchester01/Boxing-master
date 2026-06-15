using System.Collections;
using UnityEngine;

public class PlayerSpawn : MonoBehaviour
{
    void Start()
    {
        Spawn();
    }

    void Spawn()
    {
        GameObject player = GameObject.FindGameObjectWithTag("Player");
        player.transform.position = transform.position;
        player.transform.rotation = Quaternion.identity;
    }
}

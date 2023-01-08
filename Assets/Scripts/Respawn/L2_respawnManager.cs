using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class L2_respawnManager : MonoBehaviour
{
    private GameObject player;
    private void Awake()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        player.transform.position = this.transform.position;
        player.GetComponent<CharacterStats>().setRespawnPoint(this.transform);
    }
}

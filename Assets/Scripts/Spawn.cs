using System;
using System.Collections;
using System.Collections.Generic;
using Photon.Pun;
using UnityEngine;

public class Spawn : MonoBehaviour
{
    public GameObject player;
    public GameObject position;
    private void Start()
    {
        PhotonNetwork.Instantiate(player.name, position.transform.position, Quaternion.identity);
    }
}

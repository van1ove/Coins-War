using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using UnityEditor.SceneManagement;
using UnityEngine.SceneManagement;

public class Connection : MonoBehaviourPunCallbacks
{
    private void Awake()
    {
        PhotonNetwork.ConnectUsingSettings();
    }

    public override void OnConnectedToMaster()
    {
        SceneManager.LoadScene("Lobby");
    }
}

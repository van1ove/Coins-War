using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Photon.Pun;
using Photon.Realtime;
using TMPro;
using UnityEngine.Serialization;

public class MenuManager : MonoBehaviourPunCallbacks
{
    [SerializeField] private TMP_InputField createInput;
    [SerializeField] private TMP_InputField joinInput;
    [SerializeField] private TMP_InputField nameInput;

    [SerializeField] private GameObject errorPanel;

    private void Start()
    {
        errorPanel.SetActive(false);
    }

    public void CreateRoom()
    {
        if (nameInput.text.Length < 3)
        {
            errorPanel.SetActive(true);
            return;
        }

        RoomOptions roomOptions = new RoomOptions();
        roomOptions.MaxPlayers = 4;
        PhotonNetwork.NickName = nameInput.text;
        PhotonNetwork.CreateRoom(createInput.text, roomOptions);
    }

    public void JoinRoom()
    {
        if (nameInput.text.Length < 3)
        {
            errorPanel.SetActive(true); 
            return;
        }
        PhotonNetwork.NickName = nameInput.text;
        PhotonNetwork.JoinRoom(joinInput.text);
    }

    public override void OnJoinedRoom()
    {
        PhotonNetwork.LoadLevel("Game");
    }
}

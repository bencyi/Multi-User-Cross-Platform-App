using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class PlayerAnimatorManager : MonoBehaviourPunCallbacks {
    /// <summary>
    /// MonoBehaviour method called on GameObject by Unity during initialization phase.
    /// </summary>
    void Start () {
        
    }

    // Update is called once per frame
    void Update () {
        if (photonView.IsMine == false && PhotonNetwork.IsConnected == true) {
            return;
        }
    }
}
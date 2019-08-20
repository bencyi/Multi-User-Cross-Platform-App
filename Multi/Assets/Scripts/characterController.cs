using System.Collections;
using System.Collections.Generic;
using Photon.Pun;
using UnityEngine;

public class characterController : MonoBehaviourPun {

    [Tooltip ("The local player instance. Use this to know if the local player is represented in the Scene")]
    public static GameObject LocalPlayerInstance;

    public Camera myCam;

    public float speed = 10.0F;

    //public GameObject explosionEffect;

    //public AudioClip explosionClip;

    // Start is called before the first frame update
    void Start () {
        Cursor.lockState = CursorLockMode.Locked;
    }

    void Awake () {
        // #Important
        // used in GameManager.cs: we keep track of the localPlayer instance to prevent instantiation when levels are synchronized
        if (photonView.IsMine) {
            characterController.LocalPlayerInstance = this.gameObject;
        }
        // #Critical
        // we flag as don't destroy on load so that instance survives level synchronization, thus giving a seamless experience when levels load.
        DontDestroyOnLoad (this.gameObject);
    }

    // Update is called once per frame
    void Update () {

        if (photonView.IsMine == false && PhotonNetwork.IsConnected == true) {
            return;
        }

        if (!photonView.IsMine) {
            if (myCam.enabled == false)
                myCam.enabled = true;
        }
        if (photonView.IsMine) {

            float translation = Input.GetAxis ("Vertical") * speed;
            float straffe = Input.GetAxis ("Horizontal") * speed;
            translation *= Time.deltaTime;
            straffe *= Time.deltaTime;

            transform.Translate (straffe, 0, translation);
        }

        if (Input.GetKeyDown ("escape"))
            Cursor.lockState = CursorLockMode.None;

    }

    public class PlayerManager : MonoBehaviourPunCallbacks, IPunObservable {
        #region IPunObservable implementation

        public void OnPhotonSerializeView (PhotonStream stream, PhotonMessageInfo info) { }

        #endregion

    }
}
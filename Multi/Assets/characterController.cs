using System.Collections;
using System.Collections.Generic;
using Photon.Pun;
using UnityEngine;

public class characterController : MonoBehaviourPunCallbacks {

    [Tooltip ("The local player instance. Use this to know if the local player is represented in the Scene")]
    public static GameObject LocalPlayerInstance;

<<<<<<< Updated upstream:Multi/Assets/characterController.cs
=======
    Animator m_Animator;

    public Camera myCam;

>>>>>>> Stashed changes:Multi/Assets/Scripts/characterController.cs
    public float speed = 10.0F;

    //public GameObject explosionEffect;

    //public AudioClip explosionClip;

    // Start is called before the first frame update
    void Start () {
        m_Animator = GetComponent<Animator> ();
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
         float translation = Input.GetAxis ("Vertical") * speed;
        float straffe = Input.GetAxis ("Horizontal") * speed;
        translation *= Time.deltaTime;
        straffe *= Time.deltaTime;

<<<<<<< Updated upstream:Multi/Assets/characterController.cs
        transform.Translate (straffe, 0, translation);
=======
        if (photonView.IsMine == false && PhotonNetwork.IsConnected == true) {
            return;
        }

        if (photonView.IsMine) {
            if (myCam.enabled == false)
                myCam.enabled = true;

            float translation = Input.GetAxis ("Vertical") * speed;
            float straffe = Input.GetAxis ("Horizontal") * speed;
            translation *= Time.deltaTime;
            straffe *= Time.deltaTime;

            transform.Translate (straffe, 0, translation);

            bool hasHorizontalInput = !Mathf.Approximately (straffe, 0f);

            bool hasVerticalInput = !Mathf.Approximately (translation, 0f);

            //isWalking if moving horizontally or vertically
            bool isWalking = hasHorizontalInput || hasVerticalInput;

            m_Animator.SetBool ("isWalking", isWalking);
        }
>>>>>>> Stashed changes:Multi/Assets/Scripts/characterController.cs

        if (Input.GetKeyDown ("escape"))
            Cursor.lockState = CursorLockMode.None;

        if (photonView.IsMine == false && PhotonNetwork.IsConnected == true) {
            return;
        }
    }

}
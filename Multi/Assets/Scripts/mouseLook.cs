using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class mouseLook : MonoBehaviourPun {

//Keeps track of how much movement camera has made, total movement
    Vector2 mouseLookVar;
    
    //Smooths movement of mouse
    Vector2 smoothV;

    //Mouse sensitivity - movement required of mouse
    public float sensitivity = 5.0f;

    //Smooths movement
    public float smoothing = 2.0f;

    //Character that mouse controls
    GameObject character;

    // Start is called before the first frame update
    void Start()
    {
        character = this.transform.parent.gameObject;
    }

    // Update is called once per frame
    void Update()
    {
        if(photonView.IsMine) {
        //Gets change of mouse movement since last update (mousse delta)
        var md = new Vector2(Input.GetAxisRaw("Mouse X"), Input.GetAxisRaw("Mouse Y"));

        //Multiplied by sens and smoothing
        md = Vector2.Scale(md, new Vector2(sensitivity * smoothing, sensitivity * smoothing));

        //Moves smoothly between two points, removes snappiness
        smoothV.x = Mathf.Lerp(smoothV.x, md.x, 1f/smoothing);
        smoothV.y = Mathf.Lerp(smoothV.y, md.y, 1f/smoothing);

        //Movement and smoothing of mouse
        mouseLookVar += smoothV;

        mouseLookVar.y = Mathf.Clamp(mouseLookVar.y, -90f, 90f);

        //Movement up and down rotated around vector3.right
        transform.localRotation = Quaternion.AngleAxis(-mouseLookVar.y, Vector3.right);

        //Movement left and right rotated around y
        character.transform.localRotation = Quaternion.AngleAxis(mouseLookVar.x, character.transform.up);
        }
    }
}

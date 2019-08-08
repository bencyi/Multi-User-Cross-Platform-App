using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class characterController : MonoBehaviour
{

    public float speed = 10.0F;

    //public GameObject explosionEffect;

    //public AudioClip explosionClip;

    // Start is called before the first frame update
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }

    // Update is called once per frame
    void Update()
    {
        float translation = Input.GetAxis("Vertical") * speed;
        float straffe = Input.GetAxis("Horizontal") * speed;
        translation *= Time.deltaTime;
        straffe *= Time.deltaTime;

        transform.Translate(straffe, 0, translation);

        if (Input.GetKeyDown("escape"))
            Cursor.lockState = CursorLockMode.None;
    }

    /*
     
    void OnTriggerEnter(Collider other) {
        if(other.gameObject.CompareTag("Bomb"))
        {
            AudioSource.PlayClipAtPoint(explosionClip , transform.position);

            Instantiate(explosionEffect, transform.position, transform.rotation);

            Destroy(other.gameObject);
        }
    }    
    */
}

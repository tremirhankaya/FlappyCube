using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

   
    Rigidbody playerRb;
    [SerializeField] float jumpForce;
    AudioSource audioSource;
    public AudioClip jumpSound;
    public int score = 0;
    GameController gameController;
    void Start()
    {
        playerRb = GetComponent<Rigidbody>();
        
        
        audioSource = GetComponent<AudioSource>();
        gameController = GameObject.Find("Cube").GetComponent<GameController>();

    }


    void Update()
    {


        if (Input.GetKeyDown(KeyCode.Space)&&gameController.topBoundry>transform.position.y)
        {
            playerRb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
            audioSource.PlayOneShot(jumpSound);


        }
        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);
            if (touch.phase == TouchPhase.Began)
            {
                playerRb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
                audioSource.PlayOneShot(jumpSound);

            }

        }

      
    }
}



using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.SocialPlatforms.Impl;
using UnityEngine.UI;
using UnityEngine.UIElements;
using Button = UnityEngine.UI.Button;

public class GameController : MonoBehaviour
{
    public AudioClip explosionsound, checkpointsound;
    AudioSource audioSource1;
    int score = 0;
    public bool isGameOver = false;
    public TextMeshProUGUI scoreText, gameoverText, highScore;
    public Button restart,start;
    public float topBoundry = 23.5f;
    void Start()
    {
        Time.timeScale = 0;
        highScore.text = "Best - "+PlayerPrefs.GetInt("HighScore").ToString();

       
        audioSource1 = GetComponent<AudioSource>();
        restart.gameObject.SetActive(false);
        gameoverText.gameObject.SetActive(false);
      
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position.y > topBoundry)
        {
           transform.position= new Vector3(transform.position.x, topBoundry, transform.position.z);
        }


    }
    void OnTriggerEnter(Collider other)
    {

        if (other.gameObject.tag == "Point")
        {
            audioSource1.PlayOneShot(checkpointsound);
            score++;
            scoreText.text=score.ToString();
            

            
        }
        else if (other.gameObject.tag == "Obstacle"|| other.gameObject.tag == "Ground")
        {
            audioSource1.PlayOneShot(explosionsound);
            isGameOver = true;
            if (score > PlayerPrefs.GetInt("HighScore"))
            {
            PlayerPrefs.SetInt("HighScore", score);
            }




            StartCoroutine(DestroyGameObj());
            restart.gameObject.SetActive(true);
            gameoverText.gameObject.SetActive(true);


        }

    }
    public void StartTheGame()
    {

        Time.timeScale = 1;
        highScore.gameObject.SetActive (false);
        start.gameObject.SetActive(false);
        scoreText.gameObject.SetActive(true);
    }
  
    IEnumerator DestroyGameObj()
    {
        yield return new WaitForSeconds(0.3f);
            Destroy(gameObject);
        
    }
}
   
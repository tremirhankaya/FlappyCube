using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Moveleft : MonoBehaviour
{
    [SerializeField] float speed;
   
    float leftbound = -50f;
    GameController controller;
    void Start()
    {
        
    }

    
    void Update()
    {
        
       
            transform.Translate(Vector3.left * speed * Time.deltaTime);
      
        
        if (transform.position.x < leftbound)
        {
            Destroy(gameObject);
        }
    }
}

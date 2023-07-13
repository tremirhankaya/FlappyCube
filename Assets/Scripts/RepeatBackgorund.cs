using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RepeatBackgorund : MonoBehaviour
{
    Vector3 startPos;
    
    void Start()
    {
        startPos = transform.position;
        
    }

   
    void Update()
    {
        if (transform.position.x < 15)
        {
            transform.position= startPos;
        }
    }
}

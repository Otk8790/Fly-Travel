using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GirarHelice : MonoBehaviour
{
    
    void Start()
    {
        
    }

    void Update()
    {
        transform.Translate(0f, 0f, 0f);
        transform.Rotate(0f, 0f, 7200f * Time.deltaTime);
        
    }
}

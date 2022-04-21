using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GirarAro : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(0f, 0f, 0f);
        transform.Rotate(0f, 2f, 0f * Time.deltaTime);
        
    }
}

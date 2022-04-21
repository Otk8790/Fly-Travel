using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Respawn : MonoBehaviour
{
    public Transform Player;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Player.transform.position = new Vector3(1.3f, -0.387f, -20f);
            Player.transform.rotation = Quaternion.Euler(0f, 0f, 0f);
            Physics.SyncTransforms();

        }
    }
}

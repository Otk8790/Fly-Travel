using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowPlayer : MonoBehaviour
{

    private Transform target;
    public GameObject player;
    public Vector3 offset = new Vector3(0, 4, -7);
    [Range(0, 1)] public float lerpValue;
    [Range(0, 10)] public float sensibilidad;

    // Start is called before the first frame update
    void Start()
    {
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
        //target = GameObject.Find("Avion").transform;
    }

    // Update is called once per frame
    void LateUpdate()
    {
        this.transform.position = player.transform.position + offset;
        //transform.position = Vector3.Lerp(transform.position, target.position + offset, lerpValue);
        //offset = Quaternion.AngleAxis(Input.GetAxis("Mouse X") * sensibilidad, Vector3.up) * offset;

        //transform.LookAt(target);
    }
}

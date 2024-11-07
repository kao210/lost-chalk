using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    [SerializeField] Transform follow;

    [SerializeField] float mouseSensitivity = 1;

    float yaw, pitch;
    // Start is called before the first frame update
    void Start()
    {
        Cursor.visible = false;

        Cursor.lockState = CursorLockMode.Locked;
    }

    // Update is called once per frame
    void Update()
    {
        if(follow == null)
        {
            return;
        }
        transform.position = follow.position;

        yaw += Input.GetAxis("Mouse X") * mouseSensitivity;

        //pitch -= Input.GetAxis("mouse Y") * mouseSensitivity;

        pitch = Mathf.Clamp(pitch, -60, 60);

        transform.eulerAngles = new Vector3(pitch, yaw, 0);
    }
}

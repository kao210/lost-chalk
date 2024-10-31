using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharactorControllerAddForce : MonoBehaviour
{
    Rigidbody rb;
    float jumpForce = 100.0f;
    //float walkSpeed = 30.0f;
    [SerializeField] float speed = 10f;
    float maxWalkSpeed = 2.0f;
    // Start is called before the first frame update
    void Start()
    {
        Application.targetFrameRate = 60;
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.Space))
        {
            this.rb.AddForce(transform.up * this.jumpForce);
        }

        int key = 0;
        if (Input.GetKey(KeyCode.UpArrow)) key = 1;
        if (Input.GetKey(KeyCode.DownArrow)) key = -1;

        //var input = new Vector3(Input.GetAxis("Horizontal"), 0f, Input.GetAxis("Vertical"));


    }
}

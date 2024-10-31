using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharactorController : MonoBehaviour
{
    Rigidbody rb;
    float jumpForce = 100.0f;
    //float walkSpeed = 30.0f;
    [SerializeField] float speed = 10f;
    float maxWalkSpeed = 2.0f;
    bool isjump = false;

    // Start is called before the first frame update
    void Start()
    {
        Application.targetFrameRate = 60;
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (Input.GetKey(KeyCode.Space))
        {
            isjump = true;
            this.rb.AddForce(Vector3.up * this.jumpForce);
        }

        if (isjump)
        {
            jumpForce = 0f;
            isjump = false;
        }

        var input = new Vector3(Input.GetAxis("Horizontal"), 0f, Input.GetAxis("Vertical"));

        var horizontalRotation = Quaternion.AngleAxis(Camera.main.transform.eulerAngles.y, Vector3.up);

        var velocity = horizontalRotation * input;

        rb.AddForce(velocity * speed);

        //if(velocity.sqrMagnitude > 0.01f)
        //{
        //    //transform.rotation = Quaternion.LookRotation(velocity);
        //}

        //if(velocity.magnitude > 1)
        //{
        //    velocity = velocity.normalized;
        //}

        //rb.velocity = velocity * speed;
        //bool‚ÅƒWƒƒƒ“ƒv1‰ñ‚¾‚¯‚É‚·‚é
        //‹ó’†”»’è
        //‹ó’†‚É¶‰E“ü—Í‚Å•ûŒü“]Š·
    }
}

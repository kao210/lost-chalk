using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharactorController : MonoBehaviour
{
    [SerializeField] float rotateSpeed = 0.0f;//‰ñ“]‚·‚é‘¬“x
    Rigidbody rb;
    [SerializeField] float jumpForce = 300.0f;
    //float walkSpeed = 30.0f;
    [SerializeField] float speed = 10f;
    //float maxWalkSpeed = 2.0f;
    bool isJump = true;
    [SerializeField] Transform parent;
    private RaycastHit floarHit;
    [SerializeField] private LayerMask layerMask;

    // Start is called before the first frame update
    void Start()
    {
        Application.targetFrameRate = 60;
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (Input.GetKey(KeyCode.Space) && isJump)
        {
            //ã•ûŒü‚É—Í‚ğ‰Á‚¦‚é(ƒWƒƒƒ“ƒv‚·‚é)
            this.rb.AddForce(Vector3.up * this.jumpForce);
            isJump = false;
        }

        var input = new Vector3(0f, 0f, Input.GetAxis("Vertical"));

        //var horizontalRotation = Quaternion.AngleAxis(Camera.main.transform.eulerAngles.y, Vector3.up);

        //var velocity = horizontalRotation * input;
        Vector3 velocity = input.z * parent.right ;

        rb.AddForce(velocity * speed);

        if (!isJump)//‹ó’†”»’è
        {
            //‰¡•ûŒü‚Ì“ü—Í‚ğæ‚é(‚P`|‚P)
            float direction = Input.GetAxis("Horizontal");
            //rotate‚Å‰ñ“]B‰ñ“]—Ê‚Í-rotateSpeed * direction‚Ì’l
            parent.Rotate(0.0f, -rotateSpeed * direction, 0.0f, Space.World);
            //rb.AddForce(velocity * speed);

        }

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

        
        parent.position = this.transform.position;
        this.transform.localPosition = Vector3.zero;
        this.transform.localRotation = Quaternion.Euler(this.transform.rotation.eulerAngles.x, 90, 90);

    }

    private void OnCollisionEnter(Collision collision)
    {
        Debug.Log("hit");
        //Tag‚Ìfloar‚É“–‚½‚Á‚½Ä“xƒWƒƒƒ“ƒv‚Å‚«‚é‚æ‚¤‚É‚·‚é
        if (collision.gameObject.CompareTag("floar"))
        {
            Debug.Log("floarHit");
            //jumpForce = 300.0f;
            isJump = true;
        }
    }
}

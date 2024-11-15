using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CharactorController : MonoBehaviour
{
    [SerializeField] float rotateSpeed = 0.0f;//回転する速度
    Rigidbody rb;
    [SerializeField] float jumpForce = 300.0f;
    //float walkSpeed = 30.0f;
    [SerializeField] float speed = 10f;
    //float maxWalkSpeed = 2.0f;
    bool isJump = true;
    [SerializeField] Transform parent;
    private RaycastHit floarHit;
    [SerializeField] private LayerMask layerMask;
    [SerializeField] private Transform[] respawnPointArray;


    // Start is called before the first frame update
    void Start()
    {
        Application.targetFrameRate = 60;
        rb = GetComponent<Rigidbody>();
        Respawn();//やられるてシーンが読み込まれるたびに呼び出される
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && isJump)
        {
            //上方向に力を加える(ジャンプする)
            this.rb.AddForce(Vector3.up * this.jumpForce);
            isJump = false;
        }
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (Physics.Raycast(transform.position, Vector3.down, 0.7f, layerMask))
        {
            isJump = true;
        }
        else
        {
            isJump = false;
        }

        var input = new Vector3(0f, 0f, Input.GetAxis("Vertical"));

        //var horizontalRotation = Quaternion.AngleAxis(Camera.main.transform.eulerAngles.y, Vector3.up);

        //var velocity = horizontalRotation * input;
        Vector3 velocity = input.z * parent.right ;

        rb.AddForce(velocity * speed);

        if (!isJump)//空中判定
        {
            //横方向の入力を取る(１～－１)
            float direction = Input.GetAxis("Horizontal");
            //rotateで回転。回転量は-rotateSpeed * directionの値
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
        //boolでジャンプ1回だけにする
        //空中判定
        //空中時に左右入力で方向転換

        
        parent.position = this.transform.position;
        this.transform.localPosition = Vector3.zero;
        this.transform.localRotation = Quaternion.Euler(this.transform.rotation.eulerAngles.x, 90, 90);

    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "Goal")
        {
            Debug.Log("GOAL");
            transform.position = respawnPointArray[0].position;
            SceneManager.LoadScene("ClearScene");
        }
        
        //Debug.Log("hit");
        ////Tagのfloarに当たった時再度ジャンプできるようにする
        //if (collision.gameObject.CompareTag("floar"))
        //{
        //    Debug.Log("floarHit");
        //    //jumpForce = 300.0f;
        //    isJump = true;
        //}
    }


    public void Respawn()
    {
        this.transform.position = respawnPointArray[Singleton.instance.GetRespawmNumber()].position;
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CharacterController : MonoBehaviour
{
    [Header("プレイヤーの回転速度")]
    [SerializeField] float rotateSpeed = 0.0f;//回転する速度
    Rigidbody rigidbody;
    [SerializeField] float jumpForce = 300.0f;

    [Header("プレイヤーの移動速度")]
    [SerializeField] float speed = 10f;

    //ジャンプできるかどうかのフラグ
    bool isJump = true;

    [Header("プレイヤーの親オブジェクト")]
    [SerializeField] Transform parent;

    private RaycastHit floarHit;

    [Header("床のLayer")]
    [SerializeField] private LayerMask layerMask;

    [Header("リスポーンポイント")]
    [SerializeField] public Transform[] respawnPointArray;

    [Header("レイヤーの長さ")]
    [SerializeField] private float layerDistance = 0.0f;


    // Start is called before the first frame update
    private void Start()
    {
        // AddForceで動かすときのフレームレートを固定する
        Application.targetFrameRate = 60;

        //Rigidbodyコンポーネントを取得
        rigidbody = GetComponent<Rigidbody>();

        //やられるてシーンが読み込まれるたびに呼び出される
        //
        Respawn();
    }

    private void Update()
    {
        //スペースキーを押したとき、isJumpがtrueなら
        if (Input.GetKeyDown(KeyCode.Space) && isJump)
        {
            //上方向に力を加える(ジャンプする)
            this.rigidbody.AddForce(Vector3.up * this.jumpForce);

            //二段ジャンプを防止するために、isJumpをfalseにする
            isJump = false;
        }
    }

    private void FixedUpdate()
    {
        //Raycastで床に接地しているかを判定し、接地していればisJumpをtrueにする
        if (Physics.Raycast(transform.position, Vector3.down, layerDistance, layerMask))
        {
            isJump = true;
        }
        else
        {
            isJump = false;
        }

        //プレイヤーの前後移動の入力のみを取得する(１～－１)
        var input = new Vector3(0f, 0f, Input.GetAxis("Vertical"));

        //プレイヤーの前後移動の入力に応じて、プレイヤーを前後に移動させる情報を取得する
        Vector3 velocity = input.z * parent.right ;

        //プレイヤーの前後移動の入力に応じて、AddForceで力を加えてプレイヤーを前後に移動させる
        rigidbody.AddForce(velocity * speed);

        //空中判定
        if (!isJump)
        {
            //横方向の入力を取る(１～－１)
            float direction = Input.GetAxis("Horizontal");

            //rotateで回転。回転量は-rotateSpeed * directionの値
            parent.Rotate(0.0f, -rotateSpeed * direction, 0.0f, Space.World);
        }

        // 移動しているオブジェクトの位置を親オブジェクトに合わせる
        parent.position = transform.position;

        // プレイヤーの子と親オブジェクトの位置を同じにする
        transform.localPosition = Vector3.zero;

        // プレイヤーの子と親オブジェクトの回転を同じにする
        transform.localRotation = Quaternion.Euler(transform.rotation.eulerAngles.x, 90, 90);

    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Goal")
        {
            Debug.Log("GOAL");

            // respawnPointArrayの０番目の位置にプレイヤーを移動させる
            transform.position = respawnPointArray[0].position;

            // クリアシーンに遷移する
            SceneManager.LoadScene("ClearScene");
        }

    }

    /// <summary>
    /// リスポーンポイントにプレイヤーを移動させるメソッド
    /// </summary>
    public void Respawn()
    {
        // respawnPointArrayのSingleton.instance.GetRespawmNumber()番目の位置にプレイヤーを移動させる
        this.transform.position = respawnPointArray[Singleton.instance.GetRespawmNumber()].position;
    }
}

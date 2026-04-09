using UnityEngine;
using UnityEngine.SceneManagement;

/// <summary>
/// プレイヤーの移動、ジャンプ、回転を制御するクラス
/// </summary>
public class CharacterController : MonoBehaviour
{
    [Header("プレイヤーの回転速度")]
    [SerializeField] float rotateSpeed = 0.0f;//回転する速度
    private Rigidbody rigidbody;
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

    [SerializeField] private Transform cameraTransform = null;

    float cameraAngleY = 0.0f;


    // Start is called before the first frame update
    private void Start()
    {
        // AddForceで動かすときのフレームレートを固定する
        Application.targetFrameRate = 60;

        //Rigidbodyコンポーネントを取得
        rigidbody = GetComponent<Rigidbody>();

        //やられるてシーンが読み込まれるたびに呼び出される
        Respawn();
    }

    private void Update()
    {
        //スペースキーを押したとき、isJumpがtrueなら
        if (Input.GetKeyDown(KeyCode.Space) && isJump)
        {
            //上方向に力を加える(ジャンプする)
            rigidbody.AddForce(Vector3.up * jumpForce);

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
        //var input = new Vector3(0f, 0f, Input.GetAxis("Vertical"));
        float inputZ = Input.GetAxis("Vertical");

        //カメラのY軸の角度を取得する
        //inspectorに表示されているrotationの角度と同じ値を取得するために、localEulerAnglesを使用する
        cameraAngleY = cameraTransform.localEulerAngles.y;

        //0~180度のときはそのままの値を使用し、180~360度のときは360から引いた値を使用する
        if (cameraAngleY > 180f) cameraAngleY -= 360f;

        //カメラのY軸の角度が0～180度のときは正の方向、180～360度のときは負の方向に移動するようにする
        float cameraDirection = (cameraAngleY >= -90 && cameraAngleY <= 90f) ? -1f : 1f;

        //カメラの水平の正面方向を取得し正規化する
        Vector3 cameraForward = Vector3.ProjectOnPlane(cameraTransform.forward, Vector3.up).normalized;

        //Vector3 move = cameraForward * inputZ;
        Vector3 move = parent.right * inputZ * cameraDirection;

        //プレイヤーの前後移動の入力に応じて、AddForceで力を加えてプレイヤーを前後に移動させる
        //rigidbody.AddForce(velocity * speed);
        rigidbody.AddForce(move * speed);

        //空中判定
        if (!isJump)
        {
            //横方向の入力を取る(１～－１)
            float direction = Input.GetAxis("Horizontal");

            //rotateで回転。回転量は-rotateSpeed * directionの値
            parent.Rotate(0.0f, rotateSpeed * direction, 0.0f, Space.World);
        }

        // 移動しているオブジェクトの位置を親オブジェクトに合わせる
        parent.position = transform.position;

        // プレイヤーの子と親オブジェクトの位置を同じにする
        transform.localPosition = Vector3.zero;

        // プレイヤーの子と親オブジェクトの回転を同じにする
        //このオブジェクトを水平に保つようにする
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

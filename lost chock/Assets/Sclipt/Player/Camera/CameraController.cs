using UnityEngine;

public class CameraController : MonoBehaviour
{
    [Header("追従するオブジェクト")]
    [SerializeField] private Transform targetPosition = null;

    [Header("マウス感度")]
    [SerializeField] float mouseSensitivity = 1.0f;

    private float yaw, pitch;

    
    private void Start()
    {
        //Cursor.visible = false;

        //Cursor.lockState = CursorLockMode.Locked;
    }

    // Update is called once per frame
    private void LateUpdate()
    {
        // 追従するターゲットがいない場合は処理を行わない
        if(targetPosition == null)
        {
            return;
        }

        // カメラの位置をターゲットの位置に合わせる
        transform.position = targetPosition.position;

        // マウスの移動量を取得してカメラの回転に反映させる
        yaw += Input.GetAxis("Mouse X") * mouseSensitivity;

        //pitch -= Input.GetAxis("Mouse Y") * mouseSensitivity;

        // カメラの上下の回転を制限する
        pitch = Mathf.Clamp(pitch, -60, 60);

        // カメラの回転を適用する
        transform.eulerAngles = new Vector3(pitch, yaw, 0);
    }
}

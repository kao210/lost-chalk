using UnityEngine;

/// <summary>
/// プレイヤーが落下したときのダメージ処理を行うクラス
/// </summary>
public class DamageController : MonoBehaviour
{
    //レイを飛ばす場所
    [SerializeField] private Transform rayPosition;

    //レイを飛ばす距離
    [SerializeField] private float rayRange = 0.1f;

    //落ちた場所
    private float fallenPosition;

    //HP処理スクリプト
    [SerializeField] private LifeController myHP;

    //落下しているかの判定
    private bool isFall = false;

    //落下してから地面に落ちるまでの距離
    //着地時に計算する
    private float fallDistanse = 0.0f;

    //ダメージを与える距離
    [SerializeField] private float takeDamageDistance = 0f;

    void Start()
    {
        //落下距離を初期化
        fallDistanse = 0f;

        // 落ちた場所を初期化するために自分の場所に設定する
        fallenPosition = transform.position.y;

        //落ちた地点を設定していない状態にする
        isFall = false;
    }

    void Update()
    {
        // Rayを下方向に飛ばしているのをSceneビューに表示する
        Debug.DrawLine(rayPosition.position, rayPosition.position + Vector3.down * rayRange, Color.red);

        // 落下中
        if (isFall)
        {
            FallingDamageProcess();
        }
        //落下中ではない場合
        else
        {
            //floarレイヤーが当たっていないとき落ちている判定にする
            if (!Physics.Linecast(rayPosition.position,
                rayPosition.position + Vector3.down * rayRange, LayerMask.GetMask("floar", "")))
            {
                //落下地点を設定する
                fallenPosition = transform.position.y;

                //落下距離を初期化
                fallDistanse = 0;

                //落下判定にする
                isFall = true;
            }
        }
    }

    /// <summary>
    /// 落下ダメージを計算してプレイヤーにダメージを与えるメソッド
    /// </summary>
    private void FallingDamageProcess()
    {
        //落下地点と現在地の距離を計算
        fallenPosition = Mathf.Max(fallenPosition, transform.position.y);

        //地面にレイが届いていたら
        if (Physics.Linecast(rayPosition.position,
            rayPosition.position + Vector3.down * rayRange, LayerMask.GetMask("floar", "")))
        {
            //落下距離を計算
            //落下し始めた位置-floarRayが当たった位置
            fallDistanse = fallenPosition - transform.position.y;

            //落下した距離がダメージを与える距離以上のとき
            if (fallDistanse >= takeDamageDistance)
            {
                //落下した距離分ダメージを与える
                myHP.TakeDamage((int)(fallDistanse - takeDamageDistance));
            }
            isFall = false;
        }
    }
}

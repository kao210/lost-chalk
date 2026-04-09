using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

/// <summary>
/// 回転テーブルを制御するクラス
/// </summary>
public class RotateTable : MonoBehaviour
{
    [SerializeField] private float rotateTime = 0;
    [SerializeField] private float rotateZ = 0;

    private void Start()
    {
        // 回転アニメーション
        // rotateTimeで設定した時間で360度回転させる＋360度以上回転し、回転が途切れないようにする
        transform.DOLocalRotate(new Vector3(0, 360, rotateZ), rotateTime, RotateMode.FastBeyond360).SetEase(Ease.Linear).SetLoops(-1);
    }

    private void OnCollisionEnter(Collision other)
    {
        // プレイヤーが回転テーブルに乗ったとき、プレイヤーを回転テーブルの子オブジェクトにする
        if (other.gameObject.CompareTag("player"))
        {
            //このオブジェクトは回転しているためplayerTagのオブジェクトを子オブジェクトにすることで一緒に回転させる
            other.transform.parent.SetParent(transform);
        }
    }

    private void OnCollisionExit(Collision other)
    {
        // プレイヤーが回転テーブルから降りたとき、プレイヤーを回転テーブルの子オブジェクトから外す
        if (other.gameObject.CompareTag("player"))
        {
            other.transform.parent.SetParent(null);
        }
    }
}

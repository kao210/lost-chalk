using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageController : MonoBehaviour
{
    //レイを飛ばす場所
    [SerializeField] Transform rayPosition;

    //レイを飛ばす距離
    [SerializeField] private float rayRange = 0.1f;

    //落ちた場所
    private float fallenPosition;

    //HP処理スクリプト
    private LifeController myHP;

    //落ちた地点を設定したかどうか
    private bool isFall;

    //落下してから地面に落ちるまでの距離
    private float fallDistanse;

    [SerializeField] private float takeDamageDistance = 0f;

    void Start()
    {
        fallDistanse = 0f;
        fallenPosition = transform.position.y;
        isFall = false;
        myHP = GetComponentInChildren<LifeController>();
    }

    void Update()
    {
        Debug.DrawLine(rayPosition.position, rayPosition.position + Vector3.down * rayRange, Color.red);

        if (isFall)
        {
            //落下地点と現在地の距離を計算
            fallenPosition = Mathf.Max(fallenPosition, transform.position.y);

            //地面にレイが届いていたら
            if (Physics.Linecast(rayPosition.position,
                rayPosition.position + Vector3.down * rayRange, LayerMask.GetMask("floar", "")))
            {
                //落下距離を計算
                fallDistanse = fallenPosition - transform.position.y;

                if (fallDistanse >= takeDamageDistance)
                {
                    //落下した距離分ダメージを与える
                    myHP.TakeDamage((int)(fallDistanse - takeDamageDistance));
                }
                isFall = false;
            }
        }
        else
        {
            if (!Physics.Linecast(rayPosition.position,
                rayPosition.position + Vector3.down * rayRange, LayerMask.GetMask("floar", "")))
            {
                fallenPosition = transform.position.y;
                fallDistanse = 0;
                isFall = true;
            }
        }

    }
}

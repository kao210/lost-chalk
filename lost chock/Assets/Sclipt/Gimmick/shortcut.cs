using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;


/// <summary>
/// ショートカット用の道を開通させるクラス
/// </summary>
public class shortcut : MonoBehaviour
{
    
    public void OnCollisionEnter(Collision collision)
    {
        // プレイヤーがショートカットに触れたとき、このオブジェクトをショートカットの位置に移動させる
        if (collision.gameObject.tag == "player")
        {
            transform.DOLocalMove(new Vector3(-55f, 0, 0), 0.1f);
        }
    }
}

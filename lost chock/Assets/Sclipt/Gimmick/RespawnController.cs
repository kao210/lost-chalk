using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// リスポーン地点を更新するクラス
/// </summary>
public class RespawnController : MonoBehaviour
{
    [Tooltip("リスポーンポイントの番号")]
    [SerializeField] private int respawnNumber = 0;
    
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("player"))//Tagついているか確認
        {
            // リスポーンポイントに入ったとき、リスポーンポイントの番号をSingletonクラスに渡して
            // リスポーン地点を更新する
            Singleton.instance.SetRespawnNumber(respawnNumber);
        }
    }
}

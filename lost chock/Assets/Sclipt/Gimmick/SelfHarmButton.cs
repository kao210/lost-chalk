using UnityEngine;

/// <summary>
/// F10キーを押すと自滅するクラス
/// 自滅後最大HPが増える
/// </summary>
public class SelfHarmButton : MonoBehaviour
{
    // HP処理スクリプト
    [SerializeField] private LifeController deleteHp;

    
    void Update()
    {
        // F10キーを押すと自滅する
        if (Input.GetKey(KeyCode.F10))
        {
            Debug.Log("10000");

            // HPを10000減らす
            deleteHp.TakeDamage(10000);
        }
    }
}

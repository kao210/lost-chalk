using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Singleton : MonoBehaviour
{
    // Singletonクラスのインスタンスを格納する変数
    //staticなのでクラス名と変数名を書くことでどこからでもアクセスできる
    public static Singleton instance;

    //プレイヤーの初期HP
    private int startMaxHp = 350;

    //プレイヤーの最大HP
    private int maxHp = 350;

    //リスポーン地点の番号
    private int respawnNumber = 0;

    //getMaxHpを呼び出すと返ってくる
    public int GetMaxHp()
    {
        Debug.Log("MaxHP" + maxHp);
        return maxHp;
    }

    /// <summary>
    /// 呼び出されたときに最大HPを10加算するメソッド
    /// </summary>
    public void AddHp()
    {
        //最大HPを加算する
        maxHp += 10;
        Debug.Log("addhp" + maxHp);
    }

    //クリアした時Hpを初期値に戻す
    public void ResetHp()
    {
        maxHp = startMaxHp;
        respawnNumber = 0;
    }

    /// <summary>
    /// リスポーン地点を更新するメソッド
    /// </summary>
    public void SetRespawnNumber(int value)
    {
        //valueがRespawnNumberより大きいときリスポーン更新
        if (value > respawnNumber)
        {
            respawnNumber = value;//リスポーン更新
        }
    }
    
    /// <summary>
    /// リスポーンナンバーを取得
    /// </summary>
    /// <returns></returns>
    public int GetRespawmNumber()
    {
        return respawnNumber;
    }
    
    private void Awake()
    {
        //instanceの中身が空の時、このスクリプトが最初に実行されたとき
        if(instance == null)
        {
            instance = this;
            //壊されないようにする
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            //新しく現れたinstanceはいらないので破壊する
            Destroy(gameObject);
        }
        //破壊されないオブジェクトにアタッチする(CreateEmptyで新しくオブジェクトを作るなど)
    }
}

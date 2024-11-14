using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Singleton : MonoBehaviour
{
    public static Singleton instance;

    private int startMaxHp = 200;
    private int maxHp = 20;

    //getMaxHpを呼び出すと返ってくる
    public int GetMaxHp()
    {
        Debug.Log("MaxHP" + maxHp);
        return maxHp;
    }

   

    //やられた瞬間読み込まれて加算される
    public void AddHp()
    {
        maxHp += 10;
        Debug.Log("addhp" + maxHp);
    }

    //クリアした時Hpを初期値に戻す
    public void ResetHp()
    {
        maxHp = startMaxHp;
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

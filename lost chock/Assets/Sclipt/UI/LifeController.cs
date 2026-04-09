using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

/// <summary>
/// プレイヤーのHPを管理しているクラス
/// </summary>
public class LifeController : MonoBehaviour
{
    [Header("プレイヤーオブジェクト")]
    [SerializeField] GameObject chalk;

    //プレイヤーのHP
    private int hp = 0;

    // プレイヤーのHPを表示するテキスト
    private TextMeshProUGUI myHPText = null;


    private void Start()
    {
        //SingletonのmaxHpが読み込まれてその値がプレイヤーのHPになる
        hp = Singleton.instance.GetMaxHp();

        // プレイヤーのHPを表示するテキストを取得して、初期値を表示する
        myHPText = GetComponent<TextMeshProUGUI>();
        myHPText.text = hp.ToString();
    }

    /// <summary>
    /// プレイヤーがダメージを受けると呼び出される関数
    /// </summary>
    public void TakeDamage(int damage)
    {
        // ダメージ分HPを減らす内部処理
        hp -= damage;

        // プレイヤーのHPを表示するテキストを更新する
        myHPText.text = hp.ToString();

        // HPが0以下になったときの処理
        if (hp <= 0)
        {
            // Singletonの最大HPを増やすメソッドを呼び出す
            Singleton.instance.AddHp();

            // プレイヤーオブジェクトを破壊しGameScene 1をロードする
            Destroy(chalk);
            SceneManager.LoadScene("GameScene 1");
        }
    }
}

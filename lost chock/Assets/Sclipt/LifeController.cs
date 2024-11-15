using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class LifeController : MonoBehaviour
{
    [SerializeField] GameObject chalk;
    [SerializeField] private int hp;
    private TextMeshProUGUI myHPText;
    public static LifeController Instance;

    //public GameObject Cylinder;
    //public GameObject chockhakai;

    //private void Awake()
    //{
    //    if(Instance == null)
    //    {
    //        Instance = this;

    //        DontDestroyOnLoad(gameObject);
    //    }
    //    else
    //    {
    //        Destroy(gameObject);
    //    }
    //}

    void Start()
    {
        hp = Singleton.instance.GetMaxHp();
        myHPText = GetComponent<TextMeshProUGUI>();
        myHPText.text = hp.ToString();
        //Cylinder.SetActive(true);
        //chockhakai.SetActive(false);
    }

    public void TakeDamage(int damage)
    {
        hp -= damage;
        myHPText.text = hp.ToString();
        if (hp <= 0)
        {
            //Cylinder.SetActive(false);
            //chockhakai.SetActive(true);
            Singleton.instance.AddHp();
            Destroy(chalk);
            SceneManager.LoadScene("TestScene");
            //hp = hp + 100;
        }
    }

    //public void Update()
    //{
        
    //}
}

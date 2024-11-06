using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class LifeController : MonoBehaviour
{
    private int hp;
    private TextMeshProUGUI myHPText;

    void Start()
    {
        hp = 100;
        myHPText = GetComponentInChildren<TextMeshProUGUI>();
        //myHPText.text = hp.ToString();
    }

    public void TakeDamage(int damage)
    {
        hp -= damage;
        myHPText.text = hp.ToString();
    }
}

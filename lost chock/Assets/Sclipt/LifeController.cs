using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class LifeController : MonoBehaviour
{
    [SerializeField] private int hp;
    private TextMeshProUGUI myHPText;

    void Start()
    {
        myHPText = GetComponentInChildren<TextMeshProUGUI>();
        //myHPText.text = hp.ToString();
    }

    public void TakeDamage(int damage)
    {
        hp -= damage;
        //myHPText.text = hp.ToString();
    }
}

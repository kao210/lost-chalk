using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelfHarmButton : MonoBehaviour
{
    [SerializeField] private LifeController deleteHp;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.F10))
        {
            Debug.Log("10000");
            deleteHp.TakeDamage(10000);
        }
    }
}

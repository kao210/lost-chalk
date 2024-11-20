using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class shortcut : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "player")
        {
            transform.DOLocalMove(new Vector3(-55f, 0, 0), 0.1f);
        }
    }
}

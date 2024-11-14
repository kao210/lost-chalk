using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RespawnPlayer : MonoBehaviour
{
    [SerializeField][Tooltip("GameObject")]
    private GameObject PlayerPrefab;
    // Start is called before the first frame update
    void Start()
    {
        Singleton.instance.AddHp();
    }

    // Update is called once per frame
    void Update()
    {
        GameObject playerObj = GameObject.Find(PlayerPrefab.name);

        //if(playerObj == null)
        //{
        //    GameObject newPlayerObj = Instantiate(PlayerPrefab);
        //}

        //newPlayerObj.name = PlayerPrefab.name;
    }
}

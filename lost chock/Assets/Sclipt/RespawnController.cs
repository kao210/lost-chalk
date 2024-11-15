using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RespawnController : MonoBehaviour
{
    [SerializeField] int respawnNumber = 0;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("player"))//Tag‚Â‚¢‚Ä‚¢‚é‚©Šm”F
        {
            Singleton.instance.SetRespawnNumber(respawnNumber);
        }
    }
}

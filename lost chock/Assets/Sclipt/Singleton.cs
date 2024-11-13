using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Singleton : MonoBehaviour
{
    public static Singleton instance;

    private int startMaxHp = 200;

    //getMaxHp‚ğŒÄ‚Ño‚·‚Æ•Ô‚Á‚Ä‚­‚é
    public int GetMaxHp()
    {
        return maxHp;
    }

    private int maxHp = 200;

    //‚â‚ç‚ê‚½uŠÔ“Ç‚İ‚Ü‚ê‚é
    public void AddHp()
    {
        maxHp += 10;
    }

    public void ResetHp()
    {
        maxHp = startMaxHp;
    }
    
    
    private void Awake()
    {
        //instance‚Ì’†g‚ª‹ó‚Ì
        if(instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            //V‚µ‚­Œ»‚ê‚½instance‚Í‚¢‚ç‚È‚¢‚Ì‚Å”j‰ó‚·‚é
            Destroy(gameObject);
        }
    }
}

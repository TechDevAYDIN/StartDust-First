using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManage : MonoBehaviour
{
    public static AudioClip Move, CollectLittle, Death1, MSClick, lvlclick, NCollect, ExpBig, Coin, Passed;
    static AudioSource audioSrc;
    // Start is called before the first frame update
    void Start()
    {
        Move = Resources.Load<AudioClip>("Move");
        CollectLittle = Resources.Load<AudioClip>("CollectLittle");
        Death1 = Resources.Load<AudioClip>("Death1");
        MSClick = Resources.Load<AudioClip>("MSClick");
        lvlclick = Resources.Load<AudioClip>("lvlclick");
        NCollect = Resources.Load<AudioClip>("NCollect");
        ExpBig = Resources.Load<AudioClip>("ExpBig");
        Coin = Resources.Load<AudioClip>("Coin");
        Passed = Resources.Load<AudioClip>("Passed");
        audioSrc = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public static void PlaySound(string clip)
    {
        switch (clip)
        {
            case "Move":
                audioSrc.PlayOneShot(Move);    
                break;
            case "CollectLittle":
                audioSrc.PlayOneShot(CollectLittle);
                break;
            case "Death1":
                audioSrc.PlayOneShot(Death1);
                break;
            case "MSClick":
                audioSrc.PlayOneShot(MSClick);
                break;
            case "lvlclick":
                audioSrc.PlayOneShot(lvlclick);
                break;
            case "NCollect":
                audioSrc.PlayOneShot(NCollect);
                break;
            case "ExpBig":
                audioSrc.PlayOneShot(ExpBig);
                break;
            case "Coin":
                audioSrc.PlayOneShot(Coin);
                break;
            case "Passed":
                audioSrc.PlayOneShot(Passed);
                break;
        }
    }
}

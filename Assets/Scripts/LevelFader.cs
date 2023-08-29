using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelFader : MonoBehaviour
{
    public Animator anim;
    public int leveltoLoad;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        leveltoLoad = LevelUnlock.thisbtnlvl;
        if (leveltoLoad > 0)
        {
            FadetoLevel();
        }
    }
    public void FadetoLevel()
    {
        anim.SetTrigger("FadeOut");
    }
    public void OnFadeComplete()
    {      
        SceneManager.LoadScene(leveltoLoad);
        LevelUnlock.thisbtnlvl = 0;
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MotionIntro : MonoBehaviour
{
    Animator anim;
    // Use this for initialization
    void Start()
    {
        var videoPlayer = this.GetComponent<UnityEngine.Video.VideoPlayer>();
        videoPlayer.targetCamera = GameObject.Find("Main Camera").GetComponent<Camera>();
        videoPlayer.loopPointReached += EndReached;
        anim = GameObject.Find("SceneChanger").GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {

    }
    void EndReached(UnityEngine.Video.VideoPlayer vp)
    {
        anim.SetTrigger("FadeOut");
        Destroy(GameObject.Find("Menus/MotionIntro/Button"));
    }
    public void OnClickSkip(){

        anim.SetTrigger("FadeOut");
        Destroy(GameObject.Find("Menus/MotionIntro/Button"));
    }

}


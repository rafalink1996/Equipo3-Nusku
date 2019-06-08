using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Video;

public class MotionIntro : MonoBehaviour
{
    Animator anim;
    VideoPlayer videoPlayer;
    // Use this for initialization
    void Start()
    {
        videoPlayer = this.GetComponent<UnityEngine.Video.VideoPlayer>();
        //var videoPlayer = this.GetComponent<UnityEngine.Video.VideoPlayer>();
        videoPlayer.targetCamera = GameObject.Find("Main Camera").GetComponent<Camera>();
        videoPlayer.loopPointReached += EndReached;
        anim = GameObject.Find("SceneChanger").GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        //var videoPlayer = this.GetComponent<UnityEngine.Video.VideoPlayer>();
        if (Input.GetButtonDown("Interact") || Input.GetButtonDown("Pause"))
        {
            videoPlayer.Stop();
            anim.SetTrigger("FadeOut");
            Destroy(GameObject.Find("Menus/MotionIntro/Button"));
        }
    }
    void EndReached(UnityEngine.Video.VideoPlayer vp)
    {
        anim.SetTrigger("FadeOut");
        Destroy(GameObject.Find("Menus/MotionIntro/Button"));
    }
    //public void OnClickSkip(){

    //    anim.SetTrigger("FadeOut");
    //    Destroy(GameObject.Find("Menus/MotionIntro/Button"));
    //}

}


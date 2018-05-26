
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelChanger2 : MonoBehaviour {

    public Animator animator;
   private  int LevelToLoad;



    /*public void ChangeSceneTriggered ()
    {
        FadeToLevel(2);
    }
*/

    /*void OnTriggerEnter(Collider other)
    {
        FadeToLevel(2);
    }
*/
	// Update is called once per frame
	void Update () {
        if (Input.GetMouseButtonDown(0))
        {
            FadeToLevel(2);
        }
	}

    public void FadeToLevel(int levelIndex)
    {
        LevelToLoad = levelIndex;
        animator.SetTrigger("FadeOut");
    }

    public void OnFadeComplete ()
    {
        SceneManager.LoadScene(LevelToLoad);
    }
}

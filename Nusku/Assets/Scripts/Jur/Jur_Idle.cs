using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Jur_Idle : StateMachineBehaviour {

    public float minTime;
    public float maxTime;
    public float timeToAttack;
    public bool isAttacking;
    public int attackType;
    public AudioSource jur;
    public AudioClip javelins;

	 // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
	override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex) {
        timeToAttack = Random.Range(minTime, maxTime);
        isAttacking = false;
        animator.ResetTrigger("BattleStart");
        animator.ResetTrigger("Emerge");
        animator.ResetTrigger("Stal");
        animator.ResetTrigger("Bite");
        animator.ResetTrigger("Bullet");
        animator.ResetTrigger("Javalin");
        animator.ResetTrigger("Dive");
        FindObjectOfType<PlayerMovement2D>().canMove = true;
        jur = GameObject.Find("Jur").GetComponent<AudioSource>();
	}

	// OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
	override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex) {
        if (timeToAttack <= 0 && !isAttacking)
        {
            attackType = Random.Range(1, 101);
            //animator.SetInteger("attackType", Random.Range(0, 6));
            //animator.SetTrigger("Attack");
            isAttacking = true;
        }else{
            timeToAttack -= Time.deltaTime;
            attackType = 0;
        }
        if (timeToAttack <= -0.5f)
        {
            timeToAttack = 0.1f;
            isAttacking = false;
        }
        if (attackType >= 1 && attackType <=20)
        {
            animator.SetTrigger("Stal");
        }
        if (attackType >= 21 && attackType <= 55)
        {
            animator.SetTrigger("Bite");
        }
        if (attackType >= 56 && attackType <= 75)
        {
            animator.SetTrigger("Bullet");
        }
        if (attackType >= 76 && attackType <= 90)
        {
            animator.SetTrigger("Javalin");
            jur.PlayOneShot(javelins, 1);
        }
        if (attackType >= 91 && attackType <= 100)
        {
            animator.SetTrigger("Dive");
        }
        if (animator.GetBool("StalactitesFalling") == true)
        {
            GameObject stalactite1 = GameObject.Instantiate(Resources.Load("Prefabs/Stalactite") as GameObject);
            GameObject stalactite2 = GameObject.Instantiate(Resources.Load("Prefabs/Stalactite") as GameObject);
            GameObject stalactite3 = GameObject.Instantiate(Resources.Load("Prefabs/Stalactite") as GameObject);
            stalactite1.transform.SetParent(GameObject.Find("Lanes/1").transform);
            stalactite2.transform.SetParent(GameObject.Find("Lanes/2").transform);
            stalactite3.transform.SetParent(GameObject.Find("Lanes/3").transform);
            stalactite1.transform.localPosition = new Vector3(Random.Range(-0.85f, 0.02f), Random.Range(-2.27f, 1.71f), 0f);
            stalactite2.transform.localPosition = new Vector3(Random.Range(-0.85f, 0.02f), Random.Range(-2.27f, 1.71f), 0f);
            stalactite3.transform.localPosition = new Vector3(Random.Range(-0.85f, 0.02f), Random.Range(-2.27f, 1.71f), 0f);
            timeToAttack = maxTime;
            animator.SetBool("StalactitesFalling", false);
        }
	}

	// OnStateExit is called when a transition ends and the state machine finishes evaluating this state
	override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex) {

	}

	// OnStateMove is called right after Animator.OnAnimatorMove(). Code that processes and affects root motion should be implemented here
	//override public void OnStateMove(Animator animator, AnimatorStateInfo stateInfo, int layerIndex) {
	//
	//}

	// OnStateIK is called right after Animator.OnAnimatorIK(). Code that sets up animation IK (inverse kinematics) should be implemented here.
	//override public void OnStateIK(Animator animator, AnimatorStateInfo stateInfo, int layerIndex) {
	//
	//}
}

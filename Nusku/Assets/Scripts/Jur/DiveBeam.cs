using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DiveBeam : StateMachineBehaviour {

    Transform sel;
    float time = 1.5f;
    bool beam;
    int beams = 3;

	 // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
	override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex) {
        sel = GameObject.FindWithTag("Player").GetComponent<Transform>();
        time = 1.5f;
	}

	// OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
	override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex) {
        time -= Time.deltaTime;
        if (time <= 0 && beams != 0)
        {
            beam = true;
        }
        if (beam == true)
        {
            GameObject diveBeam = GameObject.Instantiate(Resources.Load("Prefabs/DiveBeam") as GameObject);
            diveBeam.transform.position = sel.position;
            diveBeam.name = "DiveBeam";
            beams = beams - 1;
            time = 1.5f;
            beam = false;
        }
        if (beams == 0)
        {
            animator.SetTrigger("Emerge");
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

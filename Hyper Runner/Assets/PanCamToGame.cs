using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PanCamToGame : StateMachineBehaviour {
    // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    // Will load game scene on animation start
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex) {
        animator.gameObject.GetComponent<ArcadeAnimationCamera>().machine.LoadGameScene();
    }
}

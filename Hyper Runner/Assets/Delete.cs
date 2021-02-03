using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Delete : StateMachineBehaviour
{
    // Will destroy the object as soon as this animator state is entered.
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
      Destroy(this);
    }

}

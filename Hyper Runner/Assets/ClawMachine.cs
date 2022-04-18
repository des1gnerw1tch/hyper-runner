using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClawMachine : AInteractableArcadeObject
{
    [SerializeField] private Animator animator;
    public override void Interact(InteractArcade player)
    {
        base.Interact(player);
        animator.SetTrigger("Activate");
    }
}

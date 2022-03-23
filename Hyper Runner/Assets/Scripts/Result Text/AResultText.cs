using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class AResultText : MonoBehaviour 
{
    [SerializeField] public AResultText next;

    // activates this result text, starts animation
    public abstract void Activate();

    // activates the next result text
    public void ActivateNext() {
        if (this.next != null) {
            this.next.Activate();
        }
    }
}

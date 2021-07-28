using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlashPanel : MonoBehaviour {
    [SerializeField] private Color flashColor;
    [SerializeField] private Animator animator;

    // flashes this flash panel with set color
    public void Flash() {
        this.animator.SetTrigger("Flash");
    }
}

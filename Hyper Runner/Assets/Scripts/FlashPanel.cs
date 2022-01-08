using UnityEngine.UI;
using UnityEngine;

public class FlashPanel : MonoBehaviour {
    [SerializeField] private Image panel;
    [SerializeField] private Animator animator;

    // flashes this flash panel with set color
    public void Flash(Color color)
    {
        this.panel.color = color;
        this.animator.SetTrigger("Flash");
    }
}

using UnityEngine;

namespace SelectableUIElements
{
    /// <summary>
    /// A selectable element in a UI grid.
    /// </summary>
    public abstract class ASelectableElement : MonoBehaviour
    {
        [SerializeField] protected string selectedSound;
        [SerializeField] private string highlightSound;
        
        // When this UI element is selected with the Select button
        public virtual void Selected() => FindObjectOfType<AudioManager>().Play(selectedSound);

        // When UI element highlighted state
        public virtual void Highlight() => FindObjectOfType<AudioManager>().Play(highlightSound);

        // UI element finish highlighted state
        public abstract void StopHighlight();
    }
}

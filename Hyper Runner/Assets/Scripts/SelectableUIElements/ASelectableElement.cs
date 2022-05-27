using UnityEngine;

namespace SelectableUIElements
{
    /// <summary>
    /// A selectable element in a UI grid.
    /// </summary>
    public abstract class ASelectableElement : MonoBehaviour
    {
        // When this UI element is selected with the Select button
        public abstract void Selected();
        
        // When UI element highlighted state
        public abstract void Highlight();
        
        // UI element finish highlighted state
        public abstract void StopHighlight();
    }
}

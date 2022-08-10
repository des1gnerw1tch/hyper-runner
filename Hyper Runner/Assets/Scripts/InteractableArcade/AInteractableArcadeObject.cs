using UnityEngine;

namespace InteractableArcade
{
    /// <summary>
    /// A arcade object the player can interact with. Requires a trigger collider. 
    /// </summary>
    [RequireComponent(typeof(Collider))]
    public abstract class AInteractableArcadeObject : MonoBehaviour
    {
        [SerializeField] protected GameObject popUpText;

        private void Start()
        {
            UIInputHandler.Instance.OnPause.AddListener(Close);
            UIInputHandler.Instance.OnBackButton.AddListener(Close);
        }
        
        // Player interacts with this arcade object
        public virtual void Interact(InteractArcade player)
        {
            popUpText.SetActive(false);
        }

        // Player disengages with this arcade object
        protected virtual void Close() { }

        void OnTriggerEnter(Collider other)
        {
            if (other.CompareTag("Player"))
            {
                popUpText.SetActive(true);
                other.gameObject.GetComponent<InteractArcade>().SetCurrentInteractable(this);
            }
        }

        void OnTriggerExit(Collider other)
        {
            if (other.CompareTag("Player"))
            {
                popUpText.SetActive(false);
                other.gameObject.GetComponent<InteractArcade>().ClearCurrentInteractable();
            }
        }
    }
}

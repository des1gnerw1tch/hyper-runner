using SaveFileSystem;

namespace InteractableArcade
{
    public class ATMMachine : AInteractableArcadeObject
    {
        public override void Interact(InteractArcade player)
        {
            base.Interact(player);
            GameDataManager.Instance.AddTokens(1);
        }
    }
}

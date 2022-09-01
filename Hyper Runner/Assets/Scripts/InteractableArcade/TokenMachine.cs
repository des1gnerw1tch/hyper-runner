using Achievements;

namespace InteractableArcade
{
    /// <summary>
    /// Used to access achievement window.
    /// </summary>
    public class TokenMachine : InteractableArcadeObjectUI
    {
        public override void Interact(InteractArcade player)
        {
            base.Interact(player);
            AchievementsUIHelper.Instance.UpdateContent();
        }
    }
}

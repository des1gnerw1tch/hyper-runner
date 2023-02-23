using Achievements;

namespace InteractableArcade
{
    public class ATMMachine : AInteractableArcadeObject
    {
        public override void Interact(InteractArcade player)
        {
            base.Interact(player);
            FindObjectOfType<AudioManager>().Play("atm");
            AchievementManager.Instance.CompleteAchievementWithID("interactWithATM");
        }
    }
}

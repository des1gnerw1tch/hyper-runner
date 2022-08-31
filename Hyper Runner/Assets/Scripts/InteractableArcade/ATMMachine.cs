using Achievements;
using SaveFileSystem;

namespace InteractableArcade
{
    public class ATMMachine : AInteractableArcadeObject
    {
        public override void Interact(InteractArcade player)
        {
            base.Interact(player);
            FindObjectOfType<TestAchievement1>().CompleteAchievement();
        }
    }
}

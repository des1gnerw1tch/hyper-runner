using System.Collections;
using System.Collections.Generic;
using Currency;
using UnityEngine;

namespace InteractableArcade
{
    public class ATMMachine : AInteractableArcadeObject
    {
        public override void Interact(InteractArcade player)
        {
            base.Interact(player);
            PlayerCurrency.Instance.AddBalance(1);
        }
    }
}

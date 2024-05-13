using SelectableUIElements;
using UnityEngine;

namespace Telephone
{
    public class TelephoneNumberSelectableElement : ASelectableElement
    {
        [SerializeField] private TelephoneDial telephoneDial;
        [SerializeField] private int number;

        public override void Highlight() => transform.localScale = Vector3.one * 1.5f;

        public override void StopHighlight() => transform.localScale = Vector3.one * 1f;

        public override void Selected()
        {
            base.Selected();
            telephoneDial.PressNumber(number);
        }
    }
}

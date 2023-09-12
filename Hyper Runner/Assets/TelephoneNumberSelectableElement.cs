using SelectableUIElements;
using UnityEngine;

public class TelephoneNumberSelectableElement : ASelectableElement
{

    public override void Highlight() => transform.localScale = Vector3.one * 1.5f;

    public override void StopHighlight() => transform.localScale = Vector3.one * 1f;
}

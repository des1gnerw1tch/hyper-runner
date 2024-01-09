using UnityEngine;

public class TelephoneUIContent : MonoBehaviour
{
    [SerializeField] private TelephoneDial dial;
    private void OnEnable() => dial.ClearPhoneNumber();
}

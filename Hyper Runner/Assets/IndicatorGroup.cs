using UnityEditor;
using UnityEngine;

public class IndicatorGroup : MonoBehaviour
{
    [Header("Needed Serialization")]
    [SerializeField] private RectTransform[] indicators;
    [SerializeField] private RectTransform[] buttons; // this should be the locations of the buttons
    
    [Header("Auto Completed Serialization")]
    [SerializeField] private UIInputHandler uiInputHandler;
    
    private int currentSelection;

    private void Start()
    {
        uiInputHandler = FindObjectOfType<UIInputHandler>();
        uiInputHandler.OnScrollUp.AddListener(OnUp);
        uiInputHandler.OnScrollDown.AddListener(OnDown);
        uiInputHandler.OnScrollLeft.AddListener(OnLeft);
        uiInputHandler.OnScrollRight.AddListener(OnRight);

        currentSelection = 0;
        UpdateIndicatorPosition();
    }

    void UpdateIndicatorPosition()
    {
        foreach (RectTransform indicator in indicators)
        {
            Vector3 pos = new Vector3(indicator.position.x, buttons[currentSelection].position.y, indicator.position.z);
            indicator.position = pos;
        }
    }
    void OnUp()
    {
        currentSelection = Mathf.Clamp(currentSelection - 1, 0, buttons.Length - 1);
        UpdateIndicatorPosition();
    }

    void OnDown()
    {
        currentSelection = Mathf.Clamp(currentSelection + 1, 0, buttons.Length - 1);
        UpdateIndicatorPosition();
    }

    void OnLeft()
    {
        
    }

    void OnRight()
    {
        
    }


}

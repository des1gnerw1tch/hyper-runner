using System;
using System.Collections;
using UnityEngine;

public class IndicatorGroup : MonoBehaviour
{
    
    [Header("Needed Serialization")]
    [SerializeField] private RectTransform[] indicators;
    [SerializeField] private RectTransform[] buttons; // this should be the locations of the buttons
    [SerializeField] private AInGamePauseButton[] buttonsActions; // related to the action this button does
    [SerializeField] private float indicatorMoveSpeed;
    [SerializeField] private Animator[] buttonsAnimators;
    [SerializeField] private bool resetCurrentSelectionOnResume = true;
    
    [Header("Auto Completed Serialization")]
    [SerializeField] private UIInputHandler uiInputHandler;
    
    private int currentSelection; // the current button selection 
    private float indicatorYPos;
    private Coroutine lastRoutine;

    private void Start()
    {
        uiInputHandler = FindObjectOfType<UIInputHandler>();
        uiInputHandler.OnScrollUp.AddListener(OnUp);
        uiInputHandler.OnScrollDown.AddListener(OnDown);
        uiInputHandler.OnScrollLeft.AddListener(OnLeft);
        uiInputHandler.OnScrollRight.AddListener(OnRight);
        uiInputHandler.OnSelectOption.AddListener(OnSelect);
    }

    void OnEnable()
    {
        if (resetCurrentSelectionOnResume)
        {
            currentSelection = 0;
        }

        foreach (RectTransform indicator in indicators)
        {
            indicator.transform.position = new Vector3(indicator.transform.position.x,
                buttons[currentSelection].position.y, indicator.transform.position.z);
        }
        
        buttonsAnimators[currentSelection].SetBool("isHoveredOver", true);
    }
    
    void UpdateIndicatorPosition()
    {
        if (!Mathf.Approximately(indicators[0].position.y, buttons[currentSelection].position.y))
        {
            indicatorYPos = buttons[currentSelection].position.y;
            if (lastRoutine != null)
            {
                StopCoroutine(lastRoutine);
            }
            lastRoutine = StartCoroutine("MoveIndicatorsToNewPosition");
        }
    }
    
    /// <summary>
    /// Moves Indicators to new position once dictated by an input. Was very tedious to make, took me around 1 hour!
    /// </summary>
    IEnumerator MoveIndicatorsToNewPosition()
    {
        bool processDone = false;
        while (!processDone)
        {
            if (!Mathf.Approximately(indicators[0].transform.position.y, indicatorYPos))
            {
                float increment;
                float step = indicatorMoveSpeed * Time.unscaledDeltaTime;
                if (indicatorYPos > indicators[0].transform.position.y)
                {
                    if (indicators[0].transform.position.y + step > indicatorYPos)
                    {
                        increment = indicatorYPos - indicators[0].transform.position.y;
                        processDone = true;
                    }
                    else
                    {
                        increment =  step;
                    }
                }
                else
                {
                    if (indicators[0].transform.position.y -  step < indicatorYPos)
                    {
                        increment = -(indicators[0].transform.position.y - indicatorYPos);
                        processDone = true;
                    }
                    else
                    {
                        increment = -step;
                    }
                }
            
                foreach (RectTransform indicator in indicators)
                {
                    indicator.transform.position = new Vector3(indicator.transform.position.x, 
                        indicator.transform.position.y + increment, indicator.transform.position.z);
                }
            }
            
            yield return new WaitForEndOfFrame();
        }
    }
    void OnUp()
    {
        int oldSelection = currentSelection;
        currentSelection = Mathf.Clamp(currentSelection - 1, 0, buttons.Length - 1);
        
        UpdateStatesIfNewSelection(oldSelection);
    }

    void OnDown()
    {
        int oldSelection = currentSelection;
        currentSelection = Mathf.Clamp(currentSelection + 1, 0, buttons.Length - 1);
        
        UpdateStatesIfNewSelection(oldSelection);
    }

    void UpdateStatesIfNewSelection(int oldSelection)
    {
        if (oldSelection != currentSelection && gameObject.activeSelf)
        {
            buttonsAnimators[oldSelection].SetBool("isHoveredOver", false);
            buttonsAnimators[currentSelection].SetBool("isHoveredOver", true);
            FindObjectOfType<AudioManager>().Play("scroll");
            UpdateIndicatorPosition();
        }
    }

    void OnLeft()
    {
        
    }

    void OnRight()
    {
        
    }

    void OnSelect()
    {
        buttonsActions[currentSelection].OnClick();
    }


}

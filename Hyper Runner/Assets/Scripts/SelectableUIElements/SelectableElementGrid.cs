using UnityEngine;

namespace SelectableUIElements
{
    /// <summary>
    /// Represents a grid of selectable UI elements that can be navigated through using a controller
    /// </summary>
    public class SelectableElementGrid : MonoBehaviour
    {
        [System.Serializable]
        private struct Row
        {
            public ASelectableElement[] column;
        }

        [SerializeField]
        private Row[] row;
        
        private int currentRow;
        private int currentColumn;

        private void Start()
        {
            currentRow = 0;
            currentColumn = 0;
            HighlightCurrentElement();
        }

        private void OnEnable() => AddInputListeners();

        private void OnDisable() => RemoveInputListeners();

        private void AddInputListeners()
        {
            UIInputHandler uiInputHandler = UIInputHandler.Instance;
            
            if (uiInputHandler != null)
            {
                uiInputHandler.OnScrollLeft.AddListener(OnLeft);
                uiInputHandler.OnScrollRight.AddListener(OnRight);
                uiInputHandler.OnScrollUp.AddListener(OnUp);
                uiInputHandler.OnScrollDown.AddListener(OnDown);
                uiInputHandler.OnSelectOption.AddListener(OnSelect);
            }
        }
        
        private void RemoveInputListeners()
        {
            UIInputHandler uiInputHandler = UIInputHandler.Instance;

            if (uiInputHandler != null)
            {
                uiInputHandler.OnScrollLeft.RemoveListener(OnLeft);
                uiInputHandler.OnScrollRight.RemoveListener(OnRight);
                uiInputHandler.OnScrollUp.RemoveListener(OnUp);
                uiInputHandler.OnScrollDown.RemoveListener(OnDown);
                uiInputHandler.OnSelectOption.RemoveListener(OnSelect);
            }
        }

        #region Inputs Handlers

        private void OnLeft()
        {
            if (currentColumn == 0)
            {
                return;
            }
         
            StopHighlightCurrentElement();
            currentColumn--;
            HighlightCurrentElement();

        }

        private void OnRight()
        {
            if (currentColumn == row[currentRow].column.Length - 1)
            {
                return;
            }

            StopHighlightCurrentElement();
            currentColumn++;
            HighlightCurrentElement();
        }


        private void OnUp()
        {
            if (currentRow == 0)
            {
                return;
            }
            
            StopHighlightCurrentElement();
            currentRow--;
            ClampColumn();
            HighlightCurrentElement();
        }

        private void OnDown()
        {
            if (currentRow == row.Length - 1)
            {
                return;
            }
            
            StopHighlightCurrentElement();
            currentRow++;
            ClampColumn();
            HighlightCurrentElement();
        }

        private void OnSelect() => SelectCurrentElement();

        #endregion
        
        private void SelectCurrentElement() => row[currentRow].column[currentColumn].Selected();
        
        private void HighlightCurrentElement() => row[currentRow].column[currentColumn].Highlight();
        
        private void StopHighlightCurrentElement() => row[currentRow].column[currentColumn].StopHighlight();

        // Handles traversing rows with a different number of columns
        private void ClampColumn()
        {
            if (currentColumn >= row[currentRow].column.Length)
            {
                currentColumn = row[currentRow].column.Length - 1;
            }
        }
    }
}

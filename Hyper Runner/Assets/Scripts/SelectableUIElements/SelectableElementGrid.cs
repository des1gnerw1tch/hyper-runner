using UnityEngine;
using UnityEngine.InputSystem;

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
        }
        
        #region Input handlers

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
            HighlightCurrentElement();

            ClampColumn();
        }

        private void OnDown()
        {
            if (currentRow == row.Length - 1)
            {
                return;
            }
            
            StopHighlightCurrentElement();
            currentRow++;
            HighlightCurrentElement();
            
            ClampColumn();
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
                currentColumn = row[currentRow].column.Length;
            }
        }
    }
}

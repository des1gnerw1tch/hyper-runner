using UnityEngine;

namespace BossFight.Cyber
{
    public class RaceProgressDot : MonoBehaviour
    {
        [SerializeField] private Transform finishLine;
        [SerializeField] private Transform car;
        [SerializeField] private RectTransform startPointMarker;
        [SerializeField] private RectTransform endPointMarker;
        [SerializeField] private RectTransform carMarker;

        // Update is called once per frame
        void Update()
        {
            carMarker.anchoredPosition = new Vector2(carMarker.anchoredPosition.x, 
                Mathf.Lerp(startPointMarker.anchoredPosition.y, endPointMarker.anchoredPosition.y, Mathf.Clamp(car.position.z / finishLine.position.z, 0, 1)));
        }
    }
}

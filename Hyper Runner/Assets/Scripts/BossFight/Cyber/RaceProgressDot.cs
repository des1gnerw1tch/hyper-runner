using System.Collections;
using UnityEngine;

namespace BossFight.Cyber
{
    public class RaceProgressDot : MonoBehaviour
    {
        [SerializeField] private Transform finishLine;
        [SerializeField] private Transform car;
        [SerializeField] private ARacingCar racingCar;
        [SerializeField] private RectTransform startPointMarker;
        [SerializeField] private RectTransform endPointMarker;
        [SerializeField] private RectTransform carMarker;

        // Update is called once per frame
        private void Start()
        {
            racingCar.GetCarHitEvent().AddListener(SpinAnim);
        }
        private void Update()
        {
            carMarker.anchoredPosition = new Vector2(carMarker.anchoredPosition.x, 
                Mathf.Lerp(startPointMarker.anchoredPosition.y, endPointMarker.anchoredPosition.y, Mathf.Clamp(car.position.z / finishLine.position.z, 0, 1)));
        }

        private void SpinAnim()
        {
            StartCoroutine(_SpinAnim(racingCar.GetTimeToSpinAfterCrash()));
        }

        private IEnumerator _SpinAnim(float timeToSpin)
        {
            float timeElapsed = 0f;
            while (timeElapsed <= timeToSpin)
            {
                carMarker.SetPositionAndRotation(carMarker.position, Quaternion.Euler(0, 0, Mathf.Lerp(0, 360, timeElapsed / timeToSpin)));
                timeElapsed += Time.deltaTime;
                yield return null;
            }
            carMarker.SetPositionAndRotation(carMarker.position, Quaternion.Euler(0, 0, 0));
        }
    }
}

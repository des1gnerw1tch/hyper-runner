using UnityEngine;

namespace BossFight.Cyber
{
    public class BossCarAI : ARacingCar
    {
        [SerializeField] private Transform raycastOrigin;
        [SerializeField] private bool showDebugRaycasts;
        [SerializeField] private float minDistanceFromNearestVehicleToAccelerate;
        [SerializeField] private float maxDistanceFromNearestVehicleToBrake;
        [SerializeReference] private float minHorizontalDistanceBetweenObjects;

        private float distanceFrom0;
        private float distanceFrom45;
        private float distanceFrom90;
        private float distanceFromNeg45;
        private float distanceFromNeg90;
        
        
        
        protected override void Update()
        {
            UpdateVisionData();
            base.Update();
        }
        
        private void UpdateVisionData()
        {
            distanceFrom0 = HitDistanceFromRaycastAtAngle(0);
            distanceFrom45 = HitDistanceFromRaycastAtAngle(10);
            distanceFrom90 = HitDistanceFromRaycastAtAngle(90);
            distanceFromNeg45 = HitDistanceFromRaycastAtAngle(-10);
            distanceFromNeg90 = HitDistanceFromRaycastAtAngle(-90);
        }

        private float HitDistanceFromRaycastAtAngle(float angle)
        {
            RaycastHit hit;
            Vector3 direction = Quaternion.Euler(0, angle, 0) * Vector3.back;
            if (Physics.Raycast(raycastOrigin.position, direction, out hit, Mathf.Infinity))
            {
                if (showDebugRaycasts)
                {
                    Debug.DrawRay(raycastOrigin.position, direction * hit.distance, Color.yellow);
                }
                return hit.distance;
            }
            else
            {
                if (showDebugRaycasts)
                {
                    Debug.DrawRay(raycastOrigin.position, direction * 1000, Color.white);
                }
                return Mathf.Infinity;
            }

        }
        
        protected override GasPedalState GetPlayerGasInput()
        {
            if (distanceFrom0 >= minDistanceFromNearestVehicleToAccelerate)
            {
                return GasPedalState.Gas;
            }
            else if (distanceFrom0 <= maxDistanceFromNearestVehicleToBrake)
            {
                return GasPedalState.Brake;
            }
            else
            {
                return GasPedalState.Neutral;
            }
        }
        
        
        protected override TurningDirection GetTurningDirectionInput()
        {
            return GetTurningDirectionTry2();
        }

        /// <summary>
        /// 1. Find max of -45, 0, 45 rays distance
        /// 2. Check if directional (-45, 45) rays are maximum. Move in that direction if horizontal ray
        ///    leaves enough space for car to turn. Otherwise, 
        /// 3. If 
        /// </summary>
        /// <returns></returns>
        private TurningDirection GetTurningDirectionTry1()
        {
            float[] distances = {distanceFromNeg45, distanceFrom0, distanceFrom45};
            int maxIndex = 0;
            for (int i = 0; i < distances.Length; i++)
            {
                if (distances[i] > distances[maxIndex])
                {
                    maxIndex = i;
                }
                
            }

            if (Mathf.Abs(distanceFrom45 - distanceFromNeg45) < 1f && maxIndex != 1)
            {
                return TurningDirection.Right;
            }
            
            if (distanceFromNeg45 > distanceFrom45)
            {
                if (distanceFromNeg90 > minHorizontalDistanceBetweenObjects)
                {
                    return TurningDirection.Left;
                }
            }
            else
            {
                if (distanceFrom90 > minHorizontalDistanceBetweenObjects)
                {
                    return TurningDirection.Right;
                }
            }

            return TurningDirection.None;
        }
        
        private TurningDirection GetTurningDirectionTry2()
        {
            float[] distances = {distanceFromNeg90, distanceFromNeg45, distanceFrom45, distanceFrom90};
            int maxIndex = 0;
            int minIndex = 0;
            for (int i = 0; i < distances.Length; i++)
            {
                if (distances[i] > distances[maxIndex])
                {
                    maxIndex = i;
                }
                if (distances[i] < distances[minIndex])
                {
                    minIndex = i;
                }
                
            }

            switch (minIndex)
            {
                case 0:
                    return TurningDirection.Right;
                case 1:
                    return TurningDirection.Right;
                case 2:
                    return TurningDirection.Left;
                default:
                    return TurningDirection.Left;
            }
        }
    }
}


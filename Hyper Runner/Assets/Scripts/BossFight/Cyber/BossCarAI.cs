using UnityEngine;

namespace BossFight.Cyber
{
    public class BossCarAI : ARacingCar
    {
        [SerializeField] private float targetSpeed;
        
        [SerializeField] private Transform raycastOriginMiddle;
        [SerializeField] private Transform raycastOriginRight;
        [SerializeField] private Transform raycastOriginLeft;
        [SerializeField] private BoxCollider carCollider;
        [SerializeField] private bool showDebugRaycasts;
        [SerializeField] private float minDistanceFromNearestVehicleToAccelerate;
        [SerializeField] private float maxDistanceFromNearestVehicleToBrake;
        [SerializeField] private float minHorizontalDistanceBetweenObjects;

        [SerializeField] private Transform playerCar;
        
        private float distanceFrom0Middle;
        private float distanceFrom45;
        private float distanceFrom90;
        private float distanceFromNeg45;
        private float distanceFromNeg90;
        private float distanceFrom0LeftSide;
        private float distanceFrom0RightSide;

        private bool isInBeginningCutscene = true;
        
        protected override void Update()
        {
            carCollider.enabled = !LosingRace();
            UpdateVisionData();
            base.Update();
        }

        private bool LosingRace()
        {
            return transform.position.z > playerCar.position.z;
        }
        
        private void UpdateVisionData()
        {
            distanceFrom0Middle = HitDistanceFromRaycastAtAngle(raycastOriginMiddle, 0);
            distanceFrom0LeftSide = HitDistanceFromRaycastAtAngle(raycastOriginLeft, 0);
            distanceFrom0RightSide = HitDistanceFromRaycastAtAngle(raycastOriginRight, 0);
            distanceFrom45 = HitDistanceFromRaycastAtAngle(raycastOriginMiddle, 10);
            distanceFrom90 = HitDistanceFromRaycastAtAngle(raycastOriginMiddle, 90);
            distanceFromNeg45 = HitDistanceFromRaycastAtAngle(raycastOriginMiddle, -10);
            distanceFromNeg90 = HitDistanceFromRaycastAtAngle(raycastOriginMiddle, -90);
        }

        private float HitDistanceFromRaycastAtAngle(Transform raycastOrigin, float angle)
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
            if (isInBeginningCutscene)
            {
                return GasPedalState.Neutral;
            }
            else if (FrontOfCarAllClearToAccelerate())
            {
                Debug.Log("Accelerating");
                return GasPedalState.Gas;
            }
            else if (IsSoonHeadOnCollision())
            {
                Debug.Log("Braking");
                return GasPedalState.Brake;
            }
            else
            {
                Debug.Log("Neutral");
                return GasPedalState.Neutral;
            }
        }
        
        private bool FrontOfCarAllClearToAccelerate()
        {
            return !HasReachedTargetSpeed() &&
                   (distanceFrom0Middle >= minDistanceFromNearestVehicleToAccelerate ||
                    distanceFrom0LeftSide >= minDistanceFromNearestVehicleToAccelerate ||
                    distanceFrom0RightSide >= minDistanceFromNearestVehicleToAccelerate);
        }

        private bool HasReachedTargetSpeed() => Mathf.Abs(GetVelocity()) > targetSpeed;


        protected override TurningDirection GetTurningDirectionInput()
        {
            return GetTurningDirectionTry3();
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
            float[] distances = {distanceFromNeg45, distanceFrom0Middle, distanceFrom45};
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
            
            // Check for soon head on collision
            if (IsSoonHeadOnCollision())
            {
                Debug.Log("Head on collision immininent");
                if (distanceFrom90 > minHorizontalDistanceBetweenObjects)
                {
                    Debug.Log("Turning Right");
                    return TurningDirection.Right;
                }
                else
                {
                    Debug.Log("Turning Left");
                    return TurningDirection.Left;
                }
            }
            
            // If no head on collision soon, check directional rays
            float buffer = 3;
            if (Mathf.Abs(distanceFromNeg45 - distanceFrom45) < buffer && Mathf.Abs(distanceFromNeg90 - distanceFrom90) < buffer)
            {
                Debug.Log("No turn direction");
                return TurningDirection.None;
            }

            switch (minIndex)
            {
                case 0:
                    Debug.Log("Turning Right");
                    return TurningDirection.Right;
                case 1:
                    Debug.Log("Turning Right");
                    return TurningDirection.Right;
                case 2:
                    Debug.Log("Turning Left");
                    return TurningDirection.Left;
                default:
                    Debug.Log("Turning Left");
                    return TurningDirection.Left;
            }
        }
        
        private TurningDirection GetTurningDirectionTry3()
        {
            if (isInBeginningCutscene)
            {
                return TurningDirection.None;
            }
            // Check for soon head on collision
            if (IsSoonHeadOnCollision())
            {
                Debug.Log("Head on collision immininent");
                if (distanceFrom90 > minHorizontalDistanceBetweenObjects)
                {
                    Debug.Log("Turning Right");
                    return TurningDirection.Right;
                }
                else
                {
                    Debug.Log("Turning Left");
                    return TurningDirection.Left;
                }
            }
            
            // If no head on collision soon, check directional rays
            float buffer = 20;
            if (Mathf.Abs(distanceFromNeg45 - distanceFrom45) < buffer)
            {
                Debug.Log("No turn direction");
                return TurningDirection.None;
            }

            if (distanceFromNeg45 > distanceFrom45)
            {
                Debug.Log("Turning Left");
                return TurningDirection.Left;
            }
            else
            {
                Debug.Log("Turning Right");
                return TurningDirection.Right;
            }
        }

        private bool IsSoonHeadOnCollision()
        {
            return distanceFrom0Middle < maxDistanceFromNearestVehicleToBrake ||
                   distanceFrom0LeftSide < maxDistanceFromNearestVehicleToBrake ||
                   distanceFrom0RightSide < maxDistanceFromNearestVehicleToBrake;
        }

        public void SetIsInBeginningCutscene(bool value)
        {
            isInBeginningCutscene = value;
        }
    }
}


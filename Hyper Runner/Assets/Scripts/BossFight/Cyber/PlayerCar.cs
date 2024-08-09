using UnityEngine;

namespace BossFight.Cyber
{
    public class PlayerCar : ARacingCar
    {
        [SerializeField] private float acceleration;
        [SerializeField] private float brakeAcceleration;
        
        [SerializeField] private Transform playerCam;
        [SerializeField] private float camTiltAngleWhileTurn;

        protected override TurningDirection GetTurningDirectionInput()
        {
            bool turningLeft = Input.GetKey("a");
            bool turningRight = Input.GetKey("d");
            if ((turningLeft && turningRight) || (!turningLeft && !turningRight))
            {
                ResetCamTilt();
                return TurningDirection.None;
            }
            if (turningLeft)
            {
                TiltCamLeft();
                return TurningDirection.Left;
            }
            TiltCamRight();
            return TurningDirection.Right;
        }

        protected override void BumpedIntoObject()
        {
            base.BumpedIntoObject();
            ResetCamTilt();
        }

        protected override void HandlePlayerSpeedInput()
        {
            if (Input.GetKey("w"))
            {
                velocity += acceleration;
            }
            if (Input.GetKey("s"))
            {
                velocity -= brakeAcceleration;
            }
        }

        private void ResetCamTilt()
        {
            Vector3 camEulerAngles = playerCam.eulerAngles;
            playerCam.rotation = Quaternion.Euler(camEulerAngles.x, camEulerAngles.y, 0);
        }

        private void TiltCamLeft()
        {
            Vector3 camEulerAngles = playerCam.eulerAngles;
            playerCam.rotation = Quaternion.Euler(camEulerAngles.x, camEulerAngles.y, -camTiltAngleWhileTurn);
        }
        
        private void TiltCamRight()
        {
            Vector3 camEulerAngles = playerCam.eulerAngles;
            playerCam.rotation = Quaternion.Euler(camEulerAngles.x, camEulerAngles.y, camTiltAngleWhileTurn);
        }
    }
}

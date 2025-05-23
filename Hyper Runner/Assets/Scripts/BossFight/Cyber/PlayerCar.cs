using UnityEngine;

namespace BossFight.Cyber
{
    public class PlayerCar : ARacingCar
    {
        [SerializeField] private Transform playerCam;
        [SerializeField] private Transform playerCar;
        [SerializeField] private float camTiltAngleWhileTurn;
        [SerializeField] private float carTiltAngleWhileTurn;

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

        protected override GasPedalState GetPlayerGasInput()
        {
            if (Input.GetKey("w"))
            {
                return GasPedalState.Gas;
            }
            if (Input.GetKey("s"))
            {
                return GasPedalState.Brake;
            }
            return GasPedalState.Neutral;
        }

        private void ResetCamTilt()
        {
            Vector3 camEulerAngles = playerCam.eulerAngles;
            playerCam.rotation = Quaternion.Euler(camEulerAngles.x, camEulerAngles.y, 0);
            Vector3 carEulerAngles = playerCar.eulerAngles;
            playerCar.rotation = Quaternion.Euler(carEulerAngles.x, 0, carEulerAngles.z);
        }

        private void TiltCamLeft()
        {
            Vector3 camEulerAngles = playerCam.eulerAngles;
            playerCam.rotation = Quaternion.Euler(camEulerAngles.x, camEulerAngles.y, -camTiltAngleWhileTurn);
            Vector3 carEulerAngles = playerCar.eulerAngles;
            playerCar.rotation = Quaternion.Euler(carEulerAngles.x, -carTiltAngleWhileTurn, carEulerAngles.z);
        }
        
        private void TiltCamRight()
        {
            Vector3 camEulerAngles = playerCam.eulerAngles;
            playerCam.rotation = Quaternion.Euler(camEulerAngles.x, camEulerAngles.y, camTiltAngleWhileTurn);
            Vector3 carEulerAngles = playerCar.eulerAngles;
            playerCar.rotation = Quaternion.Euler(carEulerAngles.x, carTiltAngleWhileTurn, carEulerAngles.z);
        }
    }
}

using UnityEngine;

namespace BossFight.Cyber
{
    public class PlayerCar : MonoBehaviour
    {
        [SerializeField] private float acceleration;
        [SerializeField] private float brakeAcceleration;
        [SerializeField] private float turnSpeed;
        
        [SerializeField] private Transform playerCam;
        [SerializeField] private float camTiltAngleWhileTurn;
        private float velocity = 0;

        private void Update()
        {
            if (Input.GetKey("w"))
            {
                velocity += acceleration;
            }
            if (Input.GetKey("s"))
            {
                velocity -= brakeAcceleration;
            }

            bool turningLeft = Input.GetKey("a");
            bool turningRight = Input.GetKey("d");
            
            this.transform.Translate(Vector3.back * velocity *  Time.deltaTime);
            Vector3 camEulerAngles = playerCam.eulerAngles;
            if ((turningLeft && turningRight) || (!turningLeft && !turningRight))
            {
                playerCam.rotation = Quaternion.Euler(camEulerAngles.x, camEulerAngles.y, 0);
                return;
            }
            if (turningLeft)
            {
                this.transform.Translate(Vector3.right * turnSpeed * Time.deltaTime);
                playerCam.rotation = Quaternion.Euler(camEulerAngles.x, camEulerAngles.y, -camTiltAngleWhileTurn);
            }
            if (turningRight)
            {
                this.transform.Translate(Vector3.left * turnSpeed * Time.deltaTime);
                playerCam.rotation = Quaternion.Euler(camEulerAngles.x, camEulerAngles.y, camTiltAngleWhileTurn);
            }
        }
    }
}

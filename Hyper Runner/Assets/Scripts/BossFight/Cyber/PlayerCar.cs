using UnityEngine;

namespace BossFight.Cyber
{
    public class PlayerCar : AObjectWithMeshWidth
    {
        [SerializeField] private float acceleration;
        [SerializeField] private float brakeAcceleration;
        [SerializeField] private float turnSpeed;
        
        [SerializeField] private Transform playerCam;
        [SerializeField] private float camTiltAngleWhileTurn;
        
        [SerializeField]
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
                // Turning speed should be linear to velocity of player
                this.transform.Translate(Vector3.right * turnSpeed * velocity * (1f / 100f) * Time.deltaTime);
                playerCam.rotation = Quaternion.Euler(camEulerAngles.x, camEulerAngles.y, -camTiltAngleWhileTurn);
            }
            if (turningRight)
            {
                this.transform.Translate(Vector3.left * turnSpeed * velocity * (1f / 100f) * Time.deltaTime);
                playerCam.rotation = Quaternion.Euler(camEulerAngles.x, camEulerAngles.y, camTiltAngleWhileTurn);
            }
        }

        private void OnTriggerEnter(Collider other) => BumpedIntoObject();

        private void BumpedIntoObject()
        {
            Debug.Log("Bumped into Object");
        }
    }
}

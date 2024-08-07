using System.Collections;
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
        [SerializeField] private StreetBounds streetBounds;
        [SerializeField] private float crashStunTime;
        [SerializeField] private float velocityAfterCrash;
        
        [SerializeField]
        private float velocity = 0;

        private bool playerStunned = false;
        
        private void Update()
        {
            if (Input.GetKey("w") && !playerStunned)
            {
                velocity += acceleration;
            }
            if (Input.GetKey("s") && !playerStunned)
            {
                velocity -= brakeAcceleration;
            }
            
            this.transform.Translate(Vector3.back * velocity *  Time.deltaTime);
            if (playerStunned)
            {
                return;
            }
            HandlePlayerTurning();
        }

        private void HandlePlayerTurning()
        {
            Vector3 camEulerAngles = playerCam.eulerAngles;
            bool turningLeft = Input.GetKey("a");
            bool turningRight = Input.GetKey("d");

            if ((turningLeft && turningRight) || (!turningLeft && !turningRight))
            {
                ResetCamTilt();
                return;
            }
            
            Vector3 cur = transform.position;
            if (turningLeft)
            {
                // Turning speed should be linear to velocity of player
                Vector3 newPos = new Vector3(cur.x + turnSpeed * velocity * (1f / 100f) * Time.deltaTime,
                    cur.y,
                    cur.z);
                this.transform.position = ClampPlayerX(newPos);
                TiltCamLeft();
            }
            if (turningRight)
            {
                Vector3 newPos = new Vector3(cur.x - turnSpeed * velocity * (1f / 100f) * Time.deltaTime, 
                    cur.y,
                    cur.z);
                this.transform.position = ClampPlayerX(newPos);
                TiltCamRight();
            }
        }
        
        private Vector3 ClampPlayerX(Vector3 pos)
        {
            float clampedX = Mathf.Clamp(pos.x,
                streetBounds.GetMinX() + (GetMeshWidth() / 2), 
                streetBounds.GetMaxX() - (GetMeshWidth() / 2));
            return new Vector3(clampedX, pos.y, pos.z);
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

        private void OnTriggerEnter(Collider other) => BumpedIntoObject();

        private void BumpedIntoObject()
        {
            if (playerStunned)
            {
                return;
            }
            playerStunned = true;
            ResetCamTilt();
            velocity = velocityAfterCrash;
            StartCoroutine(EndPlayerStun());
        }

        private IEnumerator EndPlayerStun()
        {
            yield return new WaitForSeconds(this.crashStunTime);
            playerStunned = false;
        }
    }
}

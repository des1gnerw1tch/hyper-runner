using UnityEngine;
using System.Collections;

namespace BossFight.Cyber
{
    public abstract class ARacingCar : AObjectWithMeshWidth
    {
        [SerializeField] private float acceleration;
        [SerializeField] private float brakeAcceleration;
        [SerializeField] private float turnSpeed;
        
        [SerializeField] private StreetBounds streetBounds;
        [SerializeField] private float crashStunTime;
        [SerializeField] private float velocityAfterCrash;

        [SerializeField] private GameObject mesh;
        [SerializeField] private float timeToSpinAfterCrashAnim;
        
        [SerializeField]
        private float velocity = 0;

        private bool playerStunned = false;

        protected enum GasPedalState
        {
            Gas,
            Brake,
            Neutral
        }
        
        protected enum TurningDirection
        {
            Left,
            Right,
            None
        }
        
        protected virtual void Update()
        {
            if (!playerStunned)
            {
                HandlePlayerGas();
            }
            
            this.transform.Translate(Vector3.back * velocity *  Time.deltaTime);
            if (!playerStunned)
            {
                HandlePlayerTurning();
            }
        }
        
        private void HandlePlayerGas()
        {
            GasPedalState state = GetPlayerGasInput();
            if (state == GasPedalState.Gas)
            {
                velocity += acceleration;
            }
            else if (state == GasPedalState.Brake)
            {
                velocity -= brakeAcceleration;
            }
            velocity = Mathf.Clamp(velocity, 0, Mathf.Infinity);
        }

        protected abstract GasPedalState GetPlayerGasInput();
        
        private void HandlePlayerTurning()
        {
            TurningDirection direction = GetTurningDirectionInput();
            Vector3 cur = transform.position;
            if (direction == TurningDirection.Left)
            {
                // Turning speed should be linear to velocity of player
                Vector3 newPos = new Vector3(cur.x + turnSpeed * velocity * (1f / 100f) * Time.deltaTime,
                    cur.y,
                    cur.z);
                this.transform.position = ClampPlayerX(newPos);
            }
            else if (direction == TurningDirection.Right)
            {
                Vector3 newPos = new Vector3(cur.x - turnSpeed * velocity * (1f / 100f) * Time.deltaTime, 
                    cur.y,
                    cur.z);
                this.transform.position = ClampPlayerX(newPos);
            }
        }

        protected abstract TurningDirection GetTurningDirectionInput();

        private Vector3 ClampPlayerX(Vector3 pos)
        {
            float clampedX = Mathf.Clamp(pos.x,
                streetBounds.GetMinX() + (GetMeshWidth() / 2), 
                streetBounds.GetMaxX() - (GetMeshWidth() / 2));
            return new Vector3(clampedX, pos.y, pos.z);
        }

        private void OnTriggerEnter(Collider other) => BumpedIntoObject();

        protected virtual void BumpedIntoObject()
        {
            if (playerStunned)
            {
                return;
            }
            playerStunned = true;
            velocity = velocityAfterCrash;
            StartCoroutine(EndPlayerStun());
            StartCoroutine(StartSpinAnim());
        }

        private IEnumerator EndPlayerStun()
        {
            yield return new WaitForSeconds(this.crashStunTime);
            playerStunned = false;
        }

        private IEnumerator StartSpinAnim()
        {
            float timeElapsed = 0f;
            float progress = timeElapsed / timeToSpinAfterCrashAnim;
            while (progress <= 1f)
            {
                this.mesh.transform.localRotation = Quaternion.AngleAxis(Mathf.Lerp(0, 360, timeElapsed / timeToSpinAfterCrashAnim), Vector3.up);
                timeElapsed += Time.deltaTime;
                yield return new WaitForEndOfFrame();
            }
            mesh.transform.localRotation = Quaternion.AngleAxis(0, Vector3.up);
        }

        protected float GetVelocity() => this.velocity;
    }
}

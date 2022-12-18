using System.Collections;
using UnityEngine;

namespace MusicAndSound
{
    /**
     * Allows skippage to part of song. Used when making levels, not in actual play. 
     */
    public class MusicSyncEditor : MusicSync
    {
        [SerializeField] private int minutesToStart;
        [SerializeField] private int secondsToStart;
        [SerializeField] private int delayToStartFastForwardInSeconds = 3;

        private int samplesToStart;
        private bool startPosReached = false;

        protected override void Start()
        {
            base.Start();
            StartCoroutine(SpeedUp());
            
            int seconds = minutesToStart * 60 + secondsToStart;
            samplesToStart = seconds * levelMusic.clip.frequency;
        }

        private IEnumerator SpeedUp()
        {
            yield return new WaitForSeconds(delayToStartFastForwardInSeconds);
            this.changePitch(400f, 100f);
        }

        protected override void Update()
        {
            base.Update();
            if (levelMusic.timeSamples >= samplesToStart && !startPosReached)
            {
                this.changePitch(1f, 1000f);
                startPosReached = true;
            }
        }
    }
}

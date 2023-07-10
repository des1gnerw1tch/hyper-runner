using System.Collections;
using UnityEngine;

namespace Parry_System
{
    public class clockParryObject : AParryObject
    {
        [Header("Clock Parry Specific fields")]
        [SerializeField] private float musicPitch = 1f;
        [SerializeField] private float effectEndXPos = 1f;
        [SerializeField] private Transform endPitchChangePos;
        [Header("Auto filled below")]
        [SerializeField] private MusicSync musicSync;
        [SerializeField] private Transform playerTransform;

        private UIManager uiManager;
        public override void Start()
        {
            base.Start();
            musicSync = MusicSync.Instance;
            playerTransform = GameObject.FindGameObjectWithTag("Player").transform;
            uiManager = UIManager.Instance;
        }
        
        public override void OnParry()
        {
            base.OnParry();
            musicSync.changePitch(musicPitch);
            uiManager.SetPitchMultiplierText(musicPitch);
            StartCoroutine(UpdateDistanceLeftText());
            uiManager.SetPitchMultiplierPanelActive(true);
        }

        private IEnumerator UpdateDistanceLeftText()
        {
            bool modifierActive = true;

            while (modifierActive)
            {
                float distLeft = endPitchChangePos.position.x - playerTransform.position.x;
                if (distLeft > 0)
                {
                    uiManager.SetPitchMultiplierDistanceLeftText(distLeft);
                }
                else
                {
                    uiManager.SetPitchMultiplierPanelActive(false);
                    musicSync.changePitch(1f);
                    modifierActive = false;
                }

                yield return new WaitForEndOfFrame();
            }
        }
    }
}

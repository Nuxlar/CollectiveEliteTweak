using UnityEngine;
using RoR2;

namespace CollectiveEliteTweak
{
    public class NuxNoShieldinator : MonoBehaviour
    {
        private float stopwatch = 0f;
        private float uptime = 10f;
        private float downtime = 5f;
        private bool shieldActive = true;
        AffixCollectiveAttachmentBehaviour affixBehavior;

        private void Start()
        {
            affixBehavior = GetComponent<AffixCollectiveAttachmentBehaviour>();
            if (affixBehavior == null)
            {
                Log.Error("AffixCollectiveAttachmentBehaviour not found!");
                Destroy(this);
            }
        }

        private void FixedUpdate()
        {
            stopwatch += Time.fixedDeltaTime;

            if (!affixBehavior)
                Destroy(this);

            if (shieldActive && stopwatch >= uptime)
            {
                // Deactivate shield
                affixBehavior.radius = 0f;
                affixBehavior.visualsRoot.SetActive(false);
                shieldActive = false;
                stopwatch = 0f;
            }
            else if (!shieldActive && stopwatch >= downtime)
            {
                // Activate shield
                affixBehavior.radius = 30f;
                affixBehavior.visualsRoot.SetActive(true);
                shieldActive = true;
                stopwatch = 0f;
            }
        }
    }
}
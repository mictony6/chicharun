using UnityEngine;
using UnityEngine.UI;

public class XPBarSystem : MonoBehaviour
{

    [SerializeField] CombatBehavior playerCb;
    [SerializeField] Image xpFill;
    private int lastXPAmount = 0;
    private float xpLeft = 0;
    private float lastLevel = 0;



    private void Start()
    {
        xpFill.fillAmount = 0;
        xpLeft = playerCb.nextLevelThreshold;
        lastLevel = playerCb.level;
    }
    private void Update()
    {
        if (playerCb != null)
        {
            if (lastLevel != playerCb.level)
            {
                xpLeft = (playerCb.nextLevelThreshold - playerCb.exp);
                lastLevel = playerCb.level;
            }

            if (lastXPAmount != playerCb.exp)
            {
                xpFill.fillAmount = (1.0f-(playerCb.nextLevelThreshold-playerCb.exp) / xpLeft);
                lastXPAmount = playerCb.exp;
            }


        }
    }


}

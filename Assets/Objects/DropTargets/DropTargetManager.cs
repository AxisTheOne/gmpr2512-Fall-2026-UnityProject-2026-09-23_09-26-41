using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class DropTargetManager : MonoBehaviour
{
    public List<DropTarget> dropTargets;
    float resetTimer;

    void Start()
    {
        resetTimer = 0f;
    }

    void Update()
    {
        // Check if all are inactive
        bool active = false;
        foreach (DropTarget script in dropTargets)
        {
            bool dropped = script.isActive();
            if (dropped == true)
                active = true;
        }

        if (active == false)
        {
            resetTimer += 1f;
            if (resetTimer >= 300f)
            {
                // Reset timer
                resetTimer = 0f;

                // Reset each target
                foreach (DropTarget script in dropTargets)
                {
                    script.resetTarget();
                }
            }
        }
    }
}

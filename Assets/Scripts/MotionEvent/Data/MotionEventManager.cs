using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MotionEventManager : MonoBehaviour
{
    private static MotionEventManager inst = null;
    public static MotionEventManager Inst
    { 
        get
        {
            if(inst == null)
            {
                inst = new MotionEventManager();
            }
            return inst;
        }
    }
    private MotionEventManager() { }
    public void Execute(string[] dataList) 
    {
        if (dataList == null) { return; }

        foreach(var eventId in dataList)
        {
            uint targetEventId;
            if(!uint.TryParse(eventId, out targetEventId))
            {
                Debug.LogError("Wxecuted Fail Event ID : " + eventId);
                continue;
            }

            Debug.Log("Wxecuted Event ID : " + targetEventId);
        }
    }
}

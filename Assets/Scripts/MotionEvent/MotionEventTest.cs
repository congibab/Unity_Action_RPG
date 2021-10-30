using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MotionEventTest : MonoBehaviour
{
    [SerializeField]
    private GameObject attackCollision = null;

    void AttackOn()
    {
        attackCollision.SetActive(true);
    }

    void AttackOff()
    {
        attackCollision.SetActive(false);
    }

    void OnmotionEvent(uint eventId)
    {
        
    }
}

class Command { }

class CommandFactory
{
    
}


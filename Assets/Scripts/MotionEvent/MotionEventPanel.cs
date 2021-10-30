using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MotionEventPanel : MonoBehaviour
{
    [SerializeField]
    private Button saveButton = null;

    [SerializeField]
    private Button resetButton = null;

    [SerializeField]
    private Button createNewMotionEventButton = null;

    [SerializeField]
    private GameObject motionListItemScrollView = null;

    [SerializeField]
    private Transform motionEventItemParent = null;

    [SerializeField]
    private GameObject motionListItemScrollview = null;

    private AnimationClip currentClip = null;


    public void Setup(AnimationClip clip)
    {
        currentClip = clip;

        if (currentClip != null)
        {
            var eventDatas = currentClip.events;
            if (eventDatas == null) return;
            if (eventDatas.Length == 0)
            {
                motionListItemScrollview.SetActive(false);
                return;
            }

            SetupmotionEventPanel(eventDatas);
        }
    }

    private void SetupmotionEventPanel(AnimationEvent[] events)
    {
        if (motionEventItemParent != null)
        {
            foreach (Transform child in motionEventItemParent)
            {
                Destroy(child.gameObject);
            }
        }



        foreach (var enventData in events)
        {
            //var newListItem = Instantiate();
            //MotionEventListItem meli = newListItem.get
        }

        motionListItemScrollview.SetActive(true);
    }
}

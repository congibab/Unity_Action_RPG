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

    private List<AnimationEvent> clipEventList = null;

    private MotionEventTool motionEventTool = null;

    private void Awake()
    {
        createNewMotionEventButton?.onClick.AddListener(OnCreateNewEventButtonClick);
    }

    private void OnResetMotionEvent()
    {
         
    }

    private void OnSaveMotionEvent()
    {

#if UNITY_EDITOR
        UnityEditor.AnimationUtility.SetAnimationEvents(currentClip, clipEventList.ToArray());
        UnityEditor.EditorUtility.DisplayDialog("保存成功", "モーションイベントの保存成功", "閉じる");
#endif

    }

    private void OnCreateNewEventButtonClick()
    {
        foreach(var checkEvent in clipEventList)
        {
        //    if(checkEvent.time == motionEventTool.CurrentFrame)
        //    {
        //
        //    }
        }

        AnimationEvent newAnimationEvent = new AnimationEvent();
        //newAnimationEvent.time = motionEventTool;
        newAnimationEvent.stringParameter = string.Empty;

        clipEventList.Add(newAnimationEvent);
        SetupmotionEventPanel(clipEventList.ToArray());
    }
    public void Setup(AnimationClip clip, MotionEventTool tool)
    {
        currentClip = clip;
        motionEventTool = tool;

        if (currentClip != null)
        {
            var eventDatas = currentClip.events;
            if (eventDatas == null) return;
            if (eventDatas.Length == 0)
            {
                motionListItemScrollview.SetActive(false);
                return;
            }

            clipEventList.Clear();
            clipEventList.AddRange(eventDatas);

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
    private void OnMotionEventDeleted(AnimationEvent animationEvent)
    {

    }
}

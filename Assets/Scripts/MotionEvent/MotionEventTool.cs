using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MotionEventTool : MonoBehaviour
{
    [SerializeField]
    private Animator targetActorAnimator = null;

    [SerializeField]
    private MotionListItem listItemTemplate = null;

    [SerializeField]
    private Transform motionListParent = null;

    private GameObject samplingActor = null;

    [SerializeField]
    private MotionClipSampleingPanel samplingPanel = null;

    [SerializeField]
    private MotionEventPanel eventPanel = null;

    private AnimationClip[] motionClips = null;

    private AnimationClip currentClip = null;


    void Start()
    {
        motionClips = targetActorAnimator?.runtimeAnimatorController.animationClips;
        samplingActor = targetActorAnimator?.gameObject;
        samplingPanel.SetOnSamplingValueChange(PlaySamplingAnim);
        LoadAllMotion();
    }

    void LoadAllMotion()
    {
        if (motionClips == null)
        {
            listItemTemplate.gameObject.SetActive(false);
            return;
        }

        foreach (AnimationClip motionClip in motionClips)
        {
            GameObject newListItem = Instantiate(listItemTemplate.gameObject, motionListParent);
            MotionListItem mli = newListItem.GetComponent<MotionListItem>();
            string clipName = motionClip.name;

            if (clipName.Equals("idle"))
            {
                currentClip = motionClip;
                eventPanel.Setup(currentClip);
            }

            mli.Setup(clipName, () => {
                currentClip = motionClip;
                PlaySamplingAnim(0f);

                samplingPanel.SetfSamplingClip(currentClip);
            });
        }

        listItemTemplate.gameObject.SetActive(false);
    }

    void PlaySamplingAnim(float targetFrame)
    {
        if(currentClip == null) { return; }
        if(targetActorAnimator != null)
        {
            if (targetActorAnimator.enabled)
                targetActorAnimator.enabled = false;
        }
        currentClip.SampleAnimation(samplingActor, targetFrame);
    }
}

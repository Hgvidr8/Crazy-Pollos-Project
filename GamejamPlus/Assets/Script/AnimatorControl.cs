using UnityEngine;

public class AnimatorControl : MonoBehaviour
{
    private Animator[] animators;

    private void Start()
    {
        animators = GetComponentsInChildren<Animator>();
    }

    public void TriggerAllAnimators(string triggerName)
    {
        foreach (Animator animator in animators)
        {
            if (animator != null)
            {
                //fds dei hardcode msm
                animator.ResetTrigger("Start");
                animator.ResetTrigger("Stop");

                animator.SetTrigger(triggerName);
            }
        }
    }

   
}

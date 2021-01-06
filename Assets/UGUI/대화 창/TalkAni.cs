using UnityEngine;

public class TalkAni : MonoBehaviour
{
    void Update()
    {
        Animator animator = GetComponent<Animator>();

        if ((GameManager.Graphic == 0 && GameManager.TalkAni == 0) || GameManager.TalkAni == 1)
            animator.enabled = true;
        else
            animator.enabled = false;
    }
}

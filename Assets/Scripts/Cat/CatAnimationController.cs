using UnityEngine;

public class CatAnimationController : MonoBehaviour
{
    public float idleTimeToSleep;
    private Vector3 lastPosition;
    private float idleTime;
    private bool wasMoving;

    private Transform Hat;

    Animator animator;

    void Start()
    {
        animator = GetComponent<Animator>();
        lastPosition = transform.position;
        wasMoving = false;
    }

    void Update()
    {
        var positionDelta = transform.position - lastPosition;

        if (positionDelta == Vector3.zero)
        {
            if (wasMoving)
            {
                if (Hat != null)
                    Hat.localRotation = transform.rotation;

                animator.SetBool("isStay", true);
                animator.SetFloat("HorisontalSpeed", 0);
                wasMoving = false;
            }
            idleTime = idleTime + Time.deltaTime;
            if (idleTime > idleTimeToSleep)
                animator.SetBool("isSleep", true);
        }
        else
        {
            if (!wasMoving)
            {
                idleTime = 0;
                animator.SetBool("isSleep", false);
                animator.SetBool("isStay", false);
                wasMoving = true;

                Hat = transform.FindChild("FezFez(Clone)");
                if ((Hat != null) && (positionDelta.x > 0))
                    Hat.Rotate(0, 180, 0);
            }

            if (positionDelta.x == 0)
                animator.SetFloat("HorisontalSpeed", -1);
            else
                animator.SetFloat("HorisontalSpeed", positionDelta.x);
        }

        lastPosition = transform.position;
    }

    public void Death()
    {
        animator.SetTrigger("Death");

        if (Hat != null)
            Destroy(Hat.gameObject);
        else
        {
            Hat = transform.FindChild("FezFez(Clone)");
            if (Hat != null)
                Destroy(Hat.gameObject);
        }
    }
}

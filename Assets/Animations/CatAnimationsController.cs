using UnityEngine;
using System.Collections;

public class CatAnimationsController : MonoBehaviour {
    public float idleTimeToSleep;
    private Vector3 lastPosition;
    private float idleTime;
    private bool wasMoving;
    Animator animator;

    void Start()
    {
        animator = GetComponent<Animator>();
        lastPosition = transform.position;
        wasMoving = false;
    }

    void Update () {
        //var vect = new Vector3(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"), 0);
        //transform.position += vect * 1f * Time.deltaTime;

        var positionDelta = transform.position - lastPosition;

        if (positionDelta == Vector3.zero)
        {
            if (wasMoving)
            {
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
            idleTime = 0;
            animator.SetBool("isSleep", false);
            animator.SetBool("isStay", false);
            wasMoving = true;

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
    }
}

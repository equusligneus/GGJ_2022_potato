using UnityEngine;

[RequireComponent(typeof(Animator))]
public class AnimationAbility : MonoBehaviour
{
    [SerializeField] private RuntimeBool isMovingRef;
    [SerializeField] private RuntimeBool isInteractingRef;
    [SerializeField] private RuntimeInt2 directionRef;

    private Animator animator;

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        animator.SetBool("isMoving", isMovingRef && isMovingRef.Value);
        animator.SetBool("isInteracting", isInteractingRef && isInteractingRef.Value);
        animator.SetInteger("HorizontalFacing", directionRef ? directionRef.Value.x : 0);
        animator.SetInteger("VerticalFacing", directionRef ? directionRef.Value.y : 0);
    }
}

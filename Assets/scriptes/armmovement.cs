using UnityEngine;

public class armmovement : MonoBehaviour
{
    public Transform leftHand;
    public Transform rightHand;
    public CharacterController player;

    public float pushStrength = 2.5f;
    public float minimumHandSpeed = 0.01f;
	public float gravity = -9.81f;

	private float verticalVelocity;
    public bool leftHandTouching;
    public bool rightHandTouching;

    private Vector3 lastLeftPosition;
    private Vector3 lastRightPosition;

    void Start()
    {
        lastLeftPosition = leftHand.position;
        lastRightPosition = rightHand.position;
    }

    void Update()
    {
        Vector3 leftMovement = leftHand.position - lastLeftPosition;
        Vector3 rightMovement = rightHand.position - lastRightPosition;
        Vector3 push = Vector3.zero;
	if (leftHandTouching && leftMovement.magnitude > minimumHandSpeed)	
                   push -= leftMovement * pushStrength;

        if (rightHandTouching && rightMovement.magnitude > minimumHandSpeed)
            push -= rightMovement * pushStrength;

	if (player.isGrounded && verticalVelocity < 0)
	   verticalVelocity = -2f;
 

	verticalVelocity += gravity * Time.deltaTime;

	push.y += verticalVelocity * Time.deltaTime;
 
	
	player.Move(push);

        lastLeftPosition = leftHand.position;
        lastRightPosition = rightHand.position;
    }
}
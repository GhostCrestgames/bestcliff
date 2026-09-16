using UnityEngine;

public class handtouch : MonoBehaviour
{
    public armmovement movement;
    public bool isLeftHand;

    void OnTriggerEnter(Collider other)
    {
        if (isLeftHand)
            movement.leftHandTouching = true;
        else
            movement.rightHandTouching = true;
    }

    void OnTriggerExit(Collider other)
    {
        if (isLeftHand)
            movement.leftHandTouching = false;
        else
            movement.rightHandTouching = false;
    }
}
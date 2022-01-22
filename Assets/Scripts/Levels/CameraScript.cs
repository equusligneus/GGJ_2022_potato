using UnityEngine;

public class CameraScript : MonoBehaviour
{
    [SerializeField] private RuntimeVec3 targetPositionRef;
    [SerializeField] private float lerpFactor;

    // Update is called once per frame
    void Update()
    {
        if (!targetPositionRef)
            return;

        transform.position = Vector3.Lerp(transform.position, targetPositionRef.Value, lerpFactor);
    }
}

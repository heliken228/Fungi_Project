using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform target; // игрок, за которым следует камера
    public float smoothSpeed = 0.125f; // плавность следования

    private Vector3 offset; // отступ между камерой и игроком

    void Start()
    {
        offset = transform.position - target.position;
    }

    void FixedUpdate()
    {
        Vector3 desiredPosition = target.position + offset;
        Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed);
        transform.position = smoothedPosition;

        transform.LookAt(target);
    }
}

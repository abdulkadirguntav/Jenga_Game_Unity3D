using UnityEngine;

public class OrbitCamera : MonoBehaviour
{
    public Transform target;
    public float rotateSpeed = 50f;

    void Update()
    {
        if (Input.GetKey(KeyCode.A))
        {
            transform.RotateAround(target.position, Vector3.up, rotateSpeed * Time.deltaTime);
        }

        if (Input.GetKey(KeyCode.D))
        {
            transform.RotateAround(target.position, Vector3.up, -rotateSpeed * Time.deltaTime);
        }
    }
}

using UnityEngine;

public class KeepRotating : MonoBehaviour
{
    [SerializeField] private Vector3 rotationSpeed = new Vector3(0f, 90f, 0f); // degrees per second
   // [SerializeField] private Space rotationSpace = Space.Self; // Self = local axis, World = global axis

    void Update()
    {
        transform.Rotate(rotationSpeed * Time.deltaTime);
    }
}
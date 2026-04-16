using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TeleportScript : MonoBehaviour
{
    public GameObject otherGameObject;
    public float zOffset = 1.0f;
    public float cooldown = 0.5f;

    private static float lastTeleportTime;

    private void OnCollisionEnter(Collision collision)
    {
        if (Time.time < lastTeleportTime + cooldown) return;

        if (collision.gameObject.CompareTag("Player"))
        {
            lastTeleportTime = Time.time;

            CharacterController cc = collision.gameObject.GetComponent<CharacterController>();

            // Disable CC to allow manual position change
            if (cc != null) cc.enabled = false;

            Vector3 newPosition = otherGameObject.transform.position;
            newPosition.z += zOffset;
            collision.gameObject.transform.position = newPosition;

            // Re-enable CC
            if (cc != null) cc.enabled = true;
        }
    }
}
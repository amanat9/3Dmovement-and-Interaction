using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileThrower : MonoBehaviour
{

    public GameObject ProjectilePrefab;
    public float verticalMultiplier;
    public float horizontalMultiplier;

    private float holdTime = 0f;
    private bool isCharging = false;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.T))
        {
            isCharging = true;
            holdTime = 0f;
        }

        if (Input.GetKey(KeyCode.T) && isCharging)
        {
            holdTime += Time.deltaTime;
        }

        if (Input.GetKeyUp(KeyCode.T) && isCharging)
        {
            ThrowProjectile();
            isCharging = false;
        }
    }

    void ThrowProjectile()
    {
        GameObject projectile = Instantiate(ProjectilePrefab, transform.position, transform.rotation);
        projectile.SetActive(true);
        Rigidbody rb = projectile.GetComponent<Rigidbody>();

        Vector3 throwForce = transform.forward * holdTime * horizontalMultiplier
                           + transform.up * holdTime * verticalMultiplier;

        rb.AddForce(throwForce, ForceMode.Impulse);
        holdTime = 0f;
    }
}

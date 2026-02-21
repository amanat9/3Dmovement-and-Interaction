using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float horizontalInput;
    public float verticalInput;
    public float SpeedMultiplier=5f;

    public GameObject player;

    private Rigidbody rb;
    private Transform mytf;
    // Start is called before the first frame update
    void Start()
    {
        rb = player.GetComponent<Rigidbody>();
        mytf = player.GetComponent<Transform>();

    }

    // Update is called once per frame
    void Update()
    {
        horizontalInput = Input.GetAxis("Horizontal");
        verticalInput = Input.GetAxis("Vertical");

        mytf.Translate(Vector3.forward * Time.deltaTime * verticalInput * SpeedMultiplier);
        mytf.Translate(Vector3.right * Time.deltaTime * horizontalInput * SpeedMultiplier);

        // Jump (default key = Space)
        if (Input.GetButtonDown("Jump"))
        {
            rb.AddForce(Vector3.up * SpeedMultiplier, ForceMode.VelocityChange);
        }


    }
}

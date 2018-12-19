using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [Header ("Movement")]
    public float depthSpeed;
    public float horizontalSpeed;
    public float moveSpeedMultiplier;
    private float depth;
    private float horizontal;
    private Vector3 translation;

    [Header ("Horizontal Rotation")]
    public float horizontalRotationSpeed;
    private Vector3 rotationHorizontal;

    [Header ("Vertical Rotation")]
    public float verticalRotationSpeed;
    private Vector3 rotationVertical;

    // Use this for initialization
    void Start()
    {
        
    }

    private void Update()
    {
        if (Input.GetButtonDown("Fire3"))
        {
            horizontalSpeed *= moveSpeedMultiplier;
            depthSpeed *= moveSpeedMultiplier;
        }
        if (Input.GetButtonUp("Fire3"))
        {
            horizontalSpeed /= moveSpeedMultiplier;
            depthSpeed /= moveSpeedMultiplier;
        }
    }

    // Update is called thirty times per second
    void FixedUpdate()
    {
        if (Input.GetAxis("Vertical") != 0 || Input.GetAxis("Horizontal") != 0)
        {
            Move();
        }
        if (Input.GetAxis("Mouse X") != 0 || Input.GetAxis("Mouse Y") != 0)
        {
            Turn();
        }
    }

    private void Move()
    {
        depth = Input.GetAxis("Vertical");
        horizontal = Input.GetAxis("Horizontal");
        translation.z = depth * Time.deltaTime * depthSpeed;
        translation.x = horizontal * Time.deltaTime * horizontalSpeed;
        transform.Translate(translation);
    }

    private void Turn()
    {
        rotationHorizontal.y += Input.GetAxis("Mouse X") * horizontalRotationSpeed;
        transform.eulerAngles = new Vector3(transform.eulerAngles.x, rotationHorizontal.y, 0.0f);
        rotationVertical.x += -Input.GetAxis("Mouse Y") * verticalRotationSpeed;
        rotationVertical.x = Mathf.Clamp(rotationVertical.x, -50.0f, 50.0f);
        transform.eulerAngles = (new Vector3(rotationVertical.x, transform.eulerAngles.y, 0.0f));
    }
}
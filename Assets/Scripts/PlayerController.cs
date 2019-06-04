using System;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed;
    public float jumpForce;
    public float rotationSpeed = 1.0f;
    public GameController gameController;

    float yaw;
    Rigidbody rb;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void FixedUpdate()
    {
        var moveHorizontal = Input.GetAxis("Horizontal");
        var moveVertical = Input.GetAxis("Vertical");

        var transform1 = transform;
        var movement = moveVertical * transform1.forward + moveHorizontal * transform1.right;

        rb.velocity = new Vector3(movement.x * speed, rb.velocity.y, movement.z * speed);

        if (Input.GetButton("Jump") && Math.Abs(rb.velocity.y) == 0)
        {
            rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
        }
    }

    void Update()
    {
        yaw += rotationSpeed * Input.GetAxis("Mouse X");

        while (yaw < 0f) {
            yaw += 360f;
        }
        while (yaw >= 360f) {
            yaw -= 360f;
        }

        transform.eulerAngles = new Vector3(0f, yaw, 0f);
    }

    void OnTriggerEnter(Collider other)
    {
        if (!other.CompareTag("Pickup")) return;

        gameController.CollectPickup();
        Destroy(other.gameObject);
    }
}

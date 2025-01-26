using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class Cup : MonoBehaviour
{
    [SerializeField] private float maxMoveSpeed = 20f;
    [SerializeField] private float maxDistance = 10f;
    [SerializeField] private float maxRotationSpeed = 300f;
    [SerializeField] private float maxRotationDistance = 45f;
    [SerializeField] private float maxRotationAngle = 180f;

    private Rigidbody2D rb;

    void Start()
    {
        // Get the Rigidbody2D component
        rb = GetComponent<Rigidbody2D>();
    }

    void FixedUpdate()
    {
        // Pulling the current cursor position
        Vector3 cursorLocation3D = Camera.main.ScreenToWorldPoint(Input.mousePosition);

        // Pulling the current cup position
        Vector3 cupLocation3D = transform.position;

        // Calculating the difference between the positions
        Vector3 deltaPosition = cursorLocation3D - cupLocation3D;
        deltaPosition.z = 0;
        float deltaMagnitude = deltaPosition.magnitude;

        // Calculating the speed of the cup
        float moveSpeed = deltaMagnitude * (maxMoveSpeed / maxDistance);
        moveSpeed = Mathf.Min(moveSpeed, maxMoveSpeed);
        
        Debug.Log(maxMoveSpeed);

        // Calculating the move direction
        Vector3 moveDirection = deltaPosition.normalized;

        // Move the cup using Rigidbody2D
        rb.linearVelocity = moveSpeed * moveDirection;

        // Calculating the cursor angle
        float cursorAngleRad = Mathf.Atan2(-1 * deltaPosition.x, deltaPosition.y);
        float cursorAngleDeg = cursorAngleRad * Mathf.Rad2Deg;

        // Pulling the cup angle
        float cupAngleDeg = transform.eulerAngles.z;

        // Normalizing rotation angles
        if (cursorAngleDeg < 0) cursorAngleDeg += 360;
        if (cupAngleDeg < 0) cupAngleDeg += 360;

        // Calculating the distance between the cursor and the cup in each direction
        float distanceCCW, distanceCW;
        if (cupAngleDeg > cursorAngleDeg)
        {
            distanceCW = cupAngleDeg - cursorAngleDeg;
            distanceCCW = 360 - distanceCW;
        }
        else
        {
            distanceCCW = cursorAngleDeg - cupAngleDeg;
            distanceCW = 360 - distanceCCW;
        }

        // Determining rotation speed
        float rotationSpeed;
        if (distanceCCW <= distanceCW)
        {
            rotationSpeed = (distanceCCW / maxRotationDistance) * maxRotationSpeed;
        }
        else
        {
            rotationSpeed = -1 * (distanceCW / maxRotationDistance) * maxRotationSpeed;
        }

        rotationSpeed = Mathf.Clamp(rotationSpeed, -maxRotationSpeed, maxRotationSpeed);

        // Calculating the new rotation angle
        cupAngleDeg += rotationSpeed * Time.fixedDeltaTime;
        if (cupAngleDeg > 180) cupAngleDeg -= 360;
        else if (cupAngleDeg < -180) cupAngleDeg += 360;

        cupAngleDeg = Mathf.Clamp(cupAngleDeg, -maxRotationAngle, maxRotationAngle);

        // Rotate the cup using Rigidbody2D
        rb.MoveRotation(cupAngleDeg);
    }
}

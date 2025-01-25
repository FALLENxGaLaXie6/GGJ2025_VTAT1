using UnityEngine;

public class Cup : MonoBehaviour
{

    [SerializeField] private float maxMoveSpeed = 25f;
    [SerializeField] private float maxDistance = 10f;
    [SerializeField] private float maxRotationSpeed = 720f;
    [SerializeField] private float maxRotationDistance = 180f;
    [SerializeField] private float maxRotationAngle = 90f;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
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
        if (moveSpeed > maxMoveSpeed)
        {
            moveSpeed = maxMoveSpeed;
        }
        
        // Calculating the move direction
        Vector3 moveDirection = deltaPosition.normalized;
        
        // Calculating the cursor angle
        float cursorAngleRad = Mathf.Atan2(-1 * deltaPosition.x, deltaPosition.y);
        float cursorAngleDeg = (180f / Mathf.PI) * cursorAngleRad;
        
        // Pulling the cup angle
        float cupAngleDeg = transform.eulerAngles.z;
        
        // Normalizing rotation angles
        if (cursorAngleDeg < 0)
        {
            cursorAngleDeg += 360;
        }
        if (cupAngleDeg < 0)
        {
            cupAngleDeg += 360;
        }

        // Calculating the distance between the cursor and the cup in each direction
        float distanceCCW;
        float distanceCW;
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

        if (rotationSpeed > maxRotationSpeed)
        {
            rotationSpeed = maxRotationSpeed;
        }
        else if (rotationSpeed < -maxRotationSpeed)
        {
            rotationSpeed = -maxRotationSpeed;
        }
        
        // Calculating the new rotation angle
        cupAngleDeg += rotationSpeed * Time.deltaTime;
        if (cupAngleDeg > 180)
        {
            cupAngleDeg -= 360;
        }
        else if (cupAngleDeg < -180)
        {
            cupAngleDeg += 360;
        }

        if (cupAngleDeg > maxRotationAngle)
        {
            cupAngleDeg = maxRotationAngle;
        }
        else if (cupAngleDeg < -maxRotationAngle)
        {
            cupAngleDeg = -maxRotationAngle;
        }

        // Moving and rotating the cup
        transform.position += moveSpeed * Time.deltaTime * moveDirection;
        transform.eulerAngles = new Vector3(0, 0, cupAngleDeg);
    }
}

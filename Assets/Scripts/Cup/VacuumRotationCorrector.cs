using UnityEngine;

public class VacuumRotationCorrector : MonoBehaviour
{

    private AreaEffector2D areaEffector;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        areaEffector = GetComponent<AreaEffector2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (areaEffector != null)
        {
            // Update the Force Angle to match the parent's rotation
            float parentRotation = transform.eulerAngles.z; // Z-axis rotation
            areaEffector.forceAngle = parentRotation-180;
            
            Debug.Log($"Parent Rotation (Z): {parentRotation}");
            Debug.Log($"Force Angle Applied: {areaEffector.forceAngle}");
        }
    }
}

using UnityEngine;

public class CameraBehavior : MonoBehaviour
{
    public Vector3DataList cameraPoints; // ScriptableObject containing list of points
    public float moveSpeed;
    private bool moveCamera;
    private int currentPointIndex; // To track which point we are moving towards

    public GameObject leftTrigger; // The left trigger object
    public GameObject rightTrigger; // The right trigger object

    private void Update()
    {
        if (cameraPoints == null || cameraPoints.vector3DList.Count == 0) return;

        // Move to the closest point initially
        if (!moveCamera)
        {
            int closestIndex = FindClosestPoint();
            SetTargetPoint(closestIndex);
        }

        // Move the camera to the target point
        if (moveCamera)
        {
            MoveCameraToTarget();

            // Stop moving once close enough
            if (Vector3.Distance(transform.position, cameraPoints.vector3DList[currentPointIndex].value) < 0.01f)
            {
                moveCamera = false;
            }
        }
    }

    private void MoveCameraToTarget()
    {
        transform.position = Vector3.MoveTowards(
            transform.position,
            cameraPoints.vector3DList[currentPointIndex].value,
            moveSpeed * Time.deltaTime
        );
    }

    private int FindClosestPoint()
    {
        float closestDistance = Mathf.Infinity;
        int closestIndex = 0;

        // Find the closest point to the current camera position
        for (int i = 0; i < cameraPoints.vector3DList.Count; i++)
        {
            float distance = Vector3.Distance(transform.position, cameraPoints.vector3DList[i].value);
            if (distance < closestDistance)
            {
                closestDistance = distance;
                closestIndex = i;
            }
        }

        return closestIndex;
    }

    private void SetTargetPoint(int index)
    {
        if (index >= 0 && index < cameraPoints.vector3DList.Count)
        {
            currentPointIndex = index;
            moveCamera = true;
        }
    }

    // Trigger detection when the player character enters the trigger area
    public void MoveLeft()
    {
        // Move to the previous point (wrap around if needed)
        currentPointIndex = Mathf.Clamp(currentPointIndex - 1, 0, cameraPoints.vector3DList.Count - 1);
        moveCamera = true;
    }
    
    public void MoveRight()
    {
        // Move to the next point (wrap around if needed)
        currentPointIndex = Mathf.Clamp(currentPointIndex + 1, 0, cameraPoints.vector3DList.Count - 1);
        moveCamera = true;
    }
}
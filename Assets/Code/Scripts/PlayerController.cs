using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Unit unit; // Reference to the Unit component.

    private void Start()
    {
        unit = GetComponent<Unit>();
    }

    private void Update()
    {
        if (unit.currentActionPoints > 0 && !unit.isMoving)
        {
            HandleMovementInput();
        }
    }

    private void HandleMovementInput()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit))
            {
                // Calculate the distance to the clicked point.
                float distanceToTarget = Vector3.Distance(transform.position, hit.point);

                // Calculate the action points required based on distance.
                int actionPointsRequired = Mathf.CeilToInt(distanceToTarget / unit.movementSpeed); // Convert to int.

                // Check if the unit has enough action points to move.
                if (unit.currentActionPoints >= actionPointsRequired)
                {
                    // Move the unit to the clicked point.
                    unit.UseActionPoints(actionPointsRequired);
                    unit.MoveTo(hit.point);
                }
            }
        }
    }
}

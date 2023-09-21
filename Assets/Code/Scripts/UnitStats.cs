using UnityEngine;

public class Unit : MonoBehaviour
{
    [SerializeField]
    public string unitName = "Unit"; // The name of the unit.
    [SerializeField]
    public int maxHealth = 100; // The maximum health of the unit.
    [SerializeField]
    public int currentHealth; // The current health of the unit.
    [SerializeField]
    public int maxActionPoints = 10; // The maximum action points of the unit.
    [SerializeField]
    public int currentActionPoints; // The current action points of the unit.
    [SerializeField]
    public float movementSpeed = 3.0f; // Speed in meters per action point.
    private Vector3 targetPosition; // The target position for movement.
    public bool isMoving; // Flag to track if the unit is currently moving.

    private void Start()
    {
        currentHealth = maxHealth;
        currentActionPoints = maxActionPoints;
    }

    public void TakeDamage(int damage)
    {
        currentHealth -= damage;
        if (currentHealth < 0)
            currentHealth = 0;
    }

    public void UseActionPoints(int actionPointsUsed)
    {
        currentActionPoints -= actionPointsUsed;
        if (currentActionPoints < 0)
            currentActionPoints = 0;
    }

    public void MoveTo(Vector3 destination)
    {
        targetPosition = destination;
        isMoving = true;
    }

    private void Update()
    {
        if (isMoving)
        {
            // Move the unit towards the target position.
            transform.position = Vector3.MoveTowards(transform.position, targetPosition, movementSpeed * Time.deltaTime);

            // Check if the unit has reached the target position.
            if (Vector3.Distance(transform.position, targetPosition) < 0.01f)
            {
                isMoving = false;
            }
        }
    }
}

using UnityEngine;

public class Unit : MonoBehaviour
{
    public string unitName = 'string'; 
    public int maxHealth = 100; 
    public int currentHealth; 
    public int maxActionPoints = 10; 
    public int currentActionPoints;

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

    public void UseActionPoints(int pointsUsed)
    {
        currentActionPoints -= pointsUsed;
        if (currentActionPoints < 0)
            currentActionPoints = 0;
    }

    public bool CanMove(int moveCost)
    {
        return currentActionPoints >= moveCost;
    }
}

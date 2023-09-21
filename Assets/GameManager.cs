using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance; // Singleton instance of the GameManager.
    public GameObject[] playerUnits; // Array to store player units.
    private int currentPlayerIndex; // Index of the current player in the array.

    private void Awake()
    {
        // Singleton pattern to ensure only one GameManager exists.
        if (instance == null)
        {
            instance = this;
        }
        else if (instance != this)
        {
            Destroy(gameObject);
        }
    }

    private void Start()
    {
        // Initialize the currentPlayerIndex.
        currentPlayerIndex = 0;
        StartPlayerTurn();
    }

    public void StartPlayerTurn()
    {
        // Activate the player's units and reset their action points.
        foreach (var unit in playerUnits)
        {
            unit.SetActive(true);
            unit.GetComponent<Unit>().currentActionPoints = unit.GetComponent<Unit>().maxActionPoints;
        }
    }

    public void EndPlayerTurn()
    {
        // Deactivate the current player's units.
        foreach (var unit in playerUnits)
        {
            unit.SetActive(false);
        }

        // Move to the next player's turn.
        currentPlayerIndex = (currentPlayerIndex + 1) % playerUnits.Length;
        StartPlayerTurn();
    }
}

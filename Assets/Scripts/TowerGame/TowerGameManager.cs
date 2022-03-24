using UnityEngine;

public class TowerGameManager : MonoBehaviour
{
    public static TowerGameManager ins;

    [SerializeField] GameObject[] blocksGameObjects;
    [SerializeField] Transform[] blockDefaultPositions;

    [SerializeField] int targetNumberOfBlocks = 5;
    public int currentlyStackedBlocks = 1;

    public event System.Action OnWin;
    public event System.Action OnScoreUpdated;

    private void Awake()
    {
        if (ins == null) ins = this;
    }

    private void Start()
    {
        Restart();
    }

    public void AddBlock()
    {
        currentlyStackedBlocks++;
        OnScoreUpdated?.Invoke();

        if (currentlyStackedBlocks >= targetNumberOfBlocks)
        {
            Win();
        }
    }

    public void RemoveBlock()
    {
        currentlyStackedBlocks--;
        OnScoreUpdated?.Invoke();
    }

    void Win()
    {
        OnWin?.Invoke();
    }

    public void Restart()
    {
        for (int i = 0; i < blocksGameObjects.Length; i++)
        {
            blocksGameObjects[i].transform.position = blockDefaultPositions[i].position;
        }
        currentlyStackedBlocks = 1;
        OnScoreUpdated?.Invoke();
    }
}

using UnityEngine;

public class FactoryWorkerGameManager : MonoBehaviour
{
    public static FactoryWorkerGameManager ins;
    public event System.Action OnGameOver;
    public event System.Action OnScoreUpdated;


    [SerializeField] GameObject itemPrefab;
    [SerializeField] Transform itemsSpawnPosition;


    [SerializeField] public float totalTime = 20;
    [SerializeField] float itemsSpawnDelay = 1;
    [HideInInspector] public float currentTime;
    [HideInInspector] public int score;
    bool isRunning = false;


    private void Awake()
    {
        if (ins == null) { ins = this; }
    }

    void Start()
    {
        Restart();
    }

    void FixedUpdate()
    {
        if (isRunning)
        {
            currentTime += Time.fixedDeltaTime;

            if (currentTime > totalTime)
            {
                GameOver();
            }
        }
    }


    void SpawnItem()
    {
        var item = Instantiate(itemPrefab, transform);
        item.transform.position = itemsSpawnPosition.position;
        item.GetComponent<Rigidbody>().AddForce(transform.forward);

        if (!isRunning)
        {
            CancelInvoke(nameof(SpawnItem));
        }
    }

    public void CorrectItemPlaced()
    {
        score++;
        OnScoreUpdated?.Invoke();
    }

    public void WrongItemPlaced()
    {
        score--;
        OnScoreUpdated?.Invoke();
    }

    void GameOver()
    {
        isRunning = false;
        OnGameOver?.Invoke();
    }

    public void Restart()
    {
        var leftOverItems = FindObjectsOfType<FactoryItem>();
        foreach (var item in leftOverItems)
        {
            Destroy(item.gameObject);
        }

        score = 0;
        currentTime = 0;
        isRunning = true;
        OnScoreUpdated?.Invoke();
        InvokeRepeating(nameof(SpawnItem), itemsSpawnDelay, itemsSpawnDelay);
    }


    public enum ItemType
    {
        Red, Green
    }
}

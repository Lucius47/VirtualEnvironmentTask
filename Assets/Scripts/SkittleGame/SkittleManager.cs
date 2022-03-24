using UnityEngine;

public class SkittleManager : MonoBehaviour
{
    public event System.Action OnGameOver;
    public event System.Action OnScoreUpdated;


    public static SkittleManager ins;
    [SerializeField] GameObject ball;
    [SerializeField] Transform ballDefaultPosition;

    [SerializeField] GameObject[] pins;
    [SerializeField] Transform[] pinsDefaultPositions;

    int numberOfBallThrows = 3;

    public int numberOfPinsLeft = 0;

    void Awake()
    {
        if (ins == null) ins = this;
    }

    private void Start()
    {
        Restart();
    }


    public void ResetBall()
    {
        ball.transform.position = ballDefaultPosition.position;
        ball.GetComponent<Rigidbody>().velocity = Vector3.zero;
        ball.GetComponent<Rigidbody>().angularVelocity = Vector3.zero;
    }

    public void ResetBallAfterThrow()
    {
        ResetBall();
        numberOfBallThrows--;
        if (numberOfBallThrows < 1)
        {
            GameOver();
        }
    }

    public void PushBallForward()
    {
        ball.GetComponent<Rigidbody>().AddForce(transform.forward * 2000);
    }

    public void DropPin()
    {
        numberOfPinsLeft--;
        OnScoreUpdated?.Invoke();

        if (numberOfPinsLeft < 1)
        {
            GameOver();
        }
    }

    void GameOver()
    {
        OnGameOver?.Invoke();
    }


    public void Restart()
    {
        ResetBall();
        ResetPins();
        numberOfBallThrows = 3;
    }

    public void ResetPins()
    {
        for (int i = 0; i < pins.Length; i++)
        {
            pins[i].transform.localPosition = pinsDefaultPositions[i].localPosition - (Vector3.up * 0.5f);
            pins[i].transform.rotation = pinsDefaultPositions[i].transform.rotation;
            pins[i].GetComponent<Rigidbody>().velocity = Vector3.zero;
            pins[i].GetComponent<Rigidbody>().angularVelocity = Vector3.zero;
            pinsDefaultPositions[i].GetComponent<PinPosition>().pinDropped = false;
        }
        numberOfPinsLeft = 9;
    }
}

using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    [SerializeField] int timeToEnd;
    bool win;
    bool gamePaused;

    private void Start()
    {
        if (instance == null)
        {
            instance = this;
        }
        InvokeRepeating(nameof(Stopper), 0, 1);
    }

    private void Update()
    {
        PauseCheck();
    }

    void Stopper()
    {
        timeToEnd--;
        Debug.Log("Time: " + timeToEnd + "s");
        if(timeToEnd <= 0)
        {
            timeToEnd = 0;
            EndGame();
        }
    }

    void EndGame()
    {
        CancelInvoke(nameof(Stopper));
        //Time.timeScale = 0;
        if (win)
        {
            Debug.Log("You Win!!!");
        }
        else
        {
            Debug.Log("You Lose!!!");
        }
    }

    public void PauseGame()
    {
        Debug.Log("Game paused");
        Time.timeScale = 0;
        gamePaused = true;
    }
    public void ResumeGame()
    {
        Debug.Log("Game resumed");
        Time.timeScale = 1;
        gamePaused = false;
    }

    void PauseCheck()
    {
        if (Input.GetKeyDown(KeyCode.Escape) || Input.GetKeyDown(KeyCode.Q))
        {
            if (gamePaused)
            {
                ResumeGame();
            }
            else
            {
                PauseGame();
            }
        }
    }
}

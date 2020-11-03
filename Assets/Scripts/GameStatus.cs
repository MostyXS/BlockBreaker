using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class GameStatus : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI ScoreText;

    //config params
    [Range(0.1f, 10f)] [SerializeField] float GameSpeed = 1f;
    [SerializeField] int pointsPerBlockDestroyed;
    //state variables
    [SerializeField] int currentScore = 0;
    [SerializeField] int gameStatusCount;
    [SerializeField] bool isAutoPlayEnabled;
    private void Start()
    {
        
        ScoreText.text = currentScore.ToString();

    }

    // Update is called once per frame
    void Update()
    {
        
        Time.timeScale = GameSpeed;
        ScoreText.text = currentScore.ToString();
    }
    private void Awake()
    {
        gameStatusCount = FindObjectsOfType<GameStatus>().Length;
        if (gameStatusCount > 1)
        {
            Destroy(gameObject);
        }
        else
        {

            DontDestroyOnLoad(gameObject);
        }

    }

    public void AddToScore()
    {
        currentScore += pointsPerBlockDestroyed;
        
    }   
    public void RestartStatus()
    {
        Destroy(gameObject);

    }

    public bool IsAutoPlayEnabled()
    {
        return isAutoPlayEnabled;
    }


}

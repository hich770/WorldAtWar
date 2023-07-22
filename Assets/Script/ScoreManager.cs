using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour
{
    public static int score;
    public Text scoreDisplay;
    public Text objectToSpawnDisplay;
    public Text EndScore;
    public GameObject objectToSpawn;
    public GameObject dugout;

    
    private void Update()
    {
        scoreDisplay.text = score.ToString();
        objectToSpawnDisplay.text = score.ToString(); 
        EndScore.text = ("Ваш счёт: " + score);
    }

    public void AddScore(int amount)
    {
        score += amount;
    }
}
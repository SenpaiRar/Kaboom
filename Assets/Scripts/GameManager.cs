using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class GameManager : MonoBehaviour {

    public delegate void GameState();
    public static event GameState GameOver;
    public static event GameState GameWon;

    public int Winpoint; //How many bombs dropped until win state
    public int Hitpoint; //How many bombs can be dropped until gameover

    private int CurrentWinPoint; //How many bombs have been caught by the player?
    private int CurrentHitPoint; //How many bombs have gotten past the player?

    public Text ScoreText;

    void Start () {

        CurrentHitPoint = 0;
        CurrentHitPoint = 0;

        Bombs.OnPlayerExplode += AddToWinPoint;
        Bombs.OnPlayerExplode += UpdateScoreText;
        Bombs.OnExplode += SubtractHitPoint;
        
    }
	

    void AddToWinPoint()
    {
        CurrentWinPoint += 1;
    }

    void SubtractHitPoint ()
    {
        CurrentHitPoint -= 1;
    }

    void UpdateScoreText()
    {
        ScoreText.text = CurrentWinPoint.ToString();
    }
}

using UnityEngine;
using System.Collections;

public class GameManager : MonoBehaviour {

    public delegate void GameState();
    public static event GameState GameOver;
    public static event GameState GameWon;

    public int Winpoint; //How many bombs dropped until win state
    public int Hitpoint; //How many bombs can be dropped until gameover

    void Start () {
        BombSpawner.BombDropped += AddToWinPoint;
        Bombs.OnExplode += SubtractHitPoint;
    }
	
	
	void Update () {
        Debug.Log(Winpoint);
	}

    void AddToWinPoint(int Nofbombs)
    {
        Winpoint += Nofbombs;
    }

    void SubtractHitPoint ()
    {
        Hitpoint -= 1;
    }
}

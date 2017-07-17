using UnityEngine;
using System.Collections;
//Scripts the bomber which moves and drops bombs
public class Bomber : MonoBehaviour {

    Vector3 NextPoint; //Randomly generated point which the Bomber moves towards
    public float nMin; //Upper and Lower bound of the x value of NextPoint
    public float nMax;
    public float Speed; //How fast the player goes. Note: This number should be small, around 1
    public float SpeedIncrement; //WHen the speed increases, how much to add to Speed
    public float MaxWaveTimer; //How long until the bomber stops and speeds up
    public float TimeBetweenWaves; //How long does the bomber stop 
    private float WaveTimer; 

    public delegate void BomberEvent();
    public static event BomberEvent OnWaveDone;
    public static event BomberEvent OnWaveStart;

    void Start() {
        NextPoint = GenerateNextPoint(nMin, nMax);
    }


    void LateUpdate() {

        WaveTimer += Time.deltaTime;

        if (WaveTimer > MaxWaveTimer)
        {
            StartCoroutine("StopWave");
            WaveTimer = 0;
        }

        if (Vector3.Distance(transform.position, NextPoint) > 0.5f)
        {
            transform.position = Vector3.Lerp(transform.position, NextPoint, Speed / 10);
        }
        else
        {
            NextPoint = GenerateNextPoint(nMin, nMax);
        }

    }

    Vector3 GenerateNextPoint(float min, float max)
    {
        return (new Vector3(Random.Range(min, max), 0, 0));
    }


    IEnumerator StopWave()
    {
        Debug.Log("stopped");
        float origSpeed = Speed;
        Speed = 0;

        if(OnWaveDone != null)
        {
            OnWaveDone();
        }

        yield return new WaitForSeconds(TimeBetweenWaves);

        if(OnWaveStart != null)
        {
            OnWaveStart();
        }

        Debug.Log("Started moving again!");
        Speed = origSpeed + SpeedIncrement;
    }
    
    
}

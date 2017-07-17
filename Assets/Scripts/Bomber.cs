using UnityEngine;
using System.Collections;
//Scripts the bomber which moves and drops bombs
public class Bomber : MonoBehaviour {

    Vector3 NextPoint; //Randomly generated point which the Bomber moves towards
    public float nMin; //Upper and Lower bound of the x value of NextPoint
    public float nMax;
    public float Speed;
    public float SpeedIncrement;
    public float MaxWaveTimer;
    public float TimeBetweenWaves;
    private float WaveTimer;

    public delegate void BomberEvent();
    public static event BomberEvent OnWaveDone;
    public static event BomberEvent OnWaveStart;

    void Start() {
        NextPoint = GenerateNextPoint(nMin, nMax);
    }


    void LateUpdate() {

        WaveTimer += 1 * Time.deltaTime;

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

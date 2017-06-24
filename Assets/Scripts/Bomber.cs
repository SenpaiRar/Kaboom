using UnityEngine;
using System.Collections;
//Scripts the bomber which moves and drops bombs
public class Bomber : MonoBehaviour {

    Vector3 NextPoint; //Randomly generated point which the Bomber moves towards
    public float nMin; //Upper and Lower bound of the x value of NextPoint
    public float nMax;

    void Start () {
        NextPoint = GenerateNextPoint(nMin, nMax);
	}
	
	
	void LateUpdate () {
        if (Vector3.Distance(transform.position, NextPoint) > 0.5f)
        {
            transform.position = Vector3.Lerp(transform.position, NextPoint, 0.2f);
        }
        else
        {
            NextPoint = GenerateNextPoint(nMin,nMax);
        }

	}

    Vector3 GenerateNextPoint (float min, float max)
    {
        return (new Vector3(Random.Range(min, max), 0, 0));
    }
}

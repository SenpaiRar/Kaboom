using UnityEngine;
using System.Collections;

public class Bombs : MonoBehaviour {

    float speed;
    float cutoffDistance; //The distance the bomb has to travel before causing a penalty

    public delegate void ExplodeEvent();
    public static event ExplodeEvent OnExplode;
    
	
	void LateUpdate () {
        transform.Translate(Vector3.down * speed * Time.deltaTime);
        if(transform.position.y < transform.position.y - cutoffDistance)
        {
            if(OnExplode != null)
            {
                OnExplode();
            }
        }
	}
}

using UnityEngine;
using System.Collections;

public class Bombs : MonoBehaviour {

    public float speed;
    public float cutoffDistance; //The distance the bomb has to travel before causing a penalty

    public delegate void ExplodeEvent();
    public static event ExplodeEvent OnExplode;
    public static event ExplodeEvent OnPlayerExplode;
    
	void LateUpdate () {
        transform.Translate(Vector3.down * speed * Time.deltaTime);
        if(transform.position.y < -cutoffDistance)
        {
            if(OnExplode != null)
            {
                OnExplode();
            }
            Destroy(gameObject);
        }

        
	}

    private void OnTriggerEnter(Collider col)
    {
        Debug.Log("Hit Something!");
        if (col.gameObject.tag == "Player")
        {
            if(OnPlayerExplode != null)
            {
                OnPlayerExplode();
            }
            Debug.Log("Destroyed this gameobject");
            Destroy(gameObject);
        }
    }
}

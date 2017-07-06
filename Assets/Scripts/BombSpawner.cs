using UnityEngine;
using System.Collections;

public class BombSpawner : MonoBehaviour {
    //The bombs spawn in waves. The waves will be refered to as Spawns
    public GameObject BombObject;
    public int bombsPerSpawn;
    public float timeBetweenSpawns;
    float currentTimeBetweenSpawns;

    void Start () {
        currentTimeBetweenSpawns = timeBetweenSpawns;
	}
	
	void Update () {
        currentTimeBetweenSpawns -= 1 * Time.deltaTime;
        if(currentTimeBetweenSpawns <= 0)
        {
            StartCoroutine(DropBombs());
            currentTimeBetweenSpawns = timeBetweenSpawns;
        }
	}

    IEnumerator DropBombs()
    {
        for (int i = 0; i < bombsPerSpawn; i++)
        {
            Instantiate(BombObject, transform.position, Quaternion.identity);
            yield return new WaitForSeconds(.1f);
            Debug.Log("#" + i + "Bomb dropped!");
        }
    }
}

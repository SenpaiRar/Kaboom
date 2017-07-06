using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour {
    float xMove; //Player only needs to move in one dimension
    
    public CharacterController c;
    public float speed;
   
    void Start () {
	
	}
	
	void Update () {
        xMove = Input.GetAxisRaw("Horizontal");
        c.Move(new Vector3(xMove, 0, 0) * speed * Time.deltaTime);
	}
}

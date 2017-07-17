using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour {
    float xMove; //Player only needs to move in one dimension
    public Camera mainCamera;
    public CharacterController c;
    public float speed;
    
    private float minX;
    private float maxX;


    void Start() {
        minX = GetMinXValue();
        maxX = GetMaxXValue();

        Debug.Log(minX);
        Debug.Log(maxX);
    }

    void Update() {

        //Mouse controls
        xMove = mainCamera.ScreenToWorldPoint(Input.mousePosition).x;

        //Keyboard controls
        //xMove = Input.GetAxisRaw("Horizontal");
        

    }

    void LateUpdate()
    {

        xMove = Mathf.Clamp(xMove, minX, maxX); //Prevents the player from moving off screen
       transform.transform.position = new Vector3(xMove,transform.position.y, transform.position.z);

        //c.Move(new Vector3(xMove, 0, 0) * speed * Time.deltaTime);
    }

    float GetMaxXValue()
    {
        float maxX = mainCamera.ViewportToWorldPoint(new Vector3(1, 0, 0)).x;
        return maxX;
    }

    float GetMinXValue()
    {
        float minX = mainCamera.ViewportToWorldPoint(new Vector3(0, 0, 0)).x;
        return minX;
    }
}






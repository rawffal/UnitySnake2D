using UnityEngine;
using System.Collections;

public class FoodController : MonoBehaviour {

    public GameObject food;

    public Transform borderTop;
    public Transform borderBottom;
    public Transform borderLeft;
    public Transform borderRight;

	// Use this for initialization
	void Start () {
        InvokeRepeating("Spawn", 3, 4);
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void Spawn()
    {
        int x = (int)Random.Range(borderLeft.position.x, borderRight.position.x);
        int y = (int)Random.Range(borderTop.position.y, borderBottom.position.y);
        Vector2 position = new Vector2(x, y);
        Instantiate(food, position, Quaternion.identity);   
    }
}

using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

public class SnakeController : MonoBehaviour {

    Vector2 dir = Vector2.right;

    List<Transform> tail = new List<Transform>();

    bool ate = false;

    public GameObject tailPrefab;

	// Use this for initialization
	void Start () {
        InvokeRepeating("Move", 0.3f, 0.3f); //300 milliseconds
	}
	
	// Update is called once per frame
	void Update () {
	    if (Input.GetKey(KeyCode.RightArrow))
        {
            dir = Vector2.right;
        } 
        else if (Input.GetKey(KeyCode.LeftArrow))
        {
            dir = -Vector2.right;
        }
        else if (Input.GetKey(KeyCode.UpArrow))
        {
            dir = Vector2.up;
        }
        else if (Input.GetKey(KeyCode.DownArrow))
        {
            dir = -Vector2.up;
        }
	}

    void Move()
    {
        // Save the position that has the gap after the head moves
        Vector2 currentPosition = transform.position;

        // Move the head
        transform.Translate(dir);

        if (ate)
        {
            GameObject tailObject = (GameObject)Instantiate(tailPrefab, currentPosition, Quaternion.identity);
            tail.Insert(0, tailObject.transform);
            ate = false;
        }
        // Check if the snake has a tail
        else if (tail.Count > 0)
        {
            Debug.Log(tail.Count);

            tail.Last().position = currentPosition;
            tail.Insert(0, tail.Last());
            tail.RemoveAt(tail.Count - 1);
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.name.StartsWith("Food"))
        {
            ate = true;
            Destroy(other.gameObject);
        }
        else // collided with something else besides the food and you lose
        {
            
        }
    }
}

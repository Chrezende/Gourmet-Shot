using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour 
{
	public	Path		path;
	public 	float 		speed = 10.0f;
	private float 		step = 1;
	private	int			currentNode = 0;
	private	float		distance = 0.0f;

	void Start ()
	{
		step = step * speed;
		Path[] pathsToGo = FindObjectsOfType<Path>();
		path = pathsToGo[Random.Range(0, pathsToGo.Length)];
		Move (currentNode);

	}

	void Update ()
	{
		CheckNode();
		Move (currentNode);
	}

	void FixedUpdate ()
	{

	}

	void CheckDistanceToNodes ()
	{
		for (int n = 0; n <= path.waypoints.Length - 1; n++) 
		{
			if (Vector3.Distance (transform.position, path.waypoints[n].point.transform.position) < distance) 
			{
				distance = Vector3.Distance (transform.position, path.waypoints [n].point.transform.position);
				currentNode = n;
			}
		}
	}

	void CheckNode ()
	{
		if (Vector3.Distance (transform.position, path.waypoints [currentNode].point.transform.position) < 0.1f) 
		{
			currentNode++;
		}
	}

	void Move (int index)
	{
		
		if (index <= path.waypoints.Length - 1) 
		{
			if (path.waypoints [index] != null) 
			{
				transform.position = Vector3.MoveTowards (transform.position, path.waypoints [index].point.transform.position, step * Time.deltaTime);
				Vector3 dir = path.waypoints [index].point.transform.position - transform.position;
				float angle = (Mathf.Atan2 (dir.y, dir.x) * Mathf.Rad2Deg) - 90;
				transform.rotation = Quaternion.AngleAxis (angle, Vector3.forward);
			}
			else 
			{
				Move (index++);
			}
		}
	}

	
}

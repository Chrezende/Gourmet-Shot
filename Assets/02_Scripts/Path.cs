using UnityEngine;
using System.Collections;

public class Path : MonoBehaviour 
{
	public	Color		pathColor;

	public	Node[]		waypoints;

	void OnDrawGizmos ()
	{
		for (int n = 0; n <= waypoints.Length - 1; n++) 
		{
			if (waypoints [n] != null) 
			{
				Gizmos.color = pathColor;
				Gizmos.DrawWireSphere (waypoints [n].point.transform.position, 0.1f);
				if (n < waypoints.Length - 1) 
				{
					Gizmos.DrawLine (waypoints [n].point.transform.position, waypoints [n + 1].point.transform.position);
				}
			}
		}
	}
}

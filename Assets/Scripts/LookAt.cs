using UnityEngine;
using System.Collections;

public class LookAt : MonoBehaviour {
    public Transform t;

	void Start () {
        t = GameObject.FindGameObjectWithTag("MainCamera").transform;
	}
	
	void Update () {
        if (t != null)
        {
            transform.LookAt(t);
        }
	}
}

﻿using UnityEngine;
using System.Collections;

public class SpriteLookAt : MonoBehaviour {

	public Transform target;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if ( target != null )
			transform.LookAt( target );
	}
}

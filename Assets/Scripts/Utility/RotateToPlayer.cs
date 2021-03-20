﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateToPlayer : MonoBehaviour {

    private Transform obj;
    private Transform player;

    public float moveSpeed = 5f;

	void Start ()
    {
        obj = transform;
        GameObject go = GameObject.FindWithTag("MainCamera");
        player = go.transform;

        obj.rotation = Quaternion.RotateTowards(obj.rotation, Quaternion.LookRotation(-player.position + obj.position), 1000);
    }
	
	void Update ()
    {
        obj.rotation = Quaternion.Slerp(obj.rotation, Quaternion.LookRotation(-player.position + obj.position), moveSpeed * Time.deltaTime);
	}
}

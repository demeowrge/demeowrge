﻿using UnityEngine;
using System.Collections;

public class RandomColor : MonoBehaviour {
    void Start()
    {
        gameObject.GetComponent<SpriteRenderer>().material.color =
            new Color(Random.Range(0f, 1f), Random.Range(0f, 1f), Random.Range(0f, 1f));
    }
	
}

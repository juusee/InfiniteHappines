﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera : MonoBehaviour
{
    private GameObject backgroundGradient;
    private GameObject player;

    private float distanceToPlayerY = 20f;
    private float distanceToPlayerZ = 10f;
    private Vector3 initialCameraPosition;
    private Vector3 initialBackgroundPosition;

    // Start is called before the first frame update
    void Awake()
    {
        this.backgroundGradient = GameObject.Find("BackgroundGradient");
        this.player = GameObject.Find("Player");
        this.initialCameraPosition = transform.position;
        UpdateBackground(0);
        this.initialBackgroundPosition = this.backgroundGradient.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = new Vector3(
            transform.position.x,
            this.player.transform.position.y + this.distanceToPlayerY,
            this.player.transform.position.z + this.distanceToPlayerZ
        );
    }

    public void UpdateBackground(float happiness)
    {
        this.backgroundGradient.transform.position = new Vector3(
            this.backgroundGradient.transform.position.x,
            this.backgroundGradient.transform.position.y - happiness * 50f,
            this.backgroundGradient.transform.position.z
        );
    }

    public void Reset()
    {
        transform.position = this.initialCameraPosition;
        this.backgroundGradient.transform.position = initialBackgroundPosition;
    }
}

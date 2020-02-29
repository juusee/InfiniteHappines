﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FloorSpawner : MonoBehaviour
{
    private float happiness = 0;
    private float happinessStep = 0.15f;

    private Camera cameraScript;
    private Transform playerTransform;
    private GameObject floor;

    private float distanceToPlayer = 10f;
    private float zSpeed = 1f;

    private int floorAmount = 20;
    private List<GameObject> floors = new List<GameObject>();
    private int floorIndex = 0;

    private GameObject lastFloor;

    // Start is called before the first frame update
    void Start()
    {
        this.playerTransform = GameObject.Find("Player").transform;
        this.cameraScript = GameObject.Find("Main Camera").GetComponent<Camera>();
        this.floor = GameObject.Find("Cube");
        InstantiateFloors();
    }

    // Update is called once per frame
    void Update()
    {
        /* TODO deprecated */
        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            this.ChangeHappiness(true);
            print("HAPPINESS: " + this.happiness);
        }
        if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            this.ChangeHappiness(false);
            print("HAPPINESS: " + this.happiness);
        }

        if (transform.position.z - this.playerTransform.position.z < distanceToPlayer)
        {
            transform.position = new Vector3(transform.position.x, transform.position.y + this.happiness, transform.position.z + zSpeed);
            SpawnFloor();
        }

    }

    void InstantiateFloors()
    {
        for (int i = 0; i < this.floorAmount; ++i)
        {
            GameObject floor = GameObject.Instantiate(this.floor);
            floor.SetActive(false);
            floors.Add(floor);
        }
        this.floor.SetActive(false);
        floors.Add(this.floor);
    }

    void SpawnFloor()
    {
        if (this.floorIndex > this.floors.Count - 1)
        {
            this.floorIndex = 0;
        }
        GameObject floor = this.floors[this.floorIndex];
        floor.transform.position = transform.position;
        floor.SetActive(true);
        this.floorIndex++;
        this.lastFloor = floor;
    }

    public GameObject GetLastFloor()
    {
        return this.lastFloor;
    }

    public void ChangeHappiness(bool happiness)
    {
        if (happiness)
        {
            this.happiness += this.happinessStep;
        }
        else
        {
            this.happiness -= this.happinessStep;
        }
        this.cameraScript.UpdateBackground(this.happiness);
    }
}

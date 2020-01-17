using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface ICubeSpawner
{
    // List<GameObject> cubes { get; set; }
    void CreateCube(GameObject prefab, float spectralFlux);
}
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeSpawner : MonoBehaviour, ICubeSpawner
{
    public List<GameObject> cubes  = new List<GameObject>();
    public bool makeRedColor = true;

    int i = 0;
    bool spawnRightOrMiddle = true;
    bool spawnLeftOrMiddle = true;
    bool spawnLeftOrRight = true;

    public void CreateCube(GameObject prefab, float spectralFlux)
    {        
        Vector3 SpawnPosition = Vector3.zero;

        if ((spectralFlux >= 0 && spectralFlux < 0.15f) || (spectralFlux >= 0.45f && spectralFlux < 0.6f) || (spectralFlux >= 1f && spectralFlux < 1.15f))
        {
            SpawnPosition = new Vector3(1, 0, 0);
            int counter = 0;
            if (cubes.Count > 3)
            {
                for (int i = cubes.Count - 1; i > cubes.Count - 4; i--)
                {
                    if (cubes[i].GetComponent<Cube>().SpawnPosition == SpawnPosition)
                        counter++;
                        // print("Initial position: " + (SpawnPosition.x - 2f) + " to " + SpawnPosition.x);
                        
                }
                if (counter == 3)
                {
                    SpawnPosition.x += 1f;
                }
            }
        }
        else if ((spectralFlux >= 0.15f && spectralFlux < 0.3f) || (spectralFlux >= 0.6f && spectralFlux < 0.75f) || (spectralFlux >= 1.45f && spectralFlux < 1.6f))
        {
            SpawnPosition = new Vector3(2, 0, 0);
            if (cubes.Count > 1)
            {
                if (cubes[cubes.Count-1].GetComponent<Cube>().SpawnPosition.x == 1)
                    makeRedColor = true;
                else if (cubes[cubes.Count-1].GetComponent<Cube>().SpawnPosition.x == 3)
                    makeRedColor = false;
            }
            int counter = 0;
            if (cubes.Count > 3)
            {
                for (int i = cubes.Count - 1; i > cubes.Count - 4; i--)
                {
                    if (cubes[i].GetComponent<Cube>().SpawnPosition == SpawnPosition)
                        counter++;
                        // print("Initial position: " + (SpawnPosition.x - 2f) + " to " + SpawnPosition.x);
                        
                }
                if (counter == 3)
                {
                    // print("Last 3 fellas same SpPos");
                    if (spawnLeftOrRight)
                    {
                        SpawnPosition.x -= 1f;
                        spawnLeftOrRight = false;
                    }
                    else
                    {
                        SpawnPosition.x += 1f;
                        spawnLeftOrRight = true;
                    }
                    //print("Initial position change from: " + (SpawnPosition.x - 2f) + " to " + SpawnPosition.x);
                }
            }
        }
        else
        {
            SpawnPosition = new Vector3(3, 0, 0);
            int counter = 0;
            if (cubes.Count > 3)
            {
                for (int i = cubes.Count - 1; i > cubes.Count - 4; i--)
                {
                    if (cubes[i].GetComponent<Cube>().SpawnPosition == SpawnPosition)
                        counter++;
                        // print("Initial position: " + (SpawnPosition.x - 2f) + " to " + SpawnPosition.x);
                        
                }
                if (counter == 3)
                {
                    SpawnPosition.x -= 1f;
                    // print("Last 3 fellas same SpPos");
                    // if (spawnRightOrMiddle)
                    // {
                    //     SpawnPosition.x -= 1f;
                    //     spawnRightOrMiddle = false;
                    // }
                    // else
                    // {
                    //     SpawnPosition.x -= 2f;
                    //     spawnRightOrMiddle = true;
                    // }
                    //print("Initial position change from: " + (SpawnPosition.x - 2f) + " to " + SpawnPosition.x);
                }
            }
        }

        GameObject cube = Instantiate(prefab, SpawnPosition, UnityEngine.Quaternion.identity);
        // cube.GetComponent<MeshRenderer>().material
        cube.GetComponent<Cube>().SpawnPosition = SpawnPosition;
        i++;
        cubes.Add(cube);
        
        cube.name = string.Format("Cube number: {0} with Index: {1} ", i, cubes.IndexOf(cube));
        Destroy(cube, 3f);
    }

    public void DecideCubePosition()
    {

    }
}
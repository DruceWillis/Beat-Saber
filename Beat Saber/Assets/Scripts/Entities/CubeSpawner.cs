using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeSpawner : MonoBehaviour, ICubeSpawner
{
    public List<GameObject> cubes  = new List<GameObject>();
    public bool makeRedColor = true;

    public int cubeCounter = 0;
    bool spawnRight = true;

    public void CreateCube(GameObject prefab, float spectralFlux)
    {
        Vector3 SpawnPosition = Vector3.zero;
        SpawnPosition = DecideCubePosition(spectralFlux);

        GameObject cube = Instantiate(prefab, SpawnPosition, UnityEngine.Quaternion.identity);
        cube.GetComponent<Cube>().SpawnPosition = SpawnPosition;
        cubeCounter++;
        cubes.Add(cube);

        cube.name = string.Format("Cube number: {0} with Index: {1} ", cubeCounter, cubes.IndexOf(cube));
        Destroy(cube, 3f);
    }

    private Vector3 DecideCubePosition(float spectralFlux)
    {
        Vector3 SpawnPosition;
        
        if ((spectralFlux >= 0 && spectralFlux < 0.15f) || (spectralFlux >= 0.45f && spectralFlux < 0.6f) || (spectralFlux >= 1f && spectralFlux < 1.15f))
        {
            SpawnPosition = new Vector3(1, 0, 0);
            makeRedColor = true;
            int counter = 0;
            if (cubes.Count > 3)
            {
                for (int i = cubes.Count - 1; i > cubes.Count - 4; i--)
                {
                    if (cubes[i].GetComponent<Cube>().SpawnPosition == SpawnPosition)
                        counter++;
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
            int counter = 0;
            if (cubes.Count > 3)
            {
                for (int i = cubes.Count - 1; i > cubes.Count - 4; i--)
                {
                    if (cubes[i].GetComponent<Cube>().SpawnPosition == SpawnPosition)
                        counter++;
                }

                if (counter == 3)
                {
                    if (spawnRight)
                    {
                        SpawnPosition.x -= 1f;
                        spawnRight = false;
                    }
                    else
                    {
                        SpawnPosition.x += 1f;
                        spawnRight = true;
                    }
                }
            }
        }
        else
        {
            SpawnPosition = new Vector3(3, 0, 0);
            makeRedColor = false;
            int counter = 0;
            if (cubes.Count > 3)
            {
                for (int i = cubes.Count - 1; i > cubes.Count - 4; i--)
                {
                    if (cubes[i].GetComponent<Cube>().SpawnPosition == SpawnPosition)
                        counter++;
                }

                if (counter == 3)
                {
                    SpawnPosition.x -= 1f;
                }
            }
        }

        return SpawnPosition;
    }
}
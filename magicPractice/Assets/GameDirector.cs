using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameDirector : MonoBehaviour {
    string nameTemplate = @"{0}";
    List<GameObject> cubes = new List<GameObject>();
    GameObject cube;
    GameObject cubeNumber;

    int count;
    float positionX, positionZ;
    List<GameObject> magicCube = new List<GameObject>();
    GameObject[] magic = new GameObject[9];

    void Start () {
        count = 0;
        for (int i = 1; i < 10; i++)
        {
            string cubeName = string.Format(nameTemplate, i);
            cube = GameObject.Find(cubeName);
            cubes.Add(cube);
        }
	}

    // Update is called once per frame
    void Update()
    {
        AddMagicCube();
    }

    void AddMagicCube()
    {
        foreach (GameObject cube in cubes)
        {
            positionX = cube.transform.position.x;
            positionZ = cube.transform.position.z;

            if (positionX < -1.5f && positionX > -2.5f)
            {
                if (positionZ > 1.5f && positionZ<2.5f) { magic[0] = cube;  }
                else if (positionZ < -1.5f && positionZ > -2.5f) { magic[6] = cube; }
                else if (positionZ<1.5f && positionZ >- 1.5f) { magic[3] = cube; }
            }
            else if (positionX > 1.5f && positionX<2.5f)
            {
                if (positionZ > 1.5f && positionZ < 2.5f) { magic[2] = cube;}
                else if (positionZ < -1.5f && positionZ > -2.5f) { magic[8] = cube;}
                else if (positionZ < 1.5f && positionZ > -1.5f) { magic[5] = cube;}
            }
            else if (positionX < 1.5f && positionX > -1.5f)
            {
                if (positionZ > 1.5f && positionZ < 2.5f) { magic[1] = cube; }
                else if (positionZ < -1.5f && positionZ > -2.5f) { magic[7] = cube;}
                else if (positionZ < 1.5f && positionZ > -1.5f) { magic[4] = cube;}
            }
        }
    }

    bool checkMagic()
    {
        for (int i = 0; i < 9; i++)
        {
            Debug.Log(magic[i].name);
        }
        if ((Convert.ToInt32(magic[0].name) + Convert.ToInt32(magic[4].name) + Convert.ToInt32(magic[8].name) == 15) &&
            (Convert.ToInt32(magic[2].name) + Convert.ToInt32(magic[4].name) + Convert.ToInt32(magic[6].name) == 15))
        {
            return true;
        }
        else
        {
            return false;
        }
    }
    void GameFailed()
    {
        foreach (GameObject cube in cubes)
        {
            cube.transform.position = new Vector3(UnityEngine.Random.Range(-5, 5), 3, UnityEngine.Random.Range(-7, -4));
        }
    }
    public void Submit()
    {
        if (checkMagic()) { Debug.Log("성공했어요!"); }
        else { Debug.Log("틀렸어!"); GameFailed(); }
    }
}

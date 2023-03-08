using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fractal : MonoBehaviour
{ 
    public GameObject cubePrefab;
    public int level = 3;
    public float size = 3.0f;
    private int count = 0;

    void Start()
    {
        CreateSponge(Vector3.zero, size, level);
    }

    public void Regenerate()
    {
        CreateSponge(Vector3.zero, size, level);
    }

    void CreateSponge(Vector3 center, float size, int level)
    {
        if (level == 0)
        {
            GameObject cube = Instantiate(cubePrefab, center, Quaternion.identity);
            cube.transform.localScale = Vector3.one * size;
            cube.transform.parent = transform;
            count++;
        }
        else
        {
            float newSize = size / 3.0f;
            for (int x = -1; x <= 1; x++)
            {
                for (int y = -1; y <= 1; y++)
                {
                    for (int z = -1; z <= 1; z++)
                    {
                        if (Mathf.Abs(x) + Mathf.Abs(y) + Mathf.Abs(z) > 1)
                        {
                            CreateSponge(center + new Vector3(x * newSize, y * newSize, z * newSize), newSize, level - 1);
                        }
                    }
                }
            }
        }
    }
}




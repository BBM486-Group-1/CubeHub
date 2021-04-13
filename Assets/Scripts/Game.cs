using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Game : MonoBehaviour
{

    GameObject[] cubes; 
    [SerializeField] int numberOfCubes;

    // Start is called before the first frame update
    void Start()
    {
        cubes = new GameObject[numberOfCubes];

        for (int i = 0; i < numberOfCubes; i++ ){
            GameObject cube = GameObject.CreatePrimitive(PrimitiveType.Cube);
            cube.transform.position = new Vector3(2 * i , 0, 0);
            cubes[i] = cube;
        }
        
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

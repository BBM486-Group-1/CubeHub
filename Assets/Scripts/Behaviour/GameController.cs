using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    [SerializeField] private int numberOfCubes;
    
    private ArrayList cubes; 

    [SerializeField] private Cursor _cursor;

    [SerializeField] private InputHandler inputHandler;

    // Start is called before the first frame update
    void Start()
    {
        cubes = new ArrayList();

        for (int i = 0; i < numberOfCubes; i++ ){
            GameObject cube = GameObject.CreatePrimitive(PrimitiveType.Cube);
            int x = Random.Range(-20, 20);
            int y = Random.Range(-5,   5);
            int z = Random.Range(-20, 20);
            cube.transform.position = new Vector3(x, y, z);
            cubes.Add(cube);
        }
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

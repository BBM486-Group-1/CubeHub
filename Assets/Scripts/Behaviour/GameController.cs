using System.Collections.Generic;
using DataStructure;
using Domain.Object;
using UnityEngine;

namespace Behaviour
{
    public class GameController : MonoBehaviour
    {
        [SerializeField] private int numberOfCubes;
        [SerializeField] private Material boxMaterial;

        [SerializeField] private InputHandler inputHandler;

        [SerializeField] private CursorController cursorController;

        private DiscretePositionMap<Cube> _positionMap;
        
        // Start is called before the first frame update
        void Start()
        {
            _positionMap = new DiscretePositionMap<Cube>();
            
            cursorController.GetCursor().SetCubePositionMap(_positionMap);
            
            List<Cube> cubes = new List<Cube>();

            for (var i = 0; i < numberOfCubes; i++)
            {
                var cubeObject = GameObject.CreatePrimitive(PrimitiveType.Cube);

                cubeObject.GetComponent<MeshRenderer>().material = boxMaterial;
                float hue = (Random.Range(0, 360) % 10) / 10.0f;
                cubeObject.GetComponent<Renderer>().material.color = Color.HSVToRGB(hue, 0.25f, 0.5f);

                var x = Random.Range(-20, 20);
                var y = Random.Range(-5, 5);
                var z = Random.Range(-20, 20);
                cubeObject.transform.position = new Vector3(x, y, z);
                Cube cube = new Cube(cubeObject);
                cubes.Add(cube);
                _positionMap.Set(cubeObject.transform.position, cube);
            }
        }

        // Update is called once per frame
        void Update()
        { 
            
        }
    }
}
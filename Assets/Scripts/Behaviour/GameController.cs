using System.Collections.Generic;
using DataStructure;
using Domain.Object;
using UnityEngine;

namespace Behaviour
{
    public class GameController : MonoBehaviour
    {
        private static readonly int EmissionColor = Shader.PropertyToID("_EmissionColor");
        [SerializeField] private int numberOfCubes;

        [SerializeField] private Material boxMaterial;

        [SerializeField] private InputHandler inputHandler;

        [SerializeField] private CursorController cursorController;

        [SerializeField] private float glowIntensity;

        private DiscretePositionMap<Cube> _cubePositionMap;

        // Start is called before the first frame update
        void Start()
        {
            _cubePositionMap = new DiscretePositionMap<Cube>();

            cursorController.GetCursor().SetCubePositionMap(_cubePositionMap);

            int i = 0;
            while (i < numberOfCubes)
            {
                var x = Random.Range(-5, 5);
                var y = Random.Range(-5, 5);
                var z = Random.Range(10, 20);
                var randomPosition = new Vector3(x, y, z);

                if (!_cubePositionMap.Occupied(randomPosition))
                {
                    var cubeObject = GameObject.CreatePrimitive(PrimitiveType.Cube);

                    cubeObject.GetComponent<MeshRenderer>().material = boxMaterial;

                    float hue = (Random.Range(0, 360) % 10) / 10.0f;
                    Color rgb = Color.HSVToRGB(hue, 1f, 1f);
                    rgb = new Color(rgb.r * glowIntensity, rgb.g * glowIntensity, rgb.b * glowIntensity);
                    cubeObject.GetComponent<MeshRenderer>().material.SetColor(EmissionColor, rgb);

                    cubeObject.transform.position = randomPosition;
                    Cube cube = new Cube(cubeObject);
                    _cubePositionMap.Set(randomPosition, cube);
                    i++;
                }
            }
        }

        // Update is called once per frame
        void Update()
        {
        }
    }
}
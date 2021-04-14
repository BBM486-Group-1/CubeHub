using System.Collections;
using UnityEngine;

namespace Behaviour
{
    public class GameController : MonoBehaviour
    {
        [SerializeField] private int numberOfCubes;
        [SerializeField] private Material boxMaterial;

        private ArrayList _cubes;

        [SerializeField] private InputHandler inputHandler;

        // Start is called before the first frame update
        void Start()
        {
            _cubes = new ArrayList();

            for (var i = 0; i < numberOfCubes; i++)
            {
                var cube = GameObject.CreatePrimitive(PrimitiveType.Cube);

                cube.GetComponent<MeshRenderer>().material = boxMaterial;
                float hue = (((int) Random.Range(0, 360)) % 10) / 10.0f;
                cube.GetComponent<Renderer>().material.color = Color.HSVToRGB(hue, 0.25f,0.5f);

                var x = Random.Range(-20, 20);
                var y = Random.Range(-5, 5);
                var z = Random.Range(-20, 20);
                cube.transform.position = new Vector3(x, y, z);
                _cubes.Add(cube);
            }
        }

        // Update is called once per frame
        void Update()
        {
        }
    }
}
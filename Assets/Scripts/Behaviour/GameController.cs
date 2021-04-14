using System.Collections;
using UnityEngine;

namespace Behaviour
{
    public class GameController : MonoBehaviour
    {
        [SerializeField] private int numberOfCubes;
    
        private ArrayList _cubes;  

        [SerializeField] private InputHandler inputHandler;

        // Start is called before the first frame update
        void Start()
        {
            _cubes = new ArrayList();

            for (int i = 0; i < numberOfCubes; i++ ){
                GameObject cube = GameObject.CreatePrimitive(PrimitiveType.Cube);
                int x = Random.Range(-20, 20);
                int y = Random.Range(-5,   5);
                int z = Random.Range(-20, 20);
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

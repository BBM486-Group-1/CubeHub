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

            for (var i = 0; i < numberOfCubes; i++ ){
                var cube = GameObject.CreatePrimitive(PrimitiveType.Cube);
                var x = Random.Range(-20, 20);
                var y = Random.Range(-5,   5);
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

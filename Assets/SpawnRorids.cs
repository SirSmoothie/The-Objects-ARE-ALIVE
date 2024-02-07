using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace rory
{
    public class SpawnRorids : MonoBehaviour
    {
        public int SpawnSize;
        public GameObject Boid;

        public void Spawn()
        {
            for (int x = 0; x < SpawnSize; x++)
            {
                for (int z = 0; z < SpawnSize; z++)
                {
                    Instantiate(Boid, new Vector3(x, 0, z), Quaternion.identity);
                }
            }
        }
    }
}

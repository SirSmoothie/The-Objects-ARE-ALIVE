using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace rory
{
    public class BoidCage : MonoBehaviour
    {
        public float radiusOfCage;
        
        private void OnDrawGizmos()
        {
            Gizmos.DrawSphere(transform.position, radiusOfCage);
        }
    }
}

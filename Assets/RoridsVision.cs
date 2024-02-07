using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace rory
{
    public class RoridsVision : MonoBehaviour
    {
        public float range;
        public LayerMask mask;
        private RaycastHit hit;
        public float raycastStep;
        public int noOfRays = 2;

        public float GetDist()
        {
            if (Physics.Raycast(transform.localPosition, transform.forward, out hit, range, mask))
            {
                var dist = range / hit.distance;
                return dist;
            }
            return 1;
        }

        
        private RaycastHit hitL;
        private RaycastHit hitR;
        public bool Obstructed()
        {
            if(Physics.Raycast(transform.localPosition, transform.forward, out hit, range, mask))
            {
                return true;
            }
            return false;
        }
    }
}
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

        public float maxAngle = 100;
        public int rays = 10;
        public float spacingScale = 1f;

        public float TurnDir;

        public AnimationCurve distanceMultiplier;
        
        public float GetDist()
        {
            if (Physics.Raycast(transform.localPosition, transform.forward, out hit, range, mask))
            {
                var dist = range / hit.distance;
                return dist;
            }
            return 1;
        }
        
        public float GetObstructedSight()
        {
            TurnDir = 0;
            for (int i = -rays/2; i <= rays/2; i++)
            {
                // Very simple. Doesn't take any tilting or pitching into account, but is fine for horizontal only AIs
                float spreadAngle = -maxAngle/(rays-1);
                Vector3 dir = Quaternion.Euler(0, i*spreadAngle, 0) * transform.forward;
                //Debug.DrawRay(transform.position, dir * range, Color.yellow);
                if (Physics.Raycast(transform.localPosition, dir, out hit, range, mask))
                {
                    var dist = hit.distance/range;
                    TurnDir -= (i*spreadAngle)*distanceMultiplier.Evaluate(dist);
                }
                else
                {
                    var dist = hit.distance/range;
                    TurnDir += (i*spreadAngle)*distanceMultiplier.Evaluate(dist);
                }
            }

            return TurnDir;
        }

        
        private RaycastHit hitL;
        private RaycastHit hitR;
        public bool Obstructed()
        {
            for (int i = -rays/2; i <= rays/2; i++)
            {
                float spreadAngle = -maxAngle/(rays-1);
                Vector3 dir = Quaternion.Euler(0, i*spreadAngle, 0) * transform.forward;
                if (Physics.Raycast(transform.localPosition, dir, out hit, range, mask))
                {
                    return true;
                }
            }
            return false;
        }

        public float ReturnSightRange()
        {
            return range;
        }
    }
}
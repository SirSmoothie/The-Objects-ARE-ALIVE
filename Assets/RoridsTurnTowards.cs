using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace rory
{

    public class RoridsTurnTowards : MonoBehaviour
    {
        private Rigidbody rb;

        public float turnSpeed;
        public Transform targetTransform;
        public Vector3 targetPostion;

        private void Start()
        {
            rb = GetComponent<Rigidbody>();
        }

        private void FixedUpdate()
        {
            if (targetTransform != null)
            {
                Vector3 targetDir;
                targetDir = targetTransform.position - transform.position;

                float angle = Vector3.SignedAngle(transform.forward, targetDir*turnSpeed, Vector3.up);
                
                rb.AddRelativeTorque(0, angle, 0, ForceMode.Force);
            }
        }
        
        
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace rory
{
    public class RoridsForward : MonoBehaviour
    {
        private Rigidbody rb;
        private RoridsVision vision;
        public float speed;

        private void Start()
        {
            vision = GetComponent<RoridsVision>();
            rb = GetComponent<Rigidbody>();
            transform.eulerAngles = new Vector3(0, Random.Range(0, 360), 0);
        }

        private void FixedUpdate()
        {
            MoveForward();
        }

        public void MoveForward()
        {
            var tempSpeed = speed / (vision.GetDist() /2);
            rb.AddForce(transform.forward * tempSpeed, ForceMode.Force);
        }
    }
}

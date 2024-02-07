using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;


namespace rory
{
    public class Rorids : MonoBehaviour
    {
        private Rigidbody rb;
        private float perlinOffset;
        [SerializeField] private float perlinNoise;
        public float speed;

        private void Start()
        {
            rb = GetComponent<Rigidbody>();
            transform.eulerAngles = new Vector3(0, Random.Range(0, 360), 0);
            perlinOffset = Random.Range(-99999, 99999);
        }

        private void FixedUpdate()
        {
            MoveForward();
            perlinNoise = Mathf.PerlinNoise1D(Time.time + perlinOffset);
            perlinNoise -= 0.5f;
            rb.AddRelativeTorque(0, perlinNoise, 0);
        }

        public void MoveForward()
        {
            rb.AddForce(transform.forward, ForceMode.Force);
        }
    }

}
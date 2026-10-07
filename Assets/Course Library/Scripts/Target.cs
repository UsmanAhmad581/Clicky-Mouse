using UnityEngine;
using System.Collections;
using NUnit.Framework.Internal;

public class Target : MonoBehaviour
{   
    public Rigidbody targetRb;
    public float randomizedSpeed;
    

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        targetRb = GetComponent<Rigidbody>();
        randomizedSpeed = Random.Range(15,16);
        targetRb.AddForce(Vector3.up * randomizedSpeed, ForceMode.Impulse);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

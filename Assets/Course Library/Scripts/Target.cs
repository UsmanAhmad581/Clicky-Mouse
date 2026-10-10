using UnityEngine;
using System.Collections;
using NUnit.Framework.Internal;
using UnityEngine.InputSystem;

public class Target : MonoBehaviour
{   
    public Rigidbody targetRb;
    private float minSpeed = 12;
    private float maxSpeed = 16f;
    private float ySpawnPos = -5f;
    private float xRange = 4f;
    private float maxTorque = 10f;
    private GameManager gameManager;
    public int pointValue;

    public ParticleSystem explosionParticle;
    

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {  
        gameManager = GameObject.Find("Game Manager").GetComponent<GameManager>();
        targetRb = GetComponent<Rigidbody>();
        targetRb.AddForce(RandomForce(), ForceMode.Impulse);
        targetRb.AddTorque(RandomTorque(), RandomTorque(), RandomTorque(), ForceMode.Impulse);
        transform.position = RandomSpawnPos();
    }

    // Update is called once per frame
    void Update()
    {   
        if(gameManager.isGameActive)
        {
           if(Mouse.current.leftButton.wasPressedThisFrame)
            {
            Debug.Log("Mouse Clicked");
            Ray ray = Camera.main.ScreenPointToRay(Mouse.current.position.ReadValue());
            Debug.DrawRay(ray.origin, ray.direction * 1000, Color.red, 1f);
            if(Physics.Raycast(ray, out RaycastHit hitInfo))
            {
                if(hitInfo.transform == transform)
                {
                    Destroy(gameObject);
                    Explode();
                    gameManager.UpdateScore(pointValue);
                }
            }
            }
        }
    }
    
    Vector3 RandomSpawnPos()
    {
        return new Vector3(Random.Range(-xRange, xRange), ySpawnPos);
    }
    Vector3 RandomForce()
    {
        return Vector3.up * Random.Range(minSpeed, maxSpeed);
    }
    float RandomTorque()
    {
        return Random.Range(-maxTorque, maxTorque);
    }
    void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("DestroyZone"))
        {
            Destroy(gameObject);
        }
        if(!gameObject.CompareTag("Bad"))
        {
            gameManager.GameOver();
        }
        
    }
    void Explode()
    {
        Instantiate(explosionParticle, transform.position, explosionParticle.transform.rotation);
    }
   
}

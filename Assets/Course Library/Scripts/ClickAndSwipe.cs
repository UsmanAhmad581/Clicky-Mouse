using UnityEngine;
using System.Collections;

[RequireComponent(typeof(TrailRenderer), typeof(BoxCollider))]


public class ClickAndSwipe : MonoBehaviour
{   
    private GameManager gamemanager;
    private Camera cam;
    private Vector3 mousePos;
    private TrailRenderer trail;
    private BoxCollider boxCollider;
    private bool swiping;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Awake()
    {
        gamemanager = FindObjectOfType<GameManager>();
        cam = Camera.main;
        trail = GetComponent<TrailRenderer>();
        boxCollider = GetComponent<BoxCollider>();
        trail.enabled = false;
        boxCollider.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
      if(gamemanager.isGameActive)
      {
        if (Input.GetMouseButtonDown(0))
        {
            swiping = true;
            UpdateMousePosition();
            UpdateTrailAndCollider();
        }
        else if (Input.GetMouseButtonUp(0))
        {
            swiping = false;
            UpdateTrailAndCollider();
        }
        if (swiping)
        {
            UpdateMousePosition();
        }
      }
    }
    void UpdateMousePosition()
    {
        mousePos = cam.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, 10));
        transform.position = mousePos;
    }
    void UpdateTrailAndCollider()
    {
        trail.enabled = swiping;
        boxCollider.enabled = swiping;
    }
}

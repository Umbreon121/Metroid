using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera : MonoBehaviour
{
    // is the position that the camera starts
    private Vector3 startPosition;
    // what the camera follows
    public Transform target;
    // Start is called before the first frame update
    void Start()
    {
        startPosition = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
      transform.position = target.position + startPosition;
    }
}

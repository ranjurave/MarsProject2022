using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowCamera : MonoBehaviour {
    RocketScript Rocket;

    [SerializeField]
    Vector3 CameraOffset = new Vector3(0,2,-16);

    void Start()
    {

        Rocket = FindObjectOfType<RocketScript>();
    }

    void Update()
    {
        //Debug.Log(Rocket.transform.position);
        //Debug.Log(transform.position);

        transform.position = Rocket.transform.position + CameraOffset;
    }
}

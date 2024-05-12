using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Samcam : MonoBehaviour
{
    public Sam sam;
    public float camSpeed;
    public Vector3 camPosition;
    void Start()
    {
        camPosition = transform.position - sam.transform.position;
    }


    void Update()
    {
        transform.position = Vector3.Lerp(transform.position, sam.transform.position + camPosition,Time.deltaTime * camSpeed);
    }
}

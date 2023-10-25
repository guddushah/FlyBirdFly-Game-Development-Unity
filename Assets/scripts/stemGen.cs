using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class stemGen : MonoBehaviour {

    // Use this for initialization
    public float parallaxSpeed;
    public float backgroundSize;
    public const float speed = 0.05f;
    private Transform cameraTransform;
    private Transform[] layers;
    private int downIndex;
    private int upIndex;
    private float lastCameraX;
    public const float delta = 0.008f;
    public bool canScroll;


    void Start()
    {
        cameraTransform = Camera.main.transform;
        lastCameraX = cameraTransform.position.y;
        layers = new Transform[transform.childCount];
        for (int i = 0; i < transform.childCount; i++)
        {
            layers[i] = transform.GetChild(i);
        }
        downIndex = 0;
        upIndex = layers.Length - 1;
    }

    void Update()
    {
        transformdis();


    }

    public void transformdis()
    {
        lastCameraX = cameraTransform.position.y;
        if (cameraTransform.position.y < (layers[downIndex].transform.position.y))
        {
            scrollDown();
        }
        if (cameraTransform.position.y > (layers[upIndex].transform.position.y))
        {
            scrollUp();
        }
    }


    private void scrollDown()
    {
        int lastUp = upIndex;
        layers[upIndex].position = Vector3.up * (layers[downIndex].position.y - backgroundSize);
        downIndex = upIndex;
        upIndex--;
        if (upIndex < 0)
        {
            upIndex = layers.Length - 1;
        }
    }
    private void scrollUp()
    {

        int lastDown = downIndex;
        layers[downIndex].position = Vector3.up * (layers[upIndex].position.y + backgroundSize);
        upIndex = downIndex;
        downIndex++;
        if (downIndex == layers.Length)
        {
            downIndex = 0;
        }
    }
}


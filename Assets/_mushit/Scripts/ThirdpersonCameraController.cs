//SmoothLookAt.cs
//Written by Jake Bayer
//Written and uploaded November 18, 2012
//This is a modified C# version of the SmoothLookAt JS script.  Use it the same way as the Javascript version.

using UnityEngine;
using System.Collections;

///<summary>
///Looks at a target
///</summary>
public class ThirdpersonCameraController : MonoBehaviour
{
    public new Camera camera;
    public Transform target;        //an Object to lock on to
    public Vector3 offset;
    public float distance = 10.0f;

    float xSpeed = 250;
    float ySpeed = 120;

    float yMinLimit = -20;
    float yMaxLimit = 80;

    private Transform _myTransform;
    private Vehicle jet;

    private float x = 0;
    private float y = 0;

    void Awake()
    {
        camera = camera ?? Camera.main;
        _myTransform = camera.transform;

        jet = GetComponent<Vehicle>();
    }

    // Use this for initialization
    void Start()
    {
        var angles = transform.eulerAngles;
        x = angles.y;
        y = angles.y;

    }

    // Update is called once per frame
    void Update()
    {

    }
    void LateUpdate()
    {
        if (!jet.canControl)
            return;

        if (target)
        {
            bool altDown = Input.GetAxisRaw("FreeLook") == 1;
            if (altDown)
            {
                x += Input.GetAxis("Mouse X") * xSpeed * 0.02f;
                y -= Input.GetAxis("Mouse Y") * ySpeed * 0.02f;

                y = Mathf.Clamp(y, yMinLimit, yMaxLimit);

                var rotation = Quaternion.Euler(y, x, 0);
                var position = rotation * new Vector3(0.0f, 0.0f, -distance) + target.position + offset;

                _myTransform.rotation = rotation;
                _myTransform.position = position;
            }
            else
            {
                _myTransform.localPosition = Vector3.zero;
                _myTransform.localRotation = Quaternion.identity;
            }
        }
    }
}
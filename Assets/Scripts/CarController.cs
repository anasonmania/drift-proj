using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarController : MonoBehaviour
{
    // Start is called before the first frame update


    public float MotorForce = 300f;
    public float SteerForce = 25f;
    public WheelCollider wcRF;
    public WheelCollider wcRB;
    public WheelCollider wcLF;
    public WheelCollider wcLB;

    public Transform RFtr;
    public Transform RBtr;
    public Transform LFtr;
    public Transform LBtr;

    public float _v;
    public float _h;


    void Awake()
    {

        RFtr = transform.Find("WheelMeshes").Find("RF").transform;
        RBtr = transform.Find("WheelMeshes").Find("RB").transform;
        LFtr = transform.Find("WheelMeshes").Find("LF").transform;
        LBtr = transform.Find("WheelMeshes").Find("LB").transform;
    }

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {


    }

    void FixedUpdate()
    {
        HandleInputs();
        HandleTorque();
        HandleSteer();
        HandleWheels();
    }

    void HandleInputs()
    {

        _v = Input.GetAxis("Vertical") * MotorForce;
        _h = Input.GetAxis("Horizontal") * SteerForce;
    }

    void HandleTorque()
    {
        wcRB.motorTorque = _v;
        wcLB.motorTorque = _v;

    }
    
    void HandleSteer()
    {
        wcRF.steerAngle = _h;
        wcLF.steerAngle = _h;

    }

    void HandleWheels()
    {

        UpdateWheelPosition(wcLB, LBtr);
        UpdateWheelPosition(wcLF, LFtr);
        UpdateWheelPosition(wcRB, RBtr);
        UpdateWheelPosition(wcRF, RFtr);
        
    }

    void UpdateWheelPosition(WheelCollider wc, Transform t)
    {
        Vector3 pos = t.position;
        Quaternion rot = t.rotation;

        wc.GetWorldPose(out pos, out rot);
        t.position = pos;
        t.rotation = rot;

    }
}

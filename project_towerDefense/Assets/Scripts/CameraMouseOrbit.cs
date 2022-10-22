using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMouseOrbit : MonoBehaviour
{
    public Transform target;
    public float distance = 5f;
    public float xSpeed = 120f;
    public float ySpeed = 120f;
    public float yMinLimit = -20f;
    public float yMaxLimit = 80f;
    public float distanceMin = 0.5f;
    public float distanceMax = 15f;
    private float x;
    private float y;
    [Space(20f)]
    //public bool autoMovement;
    public float autoSpeedX = 0.2f;
    public float autoSpeedY = 0.1f;
    public float autoSpeedDistance = -0.1f;

    private void Start()
    {
        Vector3 eulerAngles = this.transform.eulerAngles;
        this.x = eulerAngles.y;
        this.y = eulerAngles.x;
        Rigidbody component = this.GetComponent<Rigidbody>();
        if (!((Object)component != (Object)null))
            return;
        component.freezeRotation = true;
    }

    private void LateUpdate()
    {
        if (!(bool)(Object)this.target)
            return;
        if (Input.GetMouseButton(1))
        {
            this.x += (float)((double)Input.GetAxis("Mouse X") * (double)this.xSpeed * (double)this.distance * 0.0199999995529652);
            this.y -= (float)((double)Input.GetAxis("Mouse Y") * (double)this.ySpeed * 0.0199999995529652);
        }
       /* else if (this.autoMovement)
        {
            this.x += (float)((double)this.autoSpeedX * (double)this.distance * 0.200000002980232);
            this.y += this.autoSpeedY;
            this.distance += this.autoSpeedDistance;
        }*/
        this.y = CameraMouseOrbit.ClampAngle(this.y, this.yMinLimit, this.yMaxLimit);
        Quaternion quaternion = Quaternion.Euler(this.y, this.x, 0.0f);
        this.distance = Mathf.Clamp(this.distance - Input.GetAxis("Mouse ScrollWheel") * 5f, this.distanceMin, this.distanceMax);
        RaycastHit hitInfo;
        if (Physics.Linecast(this.target.position, this.transform.position, out hitInfo))
            this.distance -= hitInfo.distance;
        Vector3 vector3_1 = new Vector3(0.0f, 0.0f, -this.distance);
        Vector3 vector3_2 = quaternion * vector3_1 + this.target.position;
        this.transform.rotation = quaternion;
        this.transform.position = vector3_2;
    }

    public static float ClampAngle(float angle, float min, float max)
    {
        if ((double)angle < -360.0)
            angle += 360f;
        if ((double)angle > 360.0)
            angle -= 360f;
        return Mathf.Clamp(angle, min, max);
    }
}

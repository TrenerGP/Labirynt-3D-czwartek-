using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class PortalCamera : MonoBehaviour
{
    public Transform playerCamera;
    public Transform portal;
    public Transform otherPortal;

    void Update()
    {
        FixedCamera();
    }

    private void FixedCamera()
    {
        Vector3 playerOffsetFromPortal = 
            playerCamera.position - otherPortal.position;
        transform.position = portal.position + playerOffsetFromPortal;

        float angularDiffrence =
            Quaternion.Angle(portal.rotation, otherPortal.rotation);
        Quaternion portalRotationDifference =
            Quaternion.AngleAxis(angularDiffrence, Vector3.up);
        Vector3 newCameraDirection = 
            portalRotationDifference * playerCamera.forward;

        newCameraDirection = new Vector3(
            newCameraDirection.x*-1,
            newCameraDirection.y,
            newCameraDirection.z*-1
            );

        transform.rotation =
            Quaternion.LookRotation(newCameraDirection, Vector3.up);
    }

}

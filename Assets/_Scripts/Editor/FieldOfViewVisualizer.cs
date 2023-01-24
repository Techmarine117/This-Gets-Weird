using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

[CustomEditor(typeof(AIRayCast))]
public class FieldOfViewVisualizer : Editor
{
    private void OnSceneGUI()
    {
        AIRayCast Fov = (AIRayCast)target;
        Handles.color = Color.green;
        Handles.DrawWireArc(Fov.transform.position, Vector3.up, Vector3.forward, 360, Fov.ViewRadius);

        Vector3 ViewAngleA = DirFromAngle(Fov.transform.eulerAngles.y, -Fov.ViewAngle / 2);
        Vector3 ViewAngleB = DirFromAngle(Fov.transform.eulerAngles.y, Fov.ViewAngle / 2);

        Handles.color = Color.white;
        Handles.DrawLine(Fov.transform.position, Fov.transform.position + ViewAngleA * Fov.ViewRadius);
        Handles.DrawLine(Fov.transform.position, Fov.transform.position + ViewAngleB * Fov.ViewRadius);

        if (Fov.PlayerHit)
        {
            Handles.color = Color.red;
            Handles.DrawLine(Fov.transform.position, Fov.PlayerReference.transform.position);
        }
    }

    private Vector3 DirFromAngle(float EulerY, float AngleInDegrees)
    {
        AngleInDegrees += EulerY;

        return new Vector3(Mathf.Sin(AngleInDegrees * Mathf.Deg2Rad), 0, Mathf.Cos(AngleInDegrees * Mathf.Deg2Rad));
    }
}

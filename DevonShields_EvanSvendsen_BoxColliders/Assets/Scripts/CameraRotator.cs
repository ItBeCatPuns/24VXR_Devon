using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
///     Added to the player to control the camera rotation.
/// </summary>
public class CameraRotator : MonoBehaviour
{
    [SerializeField] private Transform characterPivot;
    [SerializeField] private Transform cameraPivot;
    [SerializeField] private float rotationSpeed = 50f;

    void Update()
    {
        if (Time.frameCount < 1) return;

        //Get the axis for the input
        var x = Input.GetAxis("Mouse X");
        var y = -Input.GetAxis("Mouse Y");

        cameraPivot.Rotate(Vector3.right, y * rotationSpeed * Time.deltaTime);
        characterPivot.Rotate(Vector3.up, x * rotationSpeed * Time.deltaTime);
    }
}
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraRotator : MonoBehaviour
{
    [SerializeField] private Transform characterPivot;
    [SerializeField] private Transform cameraPivot;
    [SerializeField] private float rotationSpeed = 50f;

    void Update()
    {
        var x = Input.GetAxis("Mouse X");
        var y = -Input.GetAxis("Mouse Y");

        cameraPivot.Rotate(Vector3.right, y * rotationSpeed * Time.deltaTime);
        characterPivot.Rotate(Vector3.up, x * rotationSpeed * Time.deltaTime);
    }
}
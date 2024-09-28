using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
///     Added to the player to move them using WASD keys.
/// </summary>
[RequireComponent(typeof(CharacterController))]
public class WASD : MonoBehaviour
{
    [SerializeField] private float speed = 5f;

    private CharacterController character;

    private void Start()
    {
        character = GetComponent<CharacterController>();
    }

    private void Update()
    {
        int x = 0;
        int y = 0;

        //Get the input vector
        if (Input.GetKey(KeyCode.W))
            y++;
        if (Input.GetKey(KeyCode.S))
            y--;

        if (Input.GetKey(KeyCode.D))
            x++;
        if (Input.GetKey(KeyCode.A))
            x--;

        bool running = Input.GetKey(KeyCode.LeftShift) || Input.GetKey(KeyCode.RightShift);

        //Normalize the input vector and the player direction
        var inputNormalized = (transform.forward * x + transform.right * -y).normalized;
        character.Move(inputNormalized * speed * (running ? 2f : 1f) * Time.deltaTime);
    }
}
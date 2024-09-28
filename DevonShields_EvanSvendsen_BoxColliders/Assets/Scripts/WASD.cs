using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(CharacterController))]
public class WASD : MonoBehaviour
{
    [SerializeField] private float speed = 5f;

    private CharacterController character;

    private void Start()
    {
        character = GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {
        int x = 0;
        int y = 0;

        if (Input.GetKey(KeyCode.W))
            y++;
        if (Input.GetKey(KeyCode.S))
            y--;

        if (Input.GetKey(KeyCode.D))
            x++;
        if (Input.GetKey(KeyCode.A))
            x--;

        character.Move(speed * Time.deltaTime * new Vector3(x, 0, y));
    }
}

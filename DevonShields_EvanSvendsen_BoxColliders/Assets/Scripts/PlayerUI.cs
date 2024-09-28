using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.UI;

/// <summary>
///     Used to update the UI with information about the player location.
/// </summary>
public class PlayerUI : MonoBehaviour
{
    [SerializeField] private Text info;

    /// <summary>
    ///     Shows UI text when the player enters a region.
    /// </summary>
    /// <param name="collider">The region the player has entered.</param>
    private void OnTriggerEnter(Collider collider)
    {
        if(collider.TryGetComponent<Volume>(out _))
        {
            var name = collider.name;
            info.text = $"Currently Inside: <color={name.ToLower()}>{name}</color>";
        }
    }

    /// <summary>
    ///     Hide all UI text when the player exists the red volume region.
    /// </summary>
    /// <param name="collider">The region the player has exited.</param>
    private void OnTriggerExit(Collider collider)
    {
        if (collider.TryGetComponent(out Volume v) && v.name == "Red")
        {
            info.text = "";
        }
    }
}
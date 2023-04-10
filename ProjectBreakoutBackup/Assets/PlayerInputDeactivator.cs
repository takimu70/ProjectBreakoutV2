using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerInputDeactivator : MonoBehaviour
{
    private void OnEnable()
    {
        var player = GameObject.FindWithTag("Player").GetComponent<PlayerInput>().enabled = false;
    }
    private void OnDisable()
    {
        var player = GameObject.FindWithTag("Player").GetComponent<PlayerInput>().enabled = true;
    }




}

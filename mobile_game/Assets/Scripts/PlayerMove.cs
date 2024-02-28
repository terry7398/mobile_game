using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class PlayerMove : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{
    bool is_pressed;

    void Update()
    {
        if (is_pressed)
        {
            CharacterManager.Instance.Move(transform.gameObject.name);
        }

#if UNITY_EDITOR
        if (Input.GetKeyDown(KeyCode.Space))
        {
            CharacterManager.Instance.Move("Jump");
        }
        else if (Input.GetKey(KeyCode.A))
        {
            CharacterManager.Instance.Move("Back");
        }
        else if (Input.GetKey(KeyCode.D))
        {
            CharacterManager.Instance.Move("Forward");
        }
#endif
    }

    void IPointerDownHandler.OnPointerDown(PointerEventData eventData)
    {
        if (transform.gameObject.name == "Forward")
        {
            is_pressed = true;
            CharacterManager.Instance.transform.rotation = Quaternion.Euler(0, 180, 0);
        }
        else if (transform.gameObject.name == "Back")
        {
            is_pressed = true;
            CharacterManager.Instance.transform.rotation = Quaternion.Euler(0, 0, 0);
        }
        else if (transform.gameObject.name == "Jump")
        {
            CharacterManager.Instance.Move("Jump");
        }
    }

    void IPointerUpHandler.OnPointerUp(PointerEventData eventData)
    {
        is_pressed = false;
        CharacterManager.Instance.Move("None");
    }
}
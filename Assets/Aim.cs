using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Aim : MonoBehaviour
{

    [SerializeField] private GameObject _aim;
    private Vector3 _ray;
    private float _offset;
    private bool _click;

    private void Start()
    {
        _offset = transform.position.z;
        _aim.gameObject.SetActive(false);
    }

    void Update()
    {
        Vector3 mouse = Input.mousePosition;
        Ray castPoint = Camera.main.ScreenPointToRay(mouse);
        RaycastHit hit;
        if (Physics.Raycast(castPoint, out hit, Mathf.Infinity))
        {
            if (Input.GetMouseButtonDown(0) || Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Moved)
            {
                _click = true;
                _aim.gameObject.SetActive(true);
                _aim.transform.position = hit.point;
            }
            if (Input.GetMouseButtonUp(1))
            {
                _click = false;
            }
            if(!_click)
            {
                _aim.gameObject.SetActive(false);
            }
        }
    }
}

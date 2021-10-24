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
    private Shoot _shoot;

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
            if (Input.GetMouseButton(0) && !Input.GetMouseButtonDown(0) || Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Moved)
            {
                _aim.gameObject.SetActive(true);
                _aim.transform.position = new Vector3(hit.point.x,hit.point.y,hit.point.z + _offset);
            }
            else
            {
                _aim.gameObject.SetActive(false);
            }

        }
    }

}

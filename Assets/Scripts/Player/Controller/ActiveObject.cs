using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Hope.Player.Controller;

public class ActiveObject : MonoBehaviour
{
    void Update()
    {
        if(Input.touchCount > 0 && Input.touches[0].phase == TouchPhase.Began)
        {
            Ray _ray = Camera.main.ScreenPointToRay(Input.touches[0].position);

            RaycastHit _hit;

            if(Physics.Raycast(_ray, out _hit))
            {
                if(_hit.collider.tag == "Land")
                {
                    var _controller = PlayerController._player;
                    _controller._active = !_controller._active;

                    Debug.Log("Colisionando");
                }
            }
        }
    }
}

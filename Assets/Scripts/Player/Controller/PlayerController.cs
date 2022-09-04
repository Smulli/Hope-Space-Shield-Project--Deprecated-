using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using Hope.Player.Attributes;
using Hope.Bullet.Utils;

namespace Hope.Player.Controller{ 
    public class PlayerController : MonoBehaviour {
        PlayerAttributes _attribs;
        public float _angle;
        public float _speed;
        public float rotMin = -90f;
        public float rotMax = 90f;
        [SerializeField] private float _lastShot;
        [SerializeField] private string _pTag;

        void Start(){
            _attribs = GetComponent<PlayerAttributes>();
        }

        //Basic control of the Hope("pending change")
        void FixedUpdate(){
            if(Input.GetButton("Fire1")){
                //Assing the name of power up
                _pTag = _attribs.GetName();
                _angle += Input.GetAxis("MouseX") * _speed * -Time.deltaTime;
                //Clamp the rotation
                _angle = Mathf.Clamp(_angle, rotMin, rotMax); 
                //Assing the angle variable to control rotation
                transform.rotation = Quaternion.Euler(0f, 0f, _angle);
                //Fire rate condition
                if(Time.time > _attribs.GetFireRate() + _lastShot){
                    //Calling the spawning bullets method
                    BulletPool.pooler.Shoot();
                    _lastShot = Time.time;
                }
            }
        }
    }
}



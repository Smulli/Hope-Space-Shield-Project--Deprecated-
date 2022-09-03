using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Hope.Props.Utils;

namespace Hope.Props.Controller{
    public class BuildingController : MonoBehaviour
    {
        private int _life = 3;
        [SerializeField] private SpriteRenderer _sprite;
        private float _green;

        void Start(){
            _green = 1f;
        }

        void FixedUpdate(){
            if(_life == 0){
                BuildingSpawner.pooler.AddToPool(this.gameObject);
            }

            _sprite.color = new Color(0.2f, _green, 0f, 1);
        }

        private void OnTriggerEnter2D(Collider2D col){
            if(col.tag == "Enemy"){
                _life --;
                _green -= 0.5f;
            }
        }
    }
}


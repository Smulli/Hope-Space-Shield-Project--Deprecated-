using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Hope.Enemy.Utils;
using Hope.Enemy.Attributes;
using Hope.Player.Utils;

namespace Hope.Enemy.Controller{
    public class AsteroidController : MonoBehaviour
{
        AsteroidAttributes _attribs;

        /*SerializeField para propiedades.
        [field:SerializeField]*/
        PoolAsteroid PoolAsteroid{get; set;}
        private float _speed = 4f;
        private float _offset;
        private int _getScore;

        private void Awake(){
            //gameObject.hideFlags = HideFlags.HideInHierarchy;
        }

        void Start(){
            _offset = Random.Range(-2f, 2f);
                
            _attribs = GetComponent<AsteroidAttributes>();
            PoolAsteroid = PoolAsteroid.pooler;

            //ScoreManagement.scoreManager._score = _getScore;
        }
        
        void Update(){
            //transform.position = Vector3.MoveTowards(transform.position, _position.position, _speed * Time.deltaTime);
            transform.position += new Vector3(_offset * Time.deltaTime / 6f, -_speed * Time.deltaTime, 0f);

            if(_attribs._hit == 0 && _attribs._name == "classC"){
                ScoreManagement.scoreManager._score += 50;
                PoolAsteroid.Recycle(_attribs);
            }

            if(_attribs._hit == 0 && _attribs._name == "classB"){
                ScoreManagement.scoreManager._score += 100;
                PoolAsteroid.Recycle(_attribs);
            }

            if(_attribs._hit == 0 && _attribs._name == "gold"){
                PowerUpsManagement.Instance.SetRandomPower();
                ScoreManagement.scoreManager._score += 50;
                PoolAsteroid.Recycle(_attribs);
            }

            if(transform.position.y <= -10f){
                PoolAsteroid.Recycle(_attribs);
            }
        }
    

        private void OnTriggerEnter2D(Collider2D col){
            if(col.tag == "Colony"){
                PoolAsteroid.Recycle(_attribs);
            }

            if(col.tag == "Bullet"){
                _attribs._hit --;
            }
        }
    }
}


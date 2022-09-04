using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Hope.Bullet.Utils;
using Hope.Enemy.Attributes;
using Hope.Enemy.Utils;
using Hope.Player.Attributes;

namespace Hope.Bullet.Controller{
    public class BulletController : MonoBehaviour
    {
        private float _speed;
        public Transform _target;
        //private Rigidbody2D _rb;
        [SerializeField] private string _tag;

        void Start(){
            /*Physical based movement
            _rb = gameObject.GetComponent<Rigidbody2D>();
            */
            //_target = PoolAsteroid.pooler._instantiate[PoolAsteroid.pooler._instantiate.Count].transform;
        }

        private void OnEnable() {
            if(PlayerAttributes.SINGLETON.GetName() == "rockets"){
                FindTarget();
            }
        }

        void Update()
        {
            //it just works when the condition pass to be true
            if(PlayerAttributes.SINGLETON.GetName() == "rockets"){
                if(!_target.gameObject.activeInHierarchy){
                    BulletPool.pooler.Recycle(gameObject);
                }   
                MoveToTarget(); 
            }
            else if(PlayerAttributes.SINGLETON.GetName() != "rockets")
            {
                transform.Translate(Vector3.up * _speed * Time.deltaTime);
                _speed = 50f;
            }

            //_rb.AddForce(BulletPool.pooler._initPos.up * _speed, ForceMode2D.Impulse);

        }

        void FixedUpdate(){
            if(transform.position.y > 5f){
                BulletPool.pooler.Recycle(gameObject);
            }
        }

        private void FindTarget(){
            //Assing transform for each objects in list
            foreach(var item in PoolAsteroid.pooler._instantiate){
                if(item.gameObject.activeInHierarchy){
                    _target = item.transform;
                }
            }
        }

        //Interpolate the movement between own transform of the object and transform of the targets
        public void MoveToTarget(){
            _speed = 1f;

            transform.position = Vector3.Lerp(transform.position, _target.position, _speed * Time.deltaTime);
        }

        private void OnTriggerEnter2D(Collider2D col){
            if(col.tag == "Enemy"){
                BulletPool.pooler.Recycle(gameObject);
            }
        }
    }
}

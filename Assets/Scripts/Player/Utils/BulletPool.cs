using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Hope.Enemy.Utils;
using Hope.Player.Attributes;

namespace Hope.Bullet.Utils{
    public class BulletPool : MonoBehaviour
    {
        public static BulletPool pooler;
        public Transform _initPos;
        [SerializeField] private GameObject _prefab;
        public Queue<GameObject> _available = new Queue<GameObject>();
        public List<GameObject> _instantiate = new List<GameObject>();
        public Transform _position;
        
        void Awake(){
            if(BulletPool.pooler == null){
                pooler = this;
            }
            else{Destroy(gameObject);}
        }

        void Start(){
            for(int i = 0; i < 3; i++){
                GameObject _bullet = Instantiate(_prefab);
                Recycle(_bullet);
            }
        }

        public void Shoot(){
            GameObject _bullet = GetBullet();

            float _posX = _initPos.transform.position.x;
            float _posY = _initPos.transform.position.y;
            float _posZ = _initPos.transform.position.z;

            _bullet.transform.rotation = _initPos.transform.rotation;
            _bullet.transform.position = new Vector3(_posX, _posY, _posZ);
            _bullet.transform.localScale = new Vector3(0.3f, 0.3f, 0.3f);
            _bullet.gameObject.SetActive(true);


            if(_available.Count < 1){
                CreateNewBullet();
            }
        }

        public void Recycle(GameObject _bullet){
            _bullet.gameObject.SetActive(false);
            _bullet.transform.position = Vector3.zero;
            _bullet.transform.rotation = Quaternion.identity;
            _bullet.transform.localScale = Vector3.one;
            _instantiate.Remove(_bullet);
            _available.Enqueue(_bullet);
        }

        public GameObject GetBullet(){
            GameObject _bullet = _available.Dequeue();
            _instantiate.Add(_bullet);

            return _bullet;
        }

        public GameObject CreateNewBullet(){         
            GameObject _bullet = Instantiate(_prefab);
            Recycle(_bullet);

            return _bullet;
        }

        public GameObject MoveToTarget(GameObject _bullet){
            float _speed = 1f;

            foreach(var item in PoolAsteroid.pooler._instantiate){
                if(item.gameObject.activeInHierarchy){
                    _position = item.transform;
                }
            }

            _bullet.transform.position = Vector3.Lerp(_initPos.position, _position.position, _speed);

            return _bullet;
        }
    }    
}

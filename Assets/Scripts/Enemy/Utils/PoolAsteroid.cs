using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using Hope.Enemy.Attributes;
using Hope.Bullet.Controller;

namespace Hope.Enemy.Utils{
    public class PoolAsteroid : MonoBehaviour
    {
        public static PoolAsteroid pooler;
        public Queue<AsteroidAttributes> _available = new Queue<AsteroidAttributes>();
        //Lista de objetos intanciados
        public List<AsteroidAttributes> _instantiate = new List<AsteroidAttributes>();
        [SerializeField] private AsteroidAttributes _prefab;

        void Awake(){
            if(PoolAsteroid.pooler == null){
                pooler = this;
            }
            else{Destroy(gameObject);}
        }

        void Start(){
            for (int i = 0; i < 15; i++)
            {
                AsteroidAttributes _asteroids = Instantiate(_prefab);
                _asteroids.PoolAsteroid = this;

                Recycle(_asteroids);
            }

            InvokeRepeating(nameof(Spawn), 0f, 1f);
        }

        private void Spawn(){
            AsteroidAttributes _asteroids = GetAsteroids();
            _asteroids.SetAttributes(AsteroidManagement.Instance.GetRandomAttribute());

            float xPos = Random.Range(-6f, 6f);

            _asteroids.transform.position = new Vector3(xPos, 10f, 0f);
            _asteroids.gameObject.SetActive(true);
        }

        public void Recycle(AsteroidAttributes _asteroids){
            _asteroids.gameObject.SetActive(false);
            _asteroids.transform.position = Vector3.zero;
            _asteroids.transform.rotation = Quaternion.identity;
            _asteroids.transform.localScale = Vector3.one;
            _instantiate.Remove(_asteroids);
            _available.Enqueue(_asteroids);
        }

        public AsteroidAttributes GetAsteroids(){
            AsteroidAttributes _asteroids = _available.Dequeue();
            _instantiate.Add(_asteroids);

            return _asteroids;
        }

        public void RecycleAll(){
            //Mientras el numero de elementos en la lista sea mayor a 0 se reciclaran los elementos de la lista
            while(_instantiate.Count > 0){
                Recycle(_instantiate[0]);
            }
        }
    }

}


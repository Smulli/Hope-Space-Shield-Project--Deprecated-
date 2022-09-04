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
        //Instantiated object list
        public List<AsteroidAttributes> _instantiate = new List<AsteroidAttributes>();
        [SerializeField] private AsteroidAttributes _prefab;

        void Awake(){
            //Singleton
            if(PoolAsteroid.pooler == null){
                pooler = this;
            }
            else{Destroy(gameObject);}
        }

        //Initial Pool
        void Start(){
            for (int i = 0; i < 15; i++)
            {
                AsteroidAttributes _asteroids = Instantiate(_prefab);
                _asteroids.PoolAsteroid = this;

                Recycle(_asteroids);
            }

            //InvokeRepeation function take a new asteroid each 1 second
            InvokeRepeating(nameof(Spawn), 0f, 1f);
        }

        //Spawn asteroid method
        private void Spawn(){
            AsteroidAttributes _asteroids = GetAsteroids();
            //Set random attribute from GetRandomAttribute value
            _asteroids.SetAttributes(AsteroidManagement.Instance.GetRandomAttribute());
            //x position random when spawning
            float xPos = Random.Range(-6f, 6f);

            _asteroids.transform.position = new Vector3(xPos, 10f, 0f);
            _asteroids.gameObject.SetActive(true);
        }

        //Save instance and reset the transform
        public void Recycle(AsteroidAttributes _asteroids){
            _asteroids.gameObject.SetActive(false);
            _asteroids.transform.position = Vector3.zero;
            _asteroids.transform.rotation = Quaternion.identity;
            _asteroids.transform.localScale = Vector3.one;
            _instantiate.Remove(_asteroids);
            _available.Enqueue(_asteroids);
        }

        //Get a new asteroid from the Queue
        public AsteroidAttributes GetAsteroids(){
            AsteroidAttributes _asteroids = _available.Dequeue();
            _instantiate.Add(_asteroids);

            return _asteroids;
        }

        public void RecycleAll(){
            //While the elements number at list be greater than 0 all elements in the list will be  recycled
            while(_instantiate.Count > 0){
                Recycle(_instantiate[0]);
            }
        }
    }

}


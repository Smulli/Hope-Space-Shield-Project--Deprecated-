using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using Hope.Enemy.Attributes;

namespace Hope.Enemy.Utils{
    public class AsteroidManagement : MonoBehaviour
    {
        public static AsteroidManagement Instance{get; private set;}
        public float _timer = 10f;

        void Awake(){
            Instance = this;
        }

        void Update(){
            _timer -= Time.deltaTime;
        }

        private float GoldSpawn(float _goldSpawn){
            if(_timer > 1f){
                _goldSpawn = 1f;
            }

            else if(_timer < 1f){
                _goldSpawn -= 1f;
                _timer = 10f;
            }

            return _goldSpawn;
        }

        float _spawn;

        public AsteroidAttributes.AsteroidTypes GetRandomAttribute(){
            return(AsteroidAttributes.AsteroidTypes)UnityEngine.Random.Range(GoldSpawn(_spawn), Enum.GetNames(typeof(AsteroidAttributes.AsteroidTypes)).Length);
        }
    } 
}

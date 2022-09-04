using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Hope.Enemy.Utils;

namespace Hope.Enemy.Attributes{
    public class AsteroidAttributes : MonoBehaviour
    {
        public SpriteRenderer _color;
        public PoolAsteroid PoolAsteroid{get; set;}
        public string _name; 
        public int _hit;

        public enum AsteroidTypes{
            gold,
            classC,
            classB
        }

        public AsteroidTypes _type{get; set;}

        //Set Attributes Method
        public void SetAttributes(AsteroidTypes type){
            _type = type;
            

            switch(type){
                case
                AsteroidTypes.classC:{
                    _name = "classC";
                    _hit = 1;
                    transform.localScale = new Vector3(0.5f, 0.5f, 0.5f);
                    _color.color = new Color(255, 255, 255, 1);
                }
                break;
                case
                AsteroidTypes.classB:{
                    _name = "classB";
                    _hit = 2;
                    transform.localScale = new Vector3(1, 1, 1);
                    _color.color = new Color(255, 255, 255, 1);
                }
                break;  
                case
                AsteroidTypes.gold:{
                    _name = "gold";
                    _hit = 1;
                    transform.localScale = new Vector3(0.5f, 0.5f, 0.5f);
                    _color.color = new Color(219, 196, 0, 1);
                }
                break;  
            }
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Hope.Player.Attributes{
    public class PlayerAttributes : MonoBehaviour
    {
        public static PlayerAttributes SINGLETON;
        private string _name;
        private float _fireRate;
        public float _restart = 7f;
        private bool _isValid;

        void Awake(){
            SINGLETON = this;
        }

        void Start() {
            Restart();
            _isValid = false;
        }

        void Update(){
            if(_isValid){
                _restart -= Time.deltaTime;
            }

            if(_restart < 1f){
                Restart();

                _restart = 7f;
            }
        }

        public enum PowerUps {
            Gatling,
            Rockets,
            Laser
        }

        public PowerUps _type{get; private set;}

        public void SetPower(PowerUps type){
            _type = type;
            _isValid = true;

            //Obtiene el ID del objeto dentro de la instancia
            //Debug.Log(GetInstanceID());

            switch(type){
                case
                PowerUps.Gatling:{
                    _name = "gatling";
                    _fireRate = 0.1f;
                }
                break;
                case
                PowerUps.Rockets:{
                    _name = "rockets";
                    _fireRate = 0.5f;
                }
                break;
                case
                PowerUps.Laser:{
                    _name = "laser";
                    _fireRate = 0.01f;
                }
                break;
            }
        }
        //Funciones lambda para string y float
        public string GetName() => _name;
        public float GetFireRate() => _fireRate;

        private void Restart(){
            _isValid = false;
            _name = "normal";
            _fireRate = 0.5f;
        }
    }
}

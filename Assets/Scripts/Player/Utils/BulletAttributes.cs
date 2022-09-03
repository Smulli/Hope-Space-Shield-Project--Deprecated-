using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace Hope.Bullet.Attributes{
    public class BulletAttributes : MonoBehaviour
    {
        public static BulletAttributes _bAttribs;
        
        void Awake(){
            if(BulletAttributes._bAttribs == null){
                _bAttribs = this;
            }
            else{Destroy(gameObject);}
        }

        public enum BulletTypes{
            Normal,
            Gatling,
            Rockets,
            Laser
        }

        public BulletTypes _types{get; private set;}
    }
}

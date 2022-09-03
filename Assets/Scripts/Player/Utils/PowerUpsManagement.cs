using System.Collections;
using System.Collections.Generic;
using System;
using System.Linq;
using UnityEngine;
using Hope.Player.Attributes;

namespace Hope.Player.Utils{
    public class PowerUpsManagement : MonoBehaviour
    {
        public static PowerUpsManagement Instance{get; private set;}
        [SerializeField] PlayerAttributes _player;

        void Awake(){
            Instance = this;
        }

        public void SetRandomPower(){
            //Get max length from enum
            int _maxVulue = Enum.GetValues(typeof(PlayerAttributes.PowerUps)).Length;
            //Get random enum
            int _randValue = UnityEngine.Random.Range(0, _maxVulue);

            PlayerAttributes.PowerUps _powerUp = (PlayerAttributes.PowerUps)_randValue;

            _player.SetPower(_powerUp);
        }
    }
}


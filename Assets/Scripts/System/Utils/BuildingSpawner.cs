using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

namespace Hope.Props.Utils{
    public class BuildingSpawner : MonoBehaviour
    {
        public static BuildingSpawner pooler;
        [SerializeField] private GameObject _prefab;
        public List<GameObject> _instantiate = new List<GameObject>();
        private int _amount;
        public Transform _player;

        void Awake(){
            if(BuildingSpawner.pooler == null){
                pooler = this;
            }
            else{Destroy(gameObject);}
        }

        void Start(){
            InitPool();
        }

        public void InitPool(){
            GameObject _building;

            for(int i = 0; i < 7; i++){
                _building = Instantiate(_prefab);
                _building.SetActive(true);
                _instantiate.Add(_building);

                float xPos = Random.Range(-8.8f, 8.8f);

                _building.transform.position = new Vector3(xPos, -4.8f, 0f);

                var _dist = Vector3.Distance(_player.position, _building.transform.position);

                if(_dist < 1f){
                    AddToPool(_building);
                }
            }
        }

        public void AddToPool(GameObject _building){
            _building.SetActive(false);
            _building.transform.position = Vector3.zero;
            _building.transform.rotation = Quaternion.identity;
            _instantiate.Remove(_building);
        }
    }
}

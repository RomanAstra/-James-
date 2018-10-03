using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using Object = UnityEngine.Object;

namespace Assets.Scripts.Helpers
{
    public class ObjectPool<T> : MonoBehaviour, IEnumerable where T : BaseObjectScene
    {
        private T[] _objects;
        private int _check;
        private int _countOf;

        [SerializeField] private GameObject Pool = new GameObject("Pool");
        
        public ObjectPool(T tempObj, float count)
        {
            _countOf = (int) count;
            _check = (int) count;
            _objects = new T[(int) _countOf];
            for (int i = 0; i < _countOf; i++)
            {
                _objects[i] = Instantiate(tempObj);
                _objects[i].transform.parent = Pool.transform;
            }

            if (_objects != null)
            {
                foreach (T obj in _objects)
                {
                    obj.SetActive(false);
                }
            }
        }

        public T Take(Vector3 pos, Vector3 dir)
        {
            if (_check <= 0 && _objects != null) _check = 1;
            var tempObj = _objects[_check-1];
            tempObj.SetActive(true);
            tempObj.transform.SetPositionAndRotation(pos, Quaternion.LookRotation(dir));
            _check--;
            return tempObj;
        }

        public void Reset(T obj)
        {
            obj.Rigidbody.velocity = Vector3.zero;
            if (obj.IsActive) obj.SetActive(false);
            
            _check++;
            if (_check > _countOf) _check = _countOf;
        }

        public IEnumerator GetEnumerator()
        {
            throw new NotImplementedException();
        }
    }
}
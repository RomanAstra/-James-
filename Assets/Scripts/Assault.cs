using System;
using System.Collections.Generic;
using Assets.Scripts.Helpers;
using UnityEngine;

namespace Assets.Scripts
{
    public class Assault : Weapon
    {
        [Space(20)]
        [SerializeField] private float _assaultDamage = 20;
        [SerializeField] private float _assaultStandartHolder = 20;
        [Range(0.1f, 0.5f)] [SerializeField] private float _assaultRechargeTime = 0.1f;

        protected override void Awake()
        {
            _standartHolder = _assaultStandartHolder;
            base.Awake();
            _rechargeTime = _assaultRechargeTime;
            maxClip = _holder + _curHolder;
        }

        public override void Fire()
        {
            if (!_IsReady) return;
            if (_curHolder <= 0)
            {
                Reload();
            }

            if (_IsReady)
            {
                if (_barrel != null && Physics.Raycast(_barrel.position, _barrel.forward, out Hit, _maxDistance))
                {
                    Debug.Log("Попал в " + Hit.transform.name);
                    _IsReady = false;
                    timer.Start(_rechargeTime);
                    _curHolder--;
                    maxClip = _holder + _curHolder;
                }
                else
                {
                    Debug.Log("Мимо!");
                }
            }
        }
    }
}
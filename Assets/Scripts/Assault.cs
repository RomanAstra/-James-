using System;
using System.Collections.Generic;
using Assets.Scripts.Helpers;
using UnityEngine;

namespace Assets.Scripts
{
    public class Assault : Weapon
    {
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
    }
}
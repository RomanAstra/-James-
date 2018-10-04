using System;
using System.Collections.Generic;
using Assets.Scripts.Helpers;
using UnityEngine;

namespace Assets.Scripts
{
    public class Assault : Weapon
    {
        /// <summary>
        /// Величина урона "винтовки"
        /// </summary>
        [SerializeField] private float _assaultDamage = 20;
        /// <summary>
        /// Стандартная обоима у "винтовки"
        /// </summary>
        [SerializeField] private float _assaultStandartHolder = 20;
        /// <summary>
        /// Время, промежуток между выстрелами у "винтовки"
        /// </summary>
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
using Assets.Scripts.Helpers;
using UnityEngine;

namespace Assets.Scripts
{
    public abstract class Weapon : BaseObjectScene
    {
        protected Timer timer = new Timer();
        protected RaycastHit Hit;
        
        [SerializeField] protected Transform _barrel;
        [SerializeField] protected float maxClip;
        protected float _rechargeTime;
        protected float _holder;
        protected float _curHolder;
        protected float _standartHolder;
        protected float _maxDistance = 100;

        protected bool _IsReady = true;

        protected virtual void Awake()
        {
            _curHolder = _standartHolder;
            _holder = _curHolder;
        }
        
        protected virtual void Update()
        {
            timer.Update();
            if (timer.IsEvent())
            {
                _IsReady = true;
            }
        }
        /// <summary>
        /// "Выстрел"
        /// </summary>
        public abstract void Fire();
        /// <summary>
        /// Перезерядка
        /// </summary>
        protected virtual void Reload()
        {
            _IsReady = false;
            timer.Start(2);

            _holder -= _curHolder;
            if (_holder > _standartHolder)
            {
                _holder -= _standartHolder;
                _curHolder = _standartHolder;
                return;
            }
            _curHolder = _holder;
            _holder -= _curHolder;
        }
    }
}
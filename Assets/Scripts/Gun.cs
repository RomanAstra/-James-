using UnityEngine;

namespace Assets.Scripts
{
    public class Gun : Weapon
    {
        [SerializeField] private float _gunDamage = 10;
        [SerializeField] private float _gunStandartHolder = 10;
        [Range(0.1f, 0.5f)] [SerializeField] private float _gunRechargeTime = 0.3f;

        protected override void Awake()
        {
            _standartHolder = _gunStandartHolder;
            base.Awake();
            _rechargeTime = _gunRechargeTime;
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
                if (_barrelCamera != null && Physics.Raycast(_barrelCamera.position, _barrelCamera.forward, out Hit, _maxDistance))
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
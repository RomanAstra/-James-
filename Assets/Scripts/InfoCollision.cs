using UnityEngine;

namespace Assets.Scripts
{
    public struct InfoCollision
    {
        private readonly float _damage;
        private readonly ContactPoint _contact;
        private readonly Transform _transform;
        private readonly Vector3 _dir;
        /// <summary>
        /// Хранит информацию об объекте
        /// </summary>
        /// <param name="damage">Сила урона</param>
        /// <param name="contact">Точка контакта</param>
        /// <param name="transform">Позиция объекта</param>
        /// <param name="dir">Направление движения</param>
        public InfoCollision(float damage, ContactPoint contact, Transform transform, Vector3 dir)
        {
            _damage = damage;
            _contact = contact;
            _transform = transform;
            _dir = dir;
        }

        public float Damage
        {
            get { return _damage; }
        }

        public ContactPoint Contact
        {
            get { return _contact; }
        }

        public Transform Obj
        {
            get { return _transform; }
        }

        public Vector3 Dir
        {
            get { return _dir; }
        }
    }
}
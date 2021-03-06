﻿using UnityEngine;

namespace Assets.Scripts
{
    public class InfoCollision
    {
        private readonly Vector3 _dir;
        private readonly float _damage;
        private ContactPoint _contactPoint;
        private ContactPoint _contactPoint2;
        private RaycastHit _hit;
        private readonly Transform _objCollision;

        public InfoCollision(float damage, ContactPoint contactPoint, Transform objCollision,
            Vector3 dir = default(Vector3))
        {
            _dir = dir;
            _damage = damage;
            _contactPoint = contactPoint;
            _objCollision = objCollision;
        }

        public InfoCollision(float damage, RaycastHit hit, Transform objCollision,
            Vector3 dir = default(Vector3))
        {
            _dir = dir;
            _damage = damage;
            _hit = hit;
            _objCollision = objCollision;
        }

        public Vector3 Dir
        {
            get { return _dir; }
        }

        public float Damage
        {
            get { return _damage; }
        }

        public ContactPoint Point
        {
            get { return _contactPoint; }
            set { _contactPoint = value; }
        }
        
        public Transform ObjCollision
        {
            get { return _objCollision; }
        }

        public RaycastHit Hit
        {
            get { return _hit; }
            set { _hit = value; }
        }

        public ContactPoint Point2
        {
            get { return _contactPoint2; }
            set { _contactPoint2 = value; }
        }
    }
}
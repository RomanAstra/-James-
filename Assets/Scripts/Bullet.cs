using Assets.Scripts.Helpers;
using Assets.Scripts.Interfaces;
using UnityEngine;

namespace Assets.Scripts
{
    public class Bullet : Ammunition
    {
        private void OnCollisionEnter(Collision collision)
        {
            if (collision != null)
            {
                _IsCollision = true;
            }

            var tempObj = collision.gameObject.GetComponent<ISetDamage>();
            if (tempObj != null)
            {
                tempObj.SetDamage(new InfoCollision(_curDamage, collision.contacts[0], collision.transform,
                    Rigidbody.velocity));
            }
        }

    }
}
using Assets.Scripts;
using Assets.Scripts.Helpers;
using GeekBrains.Helpers;
using UnityEngine;
using ISetDamage = Assets.Scripts.Interfaces.ISetDamage;

public class Wall : BaseObjectScene, ISetDamage
{
	[SerializeField] private BulletProjector _projector;
    
    public void SetDamage(InfoCollision info)
	{
        Debug.Log("Урон");
		if (_projector == null) return;
		var projectorRotation = Quaternion.FromToRotation(-Vector3.forward, info.Hit.normal);
		var obj = Instantiate(_projector, info.Hit.point + info.Hit.normal * 0.25f, projectorRotation, info.ObjCollision); // manager
		obj.transform.rotation = Quaternion.Euler(obj.transform.eulerAngles.x, obj.transform.eulerAngles.y, Random.Range(0, 360));
    }
}

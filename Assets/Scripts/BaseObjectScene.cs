using Assets.Scripts;
using UnityEngine;

public abstract class BaseObjectScene : MonoBehaviour
{
    private bool _IsVisible;
    private bool _IsActive;
    /// <summary>
    /// Base RigidBody
    /// </summary>
    [HideInInspector] private Rigidbody _rigidbody;
    [HideInInspector] private Collider _collider;
    [HideInInspector] private Renderer _renderer;

    #region UnityFunction

    protected virtual void Awake()
    {
        Rigidbody = GetComponent<Rigidbody>();
        Collider = GetComponent<Collider>();
        Renderer = GetComponent<Renderer>();
    }
    #endregion

    #region Properties
    /// <summary>
    /// 'RigidBody' объекта-родителя
    /// </summary>
    public Rigidbody Rigidbody
    {
        get { return _rigidbody; }
        set { _rigidbody = value; }
    }
    /// <summary>
    /// 'Collider' объекта-родителя
    /// </summary>
    public Collider Collider
    {
        get { return _collider; }
        set { _collider = value; }
    }
    /// <summary>
    /// 'Renderer' объекта-родителя
    /// </summary>
    public Renderer Renderer
    {
        get { return _renderer; }
        set { _renderer = value; }
    }
    /// <summary>
    /// Флаг "активен" или "не активен"
    /// </summary>
    public bool IsActive
    {
        get { return _IsActive; }
        set { _IsActive = value; }
    }

    #endregion

    #region Functions
    /// <summary>
    /// Вкл\Выкл. компоненты объекта
    /// </summary>
    /// <param name="value">'true' or 'false'</param>
    public virtual void SetActive(bool value)
    {
        IsActive = value;
        if (Renderer != null) Renderer.enabled = value;

        if (Collider != null) Collider.enabled = value;

        if (Rigidbody != null) Rigidbody.isKinematic = !value;

        if (transform.childCount <= 0) return;
        foreach (Transform obj in GetComponentInChildren<Transform>())
        {
            var tempRenderer = obj.gameObject.GetComponentInChildren<Renderer>(true);
            var tempCollider = obj.gameObject.GetComponentInChildren<Collider>(true);
            var tempRB = obj.gameObject.GetComponentInChildren<Rigidbody>(true);

            if (tempRenderer) tempRenderer.enabled = value;
            if (tempCollider) tempCollider.enabled = value;
            if (tempRB) tempRB.isKinematic = !value;
        }
    }

    #endregion
}

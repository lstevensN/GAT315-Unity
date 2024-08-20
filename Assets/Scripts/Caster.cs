using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Caster : MonoBehaviour
{
    public enum eType
    {
        Ray,
        Sphere,
        Box
    }

    [SerializeField] eType type = eType.Ray;
    [SerializeField] float size = 1;
    [SerializeField] float distance = 2;
    [SerializeField] LayerMask layerMask = Physics.AllLayers;

    RaycastHit[] raycastHits;

    // Update is called once per frame
    void Update()
    {
        switch (type)
        {
            case eType.Ray:
                raycastHits = Physics.RaycastAll(transform.position, transform.forward, distance, layerMask);
                break;

            case eType.Sphere:
                raycastHits = Physics.SphereCastAll(transform.position, size * 0.5f, transform.forward, distance, layerMask);
                break;

            case eType.Box:
                raycastHits = Physics.BoxCastAll(transform.position, Vector3.one * size * 0.5f, transform.forward, transform.rotation, distance, layerMask);
                break;

            default:
                break;
        }
    }

    void OnDrawGizmos()
    {
        Gizmos.color = Color.blue;
        switch (type)
        {
            case eType.Ray:
                Gizmos.DrawRay(transform.position, transform.forward * distance);
                break;

            case eType.Sphere:
                Gizmos.DrawRay(transform.position, transform.forward * distance);
                Gizmos.DrawWireSphere(transform.position + transform.forward * distance, size * 0.5f);
                break;

            case eType.Box:
                Gizmos.DrawRay(transform.position, transform.forward * distance);
                Gizmos.DrawWireCube(transform.position + transform.forward * distance, Vector3.one * size);
                break;
        }

        Gizmos.DrawRay(transform.position, transform.forward * distance);

        if (raycastHits != null)
        {
            Gizmos.color = Color.red;
            foreach(var hit in raycastHits)
            {
                Gizmos.DrawWireCube(hit.point, hit.collider.gameObject.transform.position);
            }
        }
    }
}

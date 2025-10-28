using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunRaycaster : MonoBehaviour
{
    public GameObject hitMarkerPrefab;
    public Camera aimingCamera;
    public LayerMask layerMask;
    public int damage;
    public void PerformRaycasting()
    {
        Ray aimingRay = new Ray(aimingCamera.transform.position, aimingCamera.transform.forward);

        if (Physics.Raycast(aimingRay, out RaycastHit hitInfo, 1000f, layerMask))
        {

            Debug.Log($"perform raycast {hitInfo.collider.name}");
            Quaternion effectRotation = Quaternion.LookRotation(hitInfo.normal);
            Instantiate(hitMarkerPrefab, hitInfo.point, effectRotation);
            DeliverDamage(hitInfo);
        }

    }

    private void ShowHitEffect(RaycastHit hitInfo)
    {
        HitSurface hitSurface = hitInfo.collider.GetComponent<HitSurface>();
        if (hitSurface != null)
        {
            GameObject effectPrefab = HitEffectManager.Instance.GetEffectPrefab(hitSurface.surfaceType);
            if (effectPrefab != null)
            {
                Quaternion effectRotation = Quaternion.LookRotation(hitInfo.normal);
                Instantiate(effectPrefab, hitInfo.point, effectRotation);
            }
        }
    }

    private void OnDrawGizmos()
    {
        Debug.DrawRay(aimingCamera.transform.position, aimingCamera.transform.forward * 1000f, Color.red);
    }

    // Update is called once per frame
    private void DeliverDamage(RaycastHit hitInfo)
    {
        Health health = hitInfo.collider.GetComponentInParent<Health>();
        if (health != null)
        {
            health.TakeDamage(damage);
        }
        Debug.Log("DeliverDamage");
    }
}

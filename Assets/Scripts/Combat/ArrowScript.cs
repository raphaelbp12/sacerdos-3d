using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Scrds.Utils;
using Scrds.Combat;
using Scrds.Control;
using Scrds.Core;

public class ArrowScript : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
    public void Setup(Vector3 shootDir)
    {
        Rigidbody rigidbody = GetComponent<Rigidbody>();
        float moveSpeed = 10f;
        rigidbody.AddForce(shootDir * moveSpeed, ForceMode.Impulse);
        transform.eulerAngles = new Vector3(0, Scrds.Utils.Math.GetAngleFromVectorFloat(shootDir), 0);
        transform.localScale = new Vector3(0.3f, 0.3f, 0.3f);
        Destroy(gameObject, 5f);
    }

    private void OnTriggerEnter(Collider collider)
    {
        Health target = collider.GetComponent<Health>();
        AIController aIController = collider.GetComponent<AIController>();
        if (target != null && aIController != null && aIController.targetTagType == AIController.TagType.Player) {
            Health health = target.GetComponent<Health>();
            float damage = 40f;
            if (health.IsDead()) return;
            health.TakeDamage(damage);
            DamagePopup.Create(health.healthBarPosition, Mathf.FloorToInt(damage), false);
            Destroy(gameObject);
        }
    }
}

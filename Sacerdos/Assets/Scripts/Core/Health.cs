using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Scrds.Core
{
    public class Health : MonoBehaviour
    {
        [SerializeField] float healthPoints = 100f;
        [SerializeField] Image healthBarContainerPrefab;
        [SerializeField] Image healthBarContainerInstantiated;
        [SerializeField] Transform healthBarPosition;

        float startingHealth;
        bool isDead = false;
        public Image healthBarRed;

        private void Start() {

            Color healthBarColor = Color.red;

            if (gameObject.tag == "Player") {
                healthBarColor = Color.green;
            }

            startingHealth = healthPoints;

            GameObject canvas = GameObject.FindWithTag("MainCanvas");
            healthBarContainerInstantiated = Instantiate(healthBarContainerPrefab, Vector3.zero, Quaternion.identity);
            healthBarContainerInstantiated.transform.SetParent(canvas.transform);

            Image[] images = healthBarContainerInstantiated.GetComponentsInChildren<Image>();
            healthBarRed = images[images.Length - 1];
            healthBarRed.GetComponent<Image>().color = healthBarColor;
        }

        private void LateUpdate() {
            if (healthBarContainerInstantiated) {
                Vector3 healthPos = Camera.main.WorldToScreenPoint(healthBarPosition.position);
                healthBarContainerInstantiated.transform.position = healthPos;
            }
        }

        public bool IsDead() {
            return isDead;
        }

        public void TakeDamage(float damage) {
            healthPoints = Mathf.Max(healthPoints - damage, 0);

            healthBarRed.fillAmount = healthPoints / startingHealth;

            if (healthPoints == 0)
            {
                Die();
            }
        }

        private void Die()
        {
            if (isDead) return;

            isDead = true;
            GetComponent<Animator>().SetTrigger("die");
            GetComponent<ActionScheduler>().CancelCurrentAction();
            Destroy(healthBarContainerInstantiated.gameObject);
        }
    }
}

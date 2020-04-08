using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Scrds.Core
{
    public class Health : MonoBehaviour
    {
        [SerializeField] int lifeBase = 38;
        [SerializeField] int lifePerLevel = 12;
        [SerializeField] int healthPoints = 100;
        [SerializeField] int totalDamage = 0;
        [SerializeField] int monsterMaxHealth = 40;
        [SerializeField] Image healthBarContainerPrefab;
        [SerializeField] Image healthBarContainerInstantiated;
        [SerializeField] Transform healthBarPosition;
        bool isDead = false;
        public Image healthBarRed;

        [SerializeField]
        StatsController statsController;

        private void Start() {

            statsController = transform.gameObject.GetComponent<StatsController>();
            Color healthBarColor = Color.red;

            if (gameObject.tag == "Player") {
                healthBarColor = Color.green;
            }

            GameObject canvas = GameObject.FindWithTag("MainCanvas");
            healthBarContainerInstantiated = Instantiate(healthBarContainerPrefab, Vector3.zero, Quaternion.identity);
            healthBarContainerInstantiated.transform.SetParent(canvas.transform);

            Image[] images = healthBarContainerInstantiated.GetComponentsInChildren<Image>();
            healthBarRed = images[images.Length - 1];
            healthBarRed.GetComponent<Image>().color = healthBarColor;
        }

        void Update()
        {
            int totalHealth = monsterMaxHealth;

            if (gameObject.tag == "Player") {
                totalHealth = CalculatePlayerMaxHealth();
            }

            healthPoints = Mathf.FloorToInt(Mathf.Max(totalHealth - totalDamage, 0));

            healthBarRed.fillAmount = healthPoints*1f / totalHealth*1f;

            if (healthPoints == 0)
            {
                Die();
            }
        }

        private void LateUpdate() {
            if (healthBarContainerInstantiated) {
                Vector3 healthPos = Camera.main.WorldToScreenPoint(healthBarPosition.position);
                healthBarContainerInstantiated.transform.position = healthPos;
            }
        }

        private int CalculatePlayerMaxHealth()
        {
            int playerLevel = statsController.playerLevel;
            int playerVitality = statsController.vitality;

            return Mathf.FloorToInt(lifeBase + playerLevel * lifePerLevel + playerVitality/2);
        }

        public bool IsDead() {
            return isDead;
        }

        public void TakeDamage(float damage) {
            totalDamage += Mathf.FloorToInt(damage);
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

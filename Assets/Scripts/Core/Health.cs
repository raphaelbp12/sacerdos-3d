﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Scrds.Core
{
    public class Health : MonoBehaviour
    {
        [SerializeField] int lifeBase = 38;
        [SerializeField] int lifePerLevel = 12;
        int _currentHealth;
        int _maxHealth;

        [SerializeField] int monsterMaxHealth = 40;
        [SerializeField] Image healthBarContainerPrefab;
        [SerializeField] Image healthBarContainerInstantiated;
        [SerializeField]
        public Transform healthBarPosition;
        bool isDead = false;
        public Image healthBarRed;

        [SerializeField]
        StatsController statsController;

        private void Start()
        {
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

            _maxHealth = monsterMaxHealth;

            if (gameObject.tag == "Player") {
                _maxHealth = CalculatePlayerMaxHealth();
            }

            _currentHealth = _maxHealth;
        }

        private void LateUpdate()
        {
            if (healthBarContainerInstantiated) {
                Vector3 healthPos = Camera.main.WorldToScreenPoint(healthBarPosition.position);
                healthBarContainerInstantiated.transform.position = healthPos;
            }
        }

        private int CalculatePlayerMaxHealth()
        {
            int playerLevel = statsController.playerLevel;
            int playerVitality = statsController.vitality;

            return Mathf.FloorToInt(lifeBase + playerLevel * lifePerLevel + playerVitality / 2);
        }

        public bool IsDead()
        {
            return isDead;
        }

        public void TakeDamage(int damage)
        {
            _currentHealth = Mathf.Max(_currentHealth - damage, 0);

            healthBarRed.fillAmount = (float)_currentHealth / (float)_maxHealth;

            if (_currentHealth == 0) {
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

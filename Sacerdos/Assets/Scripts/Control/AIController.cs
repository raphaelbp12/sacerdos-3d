using System.Collections;
using System.Collections.Generic;
using Scrds.Combat;
using Scrds.Core;
using UnityEngine;

namespace Scrds.Control
{
    public class AIController : MonoBehaviour
    {
        enum TagType
        {
            Player,
            Enemy,
        }

        [SerializeField] float chaseDistance = 5f;

        [SerializeField] TagType targetTagType = TagType.Player;

        string targetTagString;
        Health health;
        GameObject playerToChase = null;
        Fighter fighter;

        public GameObject[] publicPlayers;
        public GameObject publicPlayerToChase;

        private void OnDrawGizmos() {

            if (targetTagType == TagType.Player) {
                Gizmos.color = Color.red;
            } else if (targetTagType == TagType.Enemy) {
                Gizmos.color = Color.green;
            }
            Gizmos.DrawWireSphere(transform.position, chaseDistance);
        }

        private void Start() {

            if (targetTagType == TagType.Player) {
                targetTagString = "Player";
            } else if (targetTagType == TagType.Enemy) {
                targetTagString = "Enemy";
            }

            fighter = GetComponent<Fighter>();
            health = GetComponent<Health>();
        }
        private void Update() {
            if(health.IsDead()) return;

            if (playerToChase != null) {
                float distance = Vector3.Distance(playerToChase.transform.position, transform.position);

                if (distance < chaseDistance && fighter.CanAttack(playerToChase)) {
                    fighter.Attack(playerToChase);
                } else {
                    fighter.Cancel();
                }
            }
        }

        private void LateUpdate() {
            GameObject[] players = GameObject.FindGameObjectsWithTag(targetTagString);
            publicPlayers = players;
            float minDistance = Mathf.Infinity;

            foreach (GameObject player in players)
            {
                float distance = Vector3.Distance(player.transform.position, transform.position);
                Health playerHealth = player.GetComponent<Health>();

                if (distance < chaseDistance && distance < minDistance && !playerHealth.IsDead()) {
                    minDistance = distance;
                    playerToChase = player;
                    publicPlayerToChase = playerToChase;
                }
            }
        }
    }
}

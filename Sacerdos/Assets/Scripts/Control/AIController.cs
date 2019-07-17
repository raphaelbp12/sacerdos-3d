using System.Collections;
using System.Collections.Generic;
using Scrds.Combat;
using UnityEngine;

namespace Scrds.Control
{
    public class AIController : MonoBehaviour
    {
        [SerializeField] float chaseDistance = 5f;
        GameObject playerToChase = null;
        private void Update() {

            if (playerToChase != null) {
                float distance = Vector3.Distance(playerToChase.transform.position, transform.position);
                Fighter fighter = GetComponent<Fighter>();

                if (distance < chaseDistance && fighter.CanAttack(playerToChase)) {
                    fighter.Attack(playerToChase);
                } else {
                    fighter.Cancel();
                }
            }
        }

        private void LateUpdate() {
            GameObject[] players = GameObject.FindGameObjectsWithTag("Player");
            float minDistance = Mathf.Infinity;

            foreach (GameObject player in players)
            {
                float distance = Vector3.Distance(player.transform.position, transform.position);
                if (distance < chaseDistance && distance < minDistance) {
                    minDistance = distance;
                    playerToChase = player;
                }
            }
        }
    }
}

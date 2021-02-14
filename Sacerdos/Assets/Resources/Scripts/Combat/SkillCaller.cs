using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Scrds.Combat
{

    public enum SkillsList {
        empty,
        walk,
        flameDash,
        toxicRain,
        causticArrow
    }
    public class SkillCaller : MonoBehaviour
    {

        private GameObject playerGameObject;
        Walk walkSkill;
        public SkillCaller() {
        }

        void Start() {
            this.playerGameObject = GameObject.FindGameObjectsWithTag("Player")[0];
            this.walkSkill = new Walk(this.playerGameObject);
        }
        private List<SkillsList> skills = new List<SkillsList>(){
            SkillsList.walk,
            SkillsList.flameDash,
            SkillsList.flameDash,
            SkillsList.flameDash,
            SkillsList.flameDash,
            SkillsList.flameDash,
            SkillsList.flameDash,
            SkillsList.flameDash
        };

        public void Call(int skillIndex) {
            if (skillIndex > skills.Count) {
                Debug.LogError("Skill index out of range. Please, take a look on BindinsController.cs");
                return;
            }

            SkillsList skillType = skills[skillIndex];

            switch (skillType)
            {
                case SkillsList.empty:
                    Debug.Log("Call empty skill");
                    break;
                case SkillsList.walk:
                    this.walkSkill.DoAction();
                    break;
                case SkillsList.flameDash:
                    Debug.Log("Call flameDash skill");
                    break;
                default:
                    Debug.Log("Call default enum");
                    break;
            }
        }
    }
}
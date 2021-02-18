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
        throwArrow
    }
    public class SkillCaller : MonoBehaviour
    {
        [SerializeField] private Transform pfArrow;

        private GameObject playerGameObject;
        AttackBase attackBase;
        Walk walkSkill;
        FlameDash flamedashSkill;
        ThrowArrow throwArrowSkill;

        private float m_DistanceZ = 8f;

        Plane m_Plane;
        Vector3 m_DistanceFromCamera;
        public SkillCaller() {
        }

        void Start() {
            this.playerGameObject = GameObject.FindGameObjectsWithTag("Player")[0];
            this.attackBase = new AttackBase(this.playerGameObject);
            this.walkSkill = new Walk(this.playerGameObject);
            this.flamedashSkill = new FlameDash(this.playerGameObject);
            this.throwArrowSkill = new ThrowArrow(this.playerGameObject);

            //This is how far away from the Camera the plane is placed
            this.m_DistanceFromCamera = new Vector3(Camera.main.transform.position.x, Camera.main.transform.position.y - this.m_DistanceZ, Camera.main.transform.position.z);

            //Create a new plane with normal (0,0,1) at the position away from the camera you define in the Inspector. This is the plane that you can click so make sure it is reachable.
            this.m_Plane = new Plane(Vector3.forward, this.m_DistanceFromCamera);
        }
        private List<SkillsList> skills = new List<SkillsList>(){
            SkillsList.walk,
            SkillsList.throwArrow,
            SkillsList.throwArrow,
            SkillsList.throwArrow,
            SkillsList.flameDash,
            SkillsList.flameDash,
            SkillsList.flameDash,
            SkillsList.flameDash
        };

        public Vector3? getMouseProjectedPosition()
        {
            //This is how far away from the Camera the plane is placed
            this.m_DistanceFromCamera = new Vector3(Camera.main.transform.position.x, Camera.main.transform.position.y - this.m_DistanceZ, Camera.main.transform.position.z);

            //Create a new plane with normal (0,0,1) at the position away from the camera you define in the Inspector. This is the plane that you can click so make sure it is reachable.
            this.m_Plane = new Plane(Vector3.up, this.m_DistanceFromCamera);
            //Create a ray from the Mouse click position
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

            //Initialise the enter variable
            float enter = 0.0f;

            if (this.m_Plane.Raycast(ray, out enter))
            {
                //Get the point that is clicked
                Vector3 hitPoint = ray.GetPoint(enter);

                //Move your cube GameObject to the point where you clicked
                return hitPoint;
            } else {
                return null;
            }
        }

        public void Call(int skillIndex) {
            if (skillIndex > skills.Count) {
                Debug.LogError("Skill index out of range. Please, take a look on BindinsController.cs");
                return;
            }

            Vector3? mouseProjected = getMouseProjectedPosition();
            SkillsList skillType = skills[skillIndex];

            switch (skillType)
            {
                case SkillsList.empty:
                    Debug.Log("Call empty skill");
                    break;
                case SkillsList.walk:
                    this.walkSkill.mouseProjected = mouseProjected;
                    this.walkSkill.DoAction();
                    break;
                case SkillsList.flameDash:
                    this.flamedashSkill.mouseProjected = mouseProjected;
                    this.flamedashSkill.DoAction();
                    break;
                case SkillsList.throwArrow:
                    this.attackBase.mouseProjected = mouseProjected;
                    this.throwArrowSkill.mouseProjected = mouseProjected;
                    this.throwArrowSkill.pfArrow = pfArrow;
                    this.attackBase.DoActionBeforeCallback(this.throwArrowSkill);
                    break;
                default:
                    Debug.Log("Call default enum");
                    break;
            }
        }
    }
}
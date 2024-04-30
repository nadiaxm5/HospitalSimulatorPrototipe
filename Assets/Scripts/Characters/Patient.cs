using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace CharacterSystem
{
    public class Patient : MonoBehaviour
    {
        [SerializeField] NPCStatesManager statesController;

        private void Start()
        {
            statesController = GetComponent<NPCStatesManager>();
        }

        [Range(0f, 100f)]
        public float patientHappiness = 100f;
    }
}

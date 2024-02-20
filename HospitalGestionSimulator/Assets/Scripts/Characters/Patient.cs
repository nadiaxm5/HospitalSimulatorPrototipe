using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace CharacterSystem
{
    public class Patient : MonoBehaviour
    {
        private StatesController statesController;

        private void Start()
        {
            statesController = GetComponent<StatesController>();
        }

        [Range(0f, 100f)]
        public float patientHappiness = 100f;
    }
}

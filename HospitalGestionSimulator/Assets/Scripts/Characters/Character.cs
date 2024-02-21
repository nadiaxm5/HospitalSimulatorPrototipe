using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace CharacterSystem
{
    public class Character : MonoBehaviour
    {
        [SerializeField] StatesController statesController;

        private void Start()
        {
            statesController = GetComponent<StatesController>();
        }

        [Range(0f, 100f)]
        public float chaos = 0f;
    }
}


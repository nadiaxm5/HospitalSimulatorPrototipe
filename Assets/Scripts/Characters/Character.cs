using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace CharacterSystem
{
    public class Character : MonoBehaviour
    {
        [SerializeField] StatesController statesController;
        public ChaosBar chaosBar;
        public GameObject redScreen;
        private bool hasTalkedWithNurse;

        private void Start()
        {
            statesController = GetComponent<StatesController>();
            chaosBar.SetChaos(chaos);
        }

        private void Update()
        {
            //CODIGO PROVISIONAL PARA PROBAR LA BARRA, BORRAR DESPUES
            if (Input.GetKeyDown(KeyCode.Z))
            {
                chaosBar.SetChaos(10);
            }
            if (Input.GetKeyDown(KeyCode.X))
            {
                chaosBar.SetChaos(-10);
            }


        }

        [Range(0f, 100f)]
        public float chaos = 0f;

    }
}


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
        private GameObject target;

        private void Start()
        {
            statesController = GetComponent<StatesController>();
            chaosBar.AddChaos(chaos);
        }

        private void Update()
        {
            //CODIGO PROVISIONAL PARA PROBAR LA BARRA, BORRAR DESPUES
            if (Input.GetKeyDown(KeyCode.Z))
            {
                chaosBar.AddChaos(10);
            }
            if (Input.GetKeyDown(KeyCode.X))
            {
                chaosBar.AddChaos(-10);
            }

            chaos = chaosBar.getChaosValue();

            //Codigo para quitar paredes
            Ray ray = new(Camera.main.transform.position, transform.position - Camera.main.transform.position);
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit, 100) && hit.transform.CompareTag("Wall")){
                hit.transform.gameObject.SetActive(false);
                target = hit.transform.gameObject;
            }
        }

        [Range(0f, 100f)]
        public float chaos = 0f;

    }
}


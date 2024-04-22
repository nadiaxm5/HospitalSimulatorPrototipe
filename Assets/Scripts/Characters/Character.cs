using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace CharacterSystem
{
    public class Character : MonoBehaviour
    {
        [SerializeField] StatesController statesController;
        public BarManager chaosBar;
        private GameObject target;

        private float fadeAmount;
        Material mat;
        Color currentColor;

        private void Start()
        {
            statesController = GetComponent<StatesController>();
            chaosBar.AddChaos(chaos);
        }

        private void Update()
        {
            chaos = chaosBar.getChaosValue();

            //Codigo para quitar paredes
            Ray ray = new(Camera.main.transform.position, transform.position - Camera.main.transform.position);
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit, 100) && hit.transform.CompareTag("Wall")){
                mat = hit.transform.gameObject.GetComponent<Renderer>().material;
                currentColor = mat.color;
                mat.color = new Color(currentColor.r, currentColor.g, currentColor.b, 0.5f);
                target = hit.transform.gameObject;
            }
            else if(mat != null)
            {
                mat.color = new Color(currentColor.r, currentColor.g, currentColor.b, 1f);
            }
        }

        [Range(0f, 100f)]
        public float chaos = 0f;

    }
}


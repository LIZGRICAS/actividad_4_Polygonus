using UnityEngine;

namespace Player
{
    public class GenerarObjeto : MonoBehaviour
    {
        public GameObject armaPrefab;         // Prefab del arma
        public Transform puntoGeneracion;     // Punto donde generaremos el arma

        void Update()
        {
            if (Input.GetKeyDown(KeyCode.G)) // Si presionamos G, generamos el arma
            {
                InstanciarArma();
            }
        }

        void InstanciarArma()
        {
            Instantiate(armaPrefab, puntoGeneracion.position, puntoGeneracion.rotation); // Generar el arma en el punto dado
        }
    }
}
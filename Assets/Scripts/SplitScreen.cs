using UnityEngine;

namespace DefaultNamespace
{
    public class SplitScreen : MonoBehaviour
    {
        public Camera camJugador1;   // Cámara para el jugador 1
        public Camera camJugador2;   // Cámara para el jugador 2
        public GameObject jugador1;  // Referencia al jugador 1
        public GameObject jugador2;  // Referencia al jugador 2

        void Start()
        {
            // Configurar las cámaras para pantalla dividida
            camJugador1.rect = new Rect(0, 0.5f, 1, 0.5f);  // Cámara para jugador 1 en la mitad superior
            camJugador2.rect = new Rect(0, 0, 1, 0.5f);      // Cámara para jugador 2 en la mitad inferior
        }

        void Update()
        {
            // Control de movimiento para el jugador 1
            float horizontal1 = Input.GetAxis("Horizontal");
            float vertical1 = Input.GetAxis("Vertical");
            jugador1.transform.Translate(new Vector3(horizontal1, 0, vertical1));

            // Control de movimiento para el jugador 2
            float horizontal2 = Input.GetAxis("Horizontal2");
            float vertical2 = Input.GetAxis("Vertical2");
            jugador2.transform.Translate(new Vector3(horizontal2, 0, vertical2));
        }
    }
}
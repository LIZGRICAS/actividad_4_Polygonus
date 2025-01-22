using UnityEngine;

namespace Player
{
    public class PlayerController : MonoBehaviour
    {
        public float velocidad = 5f;           // Velocidad del jugador
        public float vida = 100f;              // Vida del jugador
        public int puntos = 0;                 // Puntos del jugador
        public Rigidbody2D rb;                  // Referencia al Rigidbody del jugador
        private Camera playerCamera;           // Referencia a la cámara del jugador
        private bool enPrimeraPersona = false; // Bandera para saber si estamos en primera o tercera persona
        private Vector3 terceraPersonaOffset = new Vector3(0, 5f, -10f); // Posición para la cámara en tercera persona

        // Para saber si este es el Jugador 1 o Jugador 2
        public int jugadorID = 1; // 1 para Jugador 1, 2 para Jugador 2

        void Start()
        {
            rb = GetComponent<Rigidbody2D>();  // Obtener el Rigidbody
            playerCamera = GameObject.Find("Camera_Jugador1").GetComponent<Camera>(); // Obtener la cámara jugador 1

            // Asignar una cámara específica para cada jugador
            if (jugadorID == 2)
            {
                playerCamera = GameObject.Find("Camera_Jugador2").GetComponent<Camera>();
            }
        }

        void Update()
        {
            MoverJugador(); // Mover al jugador
            // CambiarCamara(); // Cambiar la vista entre primera y tercera persona
        }

        void MoverJugador()
        {
            // Separa los controles por jugador usando entradas personalizadas.
            float horizontal = (jugadorID == 1) ? Input.GetAxis("Horizontal") : Input.GetAxis("Horizontal2");
            float vertical = (jugadorID == 1) ? Input.GetAxis("Vertical") : Input.GetAxis("Vertical2");

            // Movimiento básico utilizando el Rigidbody para físicas
            Vector3 movimiento = new Vector3(horizontal, 0, vertical) * velocidad * Time.deltaTime;
            rb.MovePosition(transform.position + movimiento);

            // Si estamos en tercera persona, ajustar la cámara
            if (!enPrimeraPersona)
            {
                playerCamera.transform.position = transform.position + terceraPersonaOffset;
                playerCamera.transform.LookAt(transform.position);
            }
        }

        void CambiarCamara()
        {
            if (jugadorID == 1 && Input.GetKeyDown(KeyCode.C)) // Cambiar la cámara cuando presionamos 'C' para el Jugador 1
            {
                enPrimeraPersona = !enPrimeraPersona;
                if (enPrimeraPersona)
                {
                    playerCamera.transform.SetParent(transform);  // La cámara se convierte en hija del jugador
                    playerCamera.transform.localPosition = new Vector3(0, 1.5f, 0);  // Posición de la cámara en primera persona
                }
                else
                {
                    playerCamera.transform.SetParent(null);  // Desvinculamos la cámara del jugador
                }
            }
        }

        // Método para recibir daño y reducir la vida
        public void RecibirDanio(float cantidad)
        {
            vida -= cantidad;
            if (vida <= 0)
            {
                Debug.Log("Jugador ha muerto");
                // Lógica de muerte (como reiniciar escena o mostrar mensaje de Game Over)
            }
        }
    }
}

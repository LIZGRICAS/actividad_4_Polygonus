using UnityEngine;

namespace DefaultNamespace
{
    public class CameraManager : MonoBehaviour
    {
   
        public Camera cameraPlayer1;   // Cámara del primer jugador
        public Camera cameraPlayer2;   // Cámara del segundo jugador

        public GameObject player1;     // Objeto del primer jugador
        public GameObject player2;     // Objeto del segundo jugador

        public float player1Speed = 5f; // Velocidad del jugador 1
        public float player2Speed = 5f; // Velocidad del jugador 2

        void Start()
        {
            // Configurar cámaras para pantalla dividida
            SetCameraView();
        }

        void Update()
        {
            // Movimiento de los jugadores
            MovePlayer(player1, "Horizontal", "Vertical", player1Speed);
            MovePlayer(player2, "Horizontal2", "Vertical2", player2Speed);
        }

        void SetCameraView()
        {
            // Configuración para la cámara del primer jugador (izquierda)
            cameraPlayer1.rect = new Rect(0, 0, 0.5f, 1);  // 50% de la pantalla
            cameraPlayer1.transform.position = new Vector3(player1.transform.position.x, player1.transform.position.y, -10f);

            // Configuración para la cámara del segundo jugador (derecha)
            cameraPlayer2.rect = new Rect(0.5f, 0, 0.5f, 1);  // 50% de la pantalla
            cameraPlayer2.transform.position = new Vector3(player2.transform.position.x, player2.transform.position.y, -10f);
        }

        void MovePlayer(GameObject player, string horizontalInput, string verticalInput, float speed)
        {
            // Obtener la entrada de movimiento de los jugadores
            float horizontal = Input.GetAxis(horizontalInput);
            float vertical = Input.GetAxis(verticalInput);

            // Movimiento del jugador
            Vector3 movement = new Vector3(horizontal, vertical, 0) * speed * Time.deltaTime;
            player.transform.Translate(movement);
        }
    
    }
}
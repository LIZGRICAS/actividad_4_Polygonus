using UnityEngine;

namespace DefaultNamespace
{
    public class ObjetivoPlay : MonoBehaviour
    {
        public Transform puntoObjetivo;  // El punto objetivo en la escena
        private bool jugador1EnObjetivo = false;
        private bool jugador2EnObjetivo = false;

        void OnTriggerEnter(Collider other)
        {
            if (other.CompareTag("Jugador1"))
            {
                jugador1EnObjetivo = true;
            }
            if (other.CompareTag("Jugador2"))
            {
                jugador2EnObjetivo = true;
            }
        }

        void Update()
        {
            if (jugador1EnObjetivo && jugador2EnObjetivo)
            {
                Debug.Log("¡Ambos jugadores han alcanzado el objetivo!");
                // Aquí podrías agregar un sistema para mostrar el final de nivel, puntuaciones, etc.
            }
        }
    }
}
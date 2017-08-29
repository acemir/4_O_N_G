using UnityEngine;
using System.Collections;

/// Este comportamento é anexado às bordas atrás dos jogadores.
/// Controla a colisão com a bola.
public class PlayerBorder : MonoBehaviour {
	
	/// Indica qual jogador que defende esta borda.
	public GameObject player;

	/// Indica se a borda está ativa, ou seja, se o jogador ainda não perdeu.
	public bool isActive = true;

	/// Executada pelo Unity quando este GameObject colide com outro.
	void OnCollisionEnter(Collision col)
	{
		// Foi a bola que colidiu?
		// O número de perdedores é menor que 3 (a partida não terminou)?
		// Esta borda está ativa?
		Ball ball = col.gameObject.GetComponent<Ball>();
		if (ball != null && ball.score < 3 && isActive)
		{
			// Disabilita o jogador que estava defendendo esta borda
			player.SetActive(false);

			// Chama a função "SetScore" da bola que deverá incrementar o número de jogadores que perderam o jogo
			ball.SetScore();

			// Depois disso, esta borda não deve mais estar ativa
			isActive = false;

		}
	}
}

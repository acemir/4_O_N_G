using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

/// Constante global que mapeia os lados possíveis para cada jogador.
public enum ePlayer
{
	Front,
	Left,
	Back,
	Right
}

/// Comportamento anexado à bola que controla seu movimento.
public class Ball : MonoBehaviour
{
	
	/// Número decimal: A velocidade inicial da bola.
	public float speed = 5f;

	/// Indicador: número de jogadores que perderam o jogo
	/// </summary>
	public int score = 0;

	/// Componente: responsável pela física da bola
	private Rigidbody rb;

	/// Executado pelo Unity quando a cena começa.
	void Start ()
	{
		/// Executa a função "StartGame" 2 segundos após o início da cena.
		Invoke("StartGame", 2);

		/// Atribui o Componente Rigidbody à variável rb
		rb = GetComponent<Rigidbody>();
	}

	/// Executado pelo Unity a cada frame de execução (normalmente 60 vezes por segundo).
	void Update ()
	{
		// Executa somente quando o jogo estiver iniciado de fato
		rb.velocity = speed * (rb.velocity.normalized);
		rb.angularVelocity = new Vector3 (0f, rb.velocity.normalized.z * speed, 0f);
	}

	// Executado a cada vez que a bola colide com algum outro GameObject.
	void OnCollisionEnter(Collision col)
	{
		// Incrementa variável de velocidade da bola
		speed = speed + 0.05f;
	}

	// Funcão para iniciar de fato o jogo, iniciando o movimento da bola
	void StartGame ()
	{
		// Gera números decimais randômicos entre -1,0 e 1.0
		float sx = Random.Range (-1f, 1f);
		float sz = Random.Range (-1f, 1f);

		// Adiciona uma forca inicial, gerando um impulso nos eixos X e Y
		rb.AddForce(new Vector3 (speed * sx, 0f, speed * sz), ForceMode.Impulse);
		// Garante que a velocidade da bola seja igual à velocidade definida no início
		rb.velocity = speed * (rb.velocity.normalized);
		// Rotaciona a bola a uma velocidade constante baseada na velocidade definida no início
		rb.angularVelocity = new Vector3(0f, rb.velocity.normalized.z * speed, 0f);

	}

	// Função para incrementar o número de jogadores que perderam o jogo
	// Deve ser publica pois será chamada através de outro GameObject
	public void SetScore ()
	{
		score++;

		// Se o número de perdedores for 3, o jogo acaba e o jogador restante é o vencedor
		if (score >= 3) {
			// Reinicia a cena 5 segundos após o fim do jogo
			Invoke("ReStartGame", 5);
		}
	}

	// Função para reiniciar a cena
	void ReStartGame()
	{
		SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
	}
}

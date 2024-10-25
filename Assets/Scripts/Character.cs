using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Character : MonoBehaviour
{
	[Header("Refs")]
	public Transform checkpoint;
	[SerializeField] Animator animator;

	[Header("Jump Param")]
	public Transform groundTransform;
	public float jumpForce = 10;
	public LayerMask jumpMask;
	public float coyoteTimeDur = 0.2f;

	[Header("Dash Param")]
	public float dashingDistance = 24f;
	public float dashingTime = 0.2f;
	public float dashingCooldown = 1f;
	public TrailRenderer dashTrailRenderer;
	private float direction = 1f;
	private bool canDash = true;
	private bool isDashing = false;

	[Header("MoveParam")]
	public float maxSpeed = 10;
	public float acceleration = 5;

	[Header("Debug")]
	public SpriteRenderer characterSpriteRenderer;
	public Vector2 playerMoveInput = new Vector2(0, 0);
	public bool canJump = false;
	public float coyoteCounter = 0;
	//Coroutine Dash;

	[Header("Health")]
	public int maxHealth = 100;
	public int currentHealth;
	public HealthBar healthBar;

	// PRIVATE
	private Rigidbody2D rb;
	private Vector2 colliderSize;

	
	/* Serialization is the automatic process of transforming data structures or GameObject states into a format that Unity can store and reconstruct later.
	* to reference the trail renderer */
	[SerializeField] private TrailRenderer tr;

	// Au play...
	void Start()
	{
		rb = GetComponent<Rigidbody2D>();
		colliderSize = GetComponent<CapsuleCollider2D>().size;
		dashTrailRenderer.enabled = false;

		// Check if the animator is assigned
		if (animator == null)
		{
			// Debug.LogError("Animator not assigned!");
		}

		currentHealth = maxHealth;
		healthBar.SetMaxHealth(maxHealth);
	}

	// A chaque frame
	void Update()
	{
		if (!isDashing)
		{
			JumpLoop(); // Gère la mécanique de saut
		}

		// Debug.DrawRay(transform.position, new Vector2(1.0f, 0f) * 5.0f, Color.green);


		if (animator != null)
		{
			animator.SetBool("isGrounded", IsGrounded()); 
			// Set isGrounded to true/false
			animator.SetBool("isWalking", Mathf.Abs(playerMoveInput.x) > 0); 
			// Set isWalking based on movement input
			animator.SetFloat("verticalVelocity", rb.velocity.y);
		}

		// Add temporary movement for testing without InputSystem
		playerMoveInput.x = Input.GetAxisRaw("Horizontal");
	}

	// A chaque fixed frame
	// C'est ici qu'on fait la physique pour des raison de stabilité
	void FixedUpdate()
	{
		if (!isDashing)
		{
			MoveLoop(); 
			// Gère la mécanique de mouvement
		}
	}

	// Gère les événements de collision
	private void OnTriggerEnter2D(Collider2D collision)
	{
		if(collision.CompareTag("Trap"))
		{
			TakeDamage(collision.gameObject.GetComponent<Trap>().damageAmount);
		}
		// Other checks like DeathZone, CheckPoint, etc.

		// DeathZone
		if (collision.gameObject.layer == 15)
		{
			Die();
		}

		// CheckPoint
		if (collision.gameObject.layer == 16)
		{
			checkpoint = collision.gameObject.transform;
		}
	}


	public void RegainHealth(int life)
	{
		currentHealth += life;
		Debug.Log("player regained health! current health: " + currentHealth);

		//update the health bar
		if (healthBar != null)
		{
			healthBar.SetHealth(currentHealth);
		}

		if (currentHealth >= 100)
		{
			//player can't take more
			Debug.Log("player has full life!");
		}

	}

	public void TakeDamage(int damage)
	{
		currentHealth -= damage;
		Debug.Log("player took damage! current health: " +currentHealth);

		//update the health bar
		if (healthBar != null)
		{
			healthBar.SetHealth(currentHealth);
		}

		if (currentHealth <=0)
		{
			//player dies
			Debug.Log("player has died!");
			Die();
			//re-using this
		}

	}

	//--- Move ---//

	// Appelé par UnityEvent depuis le player Input
	public void OnMoveInput(InputAction.CallbackContext context)
	{
		playerMoveInput = context.ReadValue<Vector2>();
	}

	private void MoveLoop()
	{
		//Si on a pas de volonté du joueur de se deplacer en x on stop
		float inputAbsX = Mathf.Abs(playerMoveInput.x);
		if (inputAbsX == 0)
		{
			return;
		}

		// Assignation de la direction du joueur
		direction = playerMoveInput.x;

		// Si on essais de se deplacer sur un mur on stop
		/* TODO : Attention utiliser la position du rb c'est pas top :/
		* Plutôt faire une class de sensor ? */
		float dir = Mathf.Sign(playerMoveInput.x);
		RaycastHit2D hit = Physics2D.Raycast(rb.position, Vector2.right * dir, 0.55f, jumpMask);
		if (hit.collider != null)
		{
			return;
		}

		//Si on est pas a la vitesse max on ajoute de la force
		if (Mathf.Abs(rb.velocity.x) < maxSpeed)
		{
			rb.AddForce(Vector2.right * dir * acceleration, ForceMode2D.Force);
		}

		// Flip the character sprite based on the direction it's moving
		characterSpriteRenderer.flipX = (rb.velocity.x < 0f);

		// Update animator speed if walking
		if (animator != null)
		{
			animator.SetFloat("Speed", Mathf.Abs(rb.velocity.x));  
			// Make sure the "Speed" parameter exists
		}
	}


	//--- Jump ---//

	// Appelé par UnityEvent depuis le player Input
	public void OnJumpInput(InputAction.CallbackContext context)
	{
		if (context.started)
		{
			Jump();
			if (animator != null)
			{
				animator.SetTrigger("jump");
			}
		}
	}

	// Logique de saut
	void JumpLoop()
	{
		// Si le chara est au sol on reset le coyote time
		if (IsGrounded())
		{
			Debug.Log("Grounded: Resetting coyote time");
			coyoteCounter = coyoteTimeDur;
			// S'assurer qu'on peut sauter si on est au sol
		}

		// Sinon on le decremente de la durée de la frame
		else if (coyoteCounter > 0)
		{
			Debug.Log("Coyote Time: " + coyoteCounter);
			// Sinon on le décrémente de la durée de la frame
			coyoteCounter -= Time.deltaTime;
		}
		else
		{
			Debug.Log("No jump available");
		}
	}

	void Jump()
	{
		if (coyoteCounter > 0)
		{
			Debug.Log("Jumping!");
			coyoteCounter = 0;

			// Fait sauter le joueur
			rb.velocity = new Vector2(rb.velocity.x, 0);        
			// On reset la velocity verticale pour que le saut soit le même qu'on soit au sol ou deja en train de tomber
			rb.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
		}
		else
		{
			Debug.Log("Cannot jump, not grounded");
		}
	}

	//--- Dash ---//

	// Appelé par UnityEvent depuis le player Input
	public void OnDashInput(InputAction.CallbackContext context)
	{
		if (context.started && canDash && !isDashing)
		{
			// Une coroutine permet de répartir les tâches sur plusieurs frames
			StartCoroutine(Dash());
		}
	}

	// Logique du dash utilisant une coroutine
	private IEnumerator Dash()
	{
		// Keep the rb's og gravity scale
		float originalGravity = rb.gravityScale;

		// Will be used to calculate the distance of the dash (if colliding with walls)
		float dashDistance;

		// Layer that will stop the dash's raycast (for walls)
		LayerMask dashLayerMask = LayerMask.GetMask("Ground");

		// Deactivate gravity during dash
		rb.gravityScale = 0f;

		// Reset character velocity when dashing
		rb.velocity = Vector2.zero;

		// Deactivate the ability to use the dash when already dashing
		canDash = false;

		// Activate the flag to tell we are dashing
		isDashing = true;

		// Activate the dash animation
		if (animator != null)
		{
			animator.SetTrigger("dash");
		}


		/* Capsule cast used to calculate the distance for the character to dash
		* based on its position, its collider size slightly reduced to not touch the ground
		* we also use the direction of the player at the time of the dash input and
		* a layer to only include the object that can stop the player when dashing (for now only walls)
		* We store the result of the cast in a variable "hit" */
		RaycastHit2D hit = Physics2D.CapsuleCast(transform.position, colliderSize * 0.99f, CapsuleDirection2D.Vertical, 0f, new Vector2(direction, 0f), dashingDistance, dashLayerMask);
		
		// We test if we hit something
		if (hit)
		{
			// If we do we calculate the distance of the dash based on the hit distance minus half the size of the player collider
			dashDistance = hit.distance * direction - (colliderSize.x / 2);
		}
		else
		{
			// Otherwise we just go for the full distance, still minus half the size of the player collider
			dashDistance = dashingDistance - (colliderSize.x / 2);
		}

		// We then calculate the origin and target positions for the dash to occur based on those informations
		Vector2 originPosition = transform.position;
		Vector2 targetPosition = new Vector2(transform.position.x + dashDistance * direction, transform.position.y);

		// This variable is used to count through time
		float elapsedTime = 0f;

		// This is the total duration of the dash, that will be shorter if something was hit, to keep a constant speed whatsoever
		float totalDuration = (dashDistance / dashingDistance) * dashingTime;

		// Activate the trail renderer
		dashTrailRenderer.enabled = true;
		
		/* This loop allow to move the character between the two positions by linearly interpolating its position
		* according to the elapsed time over the total duration of the dash, each iteration occurring on a different frame */
		while (elapsedTime < totalDuration)
		{
			transform.position = Vector2.Lerp(originPosition, targetPosition, elapsedTime / totalDuration);
			elapsedTime += Time.deltaTime;
			yield return null; 
			// Allows to wait a frame
		}

		// Reactivate gravity afterwards
		rb.gravityScale = originalGravity;

		// Deactivate the flag that says we are dashing
		isDashing = false;

		// Deactivate the dash animation
		if (animator != null)
		{
			animator.SetBool("isDashing", false);
		}

		// Deactivate the trail renderer
		dashTrailRenderer.enabled = false;

		// We trigger the dash cooldown
		yield return new WaitForSeconds(dashingCooldown);

		// And after that we wait for the player to be grounded to give the ability to dash again
		while (!IsGrounded())
			yield return null;
		canDash = true;

		// Old garbage that should be trashed but is still there "just in case" ykwim

		/* dash logic
		* yield break; // For brevity
		* isDashing = true;
		* canDash = false;
		* canJump = false;

		* Stocker l'échelle de gravité d'origine et désactiver la gravité pendant le dash
		* float originalGravity = rb.gravityScale;
		* rb.gravityScale = 0f;

		*  Appliquer la vélocité du dash dans la direction actuelle
		* rb.velocity = new Vector2(transform.localScale.x * dashingPower, 0f);

		* Activer le trail renderer pendant le dash
		* tr.emitting = true;

		* Attendre la fin du dash
		* yield return new WaitForSeconds(dashingTime);

		* Restaurer la gravité et désactiver le dash
		* tr.emitting = false;
		* rb.gravityScale = originalGravity;
		* isDashing = false;


		* Add a small delay to ensure proper re-grounding
		* yield return new WaitForSeconds(0.05f);  // Short delay to allow ground detection

		* Check if grounded again after dash ends
		* Vérifier si le personnage est au sol avant de permettre de sauter à nouveau
		* canJump = IsGrounded();
		* Re-check if grounded after dash ends
		* if (canJump)
		* {
		*	Debug.Log("Grounded after dash");
		*	coyoteCounter = coyoteTimeDur;  // Reset jump availability
		* }
		* else
		* {
		*	Debug.Log("Not grounded after dash");
		* }


		* Petite pause avant de pouvoir redasher
		* yield return new WaitForSeconds(dashingCooldown);

		* Réactiver le dash
		* canDash = true;
		*/
	}


	//--- Misc ---//

	//Est ce que le chara est au sol ?
	public bool IsGrounded()
	{
		//S'il y a du sol a moins de 10cm de ses pied il est au sol !
		//bool value = false;
		RaycastHit2D hit = Physics2D.Raycast(groundTransform.position, Vector2.down, 0.1f, jumpMask);
		Debug.DrawRay(groundTransform.position, Vector2.down * 0.1f, Color.green);
		return rb.velocity.y <= 0.1f && hit.collider != null;
	}

	// Handle player death and respawn
	void Die()
	{
		Teleport(checkpoint.position);
	}

	void Teleport(Vector2 targetPos)
	{
		//Avant d'effectuer un deplacement TRS il est important de desactiver la physique (et on la remet aprés).
		rb.velocity = Vector2.zero;
		rb.simulated = false;
		transform.position = targetPos;
		rb.simulated = true;
	}
}

/*
 * ⠀⠀⠀⠀⠀⠀⠀⠀⠀ ⠀⣴⡿⣷⣄⠀
⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀   ⢹⣧⣈⣻⣷
⠀⠀⠀⠀⠀⠀⠀⠀  ⠀⢀⣴⠟⠉⠙⠛⠁
⠀⠀⢀⣴⣿⣦⡀⢀⣴⠿⠁⠀⠀⠀⠀⠀
⠀⣴⡿⠋⠀⢹⣿⣿⡁⠀⠀⠀⠀⠀⠀⠀
⢰⣿⠀⠀⢴⠟⠉⠙⣿⣦⠀⠀⠀⠀⠀⠀
⠸⣿⡀⠀⠀⠀⣠⣾⠟⠁⠀⠀⠀⠀⠀⠀
⠀⠙⠻⠿⠿⠟⠛⠁⠀⠀⠀⠀⠀⠀⠀⠀
la sainte pelle, all hail Antoine Daniel our leader
*/
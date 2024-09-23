using System;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class PlayerBehaviour : MonoBehaviour
{
    [SerializeField] private PlayerSettings settings;
    [SerializeField] private PlayerInputController input;

    private Rigidbody rb;

    private bool isGrounded;
    private bool isInitialized = false;

    private bool isDead => GameManager.Instance.IsDead;

    public event Action OnFallDawn = () => { };

    public void Init(PlayerInputController input)
    {
        this.input = input;

        rb = GetComponent<Rigidbody>();

        this.input.JumpTap += TryToJump;

        isInitialized = true;
    }

    private void Update()
    {
        if (!isInitialized || isDead) return;

        // –ух уперед
        transform.Translate(Vector3.forward * settings.moveSpeed * Time.deltaTime);

        // ѕерев≥рка пад≥нн€ гравц€
        if (transform.position.y < settings.deathHeight) OnFallDawn.Invoke();
    }
    private void TryToJump()
    {
        if (!isInitialized || isDead || !isGrounded) return;

        Debug.Log("Jump called");
        rb.AddForce(Vector3.up * settings.jumpForce, ForceMode.Impulse);
        isGrounded = false;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.CompareTag("Ground"))
        {
            isGrounded = true;
        }
    }

    private void OnDestroy()
    {
        OnFallDawn = () => { };
    }

    public void IncreaseSpeed(int platformsPassed)
    {
        settings.moveSpeed += platformsPassed * 0.1f;// «б≥льшенн€ швидкост≥ гравц€
    }
}

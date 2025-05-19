using UnityEngine;
using UnityEngine.InputSystem;

public class ControlScript : MonoBehaviour
{
    private Rigidbody2D rb;  // Посилання на компонент батьківського GameObject
    private InputAction moveAction; // Посилання на Ассет
    void Start()
    {
        rb=this.GetComponent<Rigidbody2D>();  // пошук компонента, збереження посилання
        moveAction = InputSystem.actions.FindAction("Move");
    }
    // null safety: краще в Unity не використовувати
    // ref?.prop "null propagation"
    // ref!.prop "null checking"
    // ref ?? val "null coalescence"
    void Update()
    {
        // Взаємодія з користувачем (управління) 

        // 1.Пряме звернення до пристроїв (клавіатура,миша,тощо)
        //if(Input.GetKeyDown(KeyCode.Space)) // одноразове натискання
        //{
        //     rb.AddForce(Vector2.up * 100);
        //}
        // if (Input.GetKey(KeyCode.W)) // постійне натискання
        // {
        //     rb.AddForce(Vector2.up * 5);
        // }

        // 2. Input Manager
        //float y = Input.GetAxis("Vertical");
        //rb.AddForce(y * 5 * Vector2.up);

        // 3.(популярнее) Input System - до версії Unity 6 необхідно встановлення як пакету 
        Vector2 moveValue = moveAction.ReadValue<Vector2>();
        rb.AddForce(moveValue.y * 5 * Vector2.up +
            moveValue.x * 5 * Vector2.right);
    }
}

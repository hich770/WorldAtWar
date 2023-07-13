using UnityEngine;

public class SpawnObjectsOnButton : MonoBehaviour
{
    public KeyCode spawnKey = KeyCode.Mouse1; // клавиша, которую нужно нажать для спавна
    public float reloadTime = 1.0f; // время перезарядки в секундах
    private float lastShotTime = -Mathf.Infinity; // время последнего выстрела
    public ScoreManager scoreManager;

void Update()
{
    if (Input.GetKeyDown(spawnKey))
    {
        // Получаем позицию курсора на экране
        Vector3 mousePosition = Input.mousePosition;
        mousePosition.z = Camera.main.transform.position.z;

        // Получаем позицию в мировых координатах
        Vector3 worldPosition = Camera.main.ScreenToWorldPoint(mousePosition);

        // Проверяем, что объект можно спавнить в данной позиции
        Collider2D[] colliders = Physics2D.OverlapCircleAll(worldPosition, 0.1f);
        bool canSpawn = true;
        foreach (Collider2D collider in colliders)
        {
            if (collider.gameObject.tag != "Obstruction")
            {
                canSpawn = false;
                break;
            }
        }

        // Если объект можно спавнить, то спавним его
        if (canSpawn && scoreManager.score >= 10)
        {
            Instantiate(scoreManager.dugout, worldPosition, Quaternion.identity);
            scoreManager.AddScore(-10);
        }
        else if (canSpawn && scoreManager.score > 0)
        {
            Instantiate(scoreManager.objectToSpawn, worldPosition, Quaternion.identity);
            scoreManager.AddScore(-1);
        }
    }
}


    public void Fire()
    {
        if (Time.time - lastShotTime >= reloadTime)
        {
            lastShotTime = Time.time;
            // код, который обрабатывает выстрелы
        }
    }
}
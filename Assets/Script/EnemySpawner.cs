using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public GameObject enemyPrefab; // префаб объекта Enemy
    public float initialSpawnTime = 5f; // начальное время между спавнами
    public float finalSpawnTime = 1f; // конечное время между спавнами
    public float spawnTimeDecreaseRate = 0.1f; // скорость уменьшения времени между спавнами
    private float timer = 0f; // таймер для отслеживания времени
    private float currentSpawnTime; // текущее время между спавнами

    void Start()
    {
        currentSpawnTime = initialSpawnTime;
    }

    void Update()
    {
        // увеличиваем таймер каждый кадр
        timer += Time.deltaTime;

        // если прошло достаточно времени для спавна
        if (timer >= currentSpawnTime)
        {
            // сбрасываем таймер
            timer = 0f;

            // создаем новый объект Enemy из префаба
            GameObject newEnemy = Instantiate(enemyPrefab, transform.position, Quaternion.identity);

            // добавляем новый объект в родительский объект (если нужно)
            newEnemy.transform.parent = transform;

            // уменьшаем время между спавнами
            currentSpawnTime = Mathf.Max(currentSpawnTime - spawnTimeDecreaseRate, finalSpawnTime);
        }
    }
}
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RewardManager : MonoBehaviour
{
    public static RewardManager instance;

    [SerializeField] private GameObject rewardItem;
    [SerializeField] private float power = 3f;

    private void Awake()
    {
        instance = this;
    }
        
    public void SpawnReward(Vector3 position, float delay)
    {
        StartCoroutine(Delay(position, delay));
    }

    private IEnumerator Delay(Vector3 position, float delay)
    {
        yield return new WaitForSeconds(delay);
        var itemsCount = Random.Range(2, 5);

        for (int i = 0; i < itemsCount; i++)
        {
            var rewardRigidbody = Instantiate(rewardItem,
                position + new Vector3(Random.Range(-1f, 1f), 2, Random.Range(-1f, 1f)),
                Quaternion.Euler(Random.Range(0, 360), Random.Range(0, 360), Random.Range(0, 360)))
                .GetComponent<Rigidbody>();
            rewardRigidbody.AddForce(new Vector3(Random.Range(-1f, 1f), 1, Random.Range(-1f, 1f) * power));
        }
    }
}

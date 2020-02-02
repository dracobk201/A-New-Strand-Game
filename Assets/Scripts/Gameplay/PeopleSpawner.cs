using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PeopleSpawner : MonoBehaviour
{
    private List<GameObject> people;
    [SerializeField] private IntReference PeoplePooled;
    [SerializeField] private GameObject peoplePrefab;
    [SerializeField] private GameObject peoplePrefab2;
    [SerializeField] private Transform peopleHolder;
    [SerializeField] private Vector3Reference PeoplePosition;
    [SerializeField] private GameEvent PersonInstantiated;

    private void Start()
    {
        InstantiatePeople();
        StartCoroutine(InstantiatePersonPerTime());
    }

    private IEnumerator InstantiatePersonPerTime()
    {
        while (true)
        {
            yield return new WaitForSeconds(8);
            ShowAPerson();
        }
    }

    public void ShowAPerson()
    {
        if (PeoplePosition.Value == Vector3.zero)
            return;
        Vector2 initialPosition = Vector2.zero;
        initialPosition = (Vector2)PeoplePosition.Value;

        for (int i = 0; i < people.Count; i++)
        {
            if (!people[i].activeInHierarchy)
            {
                people[i].transform.position = PeoplePosition.Value;
                people[i].SetActive(true);
                PersonInstantiated.Raise();
                break;
            }
        }
    }

    private void InstantiatePeople()
    {
        people = new List<GameObject>();
        for (int i = 0; i < PeoplePooled.Value; i++)
        {
            GameObject targetPrefab;
            if (UnityEngine.Random.value > 0.5f)
                targetPrefab = peoplePrefab;
            else
                targetPrefab = peoplePrefab2;
            GameObject person = Instantiate(targetPrefab) as GameObject;
            person.GetComponent<Transform>().SetParent(peopleHolder.transform);
            person.SetActive(false);
            people.Add(person);
        }
    }
}

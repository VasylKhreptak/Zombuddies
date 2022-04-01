using System.Collections;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using UnityEngine;

public class ObservableCollectionTest : MonoBehaviour
{
    protected ObservableCollection<Transform> _observableCollection = new ObservableCollection<Transform>();

    private IEnumerator Start()
    {
        while (true)
        {
            Debug.Log("Add");

            _observableCollection.Add(gameObject.transform);

            yield return new WaitForSeconds(1f);
        }
    }

    private void OnEnable()
    {
        _observableCollection.CollectionChanged += ObservableCollectionOnCollectionChanged;
    }

    private void OnDisable()
    {
        _observableCollection.CollectionChanged -= ObservableCollectionOnCollectionChanged;
    }
    
    private void ObservableCollectionOnCollectionChanged(object sender, NotifyCollectionChangedEventArgs e)
    {
        Debug.Log("Changed");
    }
}

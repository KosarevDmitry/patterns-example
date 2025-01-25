using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace Features;

public interface IFeatureCollection : IEnumerable<KeyValuePair<Type, object>>
{
    object? this[Type key] { get; set; }
}

public class FeatureCollection : IFeatureCollection
{
    private static readonly KeyComparer                FeatureKeyComparer = new KeyComparer();
    private readonly        IFeatureCollection?        _defaults;
    private readonly        int                        _initialCapacity;
    private                 IDictionary<Type, object>? _features;



    public FeatureCollection()
    {
    }


   
    public FeatureCollection(int initialCapacity)
    {
        if (initialCapacity < 0)
        {
            throw new ArgumentOutOfRangeException(nameof(initialCapacity));
        }

        _initialCapacity = initialCapacity;
    }

   
    public FeatureCollection(IFeatureCollection defaults)
    {
        _defaults = defaults;
    }


   
    public bool IsReadOnly
    {
        get { return false; }
    }

    
    public object? this[Type key]
    {
        get
        {
            if (key == null)
            {
                throw new ArgumentNullException(nameof(key));
            }

            return _features != null && _features.TryGetValue(key, out var result) ? result : _defaults?[key];
        }
        set
        {
            if (key == null)
            {
                throw new ArgumentNullException(nameof(key));
            }

            if (value == null)
            {
                if (_features != null && _features.Remove(key))
                {
                    //  _containerRevision++;
                }

                return;
            }

            if (_features == null)
            {
                _features = new Dictionary<Type, object>(_initialCapacity);
            }

            _features[key] = value;
            //   _containerRevision++;
        }
    }

    IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();


  
    public IEnumerator<KeyValuePair<Type, object>> GetEnumerator()
    {
        if (_features != null)
        {
            foreach (var pair in _features)
            {
                yield return pair;
            }
        }

        if (_defaults != null)
        {
            
            foreach (var pair in _features == null ? _defaults : _defaults.Except(_features, FeatureKeyComparer))
            {
                yield return pair;
            }
        }
    }

   
    public TFeature? Get<TFeature>()
    {
        return (TFeature?)this[typeof(TFeature)];
    }

   
    public void Set<TFeature>(TFeature? instance)
    {
        this[typeof(TFeature)] = instance;
    }

    private sealed class KeyComparer : IEqualityComparer<KeyValuePair<Type, object>>
    {
        public bool Equals(KeyValuePair<Type, object> x, KeyValuePair<Type, object> y)
        {
            return x.Key.Equals(y.Key);
        }

        public int GetHashCode(KeyValuePair<Type, object> obj)
        {
            return obj.Key.GetHashCode();
        }
    }
}
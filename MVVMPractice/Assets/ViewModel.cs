using System;
using UnityEngine;

public abstract class ViewModel : MonoBehaviour
{
    public event Action OnViewModelChanged = delegate {  };

    protected void RaiseChange()
    {
        OnViewModelChanged.Invoke();
    }

    public abstract object Value { get;}
}

//TODO need to make a list or dictionary of values for observables
public abstract class ViewModel<T> : ViewModel
{
    private Observable<T> _model = new Observable<T>();

    public T Model
    {
        get => _model.Value;
        set => _model.Value = value;
    }

    private void Start()
    {
        _model.OnValueChange += OnModelChange;
    }

    protected virtual void OnModelChange()
    {
        RaiseChange();
    }

    public override object Value => Model;
}


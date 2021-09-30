using System;

public class Observable<T>
{
    private T _value;

    public T Value
    {
        get => _value;
        set
        {
            if(!_value.Equals(value))
                OnValueChange.Invoke();
            _value = value;
        }
            
    }
    //putting event here means that no one can set except this class, they only += and -=
    public event Action OnValueChange = delegate {  }; //prevents from ever being null

    public void RaiseChange()
    {
        OnValueChange.Invoke();
    }
    
}
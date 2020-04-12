using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IPresenter<T>
{
    void Present(T value);
}

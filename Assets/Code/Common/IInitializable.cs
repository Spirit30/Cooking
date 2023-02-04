public interface IInitializable
{
    void Init();
}

public interface IInitializable<T>
{
    void Init(T arg);
}

public interface IInitializable<T1, T2>
{
    void Init(T1 arg1, T2 arg2);
}

public interface IInitializable<T1, T2, T3>
{
    void Init(T1 arg1, T2 arg2, T3 arg3);
}
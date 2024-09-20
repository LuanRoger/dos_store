namespace DosStore.Views;

public interface IResultedMenu<T>
{
    public Task<T> StartFlow();
}
namespace DosStore.Views;

public interface IResultedFlowMenu<T>
{
    public Task<T> StartFlow();
}
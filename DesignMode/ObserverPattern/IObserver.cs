namespace ObserverPattern
{
    public interface IObserver
    {
        void Receive(Blog blog);
    }
}
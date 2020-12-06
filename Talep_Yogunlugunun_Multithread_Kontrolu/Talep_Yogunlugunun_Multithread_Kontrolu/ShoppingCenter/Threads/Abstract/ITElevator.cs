namespace ShoppingCenter.Threads.Abstract
{
    public interface ITElevator
    {
        void ElevetorThread(global::ShoppingCenter.Elevator.Concrete.Elevator elevator,
            global::ShoppingCenter.Floor.Concrete.Floor[] floors, int capacity);
    }
}
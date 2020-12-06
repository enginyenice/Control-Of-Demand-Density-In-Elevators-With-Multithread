using ShoppingCenter.Core;

namespace ShoppingCenter.Threads.Abstract
{
    public interface ITExit
    {
        void ExitThread(Floor.Concrete.Floor[] floors, Settings settings);
    }
}
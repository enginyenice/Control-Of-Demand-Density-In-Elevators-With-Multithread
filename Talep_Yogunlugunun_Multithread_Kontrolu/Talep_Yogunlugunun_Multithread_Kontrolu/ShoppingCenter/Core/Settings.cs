namespace ShoppingCenter.Core
{
    public class Settings
    {
        public int Capacity { get; }
        public int Ms200 { get; }
        public int Ms500 { get; }
        public int Ms1000 { get; }

        private int totalLoginCount;
        private int totalExitCount;

        public int TotalLoginCount
        {
            get { return totalLoginCount; }
            set { totalLoginCount += value; }
        }

        public int TotalExitCount
        {
            get { return totalExitCount; }
            set { totalExitCount += value; }
        }

        public Settings()
        {
            totalLoginCount = 0;
            totalExitCount = 0;
            Capacity = 10;
            Ms200 = 200;
            Ms500 = 500;
            Ms1000 = 1000;
        }
    }
}
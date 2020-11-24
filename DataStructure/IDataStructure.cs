namespace DataStructure
{
    public interface IDataStructure
    {
        void Add(int value);
        void Add(int[] values);
        void AddToBegin(int value);
        void AddToBegin(int[] values);
        void AddToIndex(int index, int value);
        void AddToIndex(int index, int[] values);
        void Delete(int count = 1);
        void DeleteFromBegin(int count = 1);
        void DeleteByIndex(int index, int count = 1);
        void DeleteByValue(int value);
        void DeleteAllByValue(int value);
        int GetMax();
        int GetMin();
        int GetMaxIndex();
        int GetMinIndex();
        void SortAscending();
        void SortDescending();
        void Reverse();
        
    }
}
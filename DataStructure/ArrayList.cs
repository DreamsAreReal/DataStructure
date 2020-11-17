using System;

namespace DataStructure
{
    public class ArrayList
    {
        public int Length { get; private set; }

        private int[] _array;
        
        public ArrayList()
        {
            _array = new int[9];
            Length = 0;
        }
      
        public ArrayList(int[] array)
        {
            _array = new int[(int) (array.Length * 1.33)];
            Array.Copy(array, _array, array.Length);
            Length = array.Length;
        }

        public int this[int index]
        {
            get
            {
                if (index > Length - 1 || index < 0)
                {
                    throw new IndexOutOfRangeException();
                }

                return _array[index];
            }
            set
            {
                if (index > Length - 1 || index < 0)
                {
                    throw new IndexOutOfRangeException();
                }

                _array[index] = value;
            }
        }

        public void Add(int value)
        {
            
            if (_array.Length <= Length)
            {
                IncreaseLenght();
            }
            _array[Length] = value;
            Length++;

        }
        
        public void Add(int[] values)
        {
            if (_array.Length <= Length+values.Length)
            {
                IncreaseLenght(values.Length);
            }
            
            for (int i = 0; i < values.Length; i++)
            {
                _array[Length] = values[i];
                Length++;
            }
        }
        public void AddToBegin(int value)
        {
            ShiftкRight();
            _array[0] = value;
            Length++;
        }
        
        public void AddToBegin(int[] values)
        {
            if (values.Length == 0)
            {
                throw new NullReferenceException("The number of elements in the values cannot be zero.");
            }
            ShiftкRight(values.Length);
    
            int tmp = 0;
            for (int i = 0; i < values.Length; i++)
            {
                _array[tmp] = values[i];
                Length++;
                tmp++;
            }
        }
        
        public int GetMax()
        {
            if (Length == 0)
            {
                throw new NullReferenceException("The list cannot be empty.");
            }
            int max = _array[0];
            
            for (int i = 0; i < Length; i++)
            {
                if (_array[i] > max)
                {
                    max = _array[i];
                }
            }

            return max;
        }
        
        public int GetMin()
        {
            if (Length == 0)
            {
                throw new NullReferenceException("The list cannot be empty.");
            }
            int min = _array[0];
            
            for (int i = 0; i < Length; i++)
            {
                if (_array[i] < min)
                {
                    min = _array[i];
                }
            }

            return min;
        }
        
        public int GetMaxIndex()
        {
            if (Length == 0)
            {
                throw new NullReferenceException("The list cannot be empty.");
            }
            int tmp = _array[0];
            int maxIndex = 0;
            for (int i = 0; i < Length; i++)
            {
                if (_array[i] > tmp)
                {
                    tmp = _array[i];
                    maxIndex = i;
                }
            }

            return maxIndex;
        }
        
        public int GetMinIndex()
        {
            if (Length == 0)
            {
                throw new NullReferenceException("The list cannot be empty.");
            }
            int tmp = _array[0];
            int minIndex = 0;
            for (int i = 0; i < Length; i++)
            {
                if (_array[i] < tmp)
                {
                    tmp = _array[i];
                    minIndex = i;
                }
            }

            return minIndex;
        }
    
        public void SortAscending()
        {
            for (int i = 1; i < Length; i++)
            {
                int cur = _array[i];
                int j = i;
                while (j > 0 && cur < _array[j - 1])
                {
                    _array[j] = _array[j - 1];
                    j--;
                }
                _array[j] = cur;
            }
        }
        
        public void SortDescending()
        {
            for (int i = 1; i < Length; i++)
            {
                int cur = _array[i];
                int j = i;
                while (j > 0 && cur > _array[j - 1])
                {
                    _array[j] = _array[j - 1];
                    j--;
                }
                _array[j] = cur;
            }
        }
        
        public void Reverse()
        {
            for (int i = 0; i < Length / 2; i++)
            {
                int a = _array[i];
                _array[i] = _array[Length - 1 - i];
                _array[Length - 1 - i] = a;
            }
        }

        

        public override bool Equals(object obj)
        {
            ArrayList arrayList = (ArrayList) obj;

            if (Length != arrayList.Length)
            {
                return false;
            }
            else
            {
                for (int i = 0; i < Length; i++)
                {
                    if (_array[i] != arrayList._array[i])
                    {
                        return false;
                    }
                }
            }

            return true;
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }

        public override string ToString()
        {
            if (Length == 0)
            {
                return "";
            }
            string values = "";
            for (int i = 0; i < Length; i++)
            {
                values += _array[i] + "; ";
            }

            return values;
        }

        private void IncreaseLenght(int number = 1)
        {
            int newLenght = _array.Length;
            while (newLenght <= Length + number)
            {
                newLenght = (int) (newLenght * 1.33 + 1);
            }

            int[] newArray = new int[newLenght];
            Array.Copy(_array, newArray, _array.Length);

            _array = newArray;
        }
        
        private void ShiftкRight(int count=1)
        {
            if (count < 1)
            {
                throw new IndexOutOfRangeException("The count must be positive.");
            }
            if (_array.Length + count >= Length)
            {
                IncreaseLenght(count);
            }
            
            for (int i = Length-1; i >= 0; i--)
            {
                _array[i+count] = _array[i];
            }
            
        }
    }
}
using System;

namespace DataStructure
{
    public class ArrayList
    {
        public int Lenght { get; private set; }

        private int[] _array;
        
        public ArrayList()
        {
            _array = new int[9];
            Lenght = 0;
        }
      
        public ArrayList(int[] array)
        {
            _array = new int[(int) (array.Length * 1.33)];
            Array.Copy(array, _array, array.Length);
            Lenght = array.Length;
        }

        public int this[int index]
        {
            get
            {
                if (index > Lenght - 1 || index < 0)
                {
                    throw new IndexOutOfRangeException();
                }

                return _array[index];
            }
            set
            {
                if (index > Lenght - 1 || index < 0)
                {
                    throw new IndexOutOfRangeException();
                }

                _array[index] = value;
            }
        }

        public int GetMax()
        {
            if (Lenght == 0)
            {
                throw new NullReferenceException("The list cannot be empty.");
            }
            int max = _array[0];
            
            for (int i = 0; i < Lenght; i++)
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
            if (Lenght == 0)
            {
                throw new NullReferenceException("The list cannot be empty.");
            }
            int max = _array[0];
            
            for (int i = 0; i < Lenght; i++)
            {
                if (_array[i] < max)
                {
                    max = _array[i];
                }
            }

            return max;
        }
        
        public void Reverse()
        {
            for (int i = 0; i < Lenght / 2; i++)
            {
                int a = _array[i];
                _array[i] = _array[Lenght - 1 - i];
                _array[Lenght - 1 - i] = a;
            }
        }


        public void Add(int value)
        {
            if (_array.Length <= Lenght)
            {
                IncreaseLenght();
            }

            _array[Lenght] = value;
            Lenght++;
        }

        public override bool Equals(object obj)
        {
            ArrayList arrayList = (ArrayList) obj;

            if (Lenght != arrayList.Lenght)
            {
                return false;
            }
            else
            {
                for (int i = 0; i < Lenght; i++)
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

        private void IncreaseLenght(int number = 1)
        {
            int newLenght = _array.Length;
            while (newLenght <= Lenght + number)
            {
                newLenght = (int) (newLenght * 1.33 + 1);
            }

            int[] newArray = new int[newLenght];
            Array.Copy(_array, newArray, _array.Length);

            _array = newArray;
        }
    }
}
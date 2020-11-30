using System;

namespace DataStructure.LinkedList
{
    public class LinkedList : IDataStructure
    {
        public int Length { get; private set;}
        private Node _root;

        public LinkedList()
        {
            Length = 0;
            _root = null;
        }
        
        public LinkedList(int value)
        {
            Length = 0;
            _root = null;
        }
        
        public LinkedList(int[] array)
        {
            Length = array.Length;

            if (array.Length != 0)
            {
                _root = new Node(array[0]);
                Node tmp = _root;
                for (int i = 1; i < array.Length; i++)
                {
                    tmp.Next = new Node(array[i]);
                    tmp = tmp.Next;
                }
            }
            else
            {
                _root = null;
            }            
        }

        public int this[int index]
        {
            get
            {
                if (index >= Length || index < 0)
                {
                    throw new IndexOutOfRangeException("Index must be greater than zero and less than length.");
                }
                
                Node tmp = _root;
                for (int i = 0; i < index; i++)
                {
                    tmp = tmp.Next;
                }
                return tmp.Value;
            }

            set
            {
                if (index >= Length || index < 0)
                {
                    throw new IndexOutOfRangeException("Index must be greater than zero and less than length.");
                }
                Node tmp = _root;
                for (int i = 0; i < index; i++)
                {
                    tmp = tmp.Next;
                }
                tmp.Value = value;
            }
        }

        public void AddByIndex(int index, int value)
        {
            if (index < 0 || index > Length)
            {
                throw new IndexOutOfRangeException("Index must be greater than zero and less than length.");
            }
            if (index != 0)
            {
                Node crnt = _root;
                for (int i = 0; i < index - 1; i++)
                {
                    crnt = crnt.Next;
                }
                Node tmp = new Node(value);
                tmp.Next = crnt.Next;
                crnt.Next = tmp;
            }
            else
            {
                Node tmp = new Node(value);
                tmp.Next = _root;
                _root = tmp;
            }
            Length++;
        }

        public void Add(int value)
        {
            if (_root == null)
            {
                Node node = new Node(value);
                _root = node;
            }
            else
            {
                Node tmp = _root;
                for (int i = 0; i < Length - 1; i++)
                {
                    tmp = tmp.Next;
                }
                Node node = new Node(value);
                tmp.Next = node;
            }
            Length++;
        }

        public void Add(int[] values)
        {
            if (values.Length == 0) return;
            int begin = 0;
            if (_root == null)
            {
                _root = new Node(values[0]);
                begin++;
            }

            Node tmp = _root;
            
            for (int i = 0; i < Length - 1; i++)
            {
                tmp = tmp.Next;
            }
            
            for (int i = begin; i < values.Length; i++)
            {
                tmp.Next = new Node(values[i]);
                tmp = tmp.Next;
            }
            
           

            Length += values.Length;
        }

        public void AddToBegin(int value)
        {
            throw new NotImplementedException();
        }

        public void AddToBegin(int[] values)
        {
            throw new NotImplementedException();
        }

        public void AddToIndex(int index, int value)
        {
            throw new NotImplementedException();
        }

        public void AddToIndex(int index, int[] values)
        {
            throw new NotImplementedException();
        }

        public void Delete(int count = 1)
        {
            throw new NotImplementedException();
        }

        public void DeleteFromBegin(int count = 1)
        {
            throw new NotImplementedException();
        }

        public void DeleteByIndex(int index, int count = 1)
        {
            throw new NotImplementedException();
        }

        public void DeleteByValue(int value)
        {
            throw new NotImplementedException();
        }

        public void DeleteAllByValue(int value)
        {
            throw new NotImplementedException();
        }

        public int GetMax()
        {
            throw new NotImplementedException();
        }

        public int GetMin()
        {
            throw new NotImplementedException();
        }

        public int GetMaxIndex()
        {
            throw new NotImplementedException();
        }

        public int GetMinIndex()
        {
            throw new NotImplementedException();
        }

        public void SortAscending()
        {
            throw new NotImplementedException();
        }

        public void SortDescending()
        {
            throw new NotImplementedException();
        }

        public void Reverse()
        {
            throw new NotImplementedException();
        }
        
        public override bool Equals(object obj)
        {
            LinkedList linkedList = (LinkedList)obj;

            if(Length!=linkedList.Length)
            {
                return false;
            }

            Node tmp1 = _root;
            Node tmp2 = linkedList._root;

            for(int i=0; i<Length;i++)
            {
                if(tmp1.Value!=tmp2.Value)
                {
                    return false;
                }
                tmp1 = tmp1.Next;
                tmp2 = tmp2.Next;
            }
            return true;
        }
        public override string ToString()
        {
            string text = "";

            Node tmp = _root;
            for (int i = 0; i < Length-1; i++)
            {
                text += tmp.Value + ";";
                tmp = tmp.Next;
            }
            return text;
        }
        public override int GetHashCode()
        {
            return base.GetHashCode();
        }
    }
}
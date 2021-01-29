using System;

namespace DataStructure.LinkedList
{
    public class LinkedList : IDataStructure
    {
        public int Length { get; private set; }
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
            Node newNode = new Node(value);
            Length++;
            newNode.Next = _root;
            _root = newNode;
        }

        public void AddToBegin(int[] values)
        {
            if (values.Length != 0)
            {
                Node newNode = new Node(values[0]);
                Length+=values.Length;
                Node curr = newNode;
                for(int i=1;i<values.Length;i++)
                {
                    curr.Next = new Node(values[i]);
                    curr = curr.Next;
                }
                curr.Next = _root;
                _root = newNode;
            }
            
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
            if (_root == null)
            {
                throw new NullReferenceException("List length can't be null");
            }

            Node curr = _root;
            Node prev = null;
            for (int i = 0; i < Length; i++)
            {
                if (curr.Value == value)
                {
                    if (prev == null)
                    {
                        _root = curr.Next;
                    }
                    else
                    {
                        prev.Next = curr.Next;
                    }

                    Length--;
                    break;
                }

                prev = curr;
                curr = curr.Next;
            }
        }

        public void DeleteAllByValue(int value)
        {
            if (_root == null)
            {
                throw new NullReferenceException("List length can't be null");
            }

            Node prev = null;
            Node curr = _root;
            while (curr != null)
            {
                if (curr.Value == value)
                {
                    if (prev == null)
                    {
                        _root = curr.Next;
                        Length--;
                    }
                    else
                    {
                        prev.Next = curr.Next;
                        Length--;
                    }
                }
                else
                {
                    prev = curr;
                }

                curr = curr.Next;
            }
        }

        public int GetMax()
        {
            if (_root == null) throw new NullReferenceException("List can't be null");
            int max = _root.Value;
            Node tmp = _root;
            for (int i = 0; i < Length - 1; i++)
            {
                tmp = tmp.Next;
                if (max < tmp.Value)
                {
                    max = tmp.Value;
                }
            }

            return max;
        }

        public int GetMin()
        {
            if (_root == null) throw new NullReferenceException("List can't be null");
            int min = _root.Value;
            Node tmp = _root;
            for (int i = 0; i < Length - 1; i++)
            {
                tmp = tmp.Next;
                if (min > tmp.Value)
                {
                    min = tmp.Value;
                }
            }

            return min;
        }

        public int GetMaxIndex()
        {
            if (_root == null) throw new NullReferenceException("List can't be null");
            int max = _root.Value;
            int maxIndex = 0;
            Node tmp = _root;
            for (int i = 0; i < Length - 1; i++)
            {
                tmp = tmp.Next;
                if (max < tmp.Value)
                {
                    max = tmp.Value;
                    maxIndex = i + 1;
                }
            }

            return maxIndex;
        }

        public int GetMinIndex()
        {
            if (_root == null) throw new NullReferenceException("List can't be null");
            int min = _root.Value;
            int minIndex = 0;
            Node tmp = _root;
            for (int i = 0; i < Length - 1; i++)
            {
                tmp = tmp.Next;
                if (min > tmp.Value)
                {
                    min = tmp.Value;
                    minIndex = i + 1;
                }
            }

            return minIndex;
        }

        public void SortAscending()
        {
            Sort(false);
        }

        public void SortDescending()
        {
            Sort(true);
        }

        

        public void Reverse()
        {
            if (Length <= 0)
            {
                throw new NullReferenceException("List length can't be zerro");
            }

            Node curr = _root;
            Node prev = null;
            while (curr.Next != null)
            {
                Node next = curr.Next;
                curr.Next = prev;
                prev = curr;
                curr = next;
            }

            curr.Next = prev;
            _root = curr;
        }

        public override bool Equals(object obj)
        {
            LinkedList linkedList = (LinkedList) obj;

            if (Length != linkedList.Length)
            {
                return false;
            }

            Node tmp1 = _root;
            Node tmp2 = linkedList._root;

            for (int i = 0; i < Length; i++)
            {
                if (tmp1.Value != tmp2.Value)
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
            for (int i = 0; i < Length; i++)
            {
                text += tmp.Value + ";";
                tmp = tmp?.Next;
            }

            return text;
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }
        
        private void Sort(bool desceding)
        {
            int i = 0;
            Node tmp;
            Node root = _root;
            Node curr=root;
            Node prev=curr;
            while(i<Length-1)
            {
                if((!desceding && curr.Next.Value<curr.Value) || (desceding && curr.Next.Value>curr.Value))
                {
                    tmp = curr.Next;
                    curr.Next = tmp.Next;
                    tmp.Next = curr;
                    if(i==0)
                    {
                        root = tmp;
                    }
                    else
                    {
                        prev.Next = tmp;
                    }
                    curr = root;
                    i = 0;
                }
                else
                {
                    i++;
                    if(curr.Next!=null)
                    {
                        prev = curr;
                        curr = curr.Next;
                    }
                }
            }
            _root = root;
        }
    }
}
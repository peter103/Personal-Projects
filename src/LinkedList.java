
public class LinkedList<T extends Comparable<T>>
{
    private Node firstNode = null;
    private Node lastNode = null;
    private int amountEntries = 0;
    
    private class Node
    {
        T value;
        Node next = null;
        private Node(T s)
        {
            value = s;
        }
        public String toString()
        {
            return value.toString();
        }
    }

    public void add(T s)
    {
        Node newNode = new Node(s);
        if(firstNode == null)
        {
            lastNode = firstNode = newNode;
            newNode.next = null;
            return;
        }
        newNode.next = firstNode;
        firstNode = newNode;
        amountEntries++;
    }

    public void addToEnd(T s)
    {
        Node newNode = new Node(s);
        newNode.next = null;
        if(lastNode == null)
        {
            firstNode = lastNode = newNode;
            return;
        }
        lastNode.next = newNode;
        lastNode = newNode;
        amountEntries++;
    }

    public boolean isInList(T s)
    {
        for(Node iterator = firstNode; iterator != null; iterator = iterator.next)
        {
            if(iterator.value.equals(s))
            {
                return true;
            }
        }
        return false;
    }
    public void clear()
    {
        firstNode = null;
        lastNode = null;
        amountEntries = 0;
    }
    
    public int getAmountEntries()
    {
        return amountEntries;
    }
    
    public T getFirstValue()
    {
        if(firstNode != null)
            return firstNode.value;
        else
            return null;
    }
    public T getLastValue()
    {
        if(lastNode != null)
            return lastNode.value;
        else
            return null;
    }
    
    public boolean remove(T s)
    {
        if(s.equals(firstNode.value))
        {
            firstNode = firstNode.next;
            if(firstNode == null)
            {
                lastNode = null;
            }
            amountEntries--;
            return true;
        }

        // Node we are removing is not the first Node in the list
        for(Node iterator = firstNode; iterator != null; iterator = iterator.next)
        {
            Node nextNode = iterator.next;
            if(nextNode != null && nextNode.value.equals(s))
            {
                iterator.next = nextNode.next;
                if(nextNode == lastNode)
                {
                    lastNode = iterator;
                }
                amountEntries--;
                return true;
            }
        }
        return false;
    }

    public void printLast()
    {
        System.out.println(lastNode);
    }

    public boolean addAfter(T valueToAdd, T afterThis)
    {
        for(Node iterator = firstNode; iterator != null; iterator = iterator.next)
        {
            if(iterator.value.equals(afterThis))
            {
                Node newNode = new Node(valueToAdd);
                newNode.next = iterator.next;
                iterator.next = newNode;
                if(iterator == lastNode)
                {
                    lastNode = newNode;
                }
                amountEntries++;
            }
        }
        return false;
    }

    public void removeLast()
    {
        for(Node iterator = firstNode; iterator != null; iterator = iterator.next)
        {
            if(iterator.next == null)
            {
                firstNode = lastNode = null;
                amountEntries--;
            }

            if(iterator.next != null && iterator.next.next == null)
            {
                iterator.next = null;
                lastNode = iterator;
                amountEntries--;
            }
        }
    }

    public String toString()
    {
        String returnString = "";
        for(Node n = firstNode; n != null; n = n.next)
        {
            returnString += n + "\n";
        }
        returnString += "";
        return returnString;
    }
}